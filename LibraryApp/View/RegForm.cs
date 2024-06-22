using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class RegForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates
        private SqliteCommand command;

        private StartForm startForm;

        public RegForm(StartForm startForm)
        {
            InitializeComponent();
            this.startForm = startForm;
        }

        #region Window control buttons
        private void RegFormCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
            startForm.Close();
        }

        private void RegFormCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            regFormCloseLabel.Text = "x";
            regFormCloseLabel.ForeColor = Color.Red;
        }

        private void RegFormCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            regFormCloseLabel.Text = "-";
            regFormCloseLabel.ForeColor = Color.Black;
        }

        #endregion

        // clear button
        private void ClearRegFormButton_Click(object? sender, EventArgs e)
        {
            ClearRegForm();
        }







        // clearing the form
        private void ClearRegForm()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = string.Empty;
            }
         
            regFormLastNameInputBox.Focus();
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
