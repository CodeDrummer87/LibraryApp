using LibraryApp.Models;
using Microsoft.Data.Sqlite;
using System.ComponentModel;
using System.Data;

namespace LibraryApp.View
{
    public partial class EmployeeAccountForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // координаты позиционирования формы

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private int currentLoginId;
        private StartForm startForm;

        private BindingList<Book> booksList = new(); // список всех книг (с привязкой)
        private List<Book> filteredList = new(); // список книг, фильтрованный по параметрам

        private ComboBox genresComboBox = new ComboBox(); // выпадающий список жанров
        private ComboBox isAvailableComboBox = new ComboBox(); // выпадающий список наличия книги
        private ComboBox statusComboBox = new ComboBox(); // выпадающий список статуса книги
        int rowIndex = 0; // индекс строки в выпадающем списке

        bool flag = false; // флаг для работы метода выделения/снятия выделения строки

        public EmployeeAccountForm(StartForm startForm, int currentLoginId)
        {
            InitializeComponent();

            ViewBooksTable();
            LoadComboBoxes();

            this.currentLoginId = currentLoginId!;
            this.startForm = startForm;

            PutCurrentEmployeeName(GetCurrentEmployeeName(currentLoginId));
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

        // выходим на стартовую форму, если нажать на ФИО сотрудника и ответить "да"
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

        // выводим ФИО текущего сотрудника
        private void PutCurrentEmployeeName(ViewEmployeeNameModel employeeName)
        {
            currentEmployeeName.Text = $"{employeeName.Lastname} {employeeName.Firstname} {employeeName.Surname}";
        }

        // получаем ФИО текущего сотрудника
        public ViewEmployeeNameModel GetCurrentEmployeeName(int loginId)
        {
            ViewEmployeeNameModel employeeNameModel = new();

            string query = "SELECT e.Id, e.PersonId, p.Firstname, p.Lastname, p.Surname " +
                           "FROM Employees e " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = e.PersonId " +
                           "WHERE e.Id = @Id;";

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

        // по умолчанию заполняем таблицу из booksList, который содержит все книги
        private void ViewBooksTable()
        {
            GetBooks();

            booksTable.DataSource = booksList; // источник данных таблицы 
            booksTable.MultiSelect = false; // нельзя выделять больше одной строки

            booksTable.Columns[0].Visible = false; // не отображаем столбец с Id 
            booksTable.Columns[5].Visible = false; // не отображаем столбец c адресом обложки 

            // задаем размеры и наименования столбцов
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

        // при выборе строки в таблице она будет выделена, кнопки "Добавить", "Сохранить", "Удалить" активны
        private void BooksTableSelectionChanged(object sender, EventArgs e)
        {
            // если в таблице есть строки
            if (booksTable.Rows.Count >= 1)
            {
                // когда строка выбрана
                if (booksTable.CurrentCell.Selected)
                {
                    flag = true;
                    booksTable.CurrentCell.Selected = true;

                    // если режим изменения выключен
                    if (!EmployeeFormEditModeCheckBox.Checked)
                    {
                        // выключаем все кнопки
                        foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = false; }
                    }
                    // если режим изменения включен
                    else
                    {
                        // включаем все кнопки
                        foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = true; }
                    }
                }
            }
        }

        // убираем выделение строки или возвращаем его по клику 
        // изменяем активность кнопок "Добавить", "Сохранить", "Удалить" в зависимости от выделения/невыделения строки
        private void BooksTableMouseUp(object sender, MouseEventArgs e)
        {
            // если в таблице есть строки
            if (booksTable.Rows.Count >= 1)
            {
                // если строка выделена
                if (booksTable.CurrentCell.Selected)
                {
                    // если включен режим редактирования
                    if (EmployeeFormEditModeCheckBox.Checked)
                    {
                        if (flag)
                        {
                            booksTable.CurrentCell.Selected = true;
                            foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = true; }
                            flag = !flag;
                        }
                        else if (!flag)
                        {
                            booksTable.CurrentCell.Selected = false;
                            foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = false; }
                            flag = !flag;
                        }
                    }
                }
            }
        }

        // проводим фильтрацию из поля поиска
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
                    filteredList = booksList.Where(x => x.Author.Contains(booksFilterBox.Text.Trim(),
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

        // по нажатию на чекбокс решаем, можно ли редатировать данные о книгах
        private void EditModeChanged(object sender, EventArgs e)
        {
            if (EmployeeFormEditModeCheckBox.Checked)
            {
                // выключить рид-онли строк
                foreach (DataGridViewBand row in booksTable.Rows) { row.ReadOnly = false; }

                // включить кнопки
                foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = true; }
            }
            else
            {
                // включить рид-онли строк
                foreach (DataGridViewBand row in booksTable.Rows) { row.ReadOnly = true; }

                // выключить выпадающие списки
                foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }

                // выключить кнопки
                foreach (Control ctrls in Controls.OfType<Button>()) { ctrls.Enabled = false; }
            }
        }

        // загружаем выпадающие списки в таблицу
        private void LoadComboBoxes()
        {
            // заполняем список жанров
            LoadGenres();

            // заполняем список наличия книги
            string[] isAvailableItems = { "в наличии", "выдана" };
            isAvailableComboBox.Items.AddRange(isAvailableItems);
            isAvailableComboBox.SelectedIndex = 0;

            // заполняем список статуса книги
            string[] statusItems = { "активная", "неактивная" };
            statusComboBox.Items.AddRange(statusItems);
            statusComboBox.SelectedIndex = 0;

            // создаем обработчик события (выбор элементов из списка)
            genresComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged!;
            isAvailableComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged!;
            statusComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged!;

            // добавляем списки в таблицу 
            booksTable.Controls.Add(genresComboBox);
            booksTable.Controls.Add(isAvailableComboBox);
            booksTable.Controls.Add(statusComboBox);
        }

        // заполням выпадающий список жанров из БД
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

        // показываем выпадающие списки при клике по ячейкам
        private void BooksTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // если в таблице есть строки
            if (booksTable.Rows.Count >= 1)
            {
                // задаем индекс строки
                rowIndex = e.RowIndex;
                if (rowIndex < 0)
                    rowIndex++;

                // получаем прямоугольники ячеек со списками
                Rectangle genresRectangle = booksTable.GetCellDisplayRectangle(2, rowIndex, true);
                Rectangle availableRectangle = booksTable.GetCellDisplayRectangle(6, rowIndex, true);
                Rectangle statusRectangle = booksTable.GetCellDisplayRectangle(7, rowIndex, true);

                // задаем размеры и месторасположение списков
                genresComboBox.Size = new Size(genresRectangle.Width, genresRectangle.Height);
                isAvailableComboBox.Size = new Size(availableRectangle.Width, availableRectangle.Height);
                statusComboBox.Size = new Size(statusRectangle.Width, statusRectangle.Height);

                genresComboBox.Location = new Point(genresRectangle.X, genresRectangle.Y);
                isAvailableComboBox.Location = new Point(availableRectangle.X, availableRectangle.Y);
                statusComboBox.Location = new Point(statusRectangle.X, statusRectangle.Y);

                // если включен режим редактирования
                if (EmployeeFormEditModeCheckBox.Checked)
                {
                    // показываем списки
                    foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = true; }

                    // если создаем новую книгу, то в списке предлагаем выбрать жанр
                    if (booksTable.CurrentRow.Cells[0].Value is null && booksTable.CurrentRow.Cells[2].Value is null)
                    {
                        genresComboBox.Text = "Выберите жанр";
                    }
                    // если редактируем существующую книгу, то показываем в списках текущие значения
                    else
                    {
                        genresComboBox.Text = booksTable.CurrentRow.Cells[2].Value.ToString();
                        isAvailableComboBox.Text = booksTable.CurrentRow.Cells[6].Value.ToString();
                        statusComboBox.Text = booksTable.CurrentRow.Cells[7].Value.ToString();
                    }
                }
                // если режим редактирования выключен
                else
                {
                    // то не показываем списки
                    foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
                }
            }
        }

        // выбираем значение из списка
        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // сохраняем значение в ячейке, если не закончили её редактирование и переключились на список
            booksTable.EndEdit();

            // заносим данные в ячейку
            booksTable[2, rowIndex].Value = genresComboBox.Text;
            booksTable[6, rowIndex].Value = isAvailableComboBox.Text;
            booksTable[7, rowIndex].Value = statusComboBox.Text;

            // скрываем список
            foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
        }

        // получаем номер жанра для записи его в БД в случае редактирования жанра в таблице
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

        // проверяем, является ли числом значение в ячейке с ограничением по возрасту
        private void IsDigit_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // если активная ячейка - ограничение по возрасту
            if (booksTable.CurrentRow.Cells[4] == booksTable.CurrentCell)
            {
                // получаем её значение
                string ageLimitEditingValue = booksTable.CurrentCell.EditedFormattedValue.ToString()!;

                // и проверяем
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

        // проверяем, все ли ячейки заполнены в строке при сохранении данных о книге
        private bool CheckIsNullOrWhiteSpace(out int emptyIndex)
        {
            emptyIndex = 0; // по-умолчанию индекс пустой ячейки 0
            bool result = false; // по-умолчанию строка считается заполненной

            for (int i = 1; i < booksTable.ColumnCount; i++)
            {
                // пропускаем ячейку с адресом обложки при проверке,
                // т.к. адрес по-молчанию для новой книги пишется сразу в БД, минуя таблицу
                if (i == 5)
                    continue;

                // если значение ячейки равно null или она содержит только пробелы
                if (booksTable.CurrentRow.Cells[i].Value is null || string.IsNullOrWhiteSpace(booksTable.CurrentRow.Cells[i].Value.ToString()))
                {
                    // то возвращаем значение true и дальше уже метод сохранения выведет сообщение об ошибке
                    result = true;
                    emptyIndex = i; // в который мы передадим индекс пустой ячейки для вывода названия незаполненного поля
                    break;
                }
            }
            return result;
        }

        // проверяем, есть ли аналогичная книга в БД
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

        // сохраняем данные о книге в таблице и БД
        private void SaveBookButton_CLick(object sender, EventArgs e)
        {
            // если в таблице есть строки
            if (booksTable.Rows.Count >= 1)
            {
                // если строка выделена
                if (booksTable.CurrentCell.Selected)
                {
                    int index; // индекс незаполненной ячейки

                    // если строка не имеет пустых ячеек
                    if (!CheckIsNullOrWhiteSpace(out index))
                    {
                        // если аналогичной книги нет в БД
                        if (!CheckBookInDataBase())
                        {
                            // если сохраняемая строка не содержит Id, значит книги еще нет в БД
                            // сохраняем новую книгу
                            if (booksTable.CurrentRow.Cells[0].Value is null)
                            {
                                string query = "INSERT INTO Books (Title, GenreId, Author, AgeLimit, ImagePath, IsAvailable, IsActive) " +
                                               "VALUES(@Title, @GenreId, @Author, @AgeLimit, @ImagePath, @IsAvailable, @IsActive)";

                                string genreId = GetGenreId(); // подставляем Id жанра из таблицы Genres БД

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
                            // если сохраняемая строка содержит Id, то пересохраняем книгу с таким Id в БД
                            else
                            {
                                string query = "UPDATE Books " +
                                               "SET Title = @Title, GenreId = @GenreId, Author = @Author, " +
                                               "AgeLimit = @AgeLimit, IsAvailable = @IsAvailable, IsActive = @IsActive " +
                                               "WHERE Id = @Id";
                                string id = booksTable.SelectedRows[0].Cells[0].Value.ToString()!;
                                string genreId = GetGenreId(); // подставляем Id жанра из таблицы Genres БД

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
                        // если в точности такая же книга есть в БД
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
            }
        }

        // добавляем пустую строку для сохранения новой книги
        private void AddBookButton_Click(object sender, EventArgs e)
        {
            // если включен режим редактирования
            if (EmployeeFormEditModeCheckBox.Checked)
            {
                // если в таблице есть строки
                if (booksTable.Rows.Count >= 1)
                {
                    // добавляем новый элемент в источник таблицы
                    booksList.Add(new Book());

                    // перемещаемся на новую строку
                    booksTable.CurrentCell = booksTable.Rows[booksTable.Rows.Count - 1].Cells[1];

                    // по-умолчанию заполняем наличие и статус
                    isAvailableComboBox.SelectedIndex = 0;
                    statusComboBox.SelectedIndex = 0;
                }
                // если в таблице нет строк, то просто добавляем новую строку
                else
                {
                    booksList.Add(new Book());
                }
            }
        }

        // удаляем книгу из таблицы и БД
        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            // если в таблице есть строки
            if (booksTable.Rows.Count >= 1)
            {
                // если строка выделена
                if (booksTable.CurrentCell.Selected)
                {
                    // если удаляемая строка не содержит Id
                    if (booksTable.CurrentRow.Cells[0].Value is null)
                    {
                        // если поля "Название" и "Автор" не пустые
                        if (booksTable.SelectedRows[0].Cells[1].Value is not null && booksTable.SelectedRows[0].Cells[3].Value is not null)
                        {
                            // если аналогичная книга есть в БД, удаляем из БД книгу с такими названием и автором
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
                            // если аналогичной книги нет в БД, просто удаляем строку
                            else
                            {
                                booksTable.Rows.RemoveAt(booksTable.CurrentRow.Index);

                                foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
                            }
                        }
                        // если строка пустая, просто удаляем строку
                        else
                        {
                            booksTable.Rows.RemoveAt(booksTable.CurrentRow.Index);

                            foreach (Control ctrl in booksTable.Controls.OfType<ComboBox>()) { ctrl.Visible = false; }
                        }
                    }
                    // если удаляемая строка содержит Id, то удаляем книгу с таким Id из БД
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
            }
        }

        // обрабатываем ошибки при работе с DataGridView
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