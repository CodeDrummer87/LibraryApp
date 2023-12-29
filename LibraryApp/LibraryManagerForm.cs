namespace LibraryApp
{
    public partial class LibraryManagerForm : Form
    {
        public LibraryManagerForm()
        {
            InitializeComponent();
        }

        private void LibraryManagerCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
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
    }
}
