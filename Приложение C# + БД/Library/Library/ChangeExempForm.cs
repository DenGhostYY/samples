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
    public partial class ChangeExempForm : Form
    {
        public int numberExemp = 0;
        public DataTable bookTable = new DataTable();

        public int idBook = 0;
        public ChangeExempForm()
        {
            InitializeComponent();
        }

        private void ChangeExempForm_Load(object sender, EventArgs e)
        {
            if (numberExemp != 0)
            {
                textBox1.Text = numberExemp.ToString();
            }

            comboBox1.DataSource = bookTable;
            comboBox1.DisplayMember = "Название книги";
            comboBox1.ValueMember = "Book_ID";

            if (idBook != 0)
            {
                int index = 0;
                for (; index < comboBox1.Items.Count; ++index)
                {
                    if (idBook == (int)((DataRowView)comboBox1.Items[index]).Row.ItemArray[0])
                    {
                        comboBox1.SelectedIndex = index;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int t;
            if (!int.TryParse(textBox1.Text, out t))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Введите число в поле \"Номер экземпляра\"",
                    "Ошибка", MessageBoxButtons.OK);
                return;
            }
            numberExemp = t;
            idBook = (int)comboBox1.SelectedValue;
        }
    }
}
