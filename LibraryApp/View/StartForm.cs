using LibraryApp.Models;
using LibraryApp.View;
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

        private void StartForm_Load(object? sender, EventArgs e)
        {
            // create the ToolTip and associate with the Form container
            ToolTip toolTip = new ToolTip();

            // set up the delays for the ToolTip
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;

            // force the ToolTip text to be displayed whether or not the form is active
            toolTip.ShowAlways = true;

            // set up the ToolTip text 
            toolTip.SetToolTip(hidePasswordPictureBox, "Показать или скрыть пароль");
            toolTip.SetToolTip(createAccountPictureBox, "Регистрация нового пользователя");

        }

        #region Window control buttons
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

        #endregion

        // change PictureBox color on hover
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

        // open the registration form
        private void CreateAccountPictureBox_Click(object? sender, EventArgs e)
        {
            RegForm regForm = new(this);
            this.Hide();
            regForm.Show();
        }

        // hide or show the password in the input field 
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
            else if (loginInputBox.Text == "emp" && passwordInputBox.Text == "emp")
            {
                EmployeeAccountForm employeeForm = new(this, loginId);
                this.Hide();
                employeeForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            loginInputBox.Clear();
            passwordInputBox.Clear();
            loginInputBox.Focus();
        }

        // get account Id
        private int GetCurrentLoginId() => Convert.ToInt32(GetCurrentAccountData(loginInputBox.Text).LoginId);

        // get account data
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
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return account;
        }

    }
}
