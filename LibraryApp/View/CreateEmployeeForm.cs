using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class CreateEmployeeForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        private SqliteCommand command;
        private SqliteDataReader reader;

        public CreateEmployeeForm()
        {
            InitializeComponent();
        }

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

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            CreateEmployee();
        }

        private void ClearFormButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // для списка должностей
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
                                "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // проверяем, является ли табельный номер числом
        private bool CheckPersonnelNumberIsNumber()
        {
            return int.TryParse(createEmployeePersonnelNumberBox.Text, out _);
        }

        // проверяем, есть ли табельный номер в базе данных
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

        // создаем нового сотрудника
        public void CreateEmployee()
        {
            if (CheckPersonnelNumberIsNumber())
            {
                if (CheckPersonnelNumberInDataBase())
                {
                    MessageBox.Show($"Сотрудник с табельным номером {createEmployeePersonnelNumberBox.Text} уже существует",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = "INSERT INTO Persons (Firstname, Lastname, Surname, DateOfBirth) " +
                                   "VALUES (@Firstname, @Lastname, @Surname, @DateOfBirth); " +
                                   "INSERT INTO Employees (PersonId, PersonnelNumber, PostId) " +
                                   "SELECT Persons.Id, @PersonnelNumber, (SELECT Id FROM Posts WHERE Post = @PostId) FROM Persons " +
                                   "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); " +
                                   "INSERT INTO Accounts (LoginId, Login, Password) SELECT Persons.Id, @Login, @Password FROM Persons " +
                                   "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); ";

                    try
                    {
                        command = DataBase.GetConnection().CreateCommand();
                        command.CommandText = query;
                        command.Parameters.AddWithValue("@Firstname", createEmployeeFirstNameInputBox.Text);
                        command.Parameters.AddWithValue("@Lastname", createEmployeeLastNameInputBox.Text);
                        command.Parameters.AddWithValue("@Surname", createEmployeeSurNameInputBox.Text);
                        command.Parameters.AddWithValue("@DateOfBirth", createEmployeeDateOfBirthInputBox.Text);
                        command.Parameters.AddWithValue("@PersonnelNumber", createEmployeePersonnelNumberBox.Text);
                        command.Parameters.AddWithValue("@PostId", createEmployeePostInputComboBox.Text);
                        command.Parameters.AddWithValue("@Login", createEmployeeLoginInputBox.Text);
                        command.Parameters.AddWithValue("@Password", createEmployeePasswordInputBox.Text);

                        DataBase.OpenConnection();
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Сотрудник с табельным номером {createEmployeePersonnelNumberBox.Text} создан",
                                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось создать сотрудника:\n\"{ex.Message}\"\n" +
                                        $"Обратитесь к системному администратору для её устранения.",
                                        "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    DataBase.CloseConnection();
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show($"Недопустимый формат табельного номера. Необходимо использовать только цифры",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                createEmployeePersonnelNumberBox.Clear();
                createEmployeePersonnelNumberBox.Focus();
            }

        }

        // очищаем форму
        private void ClearForm()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = string.Empty;
            }
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
