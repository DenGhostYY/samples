using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    static class Program
    {
        public static SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder();
        public static int UserCode;
        public static Guid ReaderID;
        public static string ReaderFIO;
        public static int ReaderTicket;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
