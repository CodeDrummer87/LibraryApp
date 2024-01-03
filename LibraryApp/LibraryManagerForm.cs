namespace LibraryApp
{
    public partial class LibraryManagerForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        private StartForm startForm;
        public LibraryManagerForm(StartForm startForm)
        {
            InitializeComponent();
            GetCurrentDate();
            this.startForm = startForm;
        }

        private void LibraryManagerCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
            startForm.Close();
        }

        private void LibraryManagerCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            libraryManagerCloseLabel.ForeColor = Color.Red;
        }

        private void LibraryManagerCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            libraryManagerCloseLabel.ForeColor = Color.Black;
        }

        private void CreateEmployeeButton_Click(object? sender, EventArgs e)
        {
            CreateEmployeeForm employeeForm = new();
            employeeForm.Show();
        }

        private void GetCurrentDate() => currentDateLabel.Text = "Сегодня " + DateTime.Now.ToLongDateString();

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
    }
}
