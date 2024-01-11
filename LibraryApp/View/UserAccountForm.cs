using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class UserAccountForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        private SqliteCommand? command;
        private SqliteDataReader? reader;
        private int currentLoginId;
        private StartForm startForm;

        public UserAccountForm(StartForm startForm, int currentLoginId)
        {
            InitializeComponent();
            GetCurrentDate();
            this.currentLoginId = currentLoginId!;
            this.startForm = startForm;

            PutCurrentUserData(GetCurrentUserData(currentLoginId));
        }

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

        // выходим на стартовую форму, если ответить "да"
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

        // выводим текущую дату
        private void GetCurrentDate() => currentDateLabel.Text = "Сегодня " + DateTime.Now.ToLongDateString();

        // выводим имя, дату рождения, номер читательского билета и кол-во книг текущего пользователя
        private void PutCurrentUserData(ViewReaderModel reader)
        {
            currentUserName.Text = $"{reader.Lastname.ToString()} {reader.Firstname.ToString()} {reader.Surname.ToString()}";
            currentDateOfBirth.Text = $"Дата рождения: {reader.DateOfBirth.ToString()}";
            currentLibraryCardNumber.Text = reader.libraryCardNumber.ToString();
            currentTotalBooks.Text = reader.TotalBooks.ToString();
        }

        // получаем данные текущего пользователя
        public ViewReaderModel GetCurrentUserData(int loginId)
        {
            ViewReaderModel model = new();

            string query = "SELECT r.Id, r.PersonalId, r.libraryCardNumber, r.TotalBooks, p.Firstname, p.Lastname, p.Surname, p.DateOfBirth " +
                           "FROM Readers r " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = r.PersonalId " +
                           "WHERE r.Id = @Id";

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
                                "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return model;
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