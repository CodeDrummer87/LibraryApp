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
            // временный код передачи Id пользователя
            int loginId = 1;
            UserAccountForm userForm = new(this, loginId);
            this.Hide();
            userForm.Show();
        }

    }
}
