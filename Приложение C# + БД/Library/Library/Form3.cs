using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Form3 : Form
    {
        private Form1 formAuthorization;
        private SqlConnection cnn;
        private SqlDataAdapter da;
        private SqlDataAdapter da1;
        private DataSet DS = new DataSet("LibrarianDS");
        private DataSet DS1 = new DataSet("DebtorDS");
        private BindingSource BSGenre = new BindingSource();
        private BindingSource BSAuthor = new BindingSource();
        private BindingSource BSBook = new BindingSource();
        private BindingSource BSExemp = new BindingSource();
        private BindingSource BSReader = new BindingSource();
        private BindingSource BSIssue = new BindingSource();
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 f)
        {
            InitializeComponent();
            formAuthorization = f;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            formAuthorization.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DS.Tables.Add("Genre");
            DS.Tables.Add("Author");
            DS.Tables.Add("Book");
            DS.Tables.Add("BookAuthor");
            DS.Tables.Add("GenreBook");
            DS.Tables.Add("Exemp");
            DS.Tables.Add("Reader");
            DS.Tables.Add("Issue");
            DS.Tables.Add("FreeExemp");

            DS1.Tables.Add("Debtor");
            DS1.Tables.Add("DebIssue");

            cnn = new SqlConnection(Program.bld.ConnectionString);
            da = new SqlDataAdapter("[dbo].[SELECT_FOR_LIBRARIAN]", cnn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da1 = new SqlDataAdapter("[dbo].[selectOverTerm]", cnn);
            da1.SelectCommand.CommandType = CommandType.StoredProcedure;
            da1.SelectCommand.Parameters.Add("@nDays", SqlDbType.Int);
            da1.SelectCommand.Parameters["@nDays"].Value = textBox1.Text;

            da.TableMappings.Add("Table", "Genre");
            da.TableMappings.Add("Table1", "Author");
            da.TableMappings.Add("Table2", "Book");
            da.TableMappings.Add("Table3", "BookAuthor");
            da.TableMappings.Add("Table4", "GenreBook");
            da.TableMappings.Add("Table5", "Exemp");
            da.TableMappings.Add("Table6", "Reader");
            da.TableMappings.Add("Table7", "Issue");
            da.TableMappings.Add("Table8", "FreeExemp");

            da1.TableMappings.Add("Table", "Debtor");
            da1.TableMappings.Add("Table1", "DebIssue");
            try
            {
                cnn.Open();
                da.Fill(DS);  // загрузили все таблицы
                da1.Fill(DS1);

                DataGridSet(BSGenre, DS.Tables["Genre"], dataGridViewGenre);
                DataGridSet(BSAuthor, DS.Tables["Author"], dataGridViewAuthor);
                DataGridSet(BSBook, DS.Tables["Book"], dataGridViewBook);
                DataGridSet(BSExemp, DS.Tables["Exemp"], dataGridViewExemp);
                DataGridSet(BSReader, DS.Tables["Reader"], dataGridViewReader);
                DataGridSet(BSIssue, DS.Tables["Issue"], dataGridViewIssue);

                DataColumn dcReaderID = DS1.Tables["Debtor"].Columns["Reader_ID"];
                DataColumn dcIsReaderID = DS1.Tables["DebIssue"].Columns["Reader_ID"];

                DataRelation dataRelation = new
                    DataRelation("Долги", dcReaderID, dcIsReaderID);
                DS1.Relations.Add(dataRelation);

                dataGridViewDebtor.DataSource = DS1.DefaultViewManager;
                dataGridViewDebtor.DataMember = "Debtor";
                dataGridViewDebtor.ReadOnly = true;
                dataGridViewDebtor.Columns[0].Visible = false;

                dataGridViewDebIssue.DataSource = DS1.DefaultViewManager;
                dataGridViewDebIssue.DataMember = "Debtor.Долги";
                dataGridViewDebIssue.ReadOnly = true;
                dataGridViewDebIssue.Columns[0].Visible = false;
                dataGridViewDebIssue.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridSet(BindingSource BS, DataTable tbl, DataGridView dgv)
        {  //привязка DataTable к DataGridView
            BS.DataSource = tbl;
            dgv.DataSource = BS;
            dgv.ReadOnly = true;             //только чтение
            dgv.Columns[0].Visible = false;  // скрыли ID
        }

        private void RefillDataSet()
        {
            DS.Clear();
            da.Fill(DS);
        }

        private void InsertDeleteAuthorGenre(int idBook, List<int> ag,
            string procedure, string nameParameter)
        {
            SqlCommand cmd = new SqlCommand(procedure, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Book_ID", SqlDbType.Int);
            cmd.Parameters["@Book_ID"].Value = idBook;

            cmd.Parameters.Add(nameParameter, SqlDbType.Int);

            foreach (int id in ag)
            {
                cmd.Parameters[nameParameter].Value = id;
                cmd.ExecuteNonQuery();
            }
        }

        private int GetIdBookByIdExemp(int idExemp)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("select dbo.GetIdBookByIdExemp(@Exemp_ID)", cnn);

                cmd.Parameters.Add("@Exemp_ID", SqlDbType.Int);
                cmd.Parameters["@Exemp_ID"].Value = idExemp;

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                result = (int)reader[0];
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private void buttonAddGenre_Click(object sender, EventArgs e)
        {
            ChangeGenreForm addGenreForm = new ChangeGenreForm();
            DialogResult result = addGenreForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.insertGenre", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@GenreName", SqlDbType.VarChar, 70);
                cmd.Parameters["@GenreName"].Value = addGenreForm.GenreName;

                //выполнить dbo.insertGenre
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Жанр успешно добавлен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonUpdateGenre_Click(object sender, EventArgs e)
        {
            if (dataGridViewGenre.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewGenre.SelectedRows[0].Index;
            int id = (int)dataGridViewGenre.Rows[index].Cells[0].Value;
            ChangeGenreForm updateGenreForm = new ChangeGenreForm();
            updateGenreForm.GenreName = dataGridViewGenre.Rows[index].Cells[1].Value.ToString();
            DialogResult result = updateGenreForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.updateGenre", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Genre_ID", SqlDbType.Int);
                cmd.Parameters["@Genre_ID"].Value = id;

                cmd.Parameters.Add("@GenreName", SqlDbType.VarChar, 70);
                cmd.Parameters["@GenreName"].Value = updateGenreForm.GenreName;

                //выполнить dbo.updateGenre
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Жанр успешно изменен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonDeleteGenre_Click(object sender, EventArgs e)
        {
            if (dataGridViewGenre.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewGenre.SelectedRows[0].Index;
            int id = (int)dataGridViewGenre.Rows[index].Cells[0].Value;

            DialogResult result = MessageBox.Show("Вы действительно хотите " +
                "удалить выбранный жанр?", "Удаление жанра", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.deleteGenre", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Genre_ID", SqlDbType.Int);
                cmd.Parameters["@Genre_ID"].Value = id;

                //выполнить dbo.deleteGenre
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DS.Tables["Genre"].Rows.RemoveAt(index);
            MessageBox.Show("Жанр успешно удален", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            ChangeAuthorForm addAuthorForm = new ChangeAuthorForm();
            DialogResult result = addAuthorForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.insertAuthor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AuthorSurname", SqlDbType.VarChar, 50);
                cmd.Parameters["@AuthorSurname"].Value = addAuthorForm.AuthorSurname;

                cmd.Parameters.Add("@AuthorName", SqlDbType.VarChar, 50);
                cmd.Parameters["@AuthorName"].Value = addAuthorForm.AuthorName;

                cmd.Parameters.Add("@AuthorOtch", SqlDbType.VarChar, 50);
                cmd.Parameters["@AuthorOtch"].Value = addAuthorForm.AuthorOtch;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Автор успешно добавлен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonUpdateAuthor_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewAuthor.SelectedRows[0].Index;
            int id = (int)dataGridViewAuthor.Rows[index].Cells[0].Value;
            ChangeAuthorForm updateAuthorForm = new ChangeAuthorForm();
            updateAuthorForm.AuthorSurname = dataGridViewAuthor.Rows[index].Cells[1].Value.ToString();
            updateAuthorForm.AuthorName = dataGridViewAuthor.Rows[index].Cells[2].Value.ToString();
            updateAuthorForm.AuthorOtch = dataGridViewAuthor.Rows[index].Cells[3].Value.ToString();
            DialogResult result = updateAuthorForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.updateAuthor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Author_ID", SqlDbType.Int);
                cmd.Parameters["@Author_ID"].Value = id;

                cmd.Parameters.Add("@AuthorSurname", SqlDbType.VarChar, 50);
                cmd.Parameters["@AuthorSurname"].Value = updateAuthorForm.AuthorSurname;

                cmd.Parameters.Add("@AuthorName", SqlDbType.VarChar, 50);
                cmd.Parameters["@AuthorName"].Value = updateAuthorForm.AuthorName;

                cmd.Parameters.Add("@AuthorOtch", SqlDbType.VarChar, 50);
                cmd.Parameters["@AuthorOtch"].Value = updateAuthorForm.AuthorOtch;

                //выполнить dbo.updateGenre
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Автор успешно изменен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewAuthor.SelectedRows[0].Index;
            int id = (int)dataGridViewAuthor.Rows[index].Cells[0].Value;

            DialogResult result = MessageBox.Show("Вы действительно хотите " +
                "удалить выбранного автора?", "Удаление автора", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.deleteAuthor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Author_ID", SqlDbType.Int);
                cmd.Parameters["@Author_ID"].Value = id;

                //выполнить dbo.deleteGenre
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Автор успешно удален", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            ChangeBookForm addBookform = new ChangeBookForm();
            foreach (DataRow author in DS.Tables["Author"].Rows)
            {
                CheckItem item =
                    new CheckItem((int)author.ItemArray[0],
                        author.ItemArray[1].ToString() + " " +
                        author.ItemArray[2].ToString(), false);
                addBookform.checkAuthors.Add(item);
            }
            foreach (DataRow genre in DS.Tables["Genre"].Rows)
            {
                CheckItem item =
                    new CheckItem((int)genre.ItemArray[0],
                        genre.ItemArray[1].ToString(), false);
                addBookform.checkGenres.Add(item);
            }
            DialogResult result = addBookform.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            int idBook = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.insertBook", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@BookName", SqlDbType.VarChar, 70);
                cmd.Parameters["@BookName"].Value = addBookform.bookName;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idBook = (int)reader[0];
                }
                else
                {
                    throw new Exception("Невозвращен идентификатор новой книги");
                }
                reader.Close();

                InsertDeleteAuthorGenre(idBook, addBookform.insertedAuthors,
                    "dbo.insertBookAuthor", "@Author_ID");
                InsertDeleteAuthorGenre(idBook, addBookform.insertedGenres,
                    "dbo.insertGenreBook", "@Genre_ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Книга успешно добавлена", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonUpdateBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewBook.SelectedRows[0].Index;
            int id = (int)dataGridViewBook.Rows[index].Cells[0].Value;

            ChangeBookForm updateBookform = new ChangeBookForm();
            updateBookform.bookName = dataGridViewBook.Rows[index].Cells[1].Value.ToString();
            foreach (DataRow author in DS.Tables["Author"].Rows)
            {
                int idAuthor = (int)author.ItemArray[0];
                bool isBook = false;
                foreach (DataRow ba in DS.Tables["BookAuthor"].Rows)
                {
                    if (id == (int)ba.ItemArray[1] && idAuthor == (int)ba.ItemArray[2])
                    {
                        isBook = true;
                        break;
                    }
                }
                CheckItem item =
                    new CheckItem(idAuthor,
                        author.ItemArray[1].ToString() + " " +
                        author.ItemArray[2].ToString(), isBook);
                updateBookform.checkAuthors.Add(item);
            }
            updateBookform.checkAuthors.Sort();

            foreach (DataRow genre in DS.Tables["Genre"].Rows)
            {
                int idGenre = (int)genre.ItemArray[0];
                bool isBook = false;
                foreach (DataRow ba in DS.Tables["GenreBook"].Rows)
                {
                    if (id == (int)ba.ItemArray[1] && idGenre == (int)ba.ItemArray[2])
                    {
                        isBook = true;
                        break;
                    }
                }
                CheckItem item =
                    new CheckItem(idGenre,
                        genre.ItemArray[1].ToString(), isBook);
                updateBookform.checkGenres.Add(item);
            }
            updateBookform.checkGenres.Sort();

            DialogResult result = updateBookform.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                string oldNameBook = dataGridViewBook.Rows[index].Cells[1].Value.ToString();
                if (oldNameBook != updateBookform.bookName)
                {
                    SqlCommand cmd = new SqlCommand("dbo.updateBook", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Book_ID", SqlDbType.Int);
                    cmd.Parameters["@Book_ID"].Value = id;

                    cmd.Parameters.Add("@BookName", SqlDbType.VarChar, 70);
                    cmd.Parameters["@BookName"].Value = updateBookform.bookName;

                    cmd.ExecuteNonQuery();
                }

                InsertDeleteAuthorGenre(id, updateBookform.insertedAuthors,
                    "dbo.insertBookAuthor", "@Author_ID");
                InsertDeleteAuthorGenre(id, updateBookform.insertedGenres,
                    "dbo.insertGenreBook", "@Genre_ID");

                InsertDeleteAuthorGenre(id, updateBookform.deletedAuthors,
                    "dbo.deleteBookAuthor", "@Author_ID");
                InsertDeleteAuthorGenre(id, updateBookform.deletedGenres,
                    "dbo.deleteGenreBook", "@Genre_ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Книга успешно изменена", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewBook.SelectedRows[0].Index;
            int id = (int)dataGridViewBook.Rows[index].Cells[0].Value;

            DialogResult result = MessageBox.Show("Вы действительно хотите " +
                "удалить выбранную книгу? Вместе с ней удалятся соотвествующие " +
                "экземпляры и факты выдачи", "Удаление книги", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.deleteBook", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Book_ID", SqlDbType.Int);
                cmd.Parameters["@Book_ID"].Value = id;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Книга успешно удалена", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonAddExemp_Click(object sender, EventArgs e)
        {
            ChangeExempForm addExempForm = new ChangeExempForm();
            addExempForm.bookTable = DS.Tables["Book"];
            DialogResult result = addExempForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.insertExemp", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Exemp_Number", SqlDbType.Int);
                cmd.Parameters["@Exemp_Number"].Value = addExempForm.numberExemp;

                cmd.Parameters.Add("@Book_ID", SqlDbType.Int);
                cmd.Parameters["@Book_ID"].Value = addExempForm.idBook;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Экземпляр успешно добавлен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonUpdateExemp_Click(object sender, EventArgs e)
        {
            if (dataGridViewExemp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewExemp.SelectedRows[0].Index;
            int id = (int)dataGridViewExemp.Rows[index].Cells[0].Value;
            ChangeExempForm updateExempForm = new ChangeExempForm();

            updateExempForm.numberExemp = (int)dataGridViewExemp.Rows[index].Cells[1].Value;
            updateExempForm.idBook = GetIdBookByIdExemp(id);
            updateExempForm.bookTable = DS.Tables["Book"];

            DialogResult result = updateExempForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.updateExemp", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Exemp_ID", SqlDbType.Int);
                cmd.Parameters["@Exemp_ID"].Value = id;

                cmd.Parameters.Add("@Book_ID", SqlDbType.Int);
                cmd.Parameters["@Book_ID"].Value = updateExempForm.idBook;

                cmd.Parameters.Add("@Exemp_Number", SqlDbType.Int);
                cmd.Parameters["@Exemp_Number"].Value = updateExempForm.numberExemp;

                //выполнить dbo.updateGenre
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Экземпляр успешно изменен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonDeleteExemp_Click(object sender, EventArgs e)
        {
            if (dataGridViewExemp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewExemp.SelectedRows[0].Index;
            int id = (int)dataGridViewExemp.Rows[index].Cells[0].Value;

            DialogResult result = MessageBox.Show("Вы действительно хотите " +
                "удалить выбранный экземпляр?", "Удаление экземпляра", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.deleteExemp", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Exemp_ID", SqlDbType.Int);
                cmd.Parameters["@Exemp_ID"].Value = id;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Экземпляр успешно удален", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonAddReader_Click(object sender, EventArgs e)
        {
            ChangeReaderForm addReaderForm = new ChangeReaderForm();

            addReaderForm.isAdd = true;

            DialogResult result = addReaderForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.insertReader", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ReaderSurname", SqlDbType.VarChar, 50);
                cmd.Parameters["@ReaderSurname"].Value = addReaderForm.surname;

                cmd.Parameters.Add("@ReaderName", SqlDbType.VarChar, 50);
                cmd.Parameters["@ReaderName"].Value = addReaderForm.name;

                cmd.Parameters.Add("@ReaderOtch", SqlDbType.VarChar, 50);
                cmd.Parameters["@ReaderOtch"].Value = addReaderForm.otch;

                cmd.Parameters.Add("@NumberTicket", SqlDbType.Int);
                cmd.Parameters["@NumberTicket"].Value = addReaderForm.numberTicket;

                cmd.Parameters.Add("@Login", SqlDbType.VarChar, 20);
                cmd.Parameters["@Login"].Value = addReaderForm.login;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Читатель успешно добавлен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonUpdateReader_Click(object sender, EventArgs e)
        {
            if (dataGridViewReader.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewReader.SelectedRows[0].Index;
            Guid id = (Guid)dataGridViewReader.Rows[index].Cells[0].Value;
            ChangeReaderForm updateReaderForm = new ChangeReaderForm();

            updateReaderForm.isAdd = false;
            updateReaderForm.numberTicket = (int)dataGridViewReader.Rows[index].Cells[1].Value;
            updateReaderForm.surname = dataGridViewReader.Rows[index].Cells[2].Value.ToString();
            updateReaderForm.name = dataGridViewReader.Rows[index].Cells[3].Value.ToString();
            updateReaderForm.otch = dataGridViewReader.Rows[index].Cells[4].Value.ToString();
            updateReaderForm.login = dataGridViewReader.Rows[index].Cells[5].Value.ToString();

            DialogResult result = updateReaderForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (result == DialogResult.Retry)
            {
                // сброс пароля
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.resetReaderPassword", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Reader_ID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@Reader_ID"].Value = id;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("Пароль читателя успешно сброшен",
                    "Сообщение", MessageBoxButtons.OK);
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.updateReader", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Reader_ID", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@Reader_ID"].Value = id;

                cmd.Parameters.Add("@ReaderSurname", SqlDbType.VarChar, 50);
                cmd.Parameters["@ReaderSurname"].Value = updateReaderForm.surname;

                cmd.Parameters.Add("@ReaderName", SqlDbType.VarChar, 50);
                cmd.Parameters["@ReaderName"].Value = updateReaderForm.name;

                cmd.Parameters.Add("@ReaderOtch", SqlDbType.VarChar, 50);
                cmd.Parameters["@ReaderOtch"].Value = updateReaderForm.otch;

                cmd.Parameters.Add("@NumberTicket", SqlDbType.Int);
                cmd.Parameters["@NumberTicket"].Value = updateReaderForm.numberTicket;

                cmd.Parameters.Add("@Login", SqlDbType.VarChar, 20);
                cmd.Parameters["@Login"].Value = updateReaderForm.login;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Читатель успешно изменен", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonDeleteReader_Click(object sender, EventArgs e)
        {
            if (dataGridViewReader.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewReader.SelectedRows[0].Index;
            Guid id = (Guid)dataGridViewReader.Rows[index].Cells[0].Value;

            DialogResult result = MessageBox.Show("Вы действительно хотите " +
                "удалить выбранного читателя?", "Удаление читателя", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.deleteReader", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Reader_ID", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@Reader_ID"].Value = id;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Читатель успешно удален", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonAddIssue_Click(object sender, EventArgs e)
        {
            ChangeIssueForm addIssueForm = new ChangeIssueForm();

            addIssueForm.isAdd = true;
            addIssueForm.readerTable = DS.Tables["Reader"].Copy();
            addIssueForm.bookTable = DS.Tables["Book"].Copy();
            addIssueForm.exempTable = DS.Tables["FreeExemp"].Copy();

            DialogResult result = addIssueForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.insertIssue", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ReaderID", SqlDbType.UniqueIdentifier);
                cmd.Parameters["@ReaderID"].Value = addIssueForm.idReader;

                cmd.Parameters.Add("@ExempID", SqlDbType.Int);
                cmd.Parameters["@ExempID"].Value = addIssueForm.idExemp;

                cmd.Parameters.Add("@DatIssue", SqlDbType.Date);
                cmd.Parameters["@DatIssue"].Value = addIssueForm.dateIssue;

                cmd.Parameters.Add("@Term", SqlDbType.Int);
                cmd.Parameters["@Term"].Value = addIssueForm.term;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Книга успешно выдана", "Сообщение", MessageBoxButtons.OK);
        }

        private void buttonUpdateIssue_Click(object sender, EventArgs e)
        {
            if (dataGridViewIssue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewIssue.SelectedRows[0].Index;
            int id = (int)dataGridViewIssue.Rows[index].Cells[0].Value;
            int numberTicket = (int)dataGridViewIssue.Rows[index].Cells[1].Value;
            int numberExemp = (int)dataGridViewIssue.Rows[index].Cells[3].Value;

            ChangeIssueForm updateIssueForm = new ChangeIssueForm();
            if (dataGridViewIssue.Rows[index].Cells[6].Value is DateTime)
            {
                MessageBox.Show("Книга уже возвращена", "Сообщение", MessageBoxButtons.OK);
                return;
            }

            updateIssueForm.isAdd = false;
            updateIssueForm.readerTable = DS.Tables["Reader"].Clone();
            int indexReader = 0;
            for (; indexReader < DS.Tables["Reader"].Rows.Count; ++indexReader)
            {
                if ((int)DS.Tables["Reader"].Rows[indexReader].ItemArray[1] == numberTicket)
                {
                    break;
                }
            }
            updateIssueForm.readerTable.Rows.Add(DS.Tables["Reader"].Rows[indexReader].ItemArray);

            updateIssueForm.bookTable = DS.Tables["Book"].Clone();
            int indexExemp = 0;
            for (; indexExemp < DS.Tables["Exemp"].Rows.Count; ++indexExemp)
            {
                if ((int)DS.Tables["Exemp"].Rows[indexExemp].ItemArray[1] == numberExemp)
                {
                    break;
                }
            }
            int idExemp = (int)DS.Tables["Exemp"].Rows[indexExemp].ItemArray[0];
            int idBook = GetIdBookByIdExemp(idExemp);
            int indexBook = 0;
            for (; indexBook < DS.Tables["Book"].Rows.Count; ++indexBook)
            {
                if ((int)DS.Tables["Book"].Rows[indexBook].ItemArray[0] == idBook)
                {
                    break;
                }
            }
            updateIssueForm.bookTable.Rows.Add(DS.Tables["Book"].Rows[indexBook].ItemArray);

            updateIssueForm.exempTable = DS.Tables["FreeExemp"].Clone();
            updateIssueForm.exempTable.Rows.Add(1, numberExemp, 2);

            updateIssueForm.dateIssue = (DateTime)dataGridViewIssue.Rows[index].Cells[5].Value;
            updateIssueForm.term = (int)dataGridViewIssue.Rows[index].Cells[7].Value;

            DialogResult result = updateIssueForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("dbo.updateIssue", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Issue_ID", SqlDbType.Int);
                cmd.Parameters["@Issue_ID"].Value = id;

                cmd.Parameters.Add("@DatReturn", SqlDbType.Date);
                cmd.Parameters["@DatReturn"].Value = updateIssueForm.dateReturn;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            RefillDataSet();
            MessageBox.Show("Книга успешно возвращена", "Сообщение", MessageBoxButtons.OK);
        }

        //private void buttonDeleteIssue_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewIssue.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Выберите строку таблицы", "Сообщение", MessageBoxButtons.OK);
        //        return;
        //    }
        //    int index = dataGridViewIssue.SelectedRows[0].Index;
        //    int id = (int)dataGridViewIssue.Rows[index].Cells[0].Value;

        //    if (!(dataGridViewIssue.Rows[index].Cells[6].Value is DateTime))
        //    {
        //        MessageBox.Show("Нельзя удалить факт выдачи, если книга еще не возвращена",
        //            "Сообщение", MessageBoxButtons.OK);
        //        return;
        //    }

        //    DialogResult result = MessageBox.Show("Вы действительно хотите " +
        //        "удалить выбранный факт выдачи?", "Удаление факта выдачи", MessageBoxButtons.YesNo);

        //    if (result == DialogResult.No)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("dbo.deleteIssue", cnn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@Issue_ID", SqlDbType.Int);
        //        cmd.Parameters["@Issue_ID"].Value = id;

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;
        //    }

        //    RefillDataSet();
        //    MessageBox.Show("Факт выдачи успешно удален", "Сообщение", MessageBoxButtons.OK);
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int t;
            if (int.TryParse(textBox1.Text, out t))
            {
                da1.SelectCommand.Parameters["@nDays"].Value = textBox1.Text;
                DS1.Clear();
                da1.Fill(DS1);
            }
        }
    }
}
