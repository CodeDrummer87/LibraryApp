namespace LibraryApp.View
{
    partial class SetReaderLoginPassword
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
            label1 = new Label();
            loginInputBox = new TextBox();
            passwordInputBox = new TextBox();
            loginInputLabel = new Label();
            passwordInputLabel = new Label();
            saveLoginPswdButton = new Button();
            setReaderLoginPasswordCloseLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(20, 29);
            label1.Name = "label1";
            label1.Size = new Size(347, 25);
            label1.TabIndex = 0;
            label1.Text = "Введите логин и пароль для читателя";
            // 
            // loginInputBox
            // 
            loginInputBox.Location = new Point(28, 97);
            loginInputBox.Name = "loginInputBox";
            loginInputBox.Size = new Size(190, 23);
            loginInputBox.TabIndex = 1;
            // 
            // passwordInputBox
            // 
            passwordInputBox.Location = new Point(28, 148);
            passwordInputBox.Name = "passwordInputBox";
            passwordInputBox.Size = new Size(190, 23);
            passwordInputBox.TabIndex = 2;
            // 
            // loginInputLabel
            // 
            loginInputLabel.AutoSize = true;
            loginInputLabel.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            loginInputLabel.ForeColor = Color.MidnightBlue;
            loginInputLabel.Location = new Point(28, 79);
            loginInputLabel.Name = "loginInputLabel";
            loginInputLabel.Size = new Size(41, 15);
            loginInputLabel.TabIndex = 3;
            loginInputLabel.Text = "Логин";
            // 
            // passwordInputLabel
            // 
            passwordInputLabel.AutoSize = true;
            passwordInputLabel.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            passwordInputLabel.ForeColor = Color.MidnightBlue;
            passwordInputLabel.Location = new Point(28, 130);
            passwordInputLabel.Name = "passwordInputLabel";
            passwordInputLabel.Size = new Size(52, 15);
            passwordInputLabel.TabIndex = 4;
            passwordInputLabel.Text = "Пароль";
            // 
            // saveLoginPswdButton
            // 
            saveLoginPswdButton.Location = new Point(28, 205);
            saveLoginPswdButton.Name = "saveLoginPswdButton";
            saveLoginPswdButton.Size = new Size(75, 23);
            saveLoginPswdButton.TabIndex = 5;
            saveLoginPswdButton.Text = "Сохранить";
            saveLoginPswdButton.UseVisualStyleBackColor = true;
            saveLoginPswdButton.Click += SaveReaderLoginPassword_CLick;
            // 
            // setReaderLoginPasswordCloseLabel
            // 
            setReaderLoginPasswordCloseLabel.AutoSize = true;
            setReaderLoginPasswordCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            setReaderLoginPasswordCloseLabel.Location = new Point(401, 9);
            setReaderLoginPasswordCloseLabel.Name = "setReaderLoginPasswordCloseLabel";
            setReaderLoginPasswordCloseLabel.Size = new Size(21, 19);
            setReaderLoginPasswordCloseLabel.TabIndex = 6;
            setReaderLoginPasswordCloseLabel.Text = "-";
            setReaderLoginPasswordCloseLabel.Click += SetReaderLoginPasswordCloseLabel_Click;
            setReaderLoginPasswordCloseLabel.MouseEnter += SetReaderLoginPasswordCloseLabel_MouseEnter;
            setReaderLoginPasswordCloseLabel.MouseLeave += SetReaderLoginPasswordCloseLabel_MouseLeave;
            // 
            // SetReaderLoginPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 261);
            Controls.Add(setReaderLoginPasswordCloseLabel);
            Controls.Add(saveLoginPswdButton);
            Controls.Add(passwordInputLabel);
            Controls.Add(loginInputLabel);
            Controls.Add(passwordInputBox);
            Controls.Add(loginInputBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SetReaderLoginPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учетные данные читателя";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox loginInputBox;
        private TextBox passwordInputBox;
        private Label loginInputLabel;
        private Label passwordInputLabel;
        private Label setReaderLoginPasswordCloseLabel;
        private Button saveLoginPswdButton;
    }
}