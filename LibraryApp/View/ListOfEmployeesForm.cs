using LibraryApp.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace LibraryApp.View
{
    public partial class ListOfEmployeesForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private List<ViewEmployeesModel> employeesList = new();

        public ListOfEmployeesForm()
        {
            InitializeComponent();

            ViewEmployeesTable();
        }
        private void ListOfEmployeesCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ListOfEmployeesCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            listOfEmployeesCloseLabel.Text = "x";
            listOfEmployeesCloseLabel.ForeColor = Color.Red;
        }

        private void ListOfEmployeesCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            listOfEmployeesCloseLabel.Text = "-";
            listOfEmployeesCloseLabel.ForeColor = Color.Black;
        }

        // получаем список сотрудников и заполняем employeesList
        private void GetEmployees()
        {
            employeesList.Clear();

            string query = "SELECT p.Id, p.Lastname, p.Firstname, p.Surname, (SELECT Post FROM Posts WHERE e.PostId = Id), e.PersonnelNumber, p.DateOfBirth, e.IsActive " +
                           "FROM Employees e " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = e.PersonId " +
                           "ORDER BY p.Lastname";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeesList.Add(new ViewEmployeesModel
                    {
                        Id = reader.GetInt32(0),
                        Lastname = reader.GetString(1),
                        Firstname = reader.GetString(2),
                        Surname = reader.GetString(3),
                        Post = reader.GetString(4),
                        PersonnelNumber = reader.GetInt32(5),
                        DateOfBirth = reader.GetString(6),
                        IsActive = reader.GetString(7) == "1" ? "действующий" : "уволен"
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список сотрудников:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // заполняем таблицу из employeesList
        private void ViewEmployeesTable()
        {
            GetEmployees();

            employeesTable.DataSource = employeesList;

            employeesTable.Columns[0].Visible = false;
            employeesTable.Columns[1].HeaderText = "Фамилия";
            employeesTable.Columns[2].HeaderText = "Имя";
            employeesTable.Columns[3].HeaderText = "Отчество";
            employeesTable.Columns[4].HeaderText = "Должность";
            employeesTable.Columns[5].HeaderText = "Табельный номер";
            employeesTable.Columns[6].HeaderText = "Дата рождения";
            employeesTable.Columns[7].HeaderText = "Релевантность";
        }

        // проводим фильтрацию из TextBox
        private void FilterTextChanged(object sender, EventArgs e)
        {
            List<ViewEmployeesModel> filteredList = new();

            if (listOfEmployeesFilterBox.Text == "")
            {
                employeesTable.DataSource = employeesList;
            }
            else
            {
                // по фамилии
                if (listOfEmployeesLastNameFilterRadioButton.Checked)
                {
                    filteredList = employeesList.Where(x => x.Lastname.StartsWith(listOfEmployeesFilterBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    employeesTable.DataSource = filteredList;
                }
                // по должности
                else if(listOfEmployeesPostFilterRadioButton.Checked)
                {
                    filteredList = employeesList.Where(x => x.Post.StartsWith(listOfEmployeesFilterBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                    employeesTable.DataSource = filteredList;
                }
                // по табельному номеру
                else if(listOfEmployeesPersonnelNumberFilterRadioButton.Checked)
                {
                    filteredList = employeesList.Where(x => x.PersonnelNumber.ToString().Contains(listOfEmployeesFilterBox.Text)).ToList();
                    employeesTable.DataSource = filteredList;
                }
            }
        } 
    
        #region Move the Form
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

        #endregion
    }


}

