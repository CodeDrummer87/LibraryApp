using LibraryApp.Models;
using Microsoft.Data.Sqlite;

namespace LibraryApp.View
{
    public partial class ListOfPostsForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY; // form positioning coordinates

        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private List<Post> postsList = new(); // the List as data source of post table

        bool flag = false; // flag for the operation of the line selection/deselection method

        public ListOfPostsForm()
        {
            InitializeComponent();

            ViewPostsTable();
        }

        #region Window control buttons
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

        #endregion

        // get a list of positions
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
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        // fill in the table from the list of posts
        private void ViewPostsTable()
        {
            GetPosts();

            postsTable.DataSource = postsList; // table data source
            postsTable.MultiSelect = false; // you can't select more than one line

            postsTable.Columns[0].Visible = false;
            postsTable.Columns[1].HeaderText = "Должность";
            postsTable.Columns[2].HeaderText = "Релевантность";
            postsTable.Columns[3].Visible = false; // do not display the "Removability" column
        }

        // when you select a new line, it is always highlighted, the "Edit" and "Delete" buttons are active
        private void PostTableSelectionChanged(object sender, EventArgs e)
        {
            if (postsTable.CurrentCell.Selected)
            {
                flag = true;
                postsTable.CurrentCell.Selected = true;
                changePostButton.Enabled = true;
                deletePostButton.Enabled = true;
            }
        }

        // remove the line selection or return it by clicking
        // change the activity of the "Edit" and "Delete" buttons depending on whether the line is selected/not selected
        private void PostTableMouseUp(object sender, MouseEventArgs e)
        {
            if (postsTable.CurrentCell.Selected)
            {
                if (flag)
                {
                    postsTable.CurrentCell.Selected = true;
                    changePostButton.Enabled = true;
                    deletePostButton.Enabled = true;
                    flag = !flag;
                }
                else if (!flag)
                {
                    postsTable.CurrentCell.Selected = false;
                    changePostButton.Enabled = false;
                    deletePostButton.Enabled = false;
                    flag = !flag;
                }
            }
        }

        // by clicking on the checkbox we decide whether it is possible to edit posts
        private void EditModeChanged(object sender, EventArgs e)
        {
            if (listOfPostsEditModeCheckBox.Checked)
            {
                foreach (DataGridViewBand row in postsTable.Rows)
                {
                    row.ReadOnly = false;
                }
            }
            else
            {
                foreach (DataGridViewBand row in postsTable.Rows)
                {
                    row.ReadOnly = true;
                }
            }
        }

        // change the post in the table and the database
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
                                "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // check if the position is being deleted
        private bool IsDeletablePost()
        {
            string query = "SELECT IsDeletable FROM Posts WHERE Id = @Id";
            string id = postsTable.SelectedRows[0].Cells[0].Value.ToString();

            command = DataBase.GetConnection().CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("@Id", id);

            DataBase.OpenConnection();
            bool answer = Convert.ToBoolean(command.ExecuteScalar());

            DataBase.CloseConnection();
            return answer;
        }

        // delete position from table and database
        private void DeletePostButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msb = MessageBoxButtons.YesNo;
            String message = "Вы действительно хотите удалить должность?";
            String caption = "Удаление должности";

            if (MessageBox.Show(message, caption, msb) == DialogResult.Yes)
            {
                if (IsDeletablePost())
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

                        BindingSource binding = new BindingSource(); // to bind a source via BindingSource
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
                                        "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Эту должность удалить нельзя",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
