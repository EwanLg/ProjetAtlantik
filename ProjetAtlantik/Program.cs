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
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MySqlConnection maCnx;
            string connectionString = "server=localhost;database=Atlantik;user=root;password=;";
            try
            {
                maCnx = new MySqlConnection(connectionString);
                maCnx.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de connexion à la base de données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ///Application.Run(new FormLiaison(maCnx));
            Application.Run(new FormTarifs(maCnx));

        }
    }
}
