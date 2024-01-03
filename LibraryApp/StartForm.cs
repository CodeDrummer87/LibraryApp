namespace LibraryApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
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

        private void AuthButton_Click(object? sender, EventArgs e)
        {
            if(loginInputBox.Text == "admin" && passwordInputBox.Text == "admin")
            {
                this.Hide();
                LibraryManagerForm ManagerForm = new(this);
                ManagerForm.Show();
            }
            else if(loginInputBox.Text == "emp" && passwordInputBox.Text == "emp")
            {
                // временный код передачи Id пользователя
                int loginId = 1;
                UserAccountForm userForm = new(this, loginId);
                this.Hide();
                userForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            loginInputBox.Clear();
            passwordInputBox.Clear();
            loginInputBox.Focus();
        }

    }
}
