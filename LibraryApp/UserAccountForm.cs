﻿using System;
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
    public partial class UserAccountForm : Form
    {
        public UserAccountForm()
        {
            InitializeComponent();

            GetCurrentDate();
        }

        private void GetCurrentDate() => currentDateLabel.Text = "Сегодня " + DateTime.Now.ToLongDateString();
      
    }
}