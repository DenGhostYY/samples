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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (newPassword.Text != repeatNewPassword.Text)
            {
                MessageBox.Show("Новый пароль и повторенный не совпадают", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            SqlConnection cnn = new SqlConnection();
            try {
                cnn = new SqlConnection(Program.bld.ConnectionString);
                SqlCommand cmd = new SqlCommand("dbo.CHANGE_PSW", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@numberTicket", SqlDbType.Int);
                cmd.Parameters["@numberTicket"].Value = Program.ReaderTicket;

                cmd.Parameters.Add("@oldPsw", SqlDbType.VarChar, 20);
                cmd.Parameters["@oldPsw"].Value = oldPassword.Text;

                cmd.Parameters.Add("@newPsw", SqlDbType.VarChar, 20);
                cmd.Parameters["@newPsw"].Value = newPassword.Text;

                cnn.Open();

                //выполнить CHANGE_PSW
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
            MessageBox.Show("Пароль успешно сменен", "Сообщение", MessageBoxButtons.OK);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
