using LibraryApp.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;

namespace LibraryApp
{
    public class AccountActions
    {
        private SqliteCommand command;

        // writing data to the Readers table
        private void SetReadersData(Person person)
        {
            string query = "INSERT INTO Readers (PersonalId, libraryCardNumber, TotalBooks) " +
                           "SELECT Persons.Id, Persons.Id + 100, @TotalBooks FROM Persons " +
                           "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); ";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Firstname", person.Firstname);
                command.Parameters.AddWithValue("@Lastname", person.Lastname);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                command.Parameters.AddWithValue("@TotalBooks", 0);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать запись в таблице Readers. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // password salt
        public byte[] GetSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            return salt;
        }

        // password hashing
        public string GetHash(string pswd, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pswd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        // writing data to the Accounts table
        private void SetAccountData(string login, string password, Person person)
        {
            byte[] salt = GetSalt();
            string pswdHash = GetHash(password, salt);

            string query = "INSERT INTO Accounts (LoginId, Login, Password, Salt) SELECT Persons.Id, @Login, @Password, @Salt FROM Persons " +
                           "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); ";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", pswdHash);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Firstname", person.Firstname);
                command.Parameters.AddWithValue("@Lastname", person.Lastname);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать запись в таблице Accounts. Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // writing data to the database and creating a reader account
        public string CreateNewAccount(string login, string password, Person person)
        {
            string message = String.Empty;

            string query = "INSERT INTO Persons (Firstname, Lastname, Surname, DateOfBirth) " +
                           "VALUES (@Firstname, @Lastname, @Surname, @DateOfBirth); ";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Firstname", person.Firstname);
                command.Parameters.AddWithValue("@Lastname", person.Lastname);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);

                DataBase.OpenConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    SetReadersData(person);
                    SetAccountData(login, password, person);

                    message = $"Аккаунт для {login} зарегистрирован";
                }
                else message = "Ошибка регистрации";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать новый аккаунт:\n\"{ex.Message}\"\n" +
                $"Обратитесь к системному администратору для её устранения.",
                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();

            return message;
        }
    }
}
