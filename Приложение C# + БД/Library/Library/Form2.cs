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
    public partial class Form2 : Form
    {
        private Form1 formAuthorization;
        private SqlConnection cnn;

        private DataSet DS = new DataSet("ReaderDS");
        private BindingSource BSFreeExemp = new BindingSource();
        private BindingSource BSBusyExemp = new BindingSource();
        private BindingSource BSTrend = new BindingSource();

        private SqlDataAdapter da1;
        private DataTable tableTrend = new DataTable("Trend");
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            formAuthorization = f;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            cnn.Close();
            formAuthorization.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Читатель " + Program.ReaderFIO + " " + Program.ReaderTicket.ToString();
            DS.Tables.Add("FreeExemp");
            DS.Tables.Add("BusyExemp");
            cnn = new SqlConnection(Program.bld.ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter("[dbo].[SELECT_FOR_READER]", cnn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Reader_ID", SqlDbType.UniqueIdentifier);
            da.SelectCommand.Parameters["@Reader_ID"].Value = Program.ReaderID;

            da.TableMappings.Add("Table", "FreeExemp");
            da.TableMappings.Add("Table1", "BusyExemp");

            da1 = new SqlDataAdapter("[dbo].[selectTrendOfBooks]", cnn);
            da1.SelectCommand.CommandType = CommandType.StoredProcedure;

            da1.SelectCommand.Parameters.Add("@nDays", SqlDbType.Int);
            da1.SelectCommand.Parameters["@nDays"].Value = textBox4.Text;
            try
            {
                cnn.Open();
                da.Fill(DS);  // загрузили все таблицы
                da1.Fill(tableTrend);

                DataGridSet(BSFreeExemp, DS.Tables["FreeExemp"], dataGridView1);
                DataGridSet(BSBusyExemp, DS.Tables["BusyExemp"], dataGridView2);

                DataGridSet(BSTrend, tableTrend, dataGridView3);
                dataGridView3.Columns[0].Visible = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<string> filterArray = new List<string>();
            if (checkBox1.Checked) { filterArray.Add("[Название книги] like '" + textBox1.Text + "%'"); }
            else { textBox1.Text = ""; }

            if (checkBox2.Checked) { filterArray.Add("[Авторы] like '%" + textBox2.Text + "%'"); }
            else { textBox2.Text = ""; }

            if (checkBox3.Checked) { filterArray.Add("[Жанры] like '%" + textBox3.Text + "%'"); }
            else { textBox3.Text = ""; }

            BSFreeExemp.Filter = FilterStr(filterArray);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<string> filterArray = new List<string>();
            if (checkBox1.Checked) { filterArray.Add("[Название книги] like '" + textBox1.Text + "%'"); }
            if (checkBox2.Checked) { filterArray.Add("[Авторы] like '%" + textBox2.Text + "%'"); }
            if (checkBox3.Checked) { filterArray.Add("[Жанры] like '%" + textBox3.Text + "%'"); }

            BSFreeExemp.Filter = FilterStr(filterArray);
        }

        private string FilterStr(List<string> filterArray)
        {
            string filter = "";
            if (filterArray.Count == 1)
            {
                filter = filterArray[0];
            }
            else if (filterArray.Count > 1)
            {
                for (int i = 0; i < filterArray.Count - 1; ++i)
                {
                    filter += filterArray[i] + "AND";
                }
                filter += filterArray[filterArray.Count - 1];
            }
            return filter;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int ndays;
            if (int.TryParse(textBox4.Text, out ndays))
            {
                tableTrend.Clear();
                da1.SelectCommand.Parameters["@nDays"].Value = ndays;
                da1.Fill(tableTrend);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm();
            form.ShowDialog();
        }
    }
}
