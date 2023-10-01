using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class UserAccountForm : Form
    {
        AccountAction currentAccount = new();
      
        public UserAccountForm(int currentLogin = default)
        {
            InitializeComponent();
            GetCurrentDate();
            
            PutCurrentUserData(currentAccount.GetCurrentUserData(currentLogin));
        }

        private void GetCurrentDate() => currentDateLabel.Text = "Сегодня " + DateTime.Now.ToLongDateString();

        private void PutCurrentUserData(Reader reader)
        {
            currentLibraryCardNumber.Text = reader.libraryCardNumber.ToString();
            currentTotalBooks.Text = reader.TotalBooks.ToString();
        }

    }

    public class AccountAction
    {
        private SqliteCommand command;
        private SqliteDataReader reader;

        public Reader GetCurrentUserData(int loginId)
        {
            Reader currentReader = new();
            string query = "SELECT * FROM Readers WHERE Id=@Id";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@Id", SqliteType.Integer).Value = loginId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    currentReader = new Reader
                    {
                        Id = reader.GetInt32(0),
                        PersonalId = reader.GetInt32(1),
                        libraryCardNumber = reader.GetInt32(2),
                        TotalBooks = reader.GetInt32(3)
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
            return currentReader;
        }

    }
}