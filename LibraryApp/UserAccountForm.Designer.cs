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
            SuspendLayout();
            // 
            // currentDateLabel
            // 
            currentDateLabel.AutoSize = true;
            currentDateLabel.BackColor = Color.Transparent;
            currentDateLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            currentDateLabel.Location = new Point(783, 39);
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
            currentLibraryCardNumber.Location = new Point(248, 96);
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
            currentTotalBooks.Location = new Point(125, 125);
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
            currentLibraryCardNumberLabel.Location = new Point(42, 96);
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
            currentTotalBooksLabel.Location = new Point(42, 125);
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
            UserAccountFormName.Location = new Point(30, 29);
            UserAccountFormName.Name = "UserAccountFormName";
            UserAccountFormName.Size = new Size(283, 45);
            UserAccountFormName.TabIndex = 7;
            UserAccountFormName.Text = "Личный кабинет";
            // 
            // UserAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1008, 729);
            Controls.Add(UserAccountFormName);
            Controls.Add(currentTotalBooksLabel);
            Controls.Add(currentLibraryCardNumberLabel);
            Controls.Add(currentTotalBooks);
            Controls.Add(currentLibraryCardNumber);
            Controls.Add(currentDateLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "UserAccountForm";
            Text = "Личный кабинет пользователя";
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
    }
}