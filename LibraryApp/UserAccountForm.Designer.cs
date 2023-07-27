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
            SuspendLayout();
            // 
            // currentDateLabel
            // 
            currentDateLabel.AutoSize = true;
            currentDateLabel.Location = new Point(12, 9);
            currentDateLabel.Name = "currentDateLabel";
            currentDateLabel.Size = new Size(97, 15);
            currentDateLabel.TabIndex = 0;
            currentDateLabel.Text = "currentDateLabel";
            // 
            // UserAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(currentDateLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserAccountForm";
            Text = "Личный кабинет пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label currentDateLabel;
    }
}