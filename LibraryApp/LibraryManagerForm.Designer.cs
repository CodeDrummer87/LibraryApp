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
            archiveEmployeeButton = new Button();
            libraryManagerCloseLabel = new Label();
            timeWorkedButton = new Button();
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
            createEmployeeButton.Location = new Point(54, 100);
            createEmployeeButton.Name = "createEmployeeButton";
            createEmployeeButton.Size = new Size(166, 23);
            createEmployeeButton.TabIndex = 1;
            createEmployeeButton.Text = "Создать сотрудника";
            createEmployeeButton.UseVisualStyleBackColor = true;
            createEmployeeButton.Click += CreateEmployeeButton_Click;
            // 
            // archiveEmployeeButton
            // 
            archiveEmployeeButton.Location = new Point(54, 129);
            archiveEmployeeButton.Name = "archiveEmployeeButton";
            archiveEmployeeButton.Size = new Size(166, 23);
            archiveEmployeeButton.TabIndex = 2;
            archiveEmployeeButton.Text = "Архивировать сотрудника";
            archiveEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // libraryManagerCloseLabel
            // 
            libraryManagerCloseLabel.AutoSize = true;
            libraryManagerCloseLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            libraryManagerCloseLabel.Location = new Point(764, 13);
            libraryManagerCloseLabel.Name = "libraryManagerCloseLabel";
            libraryManagerCloseLabel.Size = new Size(20, 21);
            libraryManagerCloseLabel.TabIndex = 3;
            libraryManagerCloseLabel.Text = "X";
            libraryManagerCloseLabel.Click += LibraryManagerCloseLabel_Click;
            libraryManagerCloseLabel.MouseEnter += LibraryManagerCloseLabel_MouseEnter;
            libraryManagerCloseLabel.MouseLeave += LibraryManagerCloseLabel_MouseLeave;
            // 
            // timeWorkedButton
            // 
            timeWorkedButton.Location = new Point(54, 158);
            timeWorkedButton.Name = "timeWorkedButton";
            timeWorkedButton.Size = new Size(166, 23);
            timeWorkedButton.TabIndex = 4;
            timeWorkedButton.Text = "Отработанное время";
            timeWorkedButton.UseVisualStyleBackColor = true;
            // 
            // LibraryManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(timeWorkedButton);
            Controls.Add(libraryManagerCloseLabel);
            Controls.Add(archiveEmployeeButton);
            Controls.Add(createEmployeeButton);
            Controls.Add(LibraryManagerName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LibraryManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LibraryManagerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LibraryManagerName;
        private Button createEmployeeButton;
        private Button archiveEmployeeButton;
        private Label libraryManagerCloseLabel;
        private Button timeWorkedButton;
    }
}