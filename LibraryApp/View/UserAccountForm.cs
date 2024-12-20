using LibraryApp.Models;
using Microsoft.Data.Sqlite;
using System.ComponentModel;

namespace LibraryApp
{
    public partial class UserAccountForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private StartForm startForm;
        Account account;

        private BindingList<Book> availableBooksList = new(); // list of available books (with binding)
        private List<Book> filteredAvailabledBooksList = new(); // list of available books filtered by parameters
        private BindingList<Book> currentBooksList = new(); // ist of books of the current user (with binding)

        public UserAccountForm(StartForm startForm, Account account)
        {
            InitializeComponent();
            GetCurrentDate();

            this.account = account;
            this.startForm = startForm;

            PutCurrentUserData(GetCurrentUserData(account.LoginId));

            ViewAvailableBooksTable();
            ViewCurrentBooksTable();
        }

        #region Window control buttons
        private void UserAccountCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
            startForm.Close();
        }

        private void UserAccountCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            userAccountCloseLabel.Text = "x";
            userAccountCloseLabel.ForeColor = Color.Red;
        }

        private void UserAccountCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            userAccountCloseLabel.Text = "-";
            userAccountCloseLabel.ForeColor = Color.Black;
        }

        // exit-button. We exit to the starting form if we answer "yes"
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
            exitToStartFormLabel.ForeColor = Color.Red;
        }

        private void ExitToStartFormLabel_MouseLeave(object sender, EventArgs e)
        {
            exitToStartFormLabel.ForeColor = Color.MidnightBlue;
        }

        #endregion

        // display the current date
        private void GetCurrentDate() => currentDateLabel.Text = "Сегодня " + DateTime.Now.ToLongDateString();

        // display the name, date of birth, library card number and number of books of the current user
        private void PutCurrentUserData(ViewReaderModel reader)
        {
            currentUserName.Text = $"{reader.Lastname} {reader.Firstname} {reader.Surname}";
            currentDateOfBirth.Text = $"Дата рождения: {reader.DateOfBirth}";
            currentLibraryCardNumber.Text = reader.libraryCardNumber.ToString();
            currentTotalBooks.Text = reader.TotalBooks.ToString();

            // if the database contains data about the file path, display the profile photo
            if (account.ImagePath is not null)
            {
                using (var stream = new FileStream(Environment.ExpandEnvironmentVariables(@"%appdata%\LibraryApp\avatars\") + account.ImagePath, FileMode.Open))
                {
                    userAccountPictureBox.BackgroundImage = null;
                    userAccountPictureBox.Image = Image.FromStream(stream);
                    userAccountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // get the current user's data
        public ViewReaderModel GetCurrentUserData(int loginId)
        {
            ViewReaderModel model = new();

            string query = "SELECT r.Id, r.PersonalId, r.libraryCardNumber, r.TotalBooks, " +
                           "p.Firstname, p.Lastname, p.Surname, p.DateOfBirth " +
                           "FROM Readers r " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = r.PersonalId " +
                           "WHERE r.PersonalId = @Id";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@Id", SqliteType.Integer).Value = loginId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    model = new ViewReaderModel()
                    {
                        Id = reader.GetInt32(0),
                        PersonalId = reader.GetInt32(1),
                        libraryCardNumber = reader.GetInt32(2),
                        TotalBooks = reader.GetInt32(3),
                        Firstname = reader.GetString(4),
                        Lastname = reader.GetString(5),
                        Surname = reader.GetString(6),
                        DateOfBirth = reader.GetString(7)
                    };

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить данные текущего пользователя:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return model;
        }

        // change the profile image by clicking on it
        private void ChangeProfileImage(object sender, EventArgs e)
        {
            // opening the file dialog
            userAccountOpenFileDialog.FileName = "Image";
            userAccountOpenFileDialog.Filter = "PNG (*.png)|*.png";
            userAccountOpenFileDialog.Title = "Выберите файл с изображением";

            if (userAccountOpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            // saving the image to the PictureBox
            userAccountPictureBox.BackgroundImage = null;

            userAccountPictureBox.Image = new Bitmap(userAccountOpenFileDialog.FileName);

            userAccountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userAccountPictureBox.Update();

            // the name of the file to save
            string fileName = account.Login + ".png";

            // the saving path
            string savePath = Environment.ExpandEnvironmentVariables(@"%appdata%\LibraryApp\avatars\") + fileName;

            if (userAccountPictureBox.Image is not null)
            {
                try
                {
                    // saving the file
                    userAccountPictureBox.Image.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                    AccountActions.SetImagePathData(command, fileName, account.LoginId);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение профиля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // icrement the book counter if we take the book, and decrement if we return it
        private void ChangeTotalBooks(int readerId, int action)
        {
            string query = String.Empty;

            // if we take a book
            if (action == 1)
            {
                query = "UPDATE Readers SET TotalBooks = TotalBooks +1 WHERE Id = @ReaderId";
            }
            // if we return a book
            else if (action == 2)
            {
                query = "UPDATE Readers SET TotalBooks = TotalBooks -1 WHERE Id = @ReaderId";
            }

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@ReaderId", readerId);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить запись в таблице Readers. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // make the book unavailable when we take it and make it available when we return it
        private void ChangeBookAvailability(int action)
        {
            string query = String.Empty;
            string rowId = String.Empty;

            // if we take a book
            if (action == 1)
            {
                query = "UPDATE Books SET IsAvailable = 0 WHERE Id = @Id ";
                rowId = availableBooksTable.SelectedRows[0].Cells[0].Value.ToString()!;
            }
            // if we return a book
            else if (action == 2)
            {
                query = "UPDATE Books SET IsAvailable = 1 WHERE Id = @Id ";
                rowId = currentBooksTable.SelectedRows[0].Cells[0].Value.ToString()!;
            }

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Id", rowId);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить запись в таблице Books. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        #region All Books Tab

        // filtering available books by the search field
        private void AvailableBooksFilterTextChanged(object sender, EventArgs e)
        {
            // if the search field is empty
            if (availableBooksFilterBox.Text.Equals(String.Empty))
            {
                // the table data source is a list with all books availableBooksList
                availableBooksTable.DataSource = availableBooksList;
            }
            // if the search field is filled, we filter (data source - filteredAvailabledBooksList)
            else
            {
                // by author
                if (availableBooksAuthorFilterRadioButton.Checked)
                {
                    filteredAvailabledBooksList = availableBooksList.Where(x => x.Author.Contains(availableBooksFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    availableBooksTable.DataSource = filteredAvailabledBooksList;
                }

                // by title
                else if (availableBooksNameFilterRadioButton.Checked)
                {
                    filteredAvailabledBooksList = availableBooksList.Where(x => x.Title.Contains(availableBooksFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    availableBooksTable.DataSource = filteredAvailabledBooksList;
                }
            }
        }

        // get a list of available books and fill availableBooksList
        private void GetAvailableBooks()
        {
            availableBooksList.Clear();

            string query = "SELECT b.Id, b.Title, (SELECT Name FROM Genres WHERE b.GenreId = Id), " +
                           "b.Author, b.AgeLimit, b.ImagePath, b.IsAvailable " +
                           "FROM Books b " +
                           "WHERE b.IsAvailable = 1 " +
                           "ORDER BY Title";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    availableBooksList.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        GenreId = reader.GetString(2),
                        Author = reader.GetString(3),
                        AgeLimit = reader.GetInt32(4),
                        ImagePath = reader.GetString(5),
                        IsAvailable = reader.GetString(6) == "1" ? "в наличии" : "ошибка"
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список доступных книг:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // by default we fill the table from availableBooksList, which contains all available books
        private void ViewAvailableBooksTable()
        {
            GetAvailableBooks();

            availableBooksTable.DataSource = availableBooksList; // table data source
            availableBooksTable.MultiSelect = false; // you can't select more than one row

            availableBooksTable.Columns[0].Visible = false; // do not display column with Id
            availableBooksTable.Columns[5].Visible = false; // do not display the column with the cover address
            availableBooksTable.Columns[7].Visible = false; // do not display the column with the availability

            // set the sizes and names of the columns
            availableBooksTable.Columns[1].Width = 500;
            availableBooksTable.Columns[1].HeaderText = "Название";

            availableBooksTable.Columns[2].Width = 160;
            availableBooksTable.Columns[2].HeaderText = "Жанр";

            availableBooksTable.Columns[3].Width = 280;
            availableBooksTable.Columns[3].HeaderText = "Автор";

            availableBooksTable.Columns[4].Width = 100;
            availableBooksTable.Columns[4].HeaderText = "Ограничение по возрасту";

            availableBooksTable.Columns[6].Width = 100;
            availableBooksTable.Columns[6].HeaderText = "Наличие";
        }

        // get the current reader's Id
        private int GetReaderId()
        {
            string query = "SELECT Id FROM Readers WHERE PersonalId = @PersonalId";
            int readerId = 0;

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@PersonalId", account.LoginId);

                DataBase.OpenConnection();
                readerId = Convert.ToInt32(command.ExecuteScalar())!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить значение Id текущего пользователя. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return readerId;
        }

        // get the total number of books of the current user
        private int GetTotalBooks(int readerId)
        {
            string query = "SELECT TotalBooks FROM Readers WHERE Id = @PersonalId";
            int totalBooks = 0;

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@PersonalId", readerId);

                DataBase.OpenConnection();
                totalBooks = Convert.ToInt32(command.ExecuteScalar())!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить значение общего количества книг текущего пользователя. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return totalBooks;
        }

        // take the selected book and write the information into the database
        private void TakeABookButton_CLick(object sender, EventArgs e)
        {
            // if the table is empty or no rows are selected, it doesn't work
            if (availableBooksTable.Rows.Count == 0 || availableBooksTable.SelectedRows.Count == 0)
                return;

            string query = "INSERT INTO ReadersBooks (ReaderId, BookId) VALUES(@ReaderId, @BookId) ";

            int readerId = GetReaderId();

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@ReaderId", readerId);
                command.Parameters.AddWithValue("@BookId", availableBooksTable.SelectedRows[0].Cells[0].Value.ToString());

                DataBase.OpenConnection();
                command.ExecuteNonQuery();

                ChangeTotalBooks(readerId, 1); // increment TotalBooks;

                ChangeBookAvailability(1); // IsAvailable = 0

                ViewCurrentBooksTable(); // update the table of books taken

                currentTotalBooks.Text = GetTotalBooks(readerId).ToString(); // update the user's books counter

                MessageBox.Show($"Вы взяли книгу: \n\"{availableBooksTable.SelectedRows[0].Cells[1].Value}\"\n",
                                "Операции с книгами", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ViewAvailableBooksTable(); // update the availableBooksTable after taking the book

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать запись в таблице ReadersBooks. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        #endregion

        #region My Books Tab

        // get a list of the current user's books
        private void GetCurrentBooks()
        {
            currentBooksList.Clear();

            string query = "SELECT b.Id, b.Title, (SELECT Name FROM Genres WHERE b.GenreId = Id), " +
                           "b.Author, b.AgeLimit, b.ImagePath " +
                           "FROM Books b " +
                           "JOIN ReadersBooks rb ON b.Id = rb.BookId " +
                           "WHERE ReaderId = @ReaderId " +
                           "ORDER BY Title";

            int readerId = GetReaderId();

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@ReaderId", readerId);

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    currentBooksList.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        GenreId = reader.GetString(2),
                        Author = reader.GetString(3),
                        AgeLimit = reader.GetInt32(4),
                        ImagePath = reader.GetString(5),
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список книг текущего пользователя:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // fill the currentBooksTable from currentBooksList
        private void ViewCurrentBooksTable()
        {
            GetCurrentBooks();

            currentBooksTable.DataSource = currentBooksList; // table data source
            currentBooksTable.MultiSelect = false; // you can't select more than one row

            currentBooksTable.Columns[0].Visible = false; // do not display column with Id
            currentBooksTable.Columns[5].Visible = false; // do not display the column with the cover address
            currentBooksTable.Columns[6].Visible = false; // do not display the column with the availability
            currentBooksTable.Columns[7].Visible = false; // do not display the column with activity

            // set the sizes and names of the columns
            currentBooksTable.Columns[1].Width = 578;
            currentBooksTable.Columns[1].HeaderText = "Название";

            currentBooksTable.Columns[2].Width = 180;
            currentBooksTable.Columns[2].HeaderText = "Жанр";

            currentBooksTable.Columns[3].Width = 300;
            currentBooksTable.Columns[3].HeaderText = "Автор";

            currentBooksTable.Columns[4].Width = 100;
            currentBooksTable.Columns[4].HeaderText = "Ограничение по возрасту";

            // if the user has not taken any books
            if (currentBooksTable.Rows.Count == 0)
            {
                currentBooksTable.Visible = false;
                noBooksLabel.Visible = true;
            }
            else
            {
                noBooksLabel.Visible = false;
                currentBooksTable.Visible = true;
            }
        }

        // return the selected book and write the information into the database
        private void ReturnABookButton_CLick(object sender, EventArgs e)
        {
            // if the table is empty or no rows are selected, it doesn't work
            if (currentBooksTable.Rows.Count == 0 || currentBooksTable.SelectedRows.Count == 0)
                return;

            string query = "DELETE FROM ReadersBooks WHERE ReaderId = @ReaderId AND BookId = @BookId";

            int readerId = GetReaderId();

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@ReaderId", readerId);
                command.Parameters.AddWithValue("@BookId", currentBooksTable.SelectedRows[0].Cells[0].Value.ToString());

                DataBase.OpenConnection();
                command.ExecuteNonQuery();

                ChangeBookAvailability(2); // IsAvailable = 1

                ChangeTotalBooks(readerId, 2); // decrement TotalBooks

                ViewAvailableBooksTable(); // update the table of available books

                currentTotalBooks.Text = GetTotalBooks(readerId).ToString(); // update the user's books counter

                MessageBox.Show($"Вы вернули книгу: \n\"{currentBooksTable.SelectedRows[0].Cells[1].Value}\"\n",
                                "Операции с книгами", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ViewCurrentBooksTable(); // update the currentBooksTable after returning the book

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось удалить запись в таблице ReadersBooks. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        #endregion

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