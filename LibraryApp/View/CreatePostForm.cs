using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class CreatePostForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates
        private SqliteCommand command;

        public CreatePostForm()
        {
            InitializeComponent();
        }

        #region Window control buttons
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

        #endregion

        // create-button
        private void CreatePostButton_Click(object? sender, EventArgs e)
        {
            CreatePost();
        }

        // clear-button
        private void ClearFormButton_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // сheck if there are more than 3 characters in the post title
        private bool CheckPostNameLength()
        {
            return createPostNewPostBox.Text.Trim().Length <= 3;
        }

        // check if there are numbers in the post title
        private bool CheckPostNameNumberContains(string postName)
        {
            foreach (char x in postName)
                if (Char.IsNumber(x))
                    return true;
            return false;
        }

        // check if the post is in the database
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

        // creating a new post
        public void CreatePost()
        {
           if(CheckPostNameLength())
            {
                MessageBox.Show($"Название должности должно содержать больше трёх букв",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm();
            }
            else
            {
                if(CheckPostNameNumberContains(createPostNewPostBox.Text.Trim()))
                {
                    MessageBox.Show($"Название должности не должно содержать цифры",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearForm();
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
                        string query = "INSERT INTO Posts(Post, IsActive, IsDeletable) " +
                                       "VALUES (@Post, @IsActive, 1)";

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
                                            "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        DataBase.CloseConnection();
                        ClearForm();
                    }
                }
            }
        }

        // clear the form
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
