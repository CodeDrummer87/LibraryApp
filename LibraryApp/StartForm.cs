using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void closeLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void closeLabel_MouseEnter(object? sender, EventArgs e)
        {
            
            closeLabel.ForeColor = Color.Red;
        }

        private void closeLabel_MouseLeave(object? sender, EventArgs e)
        {
            
            closeLabel.ForeColor = Color.Black;
        }

    }
}
