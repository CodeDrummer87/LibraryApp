using System.Windows.Forms;

namespace LibraryApp.View
{
    partial class ListOfPostsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfPostsForm));
            listOfPostsFormName = new Label();
            postsTable = new DataGridView();
            listOfPostsCloseLabel = new Label();
            changePostButton = new Button();
            deletePostButton = new Button();
            listOfPostsEditModeCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)postsTable).BeginInit();
            SuspendLayout();
            // 
            // listOfPostsFormName
            // 
            listOfPostsFormName.AutoSize = true;
            listOfPostsFormName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            listOfPostsFormName.ForeColor = Color.Black;
            listOfPostsFormName.Location = new Point(28, 27);
            listOfPostsFormName.Name = "listOfPostsFormName";
            listOfPostsFormName.Size = new Size(189, 25);
            listOfPostsFormName.TabIndex = 0;
            listOfPostsFormName.Text = "Список должностей";
            // 
            // postsTable
            // 
            postsTable.AllowDrop = true;
            postsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            postsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            postsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            postsTable.BackgroundColor = SystemColors.Control;
            postsTable.BorderStyle = BorderStyle.None;
            postsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            postsTable.Location = new Point(33, 68);
            postsTable.Name = "postsTable";
            postsTable.RowHeadersVisible = false;
            postsTable.RowTemplate.Height = 25;
            postsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            postsTable.Size = new Size(423, 269);
            postsTable.TabIndex = 1;
            postsTable.SelectionChanged += PostTableSelectionChanged;
            postsTable.MouseUp += PostTableMouseUp;
            // 
            // listOfPostsCloseLabel
            // 
            listOfPostsCloseLabel.AutoSize = true;
            listOfPostsCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            listOfPostsCloseLabel.ForeColor = Color.Black;
            listOfPostsCloseLabel.Location = new Point(450, 19);
            listOfPostsCloseLabel.Name = "listOfPostsCloseLabel";
            listOfPostsCloseLabel.Size = new Size(21, 19);
            listOfPostsCloseLabel.TabIndex = 2;
            listOfPostsCloseLabel.Text = "-";
            listOfPostsCloseLabel.Click += ListOfPostsCloseLabelCloseLabel_Click;
            listOfPostsCloseLabel.MouseEnter += ListOfPostsCloseLabelCloseLabel_MouseEnter;
            listOfPostsCloseLabel.MouseLeave += ListOfPostsCloseLabelCloseLabel_MouseLeave;
            // 
            // changePostButton
            // 
            changePostButton.Enabled = false;
            changePostButton.Location = new Point(33, 372);
            changePostButton.Name = "changePostButton";
            changePostButton.Size = new Size(75, 23);
            changePostButton.TabIndex = 3;
            changePostButton.Text = "Изменить";
            changePostButton.UseVisualStyleBackColor = true;
            changePostButton.Click += ChangePostButton_CLick;
            // 
            // deletePostButton
            // 
            deletePostButton.Enabled = false;
            deletePostButton.Location = new Point(127, 372);
            deletePostButton.Name = "deletePostButton";
            deletePostButton.Size = new Size(75, 23);
            deletePostButton.TabIndex = 4;
            deletePostButton.Text = "Удалить";
            deletePostButton.UseVisualStyleBackColor = true;
            deletePostButton.Click += DeletePostButton_Click;
            // 
            // listOfPostsEditModeCheckBox
            // 
            listOfPostsEditModeCheckBox.AutoSize = true;
            listOfPostsEditModeCheckBox.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            listOfPostsEditModeCheckBox.ForeColor = Color.MidnightBlue;
            listOfPostsEditModeCheckBox.Location = new Point(243, 374);
            listOfPostsEditModeCheckBox.Name = "listOfPostsEditModeCheckBox";
            listOfPostsEditModeCheckBox.Size = new Size(143, 21);
            listOfPostsEditModeCheckBox.TabIndex = 5;
            listOfPostsEditModeCheckBox.Text = "Режим изменения";
            listOfPostsEditModeCheckBox.UseVisualStyleBackColor = true;
            listOfPostsEditModeCheckBox.CheckedChanged += EditModeChanged;
            // 
            // ListOfPostsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 430);
            Controls.Add(listOfPostsEditModeCheckBox);
            Controls.Add(deletePostButton);
            Controls.Add(changePostButton);
            Controls.Add(listOfPostsCloseLabel);
            Controls.Add(postsTable);
            Controls.Add(listOfPostsFormName);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(490, 430);
            MinimumSize = new Size(490, 430);
            Name = "ListOfPostsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список должностей";
            Load += EditModeChanged;
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)postsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label listOfPostsFormName;
        private DataGridView postsTable;
        private Label listOfPostsCloseLabel;
        private Button changePostButton;
        private Button deletePostButton;
        private CheckBox listOfPostsEditModeCheckBox;
    }
}