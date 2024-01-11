using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class StartForm : Form
    {
        private SqliteCommand command;
        private SqliteDataReader reader;

        private bool isHiddenPassword;

        public StartForm()
        {
            InitializeComponent();
            isHiddenPassword = true;
        }

        private void CloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            closeLabel.ForeColor = Color.Red;
        }

        private void CloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            closeLabel.ForeColor = Color.MidnightBlue;
        }

        private void PictureBoxMouseEnter(object? sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Color.Wheat;
        }

        private void PictureBoxMouseLeave(object? sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.BackColor = Color.OldLace;
        }

        // скрываем или показывамем пароль в поле ввода по нажатию кнопки
        private void HidePasswordPictureBox_Click(object? sender, EventArgs e)
        {
            if (isHiddenPassword)
            {
                isHiddenPassword = false;
                hidePasswordPictureBox.Image = Properties.Resources.show_password;
                passwordInputBox.PasswordChar = '\0';
            }
            else
            {
                isHiddenPassword = true;
                hidePasswordPictureBox.Image = Properties.Resources.hide_password;
                passwordInputBox.PasswordChar = '*';
            }
        }

        private void AuthButton_Click(object? sender, EventArgs e)
        {
            // временный код передачи Id пользователя
            int loginId = GetCurrentLoginId();

            if (loginInputBox.Text == "admin" && passwordInputBox.Text == "admin")
            {

                LibraryManagerForm ManagerForm = new(this, loginId);
                this.Hide();
                ManagerForm.Show();
            }
            else if (loginInputBox.Text == "user" && passwordInputBox.Text == "user")
            {
                UserAccountForm userForm = new(this, loginId);
                this.Hide();
                userForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // получаем Id аккаунта
        private int GetCurrentLoginId() => Convert.ToInt32(GetCurrentAccountData(loginInputBox.Text).LoginId);

        // получаем данные аккаунта
        public Account GetCurrentAccountData(string login)
        {
            Account account = new();

            string query = "SELECT * FROM Accounts WHERE Login=@login";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@login", login);
                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    account = new Account
                    {
                        Id = reader.GetInt32(0),
                        LoginId = reader.GetInt32(1),
                        Login = reader.GetString(2),
                        Password = reader.GetString(3),
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return account;
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            loginInputBox.Clear();
            passwordInputBox.Clear();
            loginInputBox.Focus();
        }

    }
}
