namespace LibraryApp
{
    partial class LibraryManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryManagerForm));
            LibraryManagerName = new Label();
            createEmployeeButton = new Button();
            libraryManagerCloseLabel = new Label();
            listOfEmployeesButton = new Button();
            createNewPositionButton = new Button();
            listOfPositionsButton = new Button();
            currentDateLabel = new Label();
            currentManagerNameLabel = new Label();
            exitToStartFormLabel = new Label();
            SuspendLayout();
            // 
            // LibraryManagerName
            // 
            LibraryManagerName.AutoSize = true;
            LibraryManagerName.BackColor = Color.Transparent;
            LibraryManagerName.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            LibraryManagerName.Location = new Point(35, 27);
            LibraryManagerName.Name = "LibraryManagerName";
            LibraryManagerName.Size = new Size(423, 45);
            LibraryManagerName.TabIndex = 0;
            LibraryManagerName.Text = "Управление библиотекой";
            // 
            // createEmployeeButton
            // 
            createEmployeeButton.Cursor = Cursors.Hand;
            createEmployeeButton.Location = new Point(54, 100);
            createEmployeeButton.Name = "createEmployeeButton";
            createEmployeeButton.Size = new Size(185, 23);
            createEmployeeButton.TabIndex = 1;
            createEmployeeButton.Text = "Создать аккаунт сотрудника";
            createEmployeeButton.UseVisualStyleBackColor = true;
            createEmployeeButton.Click += CreateEmployeeButton_Click;
            // 
            // libraryManagerCloseLabel
            // 
            libraryManagerCloseLabel.AutoSize = true;
            libraryManagerCloseLabel.Cursor = Cursors.Hand;
            libraryManagerCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            libraryManagerCloseLabel.Location = new Point(764, 13);
            libraryManagerCloseLabel.Name = "libraryManagerCloseLabel";
            libraryManagerCloseLabel.Size = new Size(21, 19);
            libraryManagerCloseLabel.TabIndex = 3;
            libraryManagerCloseLabel.Text = "-";
            libraryManagerCloseLabel.Click += LibraryManagerCloseLabel_Click;
            libraryManagerCloseLabel.MouseEnter += LibraryManagerCloseLabel_MouseEnter;
            libraryManagerCloseLabel.MouseLeave += LibraryManagerCloseLabel_MouseLeave;
            // 
            // listOfEmployeesButton
            // 
            listOfEmployeesButton.Cursor = Cursors.Hand;
            listOfEmployeesButton.Location = new Point(54, 129);
            listOfEmployeesButton.Name = "listOfEmployeesButton";
            listOfEmployeesButton.Size = new Size(185, 23);
            listOfEmployeesButton.TabIndex = 5;
            listOfEmployeesButton.Text = "Список сотрудников";
            listOfEmployeesButton.UseVisualStyleBackColor = true;
            listOfEmployeesButton.Click += ListOfEmployeesButtn_Click;
            // 
            // createNewPositionButton
            // 
            createNewPositionButton.Cursor = Cursors.Hand;
            createNewPositionButton.Location = new Point(54, 158);
            createNewPositionButton.Name = "createNewPositionButton";
            createNewPositionButton.Size = new Size(185, 23);
            createNewPositionButton.TabIndex = 6;
            createNewPositionButton.Text = "Создать новую должность";
            createNewPositionButton.UseVisualStyleBackColor = true;
            // 
            // listOfPositionsButton
            // 
            listOfPositionsButton.Location = new Point(54, 187);
            listOfPositionsButton.Name = "listOfPositionsButton";
            listOfPositionsButton.Size = new Size(185, 23);
            listOfPositionsButton.TabIndex = 7;
            listOfPositionsButton.Text = "Список должностей";
            listOfPositionsButton.UseVisualStyleBackColor = true;
            // 
            // currentDateLabel
            // 
            currentDateLabel.AutoSize = true;
            currentDateLabel.BackColor = Color.Transparent;
            currentDateLabel.Location = new Point(296, 104);
            currentDateLabel.Name = "currentDateLabel";
            currentDateLabel.Size = new Size(97, 15);
            currentDateLabel.TabIndex = 8;
            currentDateLabel.Text = "currentDateLabel";
            // 
            // currentManagerNameLabel
            // 
            currentManagerNameLabel.AutoSize = true;
            currentManagerNameLabel.BackColor = Color.Transparent;
            currentManagerNameLabel.Location = new Point(296, 128);
            currentManagerNameLabel.Name = "currentManagerNameLabel";
            currentManagerNameLabel.Size = new Size(152, 15);
            currentManagerNameLabel.TabIndex = 9;
            currentManagerNameLabel.Text = "currentManagerNameLabel";
            // 
            // exitToStartFormLabel
            // 
            exitToStartFormLabel.AutoSize = true;
            exitToStartFormLabel.BackColor = Color.Transparent;
            exitToStartFormLabel.Cursor = Cursors.Hand;
            exitToStartFormLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            exitToStartFormLabel.ForeColor = Color.MidnightBlue;
            exitToStartFormLabel.Location = new Point(730, 421);
            exitToStartFormLabel.Name = "exitToStartFormLabel";
            exitToStartFormLabel.Size = new Size(49, 17);
            exitToStartFormLabel.TabIndex = 10;
            exitToStartFormLabel.Text = "Выход";
            exitToStartFormLabel.Click += ExitToStartFormLabel_CLick;
            exitToStartFormLabel.MouseEnter += ExitToStartFormLabel_MouseEnter;
            exitToStartFormLabel.MouseLeave += ExitToStartFormLabel_MouseLeave;
            // 
            // LibraryManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(exitToStartFormLabel);
            Controls.Add(currentManagerNameLabel);
            Controls.Add(currentDateLabel);
            Controls.Add(listOfPositionsButton);
            Controls.Add(createNewPositionButton);
            Controls.Add(listOfEmployeesButton);
            Controls.Add(libraryManagerCloseLabel);
            Controls.Add(createEmployeeButton);
            Controls.Add(LibraryManagerName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(800, 450);
            MinimumSize = new Size(800, 450);
            Name = "LibraryManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление библиотекой";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LibraryManagerName;
        private Button createEmployeeButton;
        private Label libraryManagerCloseLabel;
        private Button listOfEmployeesButton;
        private Button createNewPositionButton;
        private Button listOfPositionsButton;
        private Label currentDateLabel;
        private Label currentManagerNameLabel;
        private Label exitToStartFormLabel;
    }
}