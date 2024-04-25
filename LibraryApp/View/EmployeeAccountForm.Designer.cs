namespace LibraryApp.View
{
    partial class EmployeeAccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeAccountForm));
            EmployeeFormName = new Label();
            employeeFormCloseLabel = new Label();
            booksTable = new DataGridView();
            booksFilterGroupBox = new GroupBox();
            booksFilterBox = new TextBox();
            booksAgeLimitFilterRadioButton = new RadioButton();
            booksNameFilterRadioButton = new RadioButton();
            booksAuthorFilterRadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)booksTable).BeginInit();
            booksFilterGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EmployeeFormName
            // 
            EmployeeFormName.AutoSize = true;
            EmployeeFormName.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            EmployeeFormName.Location = new Point(35, 27);
            EmployeeFormName.Name = "EmployeeFormName";
            EmployeeFormName.Size = new Size(473, 45);
            EmployeeFormName.TabIndex = 0;
            EmployeeFormName.Text = "Личный кабинет сотрудника";
            // 
            // employeeFormCloseLabel
            // 
            employeeFormCloseLabel.AutoSize = true;
            employeeFormCloseLabel.BackColor = Color.Transparent;
            employeeFormCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            employeeFormCloseLabel.Location = new Point(1323, 19);
            employeeFormCloseLabel.Name = "employeeFormCloseLabel";
            employeeFormCloseLabel.Size = new Size(21, 19);
            employeeFormCloseLabel.TabIndex = 1;
            employeeFormCloseLabel.Text = "-";
            employeeFormCloseLabel.Click += EmployeeFormCloseLabel_Click;
            employeeFormCloseLabel.MouseEnter += EmployeeFormCloseLabel_MouseEnter;
            employeeFormCloseLabel.MouseLeave += EmployeeFormCloseLabel_MouseLeave;
            // 
            // booksTable
            // 
            booksTable.AllowUserToResizeColumns = false;
            booksTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            booksTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            booksTable.BackgroundColor = SystemColors.Control;
            booksTable.BorderStyle = BorderStyle.None;
            booksTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksTable.Location = new Point(44, 151);
            booksTable.Name = "booksTable";
            booksTable.RowHeadersVisible = false;
            booksTable.RowTemplate.Height = 25;
            booksTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksTable.Size = new Size(1283, 481);
            booksTable.TabIndex = 2;
            // 
            // booksFilterGroupBox
            // 
            booksFilterGroupBox.Controls.Add(booksFilterBox);
            booksFilterGroupBox.Controls.Add(booksAgeLimitFilterRadioButton);
            booksFilterGroupBox.Controls.Add(booksNameFilterRadioButton);
            booksFilterGroupBox.Controls.Add(booksAuthorFilterRadioButton);
            booksFilterGroupBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            booksFilterGroupBox.ForeColor = Color.MidnightBlue;
            booksFilterGroupBox.Location = new Point(44, 78);
            booksFilterGroupBox.Name = "booksFilterGroupBox";
            booksFilterGroupBox.Size = new Size(701, 63);
            booksFilterGroupBox.TabIndex = 3;
            booksFilterGroupBox.TabStop = false;
            booksFilterGroupBox.Text = "Фильтрация книг";
            // 
            // booksFilterBox
            // 
            booksFilterBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            booksFilterBox.Location = new Point(473, 24);
            booksFilterBox.Name = "booksFilterBox";
            booksFilterBox.Size = new Size(205, 25);
            booksFilterBox.TabIndex = 3;
            booksFilterBox.TextChanged += FilterTextChanged;
            // 
            // booksAgeLimitFilterRadioButton
            // 
            booksAgeLimitFilterRadioButton.AutoSize = true;
            booksAgeLimitFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            booksAgeLimitFilterRadioButton.ForeColor = Color.Black;
            booksAgeLimitFilterRadioButton.Location = new Point(247, 28);
            booksAgeLimitFilterRadioButton.Name = "booksAgeLimitFilterRadioButton";
            booksAgeLimitFilterRadioButton.Size = new Size(207, 21);
            booksAgeLimitFilterRadioButton.TabIndex = 2;
            booksAgeLimitFilterRadioButton.TabStop = true;
            booksAgeLimitFilterRadioButton.Text = "по возрастным ограничениям";
            booksAgeLimitFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // booksNameFilterRadioButton
            // 
            booksNameFilterRadioButton.AutoSize = true;
            booksNameFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            booksNameFilterRadioButton.ForeColor = Color.Black;
            booksNameFilterRadioButton.Location = new Point(122, 28);
            booksNameFilterRadioButton.Name = "booksNameFilterRadioButton";
            booksNameFilterRadioButton.Size = new Size(104, 21);
            booksNameFilterRadioButton.TabIndex = 1;
            booksNameFilterRadioButton.TabStop = true;
            booksNameFilterRadioButton.Text = "по названию";
            booksNameFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // booksAuthorFilterRadioButton
            // 
            booksAuthorFilterRadioButton.AutoSize = true;
            booksAuthorFilterRadioButton.Checked = true;
            booksAuthorFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            booksAuthorFilterRadioButton.ForeColor = Color.Black;
            booksAuthorFilterRadioButton.Location = new Point(15, 28);
            booksAuthorFilterRadioButton.Name = "booksAuthorFilterRadioButton";
            booksAuthorFilterRadioButton.Size = new Size(86, 21);
            booksAuthorFilterRadioButton.TabIndex = 0;
            booksAuthorFilterRadioButton.TabStop = true;
            booksAuthorFilterRadioButton.Text = "по автору";
            booksAuthorFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 768);
            Controls.Add(booksFilterGroupBox);
            Controls.Add(booksTable);
            Controls.Add(employeeFormCloseLabel);
            Controls.Add(EmployeeFormName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Личный кабинет сотрудника";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)booksTable).EndInit();
            booksFilterGroupBox.ResumeLayout(false);
            booksFilterGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label EmployeeFormName;
        private Label employeeFormCloseLabel;
        private DataGridView booksTable;
        private GroupBox booksFilterGroupBox;
        private RadioButton booksAuthorFilterRadioButton;
        private RadioButton booksNameFilterRadioButton;
        private RadioButton booksAgeLimitFilterRadioButton;
        private TextBox booksFilterBox;
    }
}