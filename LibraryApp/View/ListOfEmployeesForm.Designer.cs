namespace LibraryApp.View
{
    partial class ListOfEmployeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfEmployeesForm));
            listOfEmployeesFormName = new Label();
            listOfEmployeesCloseLabel = new Label();
            employeesTable = new DataGridView();
            listOfEmployeesGroupBox = new GroupBox();
            listOfEmployeesIsActiveCheckBox = new CheckBox();
            listOfEmployeesFilterBox = new TextBox();
            listOfEmployeesPersonnelNumberFilterRadioButton = new RadioButton();
            listOfEmployeesPostFilterRadioButton = new RadioButton();
            listOfEmployeesLastNameFilterRadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)employeesTable).BeginInit();
            listOfEmployeesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // listOfEmployeesFormName
            // 
            listOfEmployeesFormName.AutoSize = true;
            listOfEmployeesFormName.BackColor = Color.Transparent;
            listOfEmployeesFormName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            listOfEmployeesFormName.ForeColor = Color.Black;
            listOfEmployeesFormName.Location = new Point(39, 32);
            listOfEmployeesFormName.Name = "listOfEmployeesFormName";
            listOfEmployeesFormName.Size = new Size(194, 25);
            listOfEmployeesFormName.TabIndex = 0;
            listOfEmployeesFormName.Text = "Список сотрудников";
            // 
            // listOfEmployeesCloseLabel
            // 
            listOfEmployeesCloseLabel.AutoSize = true;
            listOfEmployeesCloseLabel.Font = new Font("Lucida Console", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            listOfEmployeesCloseLabel.ForeColor = Color.Black;
            listOfEmployeesCloseLabel.Location = new Point(1014, 13);
            listOfEmployeesCloseLabel.Name = "listOfEmployeesCloseLabel";
            listOfEmployeesCloseLabel.Size = new Size(21, 19);
            listOfEmployeesCloseLabel.TabIndex = 1;
            listOfEmployeesCloseLabel.Text = "-";
            listOfEmployeesCloseLabel.Click += ListOfEmployeesCloseLabel_Click;
            listOfEmployeesCloseLabel.MouseEnter += ListOfEmployeesCloseLabel_MouseEnter;
            listOfEmployeesCloseLabel.MouseLeave += ListOfEmployeesCloseLabel_MouseLeave;
            // 
            // employeesTable
            // 
            employeesTable.AllowUserToAddRows = false;
            employeesTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            employeesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            employeesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeesTable.BackgroundColor = SystemColors.Control;
            employeesTable.BorderStyle = BorderStyle.None;
            employeesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesTable.Location = new Point(47, 69);
            employeesTable.Name = "employeesTable";
            employeesTable.RowHeadersVisible = false;
            employeesTable.RowTemplate.Height = 25;
            employeesTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesTable.Size = new Size(718, 497);
            employeesTable.TabIndex = 2;
            // 
            // listOfEmployeesGroupBox
            // 
            listOfEmployeesGroupBox.Controls.Add(listOfEmployeesIsActiveCheckBox);
            listOfEmployeesGroupBox.Controls.Add(listOfEmployeesFilterBox);
            listOfEmployeesGroupBox.Controls.Add(listOfEmployeesPersonnelNumberFilterRadioButton);
            listOfEmployeesGroupBox.Controls.Add(listOfEmployeesPostFilterRadioButton);
            listOfEmployeesGroupBox.Controls.Add(listOfEmployeesLastNameFilterRadioButton);
            listOfEmployeesGroupBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            listOfEmployeesGroupBox.ForeColor = Color.MidnightBlue;
            listOfEmployeesGroupBox.Location = new Point(794, 65);
            listOfEmployeesGroupBox.Name = "listOfEmployeesGroupBox";
            listOfEmployeesGroupBox.Size = new Size(211, 210);
            listOfEmployeesGroupBox.TabIndex = 3;
            listOfEmployeesGroupBox.TabStop = false;
            listOfEmployeesGroupBox.Text = "Фильтрация";
            // 
            // listOfEmployeesIsActiveCheckBox
            // 
            listOfEmployeesIsActiveCheckBox.AutoSize = true;
            listOfEmployeesIsActiveCheckBox.Checked = true;
            listOfEmployeesIsActiveCheckBox.CheckState = CheckState.Checked;
            listOfEmployeesIsActiveCheckBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesIsActiveCheckBox.ForeColor = Color.MidnightBlue;
            listOfEmployeesIsActiveCheckBox.Location = new Point(30, 164);
            listOfEmployeesIsActiveCheckBox.Name = "listOfEmployeesIsActiveCheckBox";
            listOfEmployeesIsActiveCheckBox.Size = new Size(153, 21);
            listOfEmployeesIsActiveCheckBox.TabIndex = 4;
            listOfEmployeesIsActiveCheckBox.Tag = "";
            listOfEmployeesIsActiveCheckBox.Text = "только действующие";
            listOfEmployeesIsActiveCheckBox.UseVisualStyleBackColor = true;
            listOfEmployeesIsActiveCheckBox.CheckedChanged += FilterIsActiveChanged;
            // 
            // listOfEmployeesFilterBox
            // 
            listOfEmployeesFilterBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesFilterBox.Location = new Point(12, 121);
            listOfEmployeesFilterBox.Name = "listOfEmployeesFilterBox";
            listOfEmployeesFilterBox.Size = new Size(183, 25);
            listOfEmployeesFilterBox.TabIndex = 3;
            listOfEmployeesFilterBox.TextChanged += FilterTextChanged;
            // 
            // listOfEmployeesPersonnelNumberFilterRadioButton
            // 
            listOfEmployeesPersonnelNumberFilterRadioButton.AutoSize = true;
            listOfEmployeesPersonnelNumberFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesPersonnelNumberFilterRadioButton.ForeColor = Color.Black;
            listOfEmployeesPersonnelNumberFilterRadioButton.Location = new Point(12, 85);
            listOfEmployeesPersonnelNumberFilterRadioButton.Name = "listOfEmployeesPersonnelNumberFilterRadioButton";
            listOfEmployeesPersonnelNumberFilterRadioButton.Size = new Size(117, 21);
            listOfEmployeesPersonnelNumberFilterRadioButton.TabIndex = 2;
            listOfEmployeesPersonnelNumberFilterRadioButton.Text = "по таб. номеру";
            listOfEmployeesPersonnelNumberFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // listOfEmployeesPostFilterRadioButton
            // 
            listOfEmployeesPostFilterRadioButton.AutoSize = true;
            listOfEmployeesPostFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesPostFilterRadioButton.ForeColor = Color.Black;
            listOfEmployeesPostFilterRadioButton.Location = new Point(12, 58);
            listOfEmployeesPostFilterRadioButton.Name = "listOfEmployeesPostFilterRadioButton";
            listOfEmployeesPostFilterRadioButton.Size = new Size(109, 21);
            listOfEmployeesPostFilterRadioButton.TabIndex = 1;
            listOfEmployeesPostFilterRadioButton.Text = "по должности";
            listOfEmployeesPostFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // listOfEmployeesLastNameFilterRadioButton
            // 
            listOfEmployeesLastNameFilterRadioButton.AutoSize = true;
            listOfEmployeesLastNameFilterRadioButton.Checked = true;
            listOfEmployeesLastNameFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesLastNameFilterRadioButton.ForeColor = Color.Black;
            listOfEmployeesLastNameFilterRadioButton.Location = new Point(12, 31);
            listOfEmployeesLastNameFilterRadioButton.Name = "listOfEmployeesLastNameFilterRadioButton";
            listOfEmployeesLastNameFilterRadioButton.Size = new Size(98, 21);
            listOfEmployeesLastNameFilterRadioButton.TabIndex = 0;
            listOfEmployeesLastNameFilterRadioButton.TabStop = true;
            listOfEmployeesLastNameFilterRadioButton.Text = "по фамилии";
            listOfEmployeesLastNameFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // ListOfEmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 610);
            Controls.Add(listOfEmployeesGroupBox);
            Controls.Add(employeesTable);
            Controls.Add(listOfEmployeesCloseLabel);
            Controls.Add(listOfEmployeesFormName);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListOfEmployeesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список сотрудников";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)employeesTable).EndInit();
            listOfEmployeesGroupBox.ResumeLayout(false);
            listOfEmployeesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label listOfEmployeesFormName;
        private Label listOfEmployeesCloseLabel;
        private DataGridView employeesTable;
        private GroupBox listOfEmployeesGroupBox;
        private RadioButton listOfEmployeesLastNameFilterRadioButton;
        private TextBox listOfEmployeesFilterBox;
        private RadioButton listOfEmployeesPersonnelNumberFilterRadioButton;
        private RadioButton listOfEmployeesPostFilterRadioButton;
        private CheckBox listOfEmployeesIsActiveCheckBox;
    }
}