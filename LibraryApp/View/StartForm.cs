using LibraryApp.Models;
using LibraryApp.View;

namespace LibraryApp
{
    public partial class StartForm : Form
    {
        private AccountActions account;

        private bool isHiddenPassword;

        enum AccountRole { Reader = 1, Employee = 2, Admin = 3 }; // account roles for authorization direction

        public StartForm()
        {
            InitializeComponent();

            account = new AccountActions();
            isHiddenPassword = true;
        }

        private void StartForm_Load(object? sender, EventArgs e)
        {
            // create the ToolTip and associate with the Form container
            ToolTip hintToolTip = new ToolTip();

            // set up the delays for the ToolTip
            hintToolTip.AutoPopDelay = 5000;
            hintToolTip.InitialDelay = 500;
            hintToolTip.ReshowDelay = 500;

            // force the ToolTip text to be displayed whether or not the form is active
            hintToolTip.ShowAlways = true;

            // set up the ToolTip text 
            hintToolTip.SetToolTip(hidePasswordPictureBox, "Показать или скрыть пароль");
            hintToolTip.SetToolTip(createAccountPictureBox, "Регистрация нового пользователя");

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

        // сhecking for empty login and password fields
        private bool CheckEmptyInput(TextBox inputField)
        {
            TextBox field = inputField;
            int VisibleTime = 1500;

            ToolTip emptyToolTip = new ToolTip();
            if (String.IsNullOrWhiteSpace(inputField.Text))
            {
                emptyToolTip.Show("Поле не заполнено", field, 10, 15, VisibleTime);
                return true;
            }

            return false;
        }

        // authorization at the button-click
        private void AuthButton_Click(object? sender, EventArgs e)
        {
            string inputedLogin = loginInputBox.Text.ToLower().Trim();
            string inputedPassword = passwordInputBox.Text.ToLower().Trim();

            // if the login or password has not been entered
            if (CheckEmptyInput(loginInputBox) || CheckEmptyInput(passwordInputBox))
                return;

            // if an incorrect login was entered
            if (!account.CheckInputedLogin(inputedLogin))
            {
                MessageBox.Show($"Аккаунта с логином \"{inputedLogin}\" не существует.\n" +
                                $"Пожалуйста, введите корректный логин",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if everything was entered correctly
            Account accountDb = account.GetCurrentAccountData(inputedLogin);

            if (accountDb != null && (accountDb.Password == account.GetHash(inputedPassword, accountDb.Salt)))
            {
                // find out the role of the account

                if (accountDb.Role == (int)AccountRole.Reader)
                {
                    UserAccountForm userForm = new UserAccountForm(this, accountDb.LoginId);
                    this.Hide();
                    userForm.Show();
                }
                else if (accountDb.Role == (int)AccountRole.Employee)
                {
                    EmployeeAccountForm employeeForm = new EmployeeAccountForm(this, accountDb.LoginId);
                    this.Hide();
                    employeeForm.Show();
                }
                else if (accountDb.Role == (int)AccountRole.Admin)
                {
                    LibraryManagerForm ManagerForm = new LibraryManagerForm(this, accountDb.LoginId);
                    this.Hide();
                    ManagerForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Неверный пароль",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cancel-button
        private void CancelButton_Click(object? sender, EventArgs e)
        {
            loginInputBox.Clear();
            passwordInputBox.Clear();
            loginInputBox.Focus();
        }

    }
}