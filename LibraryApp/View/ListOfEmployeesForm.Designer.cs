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
            listOfEmployeesFilterGroupBox = new GroupBox();
            listOfEmployeesIsActiveCheckBox = new CheckBox();
            listOfEmployeesFilterBox = new TextBox();
            listOfEmployeesPersonnelNumberFilterRadioButton = new RadioButton();
            listOfEmployeesPostFilterRadioButton = new RadioButton();
            listOfEmployeesLastNameFilterRadioButton = new RadioButton();
            listOfEmployeesBirthdayGroupBox = new GroupBox();
            listOfEmployeesBirthdayListBox = new ListBox();
            listOfEmployeesBirthdayOneFilterRadioButton = new RadioButton();
            listOfEmployeesBirthdayTwoFilterRadioButton = new RadioButton();
            listOfEmployeesBirthdayThreeFilterRadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)employeesTable).BeginInit();
            listOfEmployeesFilterGroupBox.SuspendLayout();
            listOfEmployeesBirthdayGroupBox.SuspendLayout();
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
            // listOfEmployeesFilterGroupBox
            // 
            listOfEmployeesFilterGroupBox.Controls.Add(listOfEmployeesIsActiveCheckBox);
            listOfEmployeesFilterGroupBox.Controls.Add(listOfEmployeesFilterBox);
            listOfEmployeesFilterGroupBox.Controls.Add(listOfEmployeesPersonnelNumberFilterRadioButton);
            listOfEmployeesFilterGroupBox.Controls.Add(listOfEmployeesPostFilterRadioButton);
            listOfEmployeesFilterGroupBox.Controls.Add(listOfEmployeesLastNameFilterRadioButton);
            listOfEmployeesFilterGroupBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            listOfEmployeesFilterGroupBox.ForeColor = Color.MidnightBlue;
            listOfEmployeesFilterGroupBox.Location = new Point(794, 65);
            listOfEmployeesFilterGroupBox.Name = "listOfEmployeesFilterGroupBox";
            listOfEmployeesFilterGroupBox.Size = new Size(211, 210);
            listOfEmployeesFilterGroupBox.TabIndex = 3;
            listOfEmployeesFilterGroupBox.TabStop = false;
            listOfEmployeesFilterGroupBox.Text = "Фильтрация";
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
            // listOfEmployeesBirthdayGroupBox
            // 
            listOfEmployeesBirthdayGroupBox.Controls.Add(listOfEmployeesBirthdayListBox);
            listOfEmployeesBirthdayGroupBox.Controls.Add(listOfEmployeesBirthdayOneFilterRadioButton);
            listOfEmployeesBirthdayGroupBox.Controls.Add(listOfEmployeesBirthdayTwoFilterRadioButton);
            listOfEmployeesBirthdayGroupBox.Controls.Add(listOfEmployeesBirthdayThreeFilterRadioButton);
            listOfEmployeesBirthdayGroupBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            listOfEmployeesBirthdayGroupBox.ForeColor = Color.MidnightBlue;
            listOfEmployeesBirthdayGroupBox.Location = new Point(794, 290);
            listOfEmployeesBirthdayGroupBox.Name = "listOfEmployeesBirthdayGroupBox";
            listOfEmployeesBirthdayGroupBox.Size = new Size(211, 276);
            listOfEmployeesBirthdayGroupBox.TabIndex = 4;
            listOfEmployeesBirthdayGroupBox.TabStop = false;
            listOfEmployeesBirthdayGroupBox.Text = "День рождения";
            // 
            // listOfEmployeesBirthdayListBox
            // 
            listOfEmployeesBirthdayListBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesBirthdayListBox.FormattingEnabled = true;
            listOfEmployeesBirthdayListBox.ItemHeight = 17;
            listOfEmployeesBirthdayListBox.Items.AddRange(new object[] { "(не выбрано)" });
            listOfEmployeesBirthdayListBox.Location = new Point(12, 129);
            listOfEmployeesBirthdayListBox.Name = "listOfEmployeesBirthdayListBox";
            listOfEmployeesBirthdayListBox.Size = new Size(183, 123);
            listOfEmployeesBirthdayListBox.TabIndex = 3;
            // 
            // listOfEmployeesBirthdayOneFilterRadioButton
            // 
            listOfEmployeesBirthdayOneFilterRadioButton.AutoSize = true;
            listOfEmployeesBirthdayOneFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesBirthdayOneFilterRadioButton.ForeColor = Color.Black;
            listOfEmployeesBirthdayOneFilterRadioButton.Location = new Point(12, 89);
            listOfEmployeesBirthdayOneFilterRadioButton.Name = "listOfEmployeesBirthdayOneFilterRadioButton";
            listOfEmployeesBirthdayOneFilterRadioButton.Size = new Size(104, 21);
            listOfEmployeesBirthdayOneFilterRadioButton.TabIndex = 2;
            listOfEmployeesBirthdayOneFilterRadioButton.Text = "через 1 день";
            listOfEmployeesBirthdayOneFilterRadioButton.UseVisualStyleBackColor = true;
            listOfEmployeesBirthdayOneFilterRadioButton.CheckedChanged += ShowBirthdays;
            // 
            // listOfEmployeesBirthdayTwoFilterRadioButton
            // 
            listOfEmployeesBirthdayTwoFilterRadioButton.AutoSize = true;
            listOfEmployeesBirthdayTwoFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesBirthdayTwoFilterRadioButton.ForeColor = Color.Black;
            listOfEmployeesBirthdayTwoFilterRadioButton.Location = new Point(12, 62);
            listOfEmployeesBirthdayTwoFilterRadioButton.Name = "listOfEmployeesBirthdayTwoFilterRadioButton";
            listOfEmployeesBirthdayTwoFilterRadioButton.Size = new Size(97, 21);
            listOfEmployeesBirthdayTwoFilterRadioButton.TabIndex = 1;
            listOfEmployeesBirthdayTwoFilterRadioButton.Text = "через 2 дня";
            listOfEmployeesBirthdayTwoFilterRadioButton.UseVisualStyleBackColor = true;
            listOfEmployeesBirthdayTwoFilterRadioButton.CheckedChanged += ShowBirthdays;
            // 
            // listOfEmployeesBirthdayThreeFilterRadioButton
            // 
            listOfEmployeesBirthdayThreeFilterRadioButton.AutoSize = true;
            listOfEmployeesBirthdayThreeFilterRadioButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listOfEmployeesBirthdayThreeFilterRadioButton.ForeColor = Color.Black;
            listOfEmployeesBirthdayThreeFilterRadioButton.Location = new Point(12, 35);
            listOfEmployeesBirthdayThreeFilterRadioButton.Name = "listOfEmployeesBirthdayThreeFilterRadioButton";
            listOfEmployeesBirthdayThreeFilterRadioButton.Size = new Size(97, 21);
            listOfEmployeesBirthdayThreeFilterRadioButton.TabIndex = 0;
            listOfEmployeesBirthdayThreeFilterRadioButton.Text = "через 3 дня";
            listOfEmployeesBirthdayThreeFilterRadioButton.UseVisualStyleBackColor = true;
            listOfEmployeesBirthdayThreeFilterRadioButton.CheckedChanged += ShowBirthdays;
            // 
            // ListOfEmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 610);
            Controls.Add(listOfEmployeesBirthdayGroupBox);
            Controls.Add(listOfEmployeesFilterGroupBox);
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
            listOfEmployeesFilterGroupBox.ResumeLayout(false);
            listOfEmployeesFilterGroupBox.PerformLayout();
            listOfEmployeesBirthdayGroupBox.ResumeLayout(false);
            listOfEmployeesBirthdayGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label listOfEmployeesFormName;
        private Label listOfEmployeesCloseLabel;
        private DataGridView employeesTable;
        private GroupBox listOfEmployeesFilterGroupBox;
        private RadioButton listOfEmployeesLastNameFilterRadioButton;
        private TextBox listOfEmployeesFilterBox;
        private RadioButton listOfEmployeesPersonnelNumberFilterRadioButton;
        private RadioButton listOfEmployeesPostFilterRadioButton;
        private CheckBox listOfEmployeesIsActiveCheckBox;
        private GroupBox listOfEmployeesBirthdayGroupBox;
        private RadioButton listOfEmployeesBirthdayTwoFilterRadioButton;
        private RadioButton listOfEmployeesBirthdayThreeFilterRadioButton;
        private RadioButton listOfEmployeesBirthdayOneFilterRadioButton;
        private ListBox listOfEmployeesBirthdayListBox;
    }
}