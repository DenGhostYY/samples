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
    public partial class ChangeIssueForm : Form
    {
        private DataSet DS = new DataSet("ChangeIssue");
        private BindingSource BSReader = new BindingSource();

        public bool isAdd;
        public DataTable readerTable = new DataTable("Reader");
        public DataTable bookTable = new DataTable("Book");
        public DataTable exempTable = new DataTable("FreeExemp");

        public Guid idReader;
        public int idExemp;
        public DateTime dateIssue;
        public DateTime dateReturn;
        public int term = 20;

        public ChangeIssueForm()
        {
            InitializeComponent();
        }

        private void ChangeIssueForm_Load(object sender, EventArgs e)
        {
            DS.Tables.Add(readerTable);
            DS.Tables.Add(bookTable);
            DS.Tables.Add(exempTable);

            BSReader.DataSource = readerTable;
            dataGridViewReader.DataSource = BSReader;
            dataGridViewReader.ReadOnly = true;
            dataGridViewReader.Columns[0].Visible = false;

            if (!isAdd)
            {
                Text = "Прием книги";

                textBoxNumberTicket.Text = readerTable.Rows[0].ItemArray[1].ToString();
                textBoxNumberTicket.Enabled = false;

                dateTimePickerIssue.Value = dateIssue;
                dateTimePickerIssue.Enabled = false;

                dateTimePickerReturn.Value = DateTime.Now;

                textBoxTerm.Text = term.ToString();
                textBoxTerm.Enabled = false;

                dataGridViewBook.DataSource = bookTable;
                dataGridViewBook.ReadOnly = true;
                dataGridViewBook.Columns[0].Visible = false;

                dataGridViewExemp.DataSource = exempTable;
                dataGridViewExemp.ReadOnly = true;
                dataGridViewExemp.Columns[0].Visible = false;
                dataGridViewExemp.Columns[2].Visible = false;

                return;
            }
            dateTimePickerIssue.Value = DateTime.Now;

            dateTimePickerReturn.Enabled = false;

            textBoxTerm.Text = term.ToString();

            DataColumn dcBookID = DS.Tables["Book"].Columns["Book_ID"];
            DataColumn dcExBookID = DS.Tables["FreeExemp"].Columns["Book_ID"];

            DataRelation dataRelation = new
                DataRelation("[Доступные экземпляры]", dcBookID, dcExBookID);
            DS.Relations.Add(dataRelation);

            dataGridViewBook.DataSource = DS.DefaultViewManager;
            dataGridViewBook.DataMember = "Book";
            dataGridViewBook.ReadOnly = true;
            dataGridViewBook.Columns[0].Visible = false;

            dataGridViewExemp.DataSource = DS.DefaultViewManager;
            dataGridViewExemp.DataMember = "Book.[Доступные экземпляры]";
            dataGridViewExemp.ReadOnly = true;
            dataGridViewExemp.Columns[0].Visible = false;
            dataGridViewExemp.Columns[2].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int t;
            if (int.TryParse(textBoxNumberTicket.Text, out t))
            {
                BSReader.Filter = textBoxNumberTicket.Text + "=[Номер билета]";
            }
            else
            {
                BSReader.Filter = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                dateReturn = dateTimePickerReturn.Value;
                return;
            }

            if (dataGridViewReader.SelectedRows.Count == 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Выберите строку таблицы Читатели", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            int index = dataGridViewReader.SelectedRows[0].Index;
            idReader = (Guid)dataGridViewReader.Rows[index].Cells[0].Value;

            if (dataGridViewExemp.SelectedRows.Count == 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Выберите строку таблицы Экземпляры", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            index = dataGridViewExemp.SelectedRows[0].Index;
            idExemp = (int)dataGridViewExemp.Rows[index].Cells[0].Value;

            dateIssue = dateTimePickerIssue.Value;

            int t;
            if (!int.TryParse(textBoxTerm.Text, out t))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Некорректный срок выдачи", "Сообщение", MessageBoxButtons.OK);
                return;
            }
            term = t;
        }
    }
}
