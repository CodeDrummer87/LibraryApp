using LibraryApp.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;

namespace LibraryApp
{
    public class AccountActions
    {
        private SqliteCommand command;
        private SqliteDataReader reader;

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

        // writing data to the Employees table
        private void SetEmployeesData(Person person, Employee employee)
        {
            string query = "INSERT INTO Employees (PersonId, PersonnelNumber, PostId, IsActive) " +
                           "SELECT Persons.Id, @PersonnelNumber, (SELECT Id FROM Posts WHERE Post = @PostId), @IsActive FROM Persons " +
                           "WHERE (Firstname, Lastname, Surname, DateOfBirth) = (@Firstname, @Lastname, @Surname, @DateOfBirth); ";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Firstname", person.Firstname);
                command.Parameters.AddWithValue("@Lastname", person.Lastname);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                command.Parameters.AddWithValue("@PersonnelNumber", employee.PersonnelNumber);
                command.Parameters.AddWithValue("@PostId", employee.PostId);
                command.Parameters.AddWithValue("@IsActive", employee.IsActive ? 1 : 0);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать запись в таблице Employees. Ошибка:\n\"{ex.Message}\"\n" +
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

        // writing data to the database and creating an account
        // this method is called from the RegForm or CreateEmployeeForm
        public string CreateNewAccount(string login, string password, Person person, Employee? employee = null)
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
                    // if we register an employee
                    if (employee is not null)
                    {
                        SetEmployeesData(person, employee);
                    }
                    // or register a reader
                    else
                    {
                        SetReadersData(person);
                    }

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

        // get account data
        public Account GetCurrentAccountData(string login)
        {
            Account account = new();

            string query = "SELECT * FROM Accounts WHERE Login=@login";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@login", login);
                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    account = new Account
                    {
                        Id = reader.GetInt32(0),
                        LoginId = reader.GetInt32(1),
                        Login = reader.GetString(2),
                        Password = reader.GetString(3),
                        Salt = (byte[])reader[4]
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return account;
        }

        // checking the presence of a login in the database before registration or authorization
        public bool CheckInputedLogin(string login)
        {
            string query = "SELECT * FROM Accounts WHERE login = @login";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@login", login);

                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows; // gets a value indicating whether the reader contains one or more lines
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка работы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }

        // checking Id in the Readers table for authorization direction
        public bool CheckReaderData(int Id)
        {
            string query = "SELECT * FROM Readers WHERE PersonalId = @Id";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Id", Id);

                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows; // gets a value indicating whether the reader contains one or more lines
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка работы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }

        // checking Id in the Employess table for authorization direction
        public bool CheckEmployeeData(int Id)
        {
            string query = "SELECT * FROM Employees WHERE PersonId = @Id";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Id", Id);

                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows; // gets a value indicating whether the reader contains one or more lines
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка работы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }

        // checking Admin int the Employess table for authorization direction
        public bool CheckAdminData(int Id)
        {
            string query = "SELECT * FROM Employees WHERE PersonId = @Id AND PostId = 4";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@Id", Id);

                DataBase.OpenConnection();
                reader = command.ExecuteReader();

                return reader.HasRows; // gets a value indicating whether the reader contains one or more lines
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка работы с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
            return false;
        }
    }

}