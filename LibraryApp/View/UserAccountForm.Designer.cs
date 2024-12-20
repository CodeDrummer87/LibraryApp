using System.Windows.Forms;

namespace LibraryApp
{
    partial class UserAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountForm));
            currentDateLabel = new Label();
            currentLibraryCardNumber = new Label();
            currentTotalBooks = new Label();
            currentLibraryCardNumberLabel = new Label();
            currentTotalBooksLabel = new Label();
            UserAccountFormName = new Label();
            currentUserName = new Label();
            userAccountCloseLabel = new Label();
            currentDateOfBirth = new Label();
            userAccountPictureBox = new PictureBox();
            exitToStartFormLabel = new Label();
            userAccountOpenFileDialog = new OpenFileDialog();
            userAccountTabControl = new TabControl();
            tabPage1 = new TabPage();
            availableBooksFilterGroupBox = new GroupBox();
            availableBooksFilterBox = new TextBox();
            availableBooksNameFilterRadioButton = new RadioButton();
            availableBooksAuthorFilterRadioButton = new RadioButton();
            takeABookButton = new Button();
            availableBooksTable = new DataGridView();
            tabPage2 = new TabPage();
            noBooksLabel = new Label();
            reaturnABookButton = new Button();
            currentBooksTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)userAccountPictureBox).BeginInit();
            userAccountTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            availableBooksFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)availableBooksTable).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)currentBooksTable).BeginInit();
            SuspendLayout();
            // 
            // currentDateLabel
            // 
            currentDateLabel.AutoSize = true;
            currentDateLabel.BackColor = Color.Transparent;
            currentDateLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentDateLabel.ForeColor = Color.Black;
            currentDateLabel.Location = new Point(804, 63);
            currentDateLabel.Name = "currentDateLabel";
            currentDateLabel.Size = new Size(111, 17);
            currentDateLabel.TabIndex = 0;
            currentDateLabel.Text = "currentDateLabel";
            // 
            // currentLibraryCardNumber
            // 
            currentLibraryCardNumber.AutoSize = true;
            currentLibraryCardNumber.BackColor = Color.Transparent;
            currentLibraryCardNumber.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentLibraryCardNumber.Location = new Point(1010, 91);
            currentLibraryCardNumber.Name = "currentLibraryCardNumber";
            currentLibraryCardNumber.Size = new Size(172, 17);
            currentLibraryCardNumber.TabIndex = 2;
            currentLibraryCardNumber.Text = "currentLibraryCardNumber";
            // 
            // currentTotalBooks
            // 
            currentTotalBooks.AutoSize = true;
            currentTotalBooks.BackColor = Color.Transparent;
            currentTotalBooks.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentTotalBooks.ForeColor = SystemColors.ControlText;
            currentTotalBooks.Location = new Point(887, 120);
            currentTotalBooks.Name = "currentTotalBooks";
            currentTotalBooks.Size = new Size(118, 17);
            currentTotalBooks.TabIndex = 3;
            currentTotalBooks.Text = "currentTotalBooks";
            // 
            // currentLibraryCardNumberLabel
            // 
            currentLibraryCardNumberLabel.AutoSize = true;
            currentLibraryCardNumberLabel.BackColor = Color.Transparent;
            currentLibraryCardNumberLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentLibraryCardNumberLabel.ForeColor = Color.MidnightBlue;
            currentLibraryCardNumberLabel.Location = new Point(804, 91);
            currentLibraryCardNumberLabel.Name = "currentLibraryCardNumberLabel";
            currentLibraryCardNumberLabel.Size = new Size(195, 17);
            currentLibraryCardNumberLabel.TabIndex = 5;
            currentLibraryCardNumberLabel.Text = "Номер читательского билета:";
            // 
            // currentTotalBooksLabel
            // 
            currentTotalBooksLabel.AutoSize = true;
            currentTotalBooksLabel.BackColor = Color.Transparent;
            currentTotalBooksLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentTotalBooksLabel.ForeColor = Color.MidnightBlue;
            currentTotalBooksLabel.Location = new Point(804, 120);
            currentTotalBooksLabel.Name = "currentTotalBooksLabel";
            currentTotalBooksLabel.Size = new Size(77, 17);
            currentTotalBooksLabel.TabIndex = 6;
            currentTotalBooksLabel.Text = "Всего книг:";
            // 
            // UserAccountFormName
            // 
            UserAccountFormName.AutoSize = true;
            UserAccountFormName.BackColor = Color.Transparent;
            UserAccountFormName.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            UserAccountFormName.Location = new Point(35, 43);
            UserAccountFormName.Name = "UserAccountFormName";
            UserAccountFormName.Size = new Size(509, 45);
            UserAccountFormName.TabIndex = 7;
            UserAccountFormName.Text = "Личный кабинет пользователя";
            // 
            // currentUserName
            // 
            currentUserName.AutoSize = true;
            currentUserName.BackColor = Color.Transparent;
            currentUserName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            currentUserName.Location = new Point(38, 91);
            currentUserName.Name = "currentUserName";
            currentUserName.Size = new Size(164, 25);
            currentUserName.TabIndex = 8;
            currentUserName.Text = "currentUserName";
            currentUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userAccountCloseLabel
            // 
            userAccountCloseLabel.AutoSize = true;
            userAccountCloseLabel.BackColor = Color.Transparent;
            userAccountCloseLabel.Cursor = Cursors.Hand;
            userAccountCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            userAccountCloseLabel.Location = new Point(1201, 20);
            userAccountCloseLabel.Name = "userAccountCloseLabel";
            userAccountCloseLabel.Size = new Size(21, 19);
            userAccountCloseLabel.TabIndex = 9;
            userAccountCloseLabel.Text = "-";
            userAccountCloseLabel.Click += UserAccountCloseLabel_Click;
            userAccountCloseLabel.MouseEnter += UserAccountCloseLabel_MouseEnter;
            userAccountCloseLabel.MouseLeave += UserAccountCloseLabel_MouseLeave;
            // 
            // currentDateOfBirth
            // 
            currentDateOfBirth.AutoSize = true;
            currentDateOfBirth.BackColor = Color.Transparent;
            currentDateOfBirth.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            currentDateOfBirth.Location = new Point(42, 123);
            currentDateOfBirth.Name = "currentDateOfBirth";
            currentDateOfBirth.Size = new Size(114, 16);
            currentDateOfBirth.TabIndex = 10;
            currentDateOfBirth.Text = "currentDateOfBirth";
            // 
            // userAccountPictureBox
            // 
            userAccountPictureBox.BackColor = Color.Transparent;
            userAccountPictureBox.BackgroundImage = Properties.Resources.default1;
            userAccountPictureBox.Cursor = Cursors.Hand;
            userAccountPictureBox.Location = new Point(1078, 47);
            userAccountPictureBox.Name = "userAccountPictureBox";
            userAccountPictureBox.Size = new Size(100, 100);
            userAccountPictureBox.TabIndex = 12;
            userAccountPictureBox.TabStop = false;
            userAccountPictureBox.Click += ChangeProfileImage;
            // 
            // exitToStartFormLabel
            // 
            exitToStartFormLabel.AutoSize = true;
            exitToStartFormLabel.BackColor = Color.Transparent;
            exitToStartFormLabel.Cursor = Cursors.Hand;
            exitToStartFormLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            exitToStartFormLabel.ForeColor = Color.MidnightBlue;
            exitToStartFormLabel.Location = new Point(1157, 724);
            exitToStartFormLabel.Name = "exitToStartFormLabel";
            exitToStartFormLabel.Size = new Size(49, 17);
            exitToStartFormLabel.TabIndex = 13;
            exitToStartFormLabel.Text = "Выход";
            exitToStartFormLabel.Click += ExitToStartFormLabel_CLick;
            exitToStartFormLabel.MouseEnter += ExitToStartFormLabel_MouseEnter;
            exitToStartFormLabel.MouseLeave += ExitToStartFormLabel_MouseLeave;
            // 
            // userAccountOpenFileDialog
            // 
            userAccountOpenFileDialog.FileName = "openFileDialog1";
            // 
            // userAccountTabControl
            // 
            userAccountTabControl.Controls.Add(tabPage1);
            userAccountTabControl.Controls.Add(tabPage2);
            userAccountTabControl.Location = new Point(41, 157);
            userAccountTabControl.Name = "userAccountTabControl";
            userAccountTabControl.SelectedIndex = 0;
            userAccountTabControl.Size = new Size(1168, 555);
            userAccountTabControl.TabIndex = 14;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(availableBooksFilterGroupBox);
            tabPage1.Controls.Add(takeABookButton);
            tabPage1.Controls.Add(availableBooksTable);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1160, 527);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Все книги";
            // 
            // availableBooksFilterGroupBox
            // 
            availableBooksFilterGroupBox.Controls.Add(availableBooksFilterBox);
            availableBooksFilterGroupBox.Controls.Add(availableBooksNameFilterRadioButton);
            availableBooksFilterGroupBox.Controls.Add(availableBooksAuthorFilterRadioButton);
            availableBooksFilterGroupBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            availableBooksFilterGroupBox.ForeColor = Color.MidnightBlue;
            availableBooksFilterGroupBox.Location = new Point(2, 2);
            availableBooksFilterGroupBox.Name = "availableBooksFilterGroupBox";
            availableBooksFilterGroupBox.Size = new Size(478, 63);
            availableBooksFilterGroupBox.TabIndex = 4;
            availableBooksFilterGroupBox.TabStop = false;
            availableBooksFilterGroupBox.Text = "Фильтрация";
            // 
            // availableBooksFilterBox
            // 
            availableBooksFilterBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            availableBooksFilterBox.Location = new Point(253, 26);
            availableBooksFilterBox.Name = "availableBooksFilterBox";
            availableBooksFilterBox.Size = new Size(205, 25);
            availableBooksFilterBox.TabIndex = 3;
            availableBooksFilterBox.TextChanged += AvailableBooksFilterTextChanged;
            // 
            // availableBooksNameFilterRadioButton
            // 
            availableBooksNameFilterRadioButton.AutoSize = true;
            availableBooksNameFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            availableBooksNameFilterRadioButton.ForeColor = Color.Black;
            availableBooksNameFilterRadioButton.Location = new Point(122, 30);
            availableBooksNameFilterRadioButton.Name = "availableBooksNameFilterRadioButton";
            availableBooksNameFilterRadioButton.Size = new Size(104, 21);
            availableBooksNameFilterRadioButton.TabIndex = 1;
            availableBooksNameFilterRadioButton.TabStop = true;
            availableBooksNameFilterRadioButton.Text = "по названию";
            availableBooksNameFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // availableBooksAuthorFilterRadioButton
            // 
            availableBooksAuthorFilterRadioButton.AutoSize = true;
            availableBooksAuthorFilterRadioButton.Checked = true;
            availableBooksAuthorFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            availableBooksAuthorFilterRadioButton.ForeColor = Color.Black;
            availableBooksAuthorFilterRadioButton.Location = new Point(15, 30);
            availableBooksAuthorFilterRadioButton.Name = "availableBooksAuthorFilterRadioButton";
            availableBooksAuthorFilterRadioButton.Size = new Size(86, 21);
            availableBooksAuthorFilterRadioButton.TabIndex = 0;
            availableBooksAuthorFilterRadioButton.TabStop = true;
            availableBooksAuthorFilterRadioButton.Text = "по автору";
            availableBooksAuthorFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // takeABookButton
            // 
            takeABookButton.Location = new Point(27, 479);
            takeABookButton.Name = "takeABookButton";
            takeABookButton.Size = new Size(100, 23);
            takeABookButton.TabIndex = 1;
            takeABookButton.Text = "Взять книгу";
            takeABookButton.UseVisualStyleBackColor = true;
            takeABookButton.Click += TakeABookButton_CLick;
            // 
            // availableBooksTable
            // 
            availableBooksTable.AllowUserToAddRows = false;
            availableBooksTable.AllowUserToResizeColumns = false;
            availableBooksTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            availableBooksTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            availableBooksTable.BackgroundColor = SystemColors.Control;
            availableBooksTable.BorderStyle = BorderStyle.None;
            availableBooksTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            availableBooksTable.Location = new Point(2, 70);
            availableBooksTable.Name = "availableBooksTable";
            availableBooksTable.ReadOnly = true;
            availableBooksTable.RowHeadersVisible = false;
            availableBooksTable.RowTemplate.Height = 25;
            availableBooksTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availableBooksTable.Size = new Size(1158, 385);
            availableBooksTable.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(noBooksLabel);
            tabPage2.Controls.Add(reaturnABookButton);
            tabPage2.Controls.Add(currentBooksTable);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1160, 527);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Мои книги";
            // 
            // noBooksLabel
            // 
            noBooksLabel.AutoSize = true;
            noBooksLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            noBooksLabel.Location = new Point(491, 181);
            noBooksLabel.Name = "noBooksLabel";
            noBooksLabel.Size = new Size(218, 17);
            noBooksLabel.TabIndex = 15;
            noBooksLabel.Text = "Пока вы не взяли ни одной книги...";
            noBooksLabel.Visible = false;
            // 
            // reaturnABookButton
            // 
            reaturnABookButton.Location = new Point(27, 479);
            reaturnABookButton.Name = "reaturnABookButton";
            reaturnABookButton.Size = new Size(100, 23);
            reaturnABookButton.TabIndex = 1;
            reaturnABookButton.Text = "Вернуть книгу";
            reaturnABookButton.UseVisualStyleBackColor = true;
            reaturnABookButton.Click += ReturnABookButton_CLick;
            // 
            // currentBooksTable
            // 
            currentBooksTable.AllowUserToAddRows = false;
            currentBooksTable.AllowUserToResizeColumns = false;
            currentBooksTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            currentBooksTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            currentBooksTable.BackgroundColor = SystemColors.Control;
            currentBooksTable.BorderStyle = BorderStyle.None;
            currentBooksTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            currentBooksTable.Location = new Point(1, 0);
            currentBooksTable.Name = "currentBooksTable";
            currentBooksTable.ReadOnly = true;
            currentBooksTable.RowHeadersVisible = false;
            currentBooksTable.RowTemplate.Height = 25;
            currentBooksTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            currentBooksTable.Size = new Size(1160, 452);
            currentBooksTable.TabIndex = 0;
            // 
            // UserAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1246, 768);
            Controls.Add(userAccountTabControl);
            Controls.Add(exitToStartFormLabel);
            Controls.Add(userAccountPictureBox);
            Controls.Add(currentDateOfBirth);
            Controls.Add(userAccountCloseLabel);
            Controls.Add(currentUserName);
            Controls.Add(UserAccountFormName);
            Controls.Add(currentTotalBooksLabel);
            Controls.Add(currentLibraryCardNumberLabel);
            Controls.Add(currentTotalBooks);
            Controls.Add(currentLibraryCardNumber);
            Controls.Add(currentDateLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1246, 768);
            MinimumSize = new Size(1246, 768);
            Name = "UserAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Личный кабинет пользователя";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)userAccountPictureBox).EndInit();
            userAccountTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            availableBooksFilterGroupBox.ResumeLayout(false);
            availableBooksFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)availableBooksTable).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)currentBooksTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label currentDateLabel;
        private Label currentLibraryCardNumber;
        private Label currentTotalBooks;
        private Label currentLibraryCardNumberLabel;
        private Label currentTotalBooksLabel;
        private Label UserAccountFormName;
        private Label currentUserName;
        private Label userAccountCloseLabel;
        private Label currentDateOfBirth;
        private PictureBox userAccountPictureBox;
        private Label exitToStartFormLabel;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog userAccountOpenFileDialog;
        private TabControl userAccountTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView availableBooksTable;
        private Button takeABookButton;
        private DataGridView currentBooksTable;
        private Button reaturnABookButton;
        private GroupBox availableBooksFilterGroupBox;
        private TextBox availableBooksFilterBox;
        private RadioButton availableBooksNameFilterRadioButton;
        private RadioButton availableBooksAuthorFilterRadioButton;
        private Label noBooksLabel;
    }
}