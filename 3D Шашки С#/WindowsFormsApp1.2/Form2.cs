using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public string NameFirstGamer {
            get { return nameFirstGamerTextBox.Text; }
            set { nameFirstGamerTextBox.Text = value; }
        }
        public string NameSecondGamer {
            get { return nameSecondGamerTextBox.Text; }
            set { nameSecondGamerTextBox.Text = value; }
        }
        public Form2()
        {
            InitializeComponent();
            NameFirstGamer = "Игрок 1";
            NameSecondGamer = "Игрок 2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
