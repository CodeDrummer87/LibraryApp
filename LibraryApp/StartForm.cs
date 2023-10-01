using System.Security.Principal;

namespace LibraryApp
{
    public partial class StartForm : Form
    {
        private AccountAction account;
        public StartForm()
        {
            InitializeComponent();
            account = new AccountAction();
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

    }
}
