using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Library
{
    public partial class Form1 : Form
    {
        public SqlConnection cnn = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.bld.ConnectionString = ConfigurationManager.ConnectionStrings[
                "Library.Properties.Settings.ChumakovLibraryConnectionString"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.bld.UserID = "ГОСТЬ";
            Program.bld.Password = "";

            try
            {
                cnn = new SqlConnection(Program.bld.ConnectionString);
                SqlCommand cmd = new SqlCommand("dbo.CHECK_PSW", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@login", SqlDbType.VarChar, 20);
                cmd.Parameters["@login"].Value = textBox1.Text;

                cmd.Parameters.Add("@psw", SqlDbType.VarChar, 20);
                cmd.Parameters["@psw"].Value = textBox2.Text;

                cnn.Open();

                //выполнить CHECK_PSW
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {  // если библиотекарь
                    Program.UserCode = (int)dr[0];
                    Program.bld.UserID = dr[1].ToString();
                    Program.bld.Password = dr[2].ToString();
                }
                else
                {
                    dr.NextResult();
                    if (!dr.Read())
                    {
                        //исключение в случае ошибки
                        throw new Exception("Неверен логин или пароль");
                    }
                    // если читатель
                    Program.UserCode = (int)dr[0];
                    Program.bld.UserID = dr[1].ToString();
                    Program.bld.Password = dr[2].ToString();
                    
                    Program.ReaderID = (Guid)dr[3];
                    Program.ReaderFIO = dr[4].ToString();
                    Program.ReaderTicket = (int)dr[5];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                //в любом случае
                cnn.Close();
            }

            // сменить пользователя
            textBox2.Text = "";
            if (Program.UserCode == 1)
            {
                // читатель
                Form2 frm2 = new Form2(this);
                this.Hide();
                frm2.Show();
            }
            else
            {
                // библиотекарь
                Form3 frm3 = new Form3(this);
                this.Hide();
                frm3.Show();
            }
        }
    }
}
