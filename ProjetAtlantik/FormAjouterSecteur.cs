using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetAtlantik
{
    public partial class FormAjouterSecteur : Form
    {
        private MySqlConnection maCnx;
        public FormAjouterSecteur(MySqlConnection connexion)
        {
            InitializeComponent();
            maCnx = connexion;
        }
        private void btnAjouterSecteur_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO secteur (nom) VALUES (@NomSecteur)";
            maCnx.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
                {
                    cmd.Parameters.AddWithValue("@NomSecteur", tbxAjouterSecteur.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Secteur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxAjouterSecteur.Clear();
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
