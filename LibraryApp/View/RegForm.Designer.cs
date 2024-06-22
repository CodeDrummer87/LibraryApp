namespace LibraryApp.View
{
    partial class RegForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegForm));
            regFormCloseLabel = new Label();
            regFormName = new Label();
            regFormLastNameInputBox = new TextBox();
            regFormLastNameLabel = new Label();
            regFormFirstNameInputBox = new TextBox();
            regFormFirstNameLabel = new Label();
            regFormSurNameInputBox = new TextBox();
            regFormSurNameLabel = new Label();
            regFormDateOfBirthInputBox = new TextBox();
            regFormDateOfBirthLabel = new Label();
            regFormLoginInputBox = new TextBox();
            regFormLoginLabel = new Label();
            regFormPasswordInputBox = new TextBox();
            regFormPasswordLabel = new Label();
            createUserButton = new Button();
            ClearRegFormButton = new Button();
            SuspendLayout();
            // 
            // regFormCloseLabel
            // 
            regFormCloseLabel.AutoSize = true;
            regFormCloseLabel.BackColor = Color.Transparent;
            regFormCloseLabel.Cursor = Cursors.Hand;
            regFormCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            regFormCloseLabel.ForeColor = Color.Black;
            regFormCloseLabel.Location = new Point(763, 12);
            regFormCloseLabel.Name = "regFormCloseLabel";
            regFormCloseLabel.Size = new Size(21, 19);
            regFormCloseLabel.TabIndex = 0;
            regFormCloseLabel.Text = "-";
            regFormCloseLabel.Click += RegFormCloseLabel_Click;
            regFormCloseLabel.MouseEnter += RegFormCloseLabel_MouseEnter;
            regFormCloseLabel.MouseLeave += RegFormCloseLabel_MouseLeave;
            // 
            // regFormName
            // 
            regFormName.AutoSize = true;
            regFormName.BackColor = Color.Transparent;
            regFormName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            regFormName.ForeColor = Color.Black;
            regFormName.Location = new Point(39, 32);
            regFormName.Name = "regFormName";
            regFormName.Size = new Size(250, 25);
            regFormName.TabIndex = 1;
            regFormName.Text = "Регистрация пользователя";
            // 
            // regFormLastNameInputBox
            // 
            regFormLastNameInputBox.BackColor = Color.WhiteSmoke;
            regFormLastNameInputBox.Location = new Point(46, 118);
            regFormLastNameInputBox.Name = "regFormLastNameInputBox";
            regFormLastNameInputBox.Size = new Size(100, 23);
            regFormLastNameInputBox.TabIndex = 2;
            // 
            // regFormLastNameLabel
            // 
            regFormLastNameLabel.AutoSize = true;
            regFormLastNameLabel.BackColor = Color.Transparent;
            regFormLastNameLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            regFormLastNameLabel.ForeColor = Color.MidnightBlue;
            regFormLastNameLabel.Location = new Point(46, 98);
            regFormLastNameLabel.Name = "regFormLastNameLabel";
            regFormLastNameLabel.Size = new Size(65, 17);
            regFormLastNameLabel.TabIndex = 3;
            regFormLastNameLabel.Text = "Фамилия";
            // 
            // regFormFirstNameInputBox
            // 
            regFormFirstNameInputBox.BackColor = Color.WhiteSmoke;
            regFormFirstNameInputBox.Location = new Point(176, 118);
            regFormFirstNameInputBox.Name = "regFormFirstNameInputBox";
            regFormFirstNameInputBox.Size = new Size(100, 23);
            regFormFirstNameInputBox.TabIndex = 4;
            // 
            // regFormFirstNameLabel
            // 
            regFormFirstNameLabel.AutoSize = true;
            regFormFirstNameLabel.BackColor = Color.Transparent;
            regFormFirstNameLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            regFormFirstNameLabel.ForeColor = Color.MidnightBlue;
            regFormFirstNameLabel.Location = new Point(176, 98);
            regFormFirstNameLabel.Name = "regFormFirstNameLabel";
            regFormFirstNameLabel.Size = new Size(35, 17);
            regFormFirstNameLabel.TabIndex = 5;
            regFormFirstNameLabel.Text = "Имя";
            // 
            // regFormSurNameInputBox
            // 
            regFormSurNameInputBox.BackColor = Color.WhiteSmoke;
            regFormSurNameInputBox.Location = new Point(306, 118);
            regFormSurNameInputBox.Name = "regFormSurNameInputBox";
            regFormSurNameInputBox.Size = new Size(100, 23);
            regFormSurNameInputBox.TabIndex = 6;
            // 
            // regFormSurNameLabel
            // 
            regFormSurNameLabel.AutoSize = true;
            regFormSurNameLabel.BackColor = Color.Transparent;
            regFormSurNameLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            regFormSurNameLabel.ForeColor = Color.MidnightBlue;
            regFormSurNameLabel.Location = new Point(306, 98);
            regFormSurNameLabel.Name = "regFormSurNameLabel";
            regFormSurNameLabel.Size = new Size(66, 17);
            regFormSurNameLabel.TabIndex = 7;
            regFormSurNameLabel.Text = "Отчество";
            // 
            // regFormDateOfBirthInputBox
            // 
            regFormDateOfBirthInputBox.BackColor = Color.WhiteSmoke;
            regFormDateOfBirthInputBox.Location = new Point(437, 118);
            regFormDateOfBirthInputBox.Name = "regFormDateOfBirthInputBox";
            regFormDateOfBirthInputBox.Size = new Size(115, 23);
            regFormDateOfBirthInputBox.TabIndex = 8;
            // 
            // regFormDateOfBirthLabel
            // 
            regFormDateOfBirthLabel.AutoSize = true;
            regFormDateOfBirthLabel.BackColor = Color.Transparent;
            regFormDateOfBirthLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            regFormDateOfBirthLabel.ForeColor = Color.MidnightBlue;
            regFormDateOfBirthLabel.Location = new Point(437, 98);
            regFormDateOfBirthLabel.Name = "regFormDateOfBirthLabel";
            regFormDateOfBirthLabel.Size = new Size(105, 17);
            regFormDateOfBirthLabel.TabIndex = 9;
            regFormDateOfBirthLabel.Text = "Дата рождения";
            // 
            // regFormLoginInputBox
            // 
            regFormLoginInputBox.BackColor = Color.WhiteSmoke;
            regFormLoginInputBox.Location = new Point(46, 189);
            regFormLoginInputBox.Name = "regFormLoginInputBox";
            regFormLoginInputBox.Size = new Size(100, 23);
            regFormLoginInputBox.TabIndex = 10;
            // 
            // regFormLoginLabel
            // 
            regFormLoginLabel.AutoSize = true;
            regFormLoginLabel.BackColor = Color.Transparent;
            regFormLoginLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            regFormLoginLabel.ForeColor = Color.MidnightBlue;
            regFormLoginLabel.Location = new Point(46, 169);
            regFormLoginLabel.Name = "regFormLoginLabel";
            regFormLoginLabel.Size = new Size(46, 17);
            regFormLoginLabel.TabIndex = 11;
            regFormLoginLabel.Text = "Логин";
            // 
            // regFormPasswordInputBox
            // 
            regFormPasswordInputBox.BackColor = Color.WhiteSmoke;
            regFormPasswordInputBox.Location = new Point(176, 189);
            regFormPasswordInputBox.Name = "regFormPasswordInputBox";
            regFormPasswordInputBox.Size = new Size(100, 23);
            regFormPasswordInputBox.TabIndex = 12;
            // 
            // regFormPasswordLabel
            // 
            regFormPasswordLabel.AutoSize = true;
            regFormPasswordLabel.BackColor = Color.Transparent;
            regFormPasswordLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            regFormPasswordLabel.ForeColor = Color.MidnightBlue;
            regFormPasswordLabel.Location = new Point(176, 169);
            regFormPasswordLabel.Name = "regFormPasswordLabel";
            regFormPasswordLabel.Size = new Size(55, 17);
            regFormPasswordLabel.TabIndex = 13;
            regFormPasswordLabel.Text = "Пароль";
            // 
            // createUserButton
            // 
            createUserButton.Cursor = Cursors.Hand;
            createUserButton.Location = new Point(46, 268);
            createUserButton.Name = "createUserButton";
            createUserButton.Size = new Size(75, 23);
            createUserButton.TabIndex = 14;
            createUserButton.Text = "Создать";
            createUserButton.UseVisualStyleBackColor = true;
            // 
            // ClearRegFormButton
            // 
            ClearRegFormButton.Cursor = Cursors.Hand;
            ClearRegFormButton.Location = new Point(137, 268);
            ClearRegFormButton.Name = "ClearRegFormButton";
            ClearRegFormButton.Size = new Size(75, 23);
            ClearRegFormButton.TabIndex = 15;
            ClearRegFormButton.Text = "Очистить";
            ClearRegFormButton.UseVisualStyleBackColor = true;
            ClearRegFormButton.Click += ClearRegFormButton_Click;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 461);
            Controls.Add(ClearRegFormButton);
            Controls.Add(createUserButton);
            Controls.Add(regFormPasswordLabel);
            Controls.Add(regFormPasswordInputBox);
            Controls.Add(regFormLoginLabel);
            Controls.Add(regFormLoginInputBox);
            Controls.Add(regFormDateOfBirthLabel);
            Controls.Add(regFormDateOfBirthInputBox);
            Controls.Add(regFormSurNameLabel);
            Controls.Add(regFormSurNameInputBox);
            Controls.Add(regFormFirstNameLabel);
            Controls.Add(regFormFirstNameInputBox);
            Controls.Add(regFormLastNameLabel);
            Controls.Add(regFormLastNameInputBox);
            Controls.Add(regFormName);
            Controls.Add(regFormCloseLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 0);
            Name = "RegForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация пользователя";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label regFormCloseLabel;
        private Label regFormName;
        private TextBox regFormLastNameInputBox;
        private Label regFormLastNameLabel;
        private TextBox regFormFirstNameInputBox;
        private Label regFormFirstNameLabel;
        private TextBox regFormSurNameInputBox;
        private Label regFormSurNameLabel;
        private TextBox regFormDateOfBirthInputBox;
        private Label regFormDateOfBirthLabel;
        private TextBox regFormLoginInputBox;
        private Label regFormLoginLabel;
        private TextBox regFormPasswordInputBox;
        private Label regFormPasswordLabel;
        private Button createUserButton;
        private Button ClearRegFormButton;
    }
}