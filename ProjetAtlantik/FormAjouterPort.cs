using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetAtlantik
{
    public partial class FormAjouterPort : Form
    {
        private MySqlConnection conn;
        public FormAjouterPort(MySqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void btnAjouterPort_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO port (nom) VALUES (@NomPort)";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomPort", tbxAjouterPort.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Port ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxAjouterPort.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur d'insertion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAjouterPort_Load(object sender, EventArgs e)
        {

        }
    }
}
