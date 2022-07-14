using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class ChangeAuthorForm : Form
    {
        public string AuthorSurname { get; set; }
        public string AuthorName { get; set; }
        public string AuthorOtch { get; set; }
        public ChangeAuthorForm()
        {
            InitializeComponent();
        }

        private void ChangeAuthorForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = AuthorSurname;
            textBox2.Text = AuthorName;
            textBox3.Text = AuthorOtch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Обязательно введите фамилию и имя автора", "Ошибка",
                    MessageBoxButtons.OK);
                return;
            }
            AuthorSurname = textBox1.Text;
            AuthorName = textBox2.Text;
            AuthorOtch = textBox3.Text;
        }
    }
}
