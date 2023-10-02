namespace LibraryApp
{
    partial class StartForm
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            appName = new Label();
            loginInputBox = new TextBox();
            loginInputLabel = new Label();
            passwordInputBox = new TextBox();
            pswdInputLabel = new Label();
            authButton = new Button();
            cancelButton = new Button();
            appVersion = new Label();
            closeLabel = new Label();
            SuspendLayout();
            // 
            // appName
            // 
            appName.AutoSize = true;
            appName.BackColor = Color.Transparent;
            appName.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            appName.ForeColor = Color.MidnightBlue;
            appName.Location = new Point(405, 38);
            appName.Name = "appName";
            appName.Size = new Size(175, 31);
            appName.TabIndex = 0;
            appName.Text = "Библионикс";
            // 
            // loginInputBox
            // 
            loginInputBox.BackColor = Color.OldLace;
            loginInputBox.Location = new Point(264, 140);
            loginInputBox.Name = "loginInputBox";
            loginInputBox.Size = new Size(189, 23);
            loginInputBox.TabIndex = 1;
            // 
            // loginInputLabel
            // 
            loginInputLabel.AutoSize = true;
            loginInputLabel.BackColor = Color.Transparent;
            loginInputLabel.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            loginInputLabel.ForeColor = Color.MidnightBlue;
            loginInputLabel.Location = new Point(264, 122);
            loginInputLabel.Name = "loginInputLabel";
            loginInputLabel.Size = new Size(41, 15);
            loginInputLabel.TabIndex = 2;
            loginInputLabel.Text = "Логин";
            // 
            // passwordInputBox
            // 
            passwordInputBox.BackColor = Color.OldLace;
            passwordInputBox.Location = new Point(264, 197);
            passwordInputBox.Name = "passwordInputBox";
            passwordInputBox.Size = new Size(189, 23);
            passwordInputBox.TabIndex = 3;
            // 
            // pswdInputLabel
            // 
            pswdInputLabel.AutoSize = true;
            pswdInputLabel.BackColor = Color.Transparent;
            pswdInputLabel.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            pswdInputLabel.ForeColor = Color.MidnightBlue;
            pswdInputLabel.Location = new Point(264, 179);
            pswdInputLabel.Name = "pswdInputLabel";
            pswdInputLabel.Size = new Size(52, 15);
            pswdInputLabel.TabIndex = 4;
            pswdInputLabel.Text = "Пароль";
            // 
            // authButton
            // 
            authButton.BackColor = SystemColors.Control;
            authButton.Cursor = Cursors.Hand;
            authButton.Location = new Point(293, 252);
            authButton.Name = "authButton";
            authButton.Size = new Size(75, 23);
            authButton.TabIndex = 5;
            authButton.Text = "Вход";
            authButton.UseVisualStyleBackColor = false;
            authButton.Click += AuthButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.Location = new Point(378, 252);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // appVersion
            // 
            appVersion.AutoSize = true;
            appVersion.BackColor = Color.Transparent;
            appVersion.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            appVersion.Location = new Point(518, 69);
            appVersion.Name = "appVersion";
            appVersion.Size = new Size(62, 14);
            appVersion.TabIndex = 7;
            appVersion.Text = "версия 0.1";
            // 
            // closeLabel
            // 
            closeLabel.AutoSize = true;
            closeLabel.BackColor = Color.Transparent;
            closeLabel.Cursor = Cursors.Hand;
            closeLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            closeLabel.ForeColor = Color.MidnightBlue;
            closeLabel.Location = new Point(519, 337);
            closeLabel.Name = "closeLabel";
            closeLabel.Size = new Size(53, 15);
            closeLabel.TabIndex = 8;
            closeLabel.Text = "Закрыть";
            closeLabel.Click += CloseLabel_Click;
            closeLabel.MouseEnter += CloseLabel_MouseEnter;
            closeLabel.MouseLeave += CloseLabel_MouseLeave;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(600, 361);
            Controls.Add(closeLabel);
            Controls.Add(appVersion);
            Controls.Add(cancelButton);
            Controls.Add(authButton);
            Controls.Add(pswdInputLabel);
            Controls.Add(passwordInputBox);
            Controls.Add(loginInputLabel);
            Controls.Add(loginInputBox);
            Controls.Add(appName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Библионикс 0.1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appName;
        private TextBox loginInputBox;
        private Label loginInputLabel;
        private TextBox passwordInputBox;
        private Label pswdInputLabel;
        private Button authButton;
        private Button cancelButton;
        private Label appVersion;
        private Label closeLabel;
    }
}