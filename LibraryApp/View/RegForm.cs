using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class RegForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        private SqliteCommand command;
        private SqliteDataReader reader;

        private StartForm startForm;

        public RegForm(StartForm startForm)
        {
            InitializeComponent();
            this.startForm = startForm;
        }

        #region Window control buttons
        private void RegFormCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
            startForm.Close();
        }

        private void RegFormCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            regFormCloseLabel.Text = "x";
            regFormCloseLabel.ForeColor = Color.Red;
        }

        private void RegFormCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            regFormCloseLabel.Text = "-";
            regFormCloseLabel.ForeColor = Color.Black;
        }

        #endregion

        // checking for empty fields before account registration
        private bool CheckEmptyFields()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox) && string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    MessageBox.Show("Для создания акканта необходимо заполнить все поля",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            return true;
        }

        // checking for duplicate login in the database before registration
        private bool CheckInputedLogin(string login)
        {
            string query = "SELECT * FROM Accounts WHERE login = @login";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@login", login);

                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows; // gets a value indicating whether the reader contains one or more lines
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка работы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }

        // create-button
        private void CreateAccountButton_Click(object? sender, EventArgs e)
        {
            string message = String.Empty;

            string inputedLogin = regFormLoginInputBox.Text.ToLower().Trim();
            string inputedPassword = regFormPasswordInputBox.Text.ToLower().Trim();
            string confirmedPassword = regFormConfirmPasswordInputBox.Text.ToLower().Trim();

            // if there are empty fields, a message is displayed
            if (!CheckEmptyFields())
                return;

            // if the passwords don't match, a message is displayed
            if (inputedPassword != confirmedPassword)
            {
                MessageBox.Show("Проверьте правильность ввода пароля",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if the login has not been created before, then we'll register an account
            if (!CheckInputedLogin(inputedLogin))
            {
                Person person = new()
                {
                    Firstname = regFormFirstNameInputBox.Text.Trim(),
                    Lastname = regFormLastNameInputBox.Text.Trim(),
                    Surname = regFormSurNameInputBox.Text.Trim(),
                    DateOfBirth = regFormDateOfBirthInputBox.Text.Trim()
                };

                AccountActions act = new AccountActions();
                message = act.CreateNewAccount(inputedLogin, inputedPassword, person);
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

        // сlear all form fields
        private void ClearForm()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = string.Empty;
            }

            regFormLastNameInputBox.Focus();
        }

        // clear-button
        private void ClearRegFormButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
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
