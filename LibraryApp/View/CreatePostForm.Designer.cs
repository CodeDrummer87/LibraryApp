namespace LibraryApp.View
{
    partial class CreatePostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePostForm));
            CreatePostFormName = new Label();
            createPostNewPostBox = new TextBox();
            createPostNameOfPostLabel = new Label();
            createPostIsActiveCheckBox = new CheckBox();
            createPostButton = new Button();
            ClearFormButton = new Button();
            createPostCloseLabel = new Label();
            SuspendLayout();
            // 
            // CreatePostFormName
            // 
            CreatePostFormName.AutoSize = true;
            CreatePostFormName.BackColor = Color.Transparent;
            CreatePostFormName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreatePostFormName.ForeColor = Color.Black;
            CreatePostFormName.Location = new Point(37, 32);
            CreatePostFormName.Name = "CreatePostFormName";
            CreatePostFormName.Size = new Size(249, 25);
            CreatePostFormName.TabIndex = 0;
            CreatePostFormName.Text = "Создать новую должность";
            // 
            // createPostNewPostBox
            // 
            createPostNewPostBox.Location = new Point(41, 110);
            createPostNewPostBox.Name = "createPostNewPostBox";
            createPostNewPostBox.Size = new Size(196, 23);
            createPostNewPostBox.TabIndex = 1;
            // 
            // createPostNameOfPostLabel
            // 
            createPostNameOfPostLabel.AutoSize = true;
            createPostNameOfPostLabel.BackColor = Color.Transparent;
            createPostNameOfPostLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            createPostNameOfPostLabel.ForeColor = Color.MidnightBlue;
            createPostNameOfPostLabel.Location = new Point(41, 90);
            createPostNameOfPostLabel.Name = "createPostNameOfPostLabel";
            createPostNameOfPostLabel.Size = new Size(141, 17);
            createPostNameOfPostLabel.TabIndex = 2;
            createPostNameOfPostLabel.Text = "Название должности";
            // 
            // createPostIsActiveCheckBox
            // 
            createPostIsActiveCheckBox.AutoSize = true;
            createPostIsActiveCheckBox.BackColor = Color.Transparent;
            createPostIsActiveCheckBox.Checked = true;
            createPostIsActiveCheckBox.CheckState = CheckState.Checked;
            createPostIsActiveCheckBox.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            createPostIsActiveCheckBox.ForeColor = Color.MidnightBlue;
            createPostIsActiveCheckBox.Location = new Point(259, 113);
            createPostIsActiveCheckBox.Name = "createPostIsActiveCheckBox";
            createPostIsActiveCheckBox.Size = new Size(86, 21);
            createPostIsActiveCheckBox.TabIndex = 3;
            createPostIsActiveCheckBox.Text = "Активная";
            createPostIsActiveCheckBox.UseVisualStyleBackColor = false;
            // 
            // createPostButton
            // 
            createPostButton.Location = new Point(41, 164);
            createPostButton.Name = "createPostButton";
            createPostButton.Size = new Size(75, 23);
            createPostButton.TabIndex = 4;
            createPostButton.Text = "Создать";
            createPostButton.UseVisualStyleBackColor = true;
            createPostButton.Click += CreatePostButton_Click;
            // 
            // ClearFormButton
            // 
            ClearFormButton.Location = new Point(133, 164);
            ClearFormButton.Name = "ClearFormButton";
            ClearFormButton.Size = new Size(75, 23);
            ClearFormButton.TabIndex = 5;
            ClearFormButton.Text = "Очистить";
            ClearFormButton.UseVisualStyleBackColor = true;
            ClearFormButton.Click += ClearFormButton_Click;
            // 
            // createPostCloseLabel
            // 
            createPostCloseLabel.AutoSize = true;
            createPostCloseLabel.BackColor = Color.Transparent;
            createPostCloseLabel.Cursor = Cursors.Hand;
            createPostCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            createPostCloseLabel.ForeColor = Color.White;
            createPostCloseLabel.Location = new Point(450, 15);
            createPostCloseLabel.Name = "createPostCloseLabel";
            createPostCloseLabel.Size = new Size(21, 19);
            createPostCloseLabel.TabIndex = 6;
            createPostCloseLabel.Text = "-";
            createPostCloseLabel.Click += CreatePostCloseLabel_Click;
            createPostCloseLabel.MouseEnter += CreatePostCloseLabel_MouseEnter;
            createPostCloseLabel.MouseLeave += CreatePostCloseLabel_MouseLeave;
            // 
            // CreatePostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(480, 340);
            Controls.Add(createPostCloseLabel);
            Controls.Add(ClearFormButton);
            Controls.Add(createPostButton);
            Controls.Add(createPostIsActiveCheckBox);
            Controls.Add(createPostNameOfPostLabel);
            Controls.Add(createPostNewPostBox);
            Controls.Add(CreatePostFormName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(480, 340);
            MinimumSize = new Size(480, 340);
            Name = "CreatePostForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создать новую должность";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CreatePostFormName;
        private TextBox createPostNewPostBox;
        private Label createPostNameOfPostLabel;
        private CheckBox createPostIsActiveCheckBox;
        private Button createPostButton;
        private Button ClearFormButton;
        private Label createPostCloseLabel;
    }
}