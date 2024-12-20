namespace LibraryApp.View
{
    public partial class SetReaderLoginPassword : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        public ReaderAccountData accountData;

        private AccountActions acc = new AccountActions(); // for the account checking method


        public SetReaderLoginPassword()
        {
            InitializeComponent();
        }

        #region Window control buttons

        // if we close the form without clicking the "Save" button, the account data will not be saved to the database
        private void SetReaderLoginPasswordCloseLabel_Click(object? sender, EventArgs e)
        {
            EmployeeAccountForm.closingIndex = 0;
            this.Close();
        }

        private void SetReaderLoginPasswordCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            setReaderLoginPasswordCloseLabel.Text = "x";
            setReaderLoginPasswordCloseLabel.ForeColor = Color.Red;
        }

        private void SetReaderLoginPasswordCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            setReaderLoginPasswordCloseLabel.Text = "-";
            setReaderLoginPasswordCloseLabel.ForeColor = Color.Black;
        }
        #endregion

        public struct ReaderAccountData
        {
            public string login;
            public string password;

            public ReaderAccountData(string login, string password)
            {
                this.login = login;
                this.password = password;
            }
        }

        // we save the login and password in the structure
        private ReaderAccountData GetAccountData()
        {
            accountData = new(loginInputBox.Text.ToLower().Trim(), passwordInputBox.Text.ToLower().Trim());
            return accountData;
        }

        // checking for empty fields before saving an account
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

        private void SaveReaderLoginPassword_CLick(object sender, EventArgs e)
        {

            string login = loginInputBox.Text.ToLower().Trim();

            // if the fields are not filled in, we do nothing
            if (CheckEmptyInput(loginInputBox) || CheckEmptyInput(passwordInputBox))
            {
                return;
            }

            else
            {
                GetAccountData();

                // if the entered login is already in the database, please enter a new login
                if (acc.CheckInputedLogin(accountData.login))
                {
                    MessageBox.Show($"Аккаунт с логином \"{accountData.login}\" уже существует.\n" +
                                   $"Пожалуйста, выберите другой логин",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    loginInputBox.Clear();
                    passwordInputBox.Clear();

                    return;
                }

                // closing the form and getting into the SaveNewReader method in the EmployeeAccountForm
                EmployeeAccountForm.closingIndex = 1;
                this.Close();
            }
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
