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
            ((System.ComponentModel.ISupportInitialize)userAccountPictureBox).BeginInit();
            SuspendLayout();
            // 
            // currentDateLabel
            // 
            currentDateLabel.AutoSize = true;
            currentDateLabel.BackColor = Color.Transparent;
            currentDateLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentDateLabel.ForeColor = Color.MidnightBlue;
            currentDateLabel.Location = new Point(684, 61);
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
            currentLibraryCardNumber.Location = new Point(367, 180);
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
            currentTotalBooks.Location = new Point(244, 209);
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
            currentLibraryCardNumberLabel.Location = new Point(161, 180);
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
            currentTotalBooksLabel.Location = new Point(161, 209);
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
            currentUserName.Location = new Point(161, 110);
            currentUserName.Name = "currentUserName";
            currentUserName.Size = new Size(164, 25);
            currentUserName.TabIndex = 8;
            currentUserName.Text = "currentUserName";
            // 
            // userAccountCloseLabel
            // 
            userAccountCloseLabel.AutoSize = true;
            userAccountCloseLabel.BackColor = Color.Transparent;
            userAccountCloseLabel.Cursor = Cursors.Hand;
            userAccountCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            userAccountCloseLabel.Location = new Point(963, 21);
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
            currentDateOfBirth.Location = new Point(164, 142);
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
            userAccountPictureBox.Location = new Point(42, 120);
            userAccountPictureBox.Name = "userAccountPictureBox";
            userAccountPictureBox.Size = new Size(100, 100);
            userAccountPictureBox.TabIndex = 12;
            userAccountPictureBox.TabStop = false;
            userAccountPictureBox.Click += ExitToStartFormLabel_CLick;
            // 
            // UserAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1008, 729);
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
            MaximumSize = new Size(1008, 729);
            MinimumSize = new Size(1008, 729);
            Name = "UserAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Личный кабинет пользователя";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)userAccountPictureBox).EndInit();
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
    }
}