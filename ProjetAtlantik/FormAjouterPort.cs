using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetAtlantik
{
    public partial class FormAjouterPort : Form
    {
        private MySqlConnection maCnx;
        public FormAjouterPort(MySqlConnection connexion)
        {
            InitializeComponent();
            maCnx = connexion;
        }

        private void btnAjouterPort_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO port (nom) VALUES (@NomPort)";
            maCnx.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
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
            finally
            {
                maCnx.Close();
            }
        }
    }
}
