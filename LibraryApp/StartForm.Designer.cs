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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            appName = new Label();
            loginInputBox = new TextBox();
            loginInputLabel = new Label();
            passwordInputBox = new TextBox();
            label1 = new Label();
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
            appName.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            appName.ForeColor = Color.MidnightBlue;
            appName.Location = new Point(423, 36);
            appName.Name = "appName";
            appName.Size = new Size(134, 31);
            appName.TabIndex = 0;
            appName.Text = "LibraryApp";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(264, 179);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 4;
            label1.Text = "Пароль";
            // 
            // authButton
            // 
            authButton.BackColor = SystemColors.Control;
            authButton.Location = new Point(293, 252);
            authButton.Name = "authButton";
            authButton.Size = new Size(75, 23);
            authButton.TabIndex = 5;
            authButton.Text = "Вход";
            authButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
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
            appVersion.Location = new Point(493, 69);
            appVersion.Name = "appVersion";
            appVersion.Size = new Size(62, 14);
            appVersion.TabIndex = 7;
            appVersion.Text = "версия 0.1";
            // 
            // closeLabel
            // 
            closeLabel.AutoSize = true;
            closeLabel.BackColor = Color.Transparent;
            closeLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            closeLabel.ForeColor = Color.MidnightBlue;
            closeLabel.Location = new Point(519, 337);
            closeLabel.Name = "closeLabel";
            closeLabel.Size = new Size(53, 15);
            closeLabel.TabIndex = 8;
            closeLabel.Text = "Закрыть";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            this.closeLabel.MouseEnter += new System.EventHandler(this.closeLabel_MouseEnter);
            this.closeLabel.MouseLeave += new System.EventHandler(this.closeLabel_MouseLeave);
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(584, 361);
            Controls.Add(closeLabel);
            Controls.Add(appVersion);
            Controls.Add(cancelButton);
            Controls.Add(authButton);
            Controls.Add(label1);
            Controls.Add(passwordInputBox);
            Controls.Add(loginInputLabel);
            Controls.Add(loginInputBox);
            Controls.Add(appName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LibraryApp 0.1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appName;
        private TextBox loginInputBox;
        private Label loginInputLabel;
        private TextBox passwordInputBox;
        private Label label1;
        private Button authButton;
        private Button cancelButton;
        private Label appVersion;
        private Label closeLabel;
    }
}