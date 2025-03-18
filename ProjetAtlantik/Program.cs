using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetAtlantik
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MySqlConnection maCnx;
            string connectionString = "server=localhost;database=Atlantik;user=root;password=;";
            maCnx = new MySqlConnection(connectionString);
            Application.Run(new FormTarifs(maCnx));

        }
    }
}
