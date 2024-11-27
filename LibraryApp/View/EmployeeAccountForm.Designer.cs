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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            employeeAccountOpenFileDialog = new OpenFileDialog();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            deleteReaderButton = new Button();
            saveReaderButton = new Button();
            addReaderButton = new Button();
            readersTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)booksTable).BeginInit();
            booksFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeeFormPictureBox).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)readersTable).BeginInit();
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
            booksTable.Location = new Point(3, 6);
            booksTable.Name = "booksTable";
            booksTable.RowHeadersVisible = false;
            booksTable.RowTemplate.Height = 25;
            booksTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksTable.Size = new Size(1262, 499);
            booksTable.TabIndex = 2;
            booksTable.CellClick += BooksTable_CellClick;
            booksTable.CellValidating += IsDigit_CellValidating_Books;
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
            deleteBookButton.Location = new Point(224, 524);
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
            EmployeeFormEditModeCheckBox.Location = new Point(344, 526);
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
            addBookButton.Location = new Point(22, 524);
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
            saveBookButton.Location = new Point(123, 524);
            saveBookButton.Name = "saveBookButton";
            saveBookButton.Size = new Size(75, 23);
            saveBookButton.TabIndex = 8;
            saveBookButton.Text = "Сохранить";
            saveBookButton.UseVisualStyleBackColor = true;
            saveBookButton.Click += SaveBookButton_CLick;
            // 
            // currentEmployeeName
            // 
            currentEmployeeName.Cursor = Cursors.Hand;
            currentEmployeeName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            currentEmployeeName.ForeColor = Color.MidnightBlue;
            currentEmployeeName.Location = new Point(804, 76);
            currentEmployeeName.Name = "currentEmployeeName";
            currentEmployeeName.Size = new Size(374, 29);
            currentEmployeeName.TabIndex = 9;
            currentEmployeeName.Text = "currentEmployeeName";
            currentEmployeeName.TextAlign = ContentAlignment.MiddleRight;
            currentEmployeeName.Click += ExitToStartFormLabel_CLick;
            currentEmployeeName.MouseEnter += ExitToStartFormLabel_MouseEnter;
            currentEmployeeName.MouseLeave += ExitToStartFormLabel_MouseLeave;
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
            employeeFormPictureBox.Click += ChangeProfileImage;
            // 
            // employeeAccountOpenFileDialog
            // 
            employeeAccountOpenFileDialog.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(44, 154);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1276, 589);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(booksTable);
            tabPage1.Controls.Add(EmployeeFormEditModeCheckBox);
            tabPage1.Controls.Add(deleteBookButton);
            tabPage1.Controls.Add(saveBookButton);
            tabPage1.Controls.Add(addBookButton);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1268, 561);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Книги";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(deleteReaderButton);
            tabPage2.Controls.Add(saveReaderButton);
            tabPage2.Controls.Add(addReaderButton);
            tabPage2.Controls.Add(readersTable);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1268, 561);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Читатели";
            // 
            // deleteReaderButton
            // 
            deleteReaderButton.Location = new Point(224, 524);
            deleteReaderButton.Name = "deleteReaderButton";
            deleteReaderButton.Size = new Size(75, 23);
            deleteReaderButton.TabIndex = 3;
            deleteReaderButton.Text = "Удалить";
            deleteReaderButton.UseVisualStyleBackColor = true;
            deleteReaderButton.Click += DeleteReaderButton_Click;
            // 
            // saveReaderButton
            // 
            saveReaderButton.Location = new Point(123, 524);
            saveReaderButton.Name = "saveReaderButton";
            saveReaderButton.Size = new Size(75, 23);
            saveReaderButton.TabIndex = 2;
            saveReaderButton.Text = "Сохранить";
            saveReaderButton.UseVisualStyleBackColor = true;
            saveReaderButton.Click += SaveReaderButton_CLick;
            // 
            // addReaderButton
            // 
            addReaderButton.Location = new Point(22, 524);
            addReaderButton.Name = "addReaderButton";
            addReaderButton.Size = new Size(75, 23);
            addReaderButton.TabIndex = 1;
            addReaderButton.Text = "Добавить";
            addReaderButton.UseVisualStyleBackColor = true;
            addReaderButton.Click += AddReaderButton_Click;
            // 
            // readersTable
            // 
            readersTable.AllowUserToAddRows = false;
            readersTable.AllowUserToResizeColumns = false;
            readersTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            readersTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            readersTable.BackgroundColor = SystemColors.Control;
            readersTable.BorderStyle = BorderStyle.None;
            readersTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            readersTable.Location = new Point(3, 6);
            readersTable.Name = "readersTable";
            readersTable.RowHeadersVisible = false;
            readersTable.RowTemplate.Height = 25;
            readersTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            readersTable.Size = new Size(1041, 501);
            readersTable.TabIndex = 0;
            readersTable.CellValidating += IsDigit_CellValidating_Readers;
            // 
            // EmployeeAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 768);
            Controls.Add(tabControl1);
            Controls.Add(employeeFormPictureBox);
            Controls.Add(currentEmployeeName);
            Controls.Add(booksFilterGroupBox);
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
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)readersTable).EndInit();
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
        private OpenFileDialog employeeAccountOpenFileDialog;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView readersTable;
        private Button addReaderButton;
        private Button button1;
        private Button saveReaderButton;
        private Button deleteReaderButton;
    }
}