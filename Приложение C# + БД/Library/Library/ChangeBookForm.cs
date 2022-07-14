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
    public partial class ChangeBookForm : Form
    {
        public string bookName;
        public List<CheckItem> checkAuthors = new List<CheckItem>();
        public List<CheckItem> checkGenres = new List<CheckItem>();

        public List<int> insertedAuthors = new List<int>();
        public List<int> deletedAuthors = new List<int>();

        public List<int> insertedGenres = new List<int>();
        public List<int> deletedGenres = new List<int>();
        public ChangeBookForm()
        {
            InitializeComponent();
        }

        private void ChangeBookForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = bookName;
            int size = checkAuthors.Count;
            for (int i = 0; i < size; ++i)
            {
                checkedListBoxAuthor.Items.Add(checkAuthors[i].Name);
                checkedListBoxAuthor.SetItemChecked(i, checkAuthors[i].Check);
            }

            size = checkGenres.Count;
            for (int i = 0; i < size; ++i)
            {
                checkedListBoxGenre.Items.Add(checkGenres[i].Name);
                checkedListBoxGenre.SetItemChecked(i, checkGenres[i].Check);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0/* || checkedListBoxAuthor.CheckedItems.Count == 0
                || checkedListBoxGenre.CheckedItems.Count == 0*/)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Введите название книги и выберите хотя" +
                    "бы одного автора и хотя бы один жанр", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            bookName = textBox1.Text;

            int size = checkAuthors.Count;
            for (int i = 0; i < size; ++i)
            {
                if (checkAuthors[i].Check && !checkedListBoxAuthor.GetItemChecked(i))
                {
                    deletedAuthors.Add(checkAuthors[i].Id);
                }
                else if (!checkAuthors[i].Check && checkedListBoxAuthor.GetItemChecked(i))
                {
                    insertedAuthors.Add(checkAuthors[i].Id);
                }
            }

            size = checkGenres.Count;
            for (int i = 0; i < size; ++i)
            {
                if (checkGenres[i].Check && !checkedListBoxGenre.GetItemChecked(i))
                {
                    deletedGenres.Add(checkGenres[i].Id);
                }
                else if (!checkGenres[i].Check && checkedListBoxGenre.GetItemChecked(i))
                {
                    insertedGenres.Add(checkGenres[i].Id);
                }
            }
        }
    }
}
