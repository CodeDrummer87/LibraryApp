using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class CreatePostForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        private SqliteCommand command;

        public CreatePostForm()
        {
            InitializeComponent();
        }
        private void CreatePostCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void CreatePostCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            createPostCloseLabel.Text = "x";
            createPostCloseLabel.ForeColor = Color.Red;
        }

        private void CreatePostCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            createPostCloseLabel.Text = "-";
            createPostCloseLabel.ForeColor = Color.White;
        }

        // кнопка "Создать"
        private void CreatePostButton_Click(object? sender, EventArgs e)
        {
            CreatePost();
        }

        // кнопка "Очистить"
        private void ClearFormButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // проверяем, есть ли более 3-х символов в названии должности
        private bool CheckPostNameLength()
        {
            return createPostNewPostBox.Text.Trim().Length <= 3;
        }

        // проверяем, есть ли цифры в названии должности
        private bool CheckPostNameNumberContains(string postName)
        {
            foreach (char x in postName)
                if (Char.IsNumber(x))
                    return true;
            return false;
        }

        // проверяем, есть ли должность в базе данных
        private bool CheckPostInDataBase()
        {
            string query = "SELECT COUNT(Post) " +
                           "FROM Posts WHERE Post = @Post";

            command = DataBase.GetConnection().CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@Post", createPostNewPostBox.Text.Trim());

            DataBase.OpenConnection();
            bool answer = Convert.ToBoolean(command.ExecuteScalar());

            DataBase.CloseConnection();
            return answer;
        }

        // создаем новую должность
        public void CreatePost()
        {
           if(CheckPostNameLength())
            {
                MessageBox.Show($"Название должности должно содержать больше трёх букв",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(CheckPostNameNumberContains(createPostNewPostBox.Text.Trim()))
                {
                    MessageBox.Show($"Название должности не должно содержать цифры",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (CheckPostInDataBase())
                    {
                        MessageBox.Show($"Должность \"{createPostNewPostBox.Text.Trim()}\" уже существует",
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearForm();
                    }
                    else
                    {
                        string query = "INSERT INTO Posts(Post, IsActive) " +
                                       "VALUES (@Post, @IsActive)";

                        try
                        {
                            command = DataBase.GetConnection().CreateCommand();
                            command.CommandText = query;
                            command.Parameters.AddWithValue("@Post", createPostNewPostBox.Text.Trim());
                            command.Parameters.AddWithValue("@IsActive", createPostIsActiveCheckBox.Checked ? 1 : 0);

                            DataBase.OpenConnection();
                            command.ExecuteNonQuery();

                            MessageBox.Show($"Должность \"{createPostNewPostBox.Text.Trim()}\" успешно создана",
                                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось создать новую должность:\n\"{ex.Message}\"\n" +
                                            $"Обратитесь к системному администратору для её устранения.",
                                            "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        DataBase.CloseConnection();
                        ClearForm();
                    }
                }
            }
        }

        // очищаем форму
        private void ClearForm()
        {
            createPostNewPostBox.Clear();
            createPostNewPostBox.Focus();
            createPostIsActiveCheckBox.CheckState = CheckState.Checked;
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
