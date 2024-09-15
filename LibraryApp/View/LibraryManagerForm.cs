using LibraryApp.Models;
using LibraryApp.View;
using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    public partial class LibraryManagerForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private int currentLoginId;

        private StartForm startForm;
        public LibraryManagerForm(StartForm startForm, int currentLoginId)
        {
            InitializeComponent();
            GetCurrentDate();
            this.currentLoginId = currentLoginId!;
            this.startForm = startForm;

            PutCurrentUserData(GetCurrentManagerData(currentLoginId));
        }

        #region Window control buttons
        private void LibraryManagerCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
            startForm.Close();
        }

        private void LibraryManagerCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            libraryManagerCloseLabel.Text = "x";
            libraryManagerCloseLabel.ForeColor = Color.Red;
        }

        private void LibraryManagerCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            libraryManagerCloseLabel.Text = "-";
            libraryManagerCloseLabel.ForeColor = Color.Black;
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

        #endregion

        // "сreate employee account" button
        private void CreateEmployeeButton_Click(object? sender, EventArgs e)
        {
            CreateEmployeeForm employeeForm = new();
            employeeForm.Show();
        }

        // "list of employees" button
        private void ListOfEmployeesButtn_Click(object? sender, EventArgs e)
        {
            ListOfEmployeesForm listOfEmployeesForm = new ListOfEmployeesForm();
            listOfEmployeesForm.Show();
        }

        // "create a new post" button
        private void CreatePostButton_Click(object? sender, EventArgs e)
        {
            CreatePostForm newPostForm = new CreatePostForm();
            newPostForm.Show();
        }

        // "list of positions" button
        private void ListOfPostsButton_Click(object? sender, EventArgs e)
        {
            ListOfPostsForm listOfPostsForm = new ListOfPostsForm();
            listOfPostsForm.Show();
        }

        // display the current date
        private void GetCurrentDate() => currentDateLabel.Text = "Сегодня " + DateTime.Now.ToLongDateString();

        // display the name of the current manager
        private void PutCurrentUserData(ViewManagerModel manager)
        {
            currentManagerNameLabel.Text = $"Управляющий: {manager.Lastname} {manager.Firstname} {manager.Surname}";
        }

        // get the data of the current manager
        public ViewManagerModel GetCurrentManagerData(int loginId)
        {
            ViewManagerModel model = new();

            string query = "SELECT e.Id, e.PersonId, e.PersonnelNumber, e.PostId, p.Firstname, p.Lastname, p.Surname " +
                           "FROM Employees e " +
                           "INNER JOIN Persons p " +
                           "ON p.Id = e.PersonId " +
                           "WHERE e.PersonId = @Id";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@Id", SqliteType.Integer).Value = loginId;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    model = new ViewManagerModel()
                    {
                        Id = reader.GetInt32(0),
                        PersonId = reader.GetInt32(1),
                        PersonnelNumber = reader.GetInt32(2),
                        PostId = reader.GetInt32(3),
                        Firstname = reader.GetString(4),
                        Lastname = reader.GetString(5),
                        Surname = reader.GetString(6)
                    };

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить данные текущего управляющего:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
