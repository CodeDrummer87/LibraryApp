using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class EmployeeAccountForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private int currentLoginId;
        private StartForm startForm;

        private List<Book> booksList = new(); // список всех книг
        private List<Book> filteredList = new(); // список книг, фильтрованный по параметрам

        bool flag = false; // флаг для работы метода выделения/снятия выделения строки

        public EmployeeAccountForm(StartForm startForm, int currentLoginId)
        {
            InitializeComponent();
            ViewBooksTable();

            this.currentLoginId = currentLoginId!;
            this.startForm = startForm;
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

        // кнопка "Выход". Выходим на стартовую форму, если ответить "да"
        private void ExitToStartFormLabel_CLick(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            String message = "Вы действительно хотите выйти?";
            String caption = "Выход";
            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
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

        // получаем список книг и заполняем booksList
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
                        IsAvailable = reader.GetString(6) == "1" ? "доступна" : "недоступна",
                        IsActive = reader.GetString(7) == "1" ? "активная" : "неактивная"
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список книг:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // по умолчанию заполняем таблицу из booksList, который содержит все книги
        private void ViewBooksTable()
        {
            GetBooks();

            booksTable.DataSource = booksList; // источник данных таблицы 
            booksTable.MultiSelect = false; // нельзя выделять больше одной строки

            booksTable.Columns[0].Visible = false;

            booksTable.Columns[1].Width = 400;
            booksTable.Columns[1].HeaderText = "Название";

            booksTable.Columns[2].Width = 180;
            booksTable.Columns[2].HeaderText = "Жанр";

            booksTable.Columns[3].Width = 280;
            booksTable.Columns[3].HeaderText = "Автор";

            booksTable.Columns[4].Width = 100;
            booksTable.Columns[4].HeaderText = "Ограничение по возрасту";

            booksTable.Columns[5].Width = 100;
            booksTable.Columns[5].HeaderText = "Адрес обложки";

            booksTable.Columns[6].Width = 100;
            booksTable.Columns[6].HeaderText = "Доступность";

            booksTable.Columns[7].Width = 100;
            booksTable.Columns[7].HeaderText = "Активность";
        }

        // при выборе новой строки в таблице она всегда выделена, кнопки "Добавить", "Изменить", "Удалить" активны
        private void BooksTableSelectionChanged(object sender, EventArgs e)
        {
            if (booksTable.CurrentCell.Selected)
            {
                flag = true;
                booksTable.CurrentCell.Selected = true;
                addBookButton.Enabled = true;
                changeBookButton.Enabled = true;
                deleteBookButton.Enabled = true;
            }
        }

        // убираем выделение строки или возвращаем его по клику 
        // изменяем активность кнопок "Добавить", "Изменить", "Удалить" в зависимости от выделения/невыделения строки
        private void BooksTableMouseUp(object sender, MouseEventArgs e)
        {
            if (booksTable.CurrentCell.Selected)
            {
                if (flag)
                {
                    booksTable.CurrentCell.Selected = true;
                    addBookButton.Enabled = true;
                    changeBookButton.Enabled = true;
                    deleteBookButton.Enabled = true;
                    flag = !flag;
                }
                else if (!flag)
                {
                    booksTable.CurrentCell.Selected = false;
                    addBookButton.Enabled = false;
                    changeBookButton.Enabled = false;
                    deleteBookButton.Enabled = false;
                    flag = !flag;
                }
            }
        }

        // по нажатию на чекбокс решаем, можно ли редатировать книги
        private void EditModeChanged(object sender, EventArgs e)
        {
            if (EmployeeFormEditModeCheckBox.Checked)
            {
                foreach (DataGridViewBand row in booksTable.Rows)
                {
                    row.ReadOnly = false;
                }

                addBookButton.Enabled = true;
                changeBookButton.Enabled = true;
                deleteBookButton.Enabled = true;
            }
            else
            {
                foreach (DataGridViewBand row in booksTable.Rows)
                {
                    row.ReadOnly = true;
                }
            }
        }

        // проводим фильтрацию из TextBox
        private void FilterTextChanged(object sender, EventArgs e)
        {
            // если поле поиска пустое
            if (booksFilterBox.Text.Equals(String.Empty))
            {
                // то источник данных таблицы - лист со всеми книгами booksList
                booksTable.DataSource = booksList;
            }
            // если поле поиска заполняется, тогда фильтруем (источник данных - filteredList)
            else
            {
                // по автору
                if (booksAuthorFilterRadioButton.Checked)
                {
                    filteredList = booksList.Where(x => x.Author.StartsWith(booksFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    booksTable.DataSource = filteredList;
                }

                // по названию
                else if (booksNameFilterRadioButton.Checked)
                {
                    filteredList = booksList.Where(x => x.Title.Contains(booksFilterBox.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)).ToList();
                    booksTable.DataSource = filteredList;
                }

                // по возрастным ограничениям
                else if (booksAgeLimitFilterRadioButton.Checked)
                {
                    filteredList = booksList.Where(x => x.AgeLimit.ToString().Contains(booksFilterBox.Text.Trim())).ToList();
                    booksTable.DataSource = filteredList;
                }
            }
        }

        // изменяем данные о книге в таблице и БД
        private void ChangeBookButton_CLick(object sender, EventArgs e)
        {
            string query = "UPDATE Books " +
                           "SET Title = @Title, GenreId = @GenreId, Author = @Author, " +
                           "AgeLimit = @AgeLimit, IsAvailable = @IsAvailable, IsActive = @IsActive " +
                           "WHERE Id = @Id";
            string id = booksTable.SelectedRows[0].Cells[0].Value.ToString();

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("Title", booksTable.SelectedRows[0].Cells[1].Value.ToString());
                // command.Parameters.AddWithValue("GenreId", booksTable.SelectedRows[0].Cells[2].Value.ToString()); // ЗАМЕНИ-ПРИДУМАЙ-СДЕЛАЙ
                command.Parameters.AddWithValue("Author", booksTable.SelectedRows[0].Cells[3].Value.ToString());
                command.Parameters.AddWithValue("AgeLimit", booksTable.SelectedRows[0].Cells[4].Value.ToString());
                command.Parameters.AddWithValue("IsAvailable", booksTable.SelectedRows[0].Cells[6].Value.ToString() == "доступна" ? 1 : 0);
                command.Parameters.AddWithValue("IsActive", booksTable.SelectedRows[0].Cells[7].Value.ToString() == "активная" ? 1 : 0);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();

                DataBase.CloseConnection();

                GetBooks();

                MessageBox.Show("Данные о книге были успешно изменены",
                                "Изменение данных о книге", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить данные о книге в базе данных:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Нет соединения с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // удаляем книгу из таблицы и БД
        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            String message = "Вы действительно хотите удалить эту книгу?";
            String caption = "Удаление книги";

            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                string query = "DELETE FROM Books WHERE Id = @Id";
                string id = booksTable.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.AddWithValue("Id", id);
                    DataBase.OpenConnection();
                    command.ExecuteNonQuery();

                    DataBase.CloseConnection();

                    BindingSource binding = new BindingSource(); // для привязки источника через BindingSource
                    binding.SuspendBinding();
                    binding.DataSource = booksList;
                    binding.ResumeBinding();

                    GetBooks();

                    booksTable.DataSource = binding;
                    booksTable.Refresh();

                    MessageBox.Show("Книга была успешно удалена из базы данных",
                                    "Удаление книги", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить книгу из базы данных:\n\"{ex.Message}\"\n" +
                                    $"Обратитесь к системному администратору для её устранения.",
                                    "Нет соединения с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
