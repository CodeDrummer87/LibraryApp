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
            deleteBookButton = new Button();
            EmployeeFormEditModeCheckBox = new CheckBox();
            addBookButton = new Button();
            saveBookButton = new Button();
            currentEmployeeName = new Label();
            employeeFormPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)booksTable).BeginInit();
            booksFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeeFormPictureBox).BeginInit();
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
            employeeFormCloseLabel.Cursor = Cursors.Hand;
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
            booksTable.AllowUserToAddRows = false;
            booksTable.AllowUserToResizeColumns = false;
            booksTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            booksTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            booksTable.BackgroundColor = SystemColors.Control;
            booksTable.BorderStyle = BorderStyle.None;
            booksTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksTable.Location = new Point(44, 160);
            booksTable.Name = "booksTable";
            booksTable.RowHeadersVisible = false;
            booksTable.RowTemplate.Height = 25;
            booksTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksTable.Size = new Size(1283, 521);
            booksTable.TabIndex = 2;
            booksTable.CellClick += BooksTable_CellClick;
            booksTable.CellValidating += IsDigit_CellValidating;
            booksTable.DataError += CheckError_DataError;
            booksTable.SelectionChanged += BooksTableSelectionChanged;
            // 
            // booksFilterGroupBox
            // 
            booksFilterGroupBox.Controls.Add(booksFilterBox);
            booksFilterGroupBox.Controls.Add(booksAgeLimitFilterRadioButton);
            booksFilterGroupBox.Controls.Add(booksNameFilterRadioButton);
            booksFilterGroupBox.Controls.Add(booksAuthorFilterRadioButton);
            booksFilterGroupBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            booksFilterGroupBox.ForeColor = Color.MidnightBlue;
            booksFilterGroupBox.Location = new Point(44, 81);
            booksFilterGroupBox.Name = "booksFilterGroupBox";
            booksFilterGroupBox.Size = new Size(589, 63);
            booksFilterGroupBox.TabIndex = 3;
            booksFilterGroupBox.TabStop = false;
            booksFilterGroupBox.Text = "Фильтрация";
            // 
            // booksFilterBox
            // 
            booksFilterBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            booksFilterBox.Location = new Point(368, 26);
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
            booksAgeLimitFilterRadioButton.Location = new Point(247, 30);
            booksAgeLimitFilterRadioButton.Name = "booksAgeLimitFilterRadioButton";
            booksAgeLimitFilterRadioButton.Size = new Size(98, 21);
            booksAgeLimitFilterRadioButton.TabIndex = 2;
            booksAgeLimitFilterRadioButton.TabStop = true;
            booksAgeLimitFilterRadioButton.Text = "по возрасту";
            booksAgeLimitFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // booksNameFilterRadioButton
            // 
            booksNameFilterRadioButton.AutoSize = true;
            booksNameFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            booksNameFilterRadioButton.ForeColor = Color.Black;
            booksNameFilterRadioButton.Location = new Point(122, 30);
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
            booksAuthorFilterRadioButton.Location = new Point(15, 30);
            booksAuthorFilterRadioButton.Name = "booksAuthorFilterRadioButton";
            booksAuthorFilterRadioButton.Size = new Size(86, 21);
            booksAuthorFilterRadioButton.TabIndex = 0;
            booksAuthorFilterRadioButton.TabStop = true;
            booksAuthorFilterRadioButton.Text = "по автору";
            booksAuthorFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // deleteBookButton
            // 
            deleteBookButton.Cursor = Cursors.Hand;
            deleteBookButton.Location = new Point(246, 708);
            deleteBookButton.Name = "deleteBookButton";
            deleteBookButton.Size = new Size(75, 23);
            deleteBookButton.TabIndex = 5;
            deleteBookButton.Text = "Удалить";
            deleteBookButton.UseVisualStyleBackColor = true;
            deleteBookButton.Click += DeleteBookButton_Click;
            // 
            // EmployeeFormEditModeCheckBox
            // 
            EmployeeFormEditModeCheckBox.AutoSize = true;
            EmployeeFormEditModeCheckBox.Cursor = Cursors.Hand;
            EmployeeFormEditModeCheckBox.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            EmployeeFormEditModeCheckBox.ForeColor = Color.MidnightBlue;
            EmployeeFormEditModeCheckBox.Location = new Point(366, 710);
            EmployeeFormEditModeCheckBox.Name = "EmployeeFormEditModeCheckBox";
            EmployeeFormEditModeCheckBox.Size = new Size(143, 21);
            EmployeeFormEditModeCheckBox.TabIndex = 6;
            EmployeeFormEditModeCheckBox.Text = "Режим изменения";
            EmployeeFormEditModeCheckBox.UseVisualStyleBackColor = true;
            EmployeeFormEditModeCheckBox.CheckedChanged += EditModeChanged;
            // 
            // addBookButton
            // 
            addBookButton.Cursor = Cursors.Hand;
            addBookButton.Location = new Point(44, 708);
            addBookButton.Name = "addBookButton";
            addBookButton.Size = new Size(75, 23);
            addBookButton.TabIndex = 7;
            addBookButton.Text = "Добавить";
            addBookButton.UseVisualStyleBackColor = true;
            addBookButton.Click += AddBookButton_Click;
            // 
            // saveBookButton
            // 
            saveBookButton.Cursor = Cursors.Hand;
            saveBookButton.Location = new Point(145, 708);
            saveBookButton.Name = "saveBookButton";
            saveBookButton.Size = new Size(75, 23);
            saveBookButton.TabIndex = 8;
            saveBookButton.Text = "Сохранить";
            saveBookButton.UseVisualStyleBackColor = true;
            saveBookButton.Click += SaveBookButton_CLick;
            // 
            // currentEmployeeName
            // 
            currentEmployeeName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            currentEmployeeName.ForeColor = Color.MidnightBlue;
            currentEmployeeName.Location = new Point(804, 76);
            currentEmployeeName.Name = "currentEmployeeName";
            currentEmployeeName.Size = new Size(374, 29);
            currentEmployeeName.TabIndex = 9;
            currentEmployeeName.Text = "currentEmployeeName";
            currentEmployeeName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // employeeFormPictureBox
            // 
            employeeFormPictureBox.BackColor = Color.Transparent;
            employeeFormPictureBox.BackgroundImage = Properties.Resources.default1;
            employeeFormPictureBox.Cursor = Cursors.Hand;
            employeeFormPictureBox.Location = new Point(1203, 36);
            employeeFormPictureBox.Name = "employeeFormPictureBox";
            employeeFormPictureBox.Size = new Size(100, 100);
            employeeFormPictureBox.TabIndex = 10;
            employeeFormPictureBox.TabStop = false;
            employeeFormPictureBox.Click += ExitToStartFormLabel_CLick;
            // 
            // EmployeeAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 768);
            Controls.Add(employeeFormPictureBox);
            Controls.Add(currentEmployeeName);
            Controls.Add(saveBookButton);
            Controls.Add(addBookButton);
            Controls.Add(EmployeeFormEditModeCheckBox);
            Controls.Add(deleteBookButton);
            Controls.Add(booksFilterGroupBox);
            Controls.Add(booksTable);
            Controls.Add(employeeFormCloseLabel);
            Controls.Add(EmployeeFormName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Личный кабинет сотрудника";
            Load += EditModeChanged;
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)booksTable).EndInit();
            booksFilterGroupBox.ResumeLayout(false);
            booksFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)employeeFormPictureBox).EndInit();
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
        private Button deleteBookButton;
        private CheckBox EmployeeFormEditModeCheckBox;
        private Button addBookButton;
        private Button saveBookButton;
        private Label currentEmployeeName;
        private PictureBox employeeFormPictureBox;
    }
}