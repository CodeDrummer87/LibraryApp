using LibraryApp.Models;
using Microsoft.Data.Sqlite;
using System.ComponentModel;
using System.Data;

namespace LibraryApp.View
{
    public partial class EmployeeAccountForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private StartForm startForm;
        Account account;

        private BindingList<Book> booksList = new(); // list of all books (with binding)
        private List<Book> filteredList = new(); // list of books filtered by parameters

        private ComboBox genresComboBox = new ComboBox(); // genre drop-down list
        private ComboBox isAvailableComboBox = new ComboBox(); // drop-down list of book availability
        private ComboBox statusComboBox = new ComboBox(); // book status drop-down list
        int rowIndex = 0; // index of the row in the drop-down list

        bool flag = false; // flag for the operation of the line selection/deselection method

        public EmployeeAccountForm(StartForm startForm, Account account)
        {
            InitializeComponent();

            ViewBooksTable();
            LoadComboBoxes();

            this.account = account;
            this.startForm = startForm;

            PutCurrentEmployeeName(GetCurrentEmployeeName(account.LoginId));
        }

        #region Window control buttons
        private void EmployeeFormCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
            startForm.Close();
        }

        private void EmployeeFormCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            employeeFormCloseLabel.Text = "x";
            employeeFormCloseLabel.ForeColor = Color.Red;
        }

        private void EmployeeFormCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            employeeFormCloseLabel.Text = "-";
            employeeFormCloseLabel.ForeColor = Color.Black;
        }

        // go to the starting form if we click on the employee's full name and answer "yes"
        private void ExitToStartFormLabel_CLick(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            MessageBoxIcon icn = MessageBoxIcon.Question;
            String message = "Вы действительно хотите выйти?";
            String caption = "Выход";
            if (MessageBox.Show(message, caption, msb, icn) == DialogResult.Yes)
            {
                this.Close();
                startForm.Show();
            }
        }
        private void ExitToStartFormLabel_MouseEnter(object sender, EventArgs e)
        {
            currentEmployeeName.ForeColor = Color.Red;
        }

        private void ExitToStartFormLabel_MouseLeave(object sender, EventArgs e)
        {
            currentEmployeeName.ForeColor = Color.MidnightBlue;
        }

        #endregion

        // display the full name of the current employee
        private void PutCurrentEmployeeName(ViewEmployeeNameModel employeeName)
        {
            currentEmployeeName.Text = $"{employeeName.Lastname} {employeeName.Firstname} {employeeName.Surname}";

            // if the database contains data about the file path, display the profile photo
            if (account.ImagePath is not null)
            {
                employeeFormPictureBox.Image = Image.FromFile(Environment.ExpandEnvironmentVariables(@"%appdata%\LibraryApp") + account.ImagePath);
            }
        }

        // get the full name of the current employee
        public ViewEmployeeNameModel GetCurrentEmployeeName(int loginId)
        {
            ViewEmployeeNameModel employeeNameModel = new();

            string query = "SELECT e.Id, e.PersonId, p.Firstname, p.Lastname, p.Surname " +
                           "FROM Employees e " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = e.PersonId " +
                           "WHERE e.PersonId = @Id;";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@Id", SqliteType.Integer).Value = loginId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeeNameModel = new ViewEmployeeNameModel()
                    {
                        Id = reader.GetInt32(0),
                        PersonId = reader.GetInt32(1),
                        Firstname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        Surname = reader.GetString(4)
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить имя текущего сотрудника:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            DataBase.CloseConnection();

            return employeeNameModel;
        }

        // get a list of books and fill booksList
        private void GetBooks()
        {
            booksList.Clear();

            string query = "SELECT b.Id, b.Title, (SELECT Name FROM Genres WHERE b.GenreId = Id), " +
                           "b.Author, b.AgeLimit, b.ImagePath, b.IsAvailable, b.IsActive " +
                           "FROM Books b " +
                           "ORDER BY Title";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    booksList.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        GenreId = reader.GetString(2),
                        Author = reader.GetString(3),
                        AgeLimit = reader.GetInt32(4),
                        ImagePath = reader.GetString(5),
                        IsAvailable = reader.GetString(6) == "1" ? "в наличии" : "выдана",
                        IsActive = reader.GetString(7) == "1" ? "активная" : "неактивная"
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список книг:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // by default we fill the table from booksList, which contains all books
        private void ViewBooksTable()
        {
            GetBooks();

            booksTable.DataSource = booksList; // table data source
            booksTable.MultiSelect = false; // you can't select more than one line

            booksTable.Columns[0].Visible = false; // do not display column with Id
            booksTable.Columns[5].Visible = false; // we do not display the column with the cover address

            // set the sizes and names of the columns
            booksTable.Columns[1].Width = 500;
            booksTable.Columns[1].HeaderText = "Название";

            booksTable.Columns[2].Width = 180;
            booksTable.Columns[2].HeaderText = "Жанр";

            booksTable.Columns[3].Width = 280;
            booksTable.Columns[3].HeaderText = "Автор";

            booksTable.Columns[4].Width = 100;
            booksTable.Columns[4].HeaderText = "Ограничение по возрасту";

            booksTable.Columns[6].Width = 100;
            booksTable.Columns[6].HeaderText = "Наличие";

            booksTable.Columns[7].Width = 100;
            booksTable.Columns[7].HeaderText = "Статус";
        }

        // when you select a row in the table, it will be highlighted, the "Add", "Save", "Delete" buttons will be active
        private void BooksTableSelectionChanged(object sender, EventArgs e)
        {
            // if the table has rows and the row is selected
            if (booksTable.Rows.Count >= 1 && booksTable.CurrentCell.Selected)
            {
                flag = true;
                booksTable.CurrentCell.Selected = true;

                // if the change mode is off
                if (!EmployeeFormEditModeCheckBox.Checked)
                {
                    // turn off all buttons
                    foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = false; }
                }
                // if the change mode is enabled
                else
                {
                    // turn on all buttons
                    foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = true; }
                }
            }
        }

        // we filter from the search field
        private void FilterTextChanged(object sender, EventArgs e)
        {
            // if the search field is empty
            if (booksFilterBox.Text.Equals(String.Empty))
            {
                // then the table data source is a list with all books booksList
                booksTable.DataSource = booksList;
            }
            // if the search field is filled, then we filter (data source - filteredList)
            else
            {
                // by author
                if (booksAuthorFilterRadioButton.Checked)
                {
                    filteredList = booksList.Where(x => x.Author.Contains(booksFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    booksTable.DataSource = filteredList;
                }

                // by name
                else if (booksNameFilterRadioButton.Checked)
                {
                    filteredList = booksList.Where(x => x.Title.Contains(booksFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    booksTable.DataSource = filteredList;
                }

                // by age restrictions
                else if (booksAgeLimitFilterRadioButton.Checked)
                {
                    filteredList = booksList.Where(x => x.AgeLimit.ToString().Contains(booksFilterBox.Text.Trim())).ToList();
                    booksTable.DataSource = filteredList;
                }
            }
        }

        // by clicking on the checkbox we decide whether it is possible to edit the data about the books
        private void EditModeChanged(object sender, EventArgs e)
        {
            if (EmployeeFormEditModeCheckBox.Checked)
            {
                // turn off read-only lines
                foreach (DataGridViewBand row in booksTable.Rows) { row.ReadOnly = false; }

                // turn on buttons
                foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = true; }
            }
            else
            {
                // enable read-only lines
                foreach (DataGridViewBand row in booksTable.Rows) { row.ReadOnly = true; }

                // turn off drop-down lists
                foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }

                // turn off buttons
                foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = false; }
            }
        }

        // loading drop-down lists into the table
        private void LoadComboBoxes()
        {
            // filling in the list of genres
            LoadGenres();

            // fill the list of book availability
            string[] isAvailableItems = { "в наличии", "выдана" };
            isAvailableComboBox.Items.AddRange(isAvailableItems);
            isAvailableComboBox.SelectedIndex = 0;

            // fill in the book status list
            string[] statusItems = { "активная", "неактивная" };
            statusComboBox.Items.AddRange(statusItems);
            statusComboBox.SelectedIndex = 0;

            // create an event handler (selecting items from a list)
            genresComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged!;
            isAvailableComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged!;
            statusComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged!;

            // add lists to the table
            booksTable.Controls.Add(genresComboBox);
            booksTable.Controls.Add(isAvailableComboBox);
            booksTable.Controls.Add(statusComboBox);
        }

        // fill in the drop-down list of genres from the database
        private void LoadGenres()
        {
            genresComboBox.Items.Clear();
            genresComboBox.ResetText();

            string query = "SELECT * FROM Genres ORDER BY Name";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    genresComboBox.Items.Add(new Genre
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                genresComboBox.DisplayMember = "Name";

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить жанры:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // show drop-down lists when clicking on cells
        private void BooksTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if there are rows in the table
            if (booksTable.Rows.Count >= 1)
            {
                // set the row index
                rowIndex = e.RowIndex;
                if (rowIndex < 0)
                    rowIndex++;

                // get rectangles of cells with lists
                Rectangle genresRectangle = booksTable.GetCellDisplayRectangle(2, rowIndex, true);
                Rectangle availableRectangle = booksTable.GetCellDisplayRectangle(6, rowIndex, true);
                Rectangle statusRectangle = booksTable.GetCellDisplayRectangle(7, rowIndex, true);

                // set the sizes and locations of the lists
                genresComboBox.Size = new Size(genresRectangle.Width, genresRectangle.Height);
                isAvailableComboBox.Size = new Size(availableRectangle.Width, availableRectangle.Height);
                statusComboBox.Size = new Size(statusRectangle.Width, statusRectangle.Height);

                genresComboBox.Location = new Point(genresRectangle.X, genresRectangle.Y);
                isAvailableComboBox.Location = new Point(availableRectangle.X, availableRectangle.Y);
                statusComboBox.Location = new Point(statusRectangle.X, statusRectangle.Y);

                // if editing mode is enabled
                if (EmployeeFormEditModeCheckBox.Checked)
                {
                    // show lists
                    foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = true; }

                    // if we create a new book, we suggest choosing a genre from the list
                    if (booksTable.CurrentRow.Cells[0].Value is null && booksTable.CurrentRow.Cells[2].Value is null)
                    {
                        genresComboBox.Text = "Выберите жанр";
                    }
                    // if we edit an existing book, we show the current values ​​in the lists
                    else
                    {
                        genresComboBox.Text = booksTable.CurrentRow.Cells[2].Value.ToString();
                        isAvailableComboBox.Text = booksTable.CurrentRow.Cells[6].Value.ToString();
                        statusComboBox.Text = booksTable.CurrentRow.Cells[7].Value.ToString();
                    }
                }
                // if editing mode is off
                else
                {
                    // then we don't show the lists
                    foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
                }
            }
        }

        // select a value from the list
        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // save the value in the cell if you haven't finished editing it and switched to the list
            booksTable.EndEdit();

            // enter data into the cell
            booksTable[2, rowIndex].Value = genresComboBox.Text;
            booksTable[6, rowIndex].Value = isAvailableComboBox.Text;
            booksTable[7, rowIndex].Value = statusComboBox.Text;

            // hide the list
            foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
        }

        // get the genre number for recording it in the database in case of editing the genre in the table
        private string GetGenreId()
        {
            string query = "SELECT Id FROM Genres WHERE Name = @Name";
            string name = booksTable.SelectedRows[0].Cells[2].Value.ToString()!;

            command = DataBase.GetConnection().CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@Name", name);

            DataBase.OpenConnection();
            string genreId = Convert.ToString(command.ExecuteScalar())!;

            DataBase.CloseConnection();
            return genreId;
        }

        // check if the value in the cell with age restriction is a number
        private void IsDigit_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // if active cell is age limit
            if (booksTable.CurrentRow.Cells[4] == booksTable.CurrentCell)
            {
                // we get its value
                string ageLimitEditingValue = booksTable.CurrentCell.EditedFormattedValue.ToString()!;

                // and check
                foreach (var item in ageLimitEditingValue)
                {
                    if (!Char.IsDigit(item))
                    {
                        e.Cancel = true;
                        MessageBox.Show($"Ограничение по возрасту может быть только числом",
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }
                }
            }
        }

        // check if all cells are filled in a row when saving data about a book
        private bool CheckIsNullOrWhiteSpace(out int emptyIndex)
        {
            emptyIndex = 0; // by default the index of an empty cell is 0
            bool result = false; // by default the line is considered filled

            for (int i = 1; i < booksTable.ColumnCount; i++)
            {
                // skip the cell with the cover address when checking,
                // because the default address for a new book is written directly to the database, bypassing the table
                if (i == 5)
                    continue;

                // if the cell value is null or contains only spaces
                if (booksTable.CurrentRow.Cells[i].Value is null || string.IsNullOrWhiteSpace(booksTable.CurrentRow.Cells[i].Value.ToString()))
                {
                    // then we return true and then the save method will display an error message
                    result = true;
                    emptyIndex = i; // to which we will pass the index of an empty cell to display the name of the unfilled field
                    break;
                }
            }
            return result;
        }

        // check if there is a similar book in the database
        private bool CheckBookInDataBase()
        {
            string query = "SELECT EXISTS (SELECT * FROM Books WHERE Title = @Title AND Author = @Author)";

            command = DataBase.GetConnection().CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("Title", booksTable.SelectedRows[0].Cells[1].Value.ToString());
            command.Parameters.AddWithValue("Author", booksTable.SelectedRows[0].Cells[3].Value.ToString());

            DataBase.OpenConnection();
            bool answer = Convert.ToBoolean(command.ExecuteScalar());

            DataBase.CloseConnection();
            return answer;
        }

        // save data about the book in a table and a database
        private void SaveBookButton_CLick(object sender, EventArgs e)
        {
            // if the table is empty or no rows are selected, then saving does not work
            if (booksTable.Rows.Count == 0 || booksTable.SelectedRows.Count == 0)
                return;

            int index; // index of unfilled cell

            // if the row has no empty cells
            if (!CheckIsNullOrWhiteSpace(out index))
            {
                // if there is no similar book in the database
                if (!CheckBookInDataBase())
                {
                    // if the saved line does not contain Id, then the book is not yet in the database
                    // we save a new book
                    if (booksTable.CurrentRow.Cells[0].Value is null)
                    {
                        string query = "INSERT INTO Books (Title, GenreId, Author, AgeLimit, ImagePath, IsAvailable, IsActive) " +
                                       "VALUES(@Title, @GenreId, @Author, @AgeLimit, @ImagePath, @IsAvailable, @IsActive)";

                        string genreId = GetGenreId(); // insert genre Id from Genres table of database

                        try
                        {
                            command = DataBase.GetConnection().CreateCommand();
                            command.CommandText = query;
                            command.Parameters.AddWithValue("Title", booksTable.SelectedRows[0].Cells[1].Value.ToString().Trim());
                            command.Parameters.AddWithValue("GenreId", genreId);
                            command.Parameters.AddWithValue("Author", booksTable.SelectedRows[0].Cells[3].Value.ToString().Trim());
                            command.Parameters.AddWithValue("AgeLimit", booksTable.SelectedRows[0].Cells[4].Value.ToString());
                            command.Parameters.AddWithValue("ImagePath", "source\\book_covers\\empty.jpg");
                            command.Parameters.AddWithValue("IsAvailable", booksTable.SelectedRows[0].Cells[6].Value.ToString() == "в наличии" ? 1 : 0);
                            command.Parameters.AddWithValue("IsActive", booksTable.SelectedRows[0].Cells[7].Value.ToString() == "активная" ? 1 : 0);

                            DataBase.OpenConnection();
                            command.ExecuteNonQuery();

                            DataBase.CloseConnection();

                            MessageBox.Show("Данные о новой книге были успешно сохранены",
                                            "Сохранение новой книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось сохранить данные о новой книге:\n\"{ex.Message}\"\n" +
                                            $"Обратитесь к системному администратору для её устранения.",
                                            "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    // if the saved line contains an Id, then we re-save the book with this Id in the database
                    else
                    {
                        string query = "UPDATE Books " +
                                       "SET Title = @Title, GenreId = @GenreId, Author = @Author, " +
                                       "AgeLimit = @AgeLimit, IsAvailable = @IsAvailable, IsActive = @IsActive " +
                                       "WHERE Id = @Id";
                        string id = booksTable.SelectedRows[0].Cells[0].Value.ToString()!;
                        string genreId = GetGenreId(); // insert genre Id from Genres table of database

                        try
                        {
                            command = DataBase.GetConnection().CreateCommand();
                            command.CommandText = query;
                            command.Parameters.AddWithValue("Id", id);
                            command.Parameters.AddWithValue("Title", booksTable.SelectedRows[0].Cells[1].Value.ToString().Trim());
                            command.Parameters.AddWithValue("GenreId", genreId);
                            command.Parameters.AddWithValue("Author", booksTable.SelectedRows[0].Cells[3].Value.ToString().Trim());
                            command.Parameters.AddWithValue("AgeLimit", booksTable.SelectedRows[0].Cells[4].Value.ToString());
                            command.Parameters.AddWithValue("IsAvailable", booksTable.SelectedRows[0].Cells[6].Value.ToString() == "в наличии" ? 1 : 0);
                            command.Parameters.AddWithValue("IsActive", booksTable.SelectedRows[0].Cells[7].Value.ToString() == "активная" ? 1 : 0);

                            DataBase.OpenConnection();
                            command.ExecuteNonQuery();

                            DataBase.CloseConnection();

                            MessageBox.Show("Данные о книге были успешно изменены",
                                            "Изменение данных о книге", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось изменить данные о книге в базе данных:\n\"{ex.Message}\"\n" +
                                            $"Обратитесь к системному администратору для её устранения.",
                                            "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                // if exactly the same book is in the database
                else
                {
                    MessageBox.Show($"Книга с такими атрибутами уже существует",
                                    "Не удается сохранить данные", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show($"Поле \"{booksTable.Columns[index].HeaderText}\" не заполнено",
                                "Не удается сохранить данные", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        // add a blank line to save a new book
        private void AddBookButton_Click(object sender, EventArgs e)
        {
            // if editing mode is enabled
            if (EmployeeFormEditModeCheckBox.Checked)
            {
                // if there are rows in the table
                if (booksTable.Rows.Count >= 1)
                {
                    // add a new element to the table source
                    booksList.Add(new Book());

                    // move to a new line
                    booksTable.CurrentCell = booksTable.Rows[booksTable.Rows.Count - 1].Cells[1];

                    // by default we fill in the availability and status
                    isAvailableComboBox.SelectedIndex = 0;
                    statusComboBox.SelectedIndex = 0;
                }
                // if there are no rows in the table, then we simply add a new row
                else
                {
                    booksList.Add(new Book());
                }
            }
        }

        // delete book from table and database
        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            // if the table is empty or no rows are selected, then deletion does not work
            if (booksTable.Rows.Count == 0 || booksTable.SelectedRows.Count == 0)
                return;

            // if the line being deleted does not contain Id
            if (booksTable.CurrentRow.Cells[0].Value is null)
            {
                // if the "Title" and "Author" fields are not empty
                if (booksTable.SelectedRows[0].Cells[1].Value is not null && booksTable.SelectedRows[0].Cells[3].Value is not null)
                {
                    // if a similar book exists in the database, we delete from the database the book with the same title and author
                    if (CheckBookInDataBase())
                    {
                        MessageBoxButtons msb = MessageBoxButtons.YesNo;
                        MessageBoxIcon icn = MessageBoxIcon.Question;
                        String message = "Вы действительно хотите удалить эту книгу?";
                        String caption = "Удаление книги";

                        if (MessageBox.Show(message, caption, msb, icn) == DialogResult.Yes)
                        {
                            string query = "DELETE FROM Books WHERE Title = @Title AND Author = @Author";

                            try
                            {
                                command = DataBase.GetConnection().CreateCommand();
                                command.CommandText = query;
                                command.Parameters.AddWithValue("Title", booksTable.SelectedRows[0].Cells[1].Value.ToString());
                                command.Parameters.AddWithValue("Author", booksTable.SelectedRows[0].Cells[3].Value.ToString());
                                DataBase.OpenConnection();
                                command.ExecuteNonQuery();

                                DataBase.CloseConnection();

                                booksTable.Rows.RemoveAt(booksTable.CurrentRow.Index);

                                foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }

                                MessageBox.Show("Книга была удалена из базы данных",
                                                "Удаление книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Не удалось удалить книгу из базы данных:\n\"{ex.Message}\"\n" +
                                                $"Обратитесь к системному администратору для её устранения.",
                                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    // if there is no similar book in the database, simply delete the line
                    else
                    {
                        booksTable.Rows.RemoveAt(booksTable.CurrentRow.Index);

                        foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
                    }
                }
                // if the line is empty, just delete the line
                else
                {
                    booksTable.Rows.RemoveAt(booksTable.CurrentRow.Index);

                    foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
                }
            }
            // if the deleted line contains an Id, then we delete the book with that Id from the database
            else
            {
                MessageBoxButtons msb = MessageBoxButtons.YesNo;
                MessageBoxIcon icn = MessageBoxIcon.Question;
                String message = "Вы действительно хотите удалить эту книгу?";
                String caption = "Удаление книги";

                if (MessageBox.Show(message, caption, msb, icn) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Books WHERE Id = @Id";
                    string id = booksTable.SelectedRows[0].Cells[0].Value.ToString()!;

                    try
                    {
                        command = DataBase.GetConnection().CreateCommand();
                        command.CommandText = query;
                        command.Parameters.AddWithValue("Id", id);
                        DataBase.OpenConnection();
                        command.ExecuteNonQuery();

                        DataBase.CloseConnection();

                        booksTable.Rows.RemoveAt(booksTable.CurrentRow.Index);

                        foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }

                        MessageBox.Show("Книга была удалена из базы данных",
                                        "Удаление книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось удалить книгу из базы данных:\n\"{ex.Message}\"\n" +
                                        $"Обратитесь к системному администратору для её устранения.",
                                        "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        // handling errors when working with DataGridView
        private void CheckError_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show($"Произошла ошибка {anError.Context}\nОбратитесь к системному администратору",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "ошибка";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "ошибка";

                anError.ThrowException = false;
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