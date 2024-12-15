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


        public UserAccountForm(StartForm startForm, Account account)
        {
            InitializeComponent();
            GetCurrentDate();

            ViewAvailableBooksTable();

            this.account = account;
            this.startForm = startForm;

            PutCurrentUserData(GetCurrentUserData(account.LoginId));
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

        #region All Books Tab

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
                        IsAvailable = reader.GetString(6) == "1" ? "в наличии" : "выдана"
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
        private void ViewAvailableBooksTable()
        {
            GetAvailableBooks();

            availableBooksTable.DataSource = availableBooksList; // table data source
            availableBooksTable.MultiSelect = false; // you can't select more than one row

            availableBooksTable.Columns[0].Visible = false; // do not display column with Id
            availableBooksTable.Columns[5].Visible = false; // we do not display the column with the cover address
            availableBooksTable.Columns[7].Visible = false; // we do not display the column with the Availability

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

        private void currentTotalBooksLabel_Click(object sender, EventArgs e)
        {

        }
    }

}