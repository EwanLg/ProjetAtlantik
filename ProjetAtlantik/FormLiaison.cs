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
    public partial class FormLiaison : Form
    {
        private MySqlConnection maCnx;
        private List<Secteur> secteurs = new List<Secteur>();
        private List<Port> ports = new List<Port>();
        private Dictionary<int, List<Port>> portsParSecteur = new Dictionary<int, List<Port>>();
        public FormLiaison(MySqlConnection connexion)
        {
            InitializeComponent();
            this.maCnx = connexion;
            ChargerSecteurs();
            ChargerPorts();
        }
        private void ChargerSecteurs()
        {

            string query = "SELECT noSecteur, nom FROM secteur";

            using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
            using (MySqlDataReader jeuEnr = cmd.ExecuteReader())
            {
                while (jeuEnr.Read())
                {
                    Secteur s = new Secteur(jeuEnr.GetString("nom"), jeuEnr.GetInt32("noSecteur"));
                    secteurs.Add(s);
                    lbxLiaisonSecteur.Items.Add(s);
                }
            }
        }
        private void ChargerPorts()
        {

            string query = "SELECT noPort, nom FROM port";

            using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
            using (MySqlDataReader jeuEnr = cmd.ExecuteReader())
            {
                while (jeuEnr.Read())
                {
                    Port p = new Port(jeuEnr.GetString("nom"), jeuEnr.GetInt32("noPort"));
                    ports.Add(p);
                    cmbLiaisonDepart.Items.Add(p);
                    cmbLiaisonArrivee.Items.Add(p);
                }
            }
        }

        private void btnLiaisonNouvPort_Click(object sender, EventArgs e)
        {
            FormAjouterPort form = new FormAjouterPort(maCnx);
            form.FormClosed += FormAjouterPort_FormClosed;
            form.ShowDialog();
        }
        private void FormAjouterPort_FormClosed(object sender, FormClosedEventArgs e)
        {
            ports.Clear();
            cmbLiaisonDepart.Items.Clear();
            cmbLiaisonArrivee.Items.Clear();
            ChargerPorts();
        }
        private void btnLiaisonNouvSecteur_Click(object sender, EventArgs e)
        {
            FormAjouterSecteur form = new FormAjouterSecteur(maCnx);
            form.FormClosed += FormAjouterSecteur_FormClosed;
            form.ShowDialog();
        }
        private void FormAjouterSecteur_FormClosed(object sender, FormClosedEventArgs e)
        {
            secteurs.Clear();
            lbxLiaisonSecteur.Items.Clear();
            ChargerSecteurs();
    }

        private void btnLiaisonAjouter_Click(object sender, EventArgs e)
        {
            if (cmbLiaisonDepart.SelectedItem == null || cmbLiaisonArrivee.SelectedItem == null || lbxLiaisonSecteur.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un port de départ, un port d'arrivée et un secteur.");
                return;
            }
            Port portDepart = (Port)cmbLiaisonDepart.SelectedItem;
            Port portArrivee = (Port)cmbLiaisonArrivee.SelectedItem;
            Secteur secteur = (Secteur)lbxLiaisonSecteur.SelectedItem;
            if (!double.TryParse(tbxLiaison.Text, out double distance))
            {
                MessageBox.Show("Veuillez entrer une distance valide.");
                return;
            }
            string query = "INSERT INTO liaison (NOPORT_DEPART, NOSECTEUR, NOPORT_ARRIVEE, DISTANCE) " +
                           "VALUES (@portDepart, @secteur, @portArrivee, @distance)";

            using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
            {
                cmd.Parameters.AddWithValue("@portDepart", portDepart.GetNoPort());
                cmd.Parameters.AddWithValue("@secteur", secteur.GetNoSecteur());
                cmd.Parameters.AddWithValue("@portArrivee", portArrivee.GetNoPort());
                cmd.Parameters.AddWithValue("@distance", distance);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Liaison ajoutée avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'ajout de la liaison : {ex.Message}");
                }
            }
        }
    }
}

