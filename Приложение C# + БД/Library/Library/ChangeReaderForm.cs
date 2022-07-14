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
    public partial class ChangeReaderForm : Form
    {
        public bool isAdd;
        public string surname;
        public string name;
        public string otch;
        public int numberTicket;
        public string login;
        public ChangeReaderForm()
        {
            InitializeComponent();
        }

        private void ChangeReaderForm_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                buttonResetPassword.Enabled = false;
            }
            textBoxSurname.Text = surname;
            textBoxName.Text = name;
            textBoxOtch.Text = otch;
            if (numberTicket != 0)
            {
                textBoxNumberTicket.Text = numberTicket.ToString();
            }
            textBoxLogin.Text = login;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int t;
            if (!int.TryParse(textBoxNumberTicket.Text, out t))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Введите число в поле \"Номер билета\"",
                    "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBoxSurname.Text.Length == 0 || textBoxName.Text.Length == 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Введите фамилию и имя (отчество необязательно)",
                    "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (textBoxLogin.Text.Length == 0 || textBoxLogin.Text.Length > 20)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Введите логин до 20 букв",
                    "Ошибка", MessageBoxButtons.OK);
                return;
            }
            surname = textBoxSurname.Text;
            name = textBoxName.Text;
            otch = textBoxOtch.Text;
            numberTicket = t;
            login = textBoxLogin.Text;
        }
    }
}
