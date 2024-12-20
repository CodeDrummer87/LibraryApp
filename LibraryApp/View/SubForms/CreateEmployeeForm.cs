using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class CreateEmployeeForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        private SqliteCommand command;
        private SqliteDataReader reader;

        private AccountActions account;

        public CreateEmployeeForm()
        {
            InitializeComponent();

            account = new AccountActions();
        }

        #region Window control buttons
        private void CreateEmployeeCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateEmployeeCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            createEmployeeCloseLabel.Text = "x";
            createEmployeeCloseLabel.ForeColor = Color.Red;
        }

        private void CreateEmployeeCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            createEmployeeCloseLabel.Text = "-";
            createEmployeeCloseLabel.ForeColor = Color.Black;
        }

        #endregion

        // create-button
        private void СreateEmployeeButton_Click(object sender, EventArgs e)
        {
            string message = String.Empty;

            string inputedLogin = createEmployeeLoginInputBox.Text.ToLower().Trim();
            string inputedPassword = createEmployeePasswordInputBox.Text.ToLower().Trim();

            int role = createEmployeePostInputComboBox.Text == "Управляющий" ? 3 : 2;

            // if the personnel number is not a number
            if (!CheckPersonnelNumberIsNumber())
            {
                MessageBox.Show("Недопустимый формат табельного номера. Необходимо использовать только цифры",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                createEmployeePersonnelNumberBox.Clear();
                createEmployeePersonnelNumberBox.Focus();

                return;
            }

            // if the personnel number is already in the database
            if (CheckPersonnelNumberInDataBase())
            {
                MessageBox.Show($"Сотрудник с табельным номером {createEmployeePersonnelNumberBox.Text} уже существует",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                createEmployeePersonnelNumberBox.Clear();
                createEmployeePersonnelNumberBox.Focus();

                return;
            }

            // if the entered login is not in the database, create a new employee
            if (!account.CheckInputedLogin(inputedLogin))
            {
                Person person = new()
                {
                    Firstname = createEmployeeFirstNameInputBox.Text.Trim(),
                    Lastname = createEmployeeLastNameInputBox.Text.Trim(),
                    Surname = createEmployeeSurNameInputBox.Text.Trim(),
                    DateOfBirth = createEmployeeDateOfBirthInputBox.Text.Trim(),
                    Login = inputedLogin,
                    Password = inputedPassword
                };

                Employee employee = new()
                {
                    PersonnelNumber = createEmployeePersonnelNumberBox.Text.Trim(),
                    PostId = createEmployeePostInputComboBox.Text.Trim(),
                    IsActive = Convert.ToBoolean(createEmployeeIsActiveCheckBox.Checked ? 1 : 0)
                };

                message = account.CreateNewAccount(person, role, employee);

            }
            else
            {
                MessageBox.Show($"Аккаунт с логином \"{inputedLogin}\" уже существует.\n" +
                                $"Пожалуйста, выберите другой логин",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"\n{message}\n",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
        }

        // clear-button
        private void ClearFormButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // for the list of positions
        private void LoadPosts(object? sender, EventArgs e)
        {
            createEmployeePostInputComboBox.Items.Clear();
            createEmployeePostInputComboBox.ResetText();

            string query = "SELECT * FROM Posts ORDER BY Post";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    createEmployeePostInputComboBox.Items.Add(new Post
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1)
                    });
                }
                createEmployeePostInputComboBox.DisplayMember = "Title";
                createEmployeePostInputComboBox.SelectedIndex = 0;

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить должности:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // check if the personnel number is a number
        private bool CheckPersonnelNumberIsNumber()
        {
            return int.TryParse(createEmployeePersonnelNumberBox.Text, out _);
        }

        // check if the personnel number is in the database
        private bool CheckPersonnelNumberInDataBase()
        {
            string query = "SELECT COUNT(PersonnelNumber) " +
                           "FROM Employees WHERE PersonnelNumber = @PersonnelNumber";

            command = DataBase.GetConnection().CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@PersonnelNumber", createEmployeePersonnelNumberBox.Text);

            DataBase.OpenConnection();
            bool answer = Convert.ToBoolean(command.ExecuteScalar());

            DataBase.CloseConnection();
            return answer;
        }

        // clear the form
        private void ClearForm()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = string.Empty;
            }
            createEmployeePostInputComboBox.SelectedIndex = 0;
            createEmployeeIsActiveCheckBox.CheckState = CheckState.Checked;
            createEmployeeLastNameInputBox.Focus();
        }

        #region Move the Form
        private void ThisForm_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }

        private void ThisForm_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));
        }

        #endregion
    }

}