using LibraryApp.Models;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryApp.View
{
    public partial class ListOfPostsForm : Form
    {
        private int iFormX, iFormY, iMouseX, iMouseY;
        private SqliteCommand? command;
        private SqliteDataReader? reader;

        private List<Post> postsList = new();

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

            // по-умолчанию таблица недоступна для редактирования
            foreach (DataGridViewBand column in postsTable.Columns)
            {
                column.ReadOnly = true;
            }
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
