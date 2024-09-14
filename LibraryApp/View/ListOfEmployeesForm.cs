using LibraryApp.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace LibraryApp.View
{
    public partial class ListOfEmployeesForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates
        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private List<ViewEmployeesModel> employeesList = new(); // list of all employees
        private List<ViewEmployeesModel> activeList = new(); // list of current employees only
        private List<ViewEmployeesModel> filteredList = new(); // list of employees filtered by parameters

        private List<ViewBirthdayModel> birthdayList = new(); // list of birthdays

        public ListOfEmployeesForm()
        {
            InitializeComponent();

            ViewEmployeesTable(); // fill in the table

            GetBirthdays(); // get birthdays
        }

        #region Window control buttons
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

        #endregion

        // get a list of all employees and fill in the employeesList
        private void GetEmployees()
        {
            employeesList.Clear();

            string query = "SELECT p.Id, p.Lastname, p.Firstname, p.Surname, " +
                           "(SELECT Post FROM Posts WHERE e.PostId = Id), e.PersonnelNumber, p.DateOfBirth, e.IsActive " +
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
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // by default fill the table from activeList, which contains only active employees
        private void ViewEmployeesTable()
        {
            GetEmployees();

            // activeList is a filtered employeesList
            activeList = employeesList.Where(x => x.IsActive.ToString().Contains("действующий")).ToList();

            employeesTable.DataSource = activeList; // table data source - activeList

            employeesTable.Columns[0].Visible = false;
            employeesTable.Columns[1].HeaderText = "Фамилия";
            employeesTable.Columns[2].HeaderText = "Имя";
            employeesTable.Columns[3].HeaderText = "Отчество";
            employeesTable.Columns[4].HeaderText = "Должность";
            employeesTable.Columns[5].HeaderText = "Табельный номер";
            employeesTable.Columns[6].HeaderText = "Дата рождения";
            employeesTable.Columns[7].HeaderText = "Релевантность";

            // read only table
            foreach (DataGridViewBand column in employeesTable.Columns)
            {
                column.ReadOnly = true;
            }
            employeesTable.ClearSelection();
        }

        // switch the source of filling the table using the checkbox (either current or all employees)
        private void FilterIsActiveChanged(object sender, EventArgs e)
        {
            employeesTable.DataSource = listOfEmployeesIsActiveCheckBox.Checked ? activeList : employeesList;
        }

        // filter from TextBox
        private void FilterTextChanged(object sender, EventArgs e)
        {
            // if the search field is empty and the checkbox is not checked
            if (listOfEmployeesFilterBox.Text.Equals(String.Empty) && !listOfEmployeesIsActiveCheckBox.Checked)
            {
                employeesTable.DataSource = employeesList;
            }
            // if the search field is filled, then we filter
            else
            {
                // by last name
                if (listOfEmployeesLastNameFilterRadioButton.Checked && listOfEmployeesIsActiveCheckBox.Checked)
                {
                    filteredList = activeList.Where(x => x.Lastname.StartsWith(listOfEmployeesFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    employeesTable.DataSource = filteredList;
                }
                else if (listOfEmployeesLastNameFilterRadioButton.Checked && !listOfEmployeesIsActiveCheckBox.Checked)
                {
                    filteredList = employeesList.Where(x => x.Lastname.StartsWith(listOfEmployeesFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    employeesTable.DataSource = filteredList;
                }

                // by post
                if (listOfEmployeesPostFilterRadioButton.Checked && listOfEmployeesIsActiveCheckBox.Checked)
                {
                    filteredList = activeList.Where(x => x.Post.StartsWith(listOfEmployeesFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    employeesTable.DataSource = filteredList;
                }
                else if (listOfEmployeesPostFilterRadioButton.Checked && !listOfEmployeesIsActiveCheckBox.Checked)
                {
                    filteredList = employeesList.Where(x => x.Post.StartsWith(listOfEmployeesFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    employeesTable.DataSource = filteredList;
                }

                // by personnel number
                if (listOfEmployeesPersonnelNumberFilterRadioButton.Checked && listOfEmployeesIsActiveCheckBox.Checked)
                {
                    filteredList = activeList.Where(x => x.PersonnelNumber.ToString().Contains(listOfEmployeesFilterBox.Text.Trim())).ToList();
                    employeesTable.DataSource = filteredList;
                }
                else if (listOfEmployeesPersonnelNumberFilterRadioButton.Checked && !listOfEmployeesIsActiveCheckBox.Checked)
                {
                    filteredList = employeesList.Where(x => x.PersonnelNumber.ToString().Contains(listOfEmployeesFilterBox.Text.Trim())).ToList();
                    employeesTable.DataSource = filteredList;
                }
            }
        }

        // get birthdays of current employees
        private void GetBirthdays()
        {
            string query = "SELECT p.Id, p.Lastname, p.Firstname, p.Surname, p.DateOfBirth " +
                           "FROM Employees e " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = e.PersonId " +
                           "WHERE IsActive = 1 " +
                           "ORDER BY p.Lastname";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    birthdayList.Add(new ViewBirthdayModel
                    {
                        Id = reader.GetInt32(0),
                        Lastname = reader.GetString(1),
                        Firstname = reader.GetString(2),
                        Surname = reader.GetString(3),
                        DateOfBirth = reader.GetString(4)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список дней рождения:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // display birthdays in ListBox by specified range
        private void ShowBirthdays(object sender, EventArgs e)
        {
            listOfEmployeesBirthdayListBox.Items.Clear();

            var current = DateTime.Today;

            foreach (ViewBirthdayModel item in birthdayList)
            {
                var date = Convert.ToDateTime(item.DateOfBirth);
                var year = current.Month > date.Month || current.Month == date.Month && current.Day > date.Day ? current.Year + 1 : current.Year;
                var days = (new DateTime(year, date.Month, date.Day) - current).TotalDays;

                // in 3 days
                if (listOfEmployeesBirthdayThreeFilterRadioButton.Checked)
                {
                    if (days == 4)
                    {
                        listOfEmployeesBirthdayListBox.Items.Add(Convert.ToString(item.Lastname + " " 
                        + item.Firstname.Substring(0, 1) + "." + item.Surname.Substring(0, 1) + "."));
                    }
                }

                // in 2 days
                else if (listOfEmployeesBirthdayTwoFilterRadioButton.Checked)
                {
                    if (days == 3)
                    {
                        listOfEmployeesBirthdayListBox.Items.Add(Convert.ToString(item.Lastname + " " 
                        + item.Firstname.Substring(0, 1) + "." + item.Surname.Substring(0, 1) + "."));
                    }
                }

                // in 1 day
                else if (listOfEmployeesBirthdayOneFilterRadioButton.Checked)
                {
                    if (days == 2)
                    {
                        listOfEmployeesBirthdayListBox.Items.Add(Convert.ToString(item.Lastname + " " 
                        + item.Firstname.Substring(0, 1) + "." + item.Surname.Substring(0, 1) + "."));
                    }
                }
            }

            // if there are no suitable dates and nothing has been added to the ListBox, then we display "no"
            if (listOfEmployeesBirthdayListBox.Items.Count == 0)
            {
                listOfEmployeesBirthdayListBox.Items.Add("(нет)");
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
