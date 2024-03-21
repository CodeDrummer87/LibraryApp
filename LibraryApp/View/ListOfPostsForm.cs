using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class ListOfPostsForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private List<Post> postsList = new(); // лист как источник данных таблицы должностей

        BindingSource binding = new BindingSource(); // привязкой источника через BindingSource

        bool flag = false;

        public ListOfPostsForm()
        {
            InitializeComponent();

            ViewPostsTable();
        }

        private void ListOfPostsCloseLabelCloseLabel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ListOfPostsCloseLabelCloseLabel_MouseEnter(object? sender, EventArgs e)
        {
            listOfPostsCloseLabel.Text = "x";
            listOfPostsCloseLabel.ForeColor = Color.Red;
        }

        private void ListOfPostsCloseLabelCloseLabel_MouseLeave(object? sender, EventArgs e)
        {
            listOfPostsCloseLabel.Text = "-";
            listOfPostsCloseLabel.ForeColor = Color.Black;
        }

        // получаем список должностей
        private void GetPosts()
        {
            postsList.Clear();

            string query = "SELECT * FROM Posts ORDER BY Post";

            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;

                DataBase.OpenConnection();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    postsList.Add(new Post
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        IsActive = reader.GetString(2) == "1" ? "активная" : "неактивная"
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список должностей:" +
                                $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                                "Ошибка при работе с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // заполняем таблицу из списка должностей
        private void ViewPostsTable()
        {
            GetPosts();

            postsTable.DataSource = postsList; // источник данных таблицы 

            postsTable.Columns[0].Visible = false;
            postsTable.Columns[1].HeaderText = "Должность";
            postsTable.Columns[2].HeaderText = "Релевантность";
        }

        // изменяем активность кнопок "Изменить" и "Удалить" в зависимости от выделения/невыделения строки
        private void PostTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (postsTable.Rows[e.RowIndex].Selected == true)
            {
                if (flag)
                {
                    postsTable.Rows[e.RowIndex].Selected = true;
                    changePostButton.Enabled = true;
                    deletePostButton.Enabled = true;
                    flag = !flag;
                }
                else if (!flag)
                {
                    postsTable.Rows[e.RowIndex].Selected = false;
                    changePostButton.Enabled = false;
                    deletePostButton.Enabled = false;
                    flag = !flag;
                }
            }
        }

        // по нажатию на чекбокс решаем, можно ли редатировать должности
        private void EditModeChanged(object sender, EventArgs e)
        {
            if (listOfPostsEditModeCheckBox.Checked)
            {
                foreach (DataGridViewBand row in postsTable.Rows)
                {
                    row.ReadOnly = false;
                }

                changePostButton.Enabled = true;
                deletePostButton.Enabled = true;
            }
            else
            {
                foreach (DataGridViewBand row in postsTable.Rows)
                {
                    row.ReadOnly = true;
                }
            }
        }

        // изменяем должность в таблице и БД
        private void ChangePostButton_CLick(object sender, EventArgs e)
        {
            string query = "UPDATE Posts " +
                           "SET Post = @Post, IsActive = @IsActive " +
                           "WHERE Id = @Id";
            string id = postsTable.SelectedRows[0].Cells[0].Value.ToString();
            
            try
            {
                command = DataBase.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("Post", postsTable.SelectedRows[0].Cells[1].Value.ToString());
                command.Parameters.AddWithValue("IsActive", postsTable.SelectedRows[0].Cells[2].Value.ToString() == "активная" ? 1 : 0);

                DataBase.OpenConnection();
                command.ExecuteNonQuery();

                DataBase.CloseConnection();

                GetPosts();

                MessageBox.Show("Должность была успешно изменена",
                                "Изменение должности", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить должность в базе данных:\n\"{ex.Message}\"\n" +
                                $"Обратитесь к системному администратору для её устранения.",
                                "Нет соединения с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // удаляем должность из таблицы и БД
        private void DeletePostButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            String message = "Вы действительно хотите удалить должность?";
            String caption = "Удаление должности";

            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                string query = "DELETE FROM Posts WHERE Id = @Id";
                string id = postsTable.SelectedRows[0].Cells[0].Value.ToString();

                try
                {
                    command = DataBase.GetConnection().CreateCommand();
                    command.CommandText = query;
                    command.Parameters.AddWithValue("Id", id);
                    DataBase.OpenConnection();
                    command.ExecuteNonQuery();

                    DataBase.CloseConnection();

                    binding.SuspendBinding();
                    binding.DataSource = postsList;
                    binding.ResumeBinding();

                    GetPosts();

                    postsTable.DataSource = binding;
                    postsTable.Refresh();

                    MessageBox.Show("Должность была успешно удалена из базы данных",
                                    "Удаление должности", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить должность из базы данных:\n\"{ex.Message}\"\n" +
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
