namespace LibraryApp.View
{
    public partial class EmployeeForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;

        public EmployeeForm()
        {
            InitializeComponent();
        }

        #region Window control buttons
        private void EmployeeFormCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeFormCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            employeeFormCloseLabel.Text = "x";
            employeeFormCloseLabel.ForeColor = Color.Red;
        }

        private void EmployeeFormCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            employeeFormCloseLabel.Text = "-";
            employeeFormCloseLabel.ForeColor = Color.Black;
        }


        #endregion





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
