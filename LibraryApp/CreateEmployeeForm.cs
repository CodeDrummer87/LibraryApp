using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class CreateEmployeeForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        public CreateEmployeeForm()
        {
            InitializeComponent();

            // Для автозаполнения поля "Должность"
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
            {
                "Библиотекарь",
                "Методист",
                "Библиограф"
            };

            createEmployeePostInputBox.AutoCompleteCustomSource = source;
            createEmployeePostInputBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            createEmployeePostInputBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CreateEmployeeCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateEmployeeCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            createEmployeeCloseLabel.ForeColor = Color.Red;
        }

        private void CreateEmployeeCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            createEmployeeCloseLabel.ForeColor = Color.Black;
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            CreateEmployee();
        }

        private void ClearFormButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        public void CreateEmployee()
        {
            try
            {
                SqliteCommand command = new SqliteCommand();
                command = DataBase.GetConnection().CreateCommand();
                DataBase.OpenConnection();

                command.CommandText = "INSERT INTO Persons (Firstname, Lastname, Surname, DateOfBirth) " +
                                      "VALUES (@Firstname, @Lastname, @Surname, @DateOfBirth); " +
                                      "INSERT INTO Employees (PersonId, PersonnelNumber, PostId) " +
                                      "SELECT Persons.Id, @PersonnelNumber, (SELECT Id FROM Posts WHERE Post = @PostId) FROM Persons " +
                                      "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); " +
                                      "INSERT INTO Accounts (LoginId, Login, Password) SELECT Persons.Id, @Login, @Password FROM Persons " +
                                      "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); ";

                command.Parameters.AddWithValue("@Firstname", createEmployeeFirstNameInputBox.Text);
                command.Parameters.AddWithValue("@Lastname", createEmployeeLastNameInputBox.Text);
                command.Parameters.AddWithValue("@Surname", createEmployeeSurNameInputBox.Text);
                command.Parameters.AddWithValue("@DateOfBirth", createEmployeeDateOfBirthInputBox.Text);
                command.Parameters.AddWithValue("@PersonnelNumber", createEmployeePersonnelNumberBox.Text);
                command.Parameters.AddWithValue("@PostId", createEmployeePostInputBox.Text);
                command.Parameters.AddWithValue("@Login", createEmployeeLoginInputBox.Text);
                command.Parameters.AddWithValue("@Password", createEmployeePasswordInputBox.Text);
                command.ExecuteNonQuery();

                MessageBox.Show($"Сотрудник с табельным номером {createEmployeePersonnelNumberBox.Text} создан", 
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать сотрудника:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            ClearForm();
        }

        private void ClearForm()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = string.Empty;
            }
            createEmployeeLastNameInputBox.Focus();
        }

        private void ThisForm_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }

        private void ThisForm_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));
        }
    }
}
