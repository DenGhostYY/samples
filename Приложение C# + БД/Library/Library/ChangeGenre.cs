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
    public partial class ChangeGenreForm : Form
    {
        public string GenreName { get; set; }
        public ChangeGenreForm()
        {
            InitializeComponent();
        }

        private void ChangeGenreForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = GenreName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Введите название жанра", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            GenreName = textBox1.Text;
        }
    }
}
