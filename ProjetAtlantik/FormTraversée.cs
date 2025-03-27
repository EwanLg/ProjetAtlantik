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
    public partial class FormTraversée : Form
    {
        private MySqlConnection maCnx;
        public FormTraversée(MySqlConnection connexion)
        {
            InitializeComponent();
            this.maCnx = connexion;
            lbxSecteurTraversée.SelectedIndexChanged += lbxSecteurTraversée_SelectedIndexChanged;
        }
        private void FormTraversée_Load(object sender, EventArgs e)
        {
            ChargerSecteurs();
            ChargerNomBateau();
            if (lbxSecteurTraversée.Items.Count > 0)
            {
                lbxSecteurTraversée.SelectedIndex = 0;
                ChargerLiaisons(((Secteur)lbxSecteurTraversée.SelectedItem).GetNoSecteur());
            }
        }
        private void ChargerSecteurs()
        {
            string query = "SELECT noSecteur, nom FROM secteur";
            try
            {
                if (maCnx.State == System.Data.ConnectionState.Closed)
                    maCnx.Open();

                MySqlCommand cmd = new MySqlCommand(query, maCnx);
                MySqlDataReader jeuEnr = cmd.ExecuteReader();
                {
                    while (jeuEnr.Read())
                    {
                        Secteur s = new Secteur(jeuEnr.GetString("nom"), jeuEnr.GetInt32("noSecteur"));
                        lbxSecteurTraversée.Items.Add(s);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur de connexion ou de lecture des secteurs : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (maCnx.State == System.Data.ConnectionState.Open)
                    maCnx.Close();
            }
        }
        private void ChargerLiaisons(int noSecteur)
        {
            cmbLiaisonTraversée.Items.Clear();
            cmbLiaisonTraversée.Text = null;

            string query = @"SELECT l.noliaison, l.noport_depart, l.nosecteur, l.noport_arrivee, 
                        p1.nom AS nom_port_depart, p2.nom AS nom_port_arrivee 
                 FROM liaison l 
                 INNER JOIN port p1 ON l.noport_depart = p1.noport 
                 INNER JOIN port p2 ON l.noport_arrivee = p2.noport
                 WHERE l.nosecteur = @noSecteur";
            if (maCnx.State == ConnectionState.Closed)
            {
                maCnx.Open();
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, maCnx);
                cmd.Parameters.AddWithValue("@noSecteur", noSecteur);
                MySqlDataReader jeuEnr = cmd.ExecuteReader();
                bool hasResults = false;
                    while (jeuEnr.Read())
                    {
                        hasResults = true;
                        string nomPortDepart = jeuEnr.GetString("nom_port_depart");
                        string nomPortArrivee = jeuEnr.GetString("nom_port_arrivee");
                        Liaison l = new Liaison(jeuEnr.GetInt32("noport_depart"), jeuEnr.GetInt32("noport_arrivee"), jeuEnr.GetInt32("nosecteur"), jeuEnr.GetInt32("noliaison"), nomPortDepart, nomPortArrivee);
                        cmbLiaisonTraversée.Items.Add(l);
                    }
                    jeuEnr.Close();
                if (!hasResults)
                {
                    cmbLiaisonTraversée.Items.Clear();
                    cmbLiaisonTraversée.Text = "Aucune liaison pour ce secteur."; 
                    cmbLiaisonTraversée.Enabled = false; 
                }
                else
                {
                    cmbLiaisonTraversée.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }
        }
        private void ChargerNomBateau()
        {
            string query = "SELECT * FROM bateau";
            if (maCnx.State == ConnectionState.Closed)
            {
                maCnx.Open();
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, maCnx);
                MySqlDataReader jeuEnr = cmd.ExecuteReader();
                {
                    while (jeuEnr.Read())
                    {
                        Bateau b = new Bateau(jeuEnr.GetString("nom"), jeuEnr.GetInt32("nobateau"));
                        cmbNomBateauTraversée.Items.Add(b);
                    }
                    jeuEnr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }
        }

        private void lbxSecteurTraversée_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxSecteurTraversée.SelectedItem != null)
            {
                Secteur secteurSelectionne = (Secteur)lbxSecteurTraversée.SelectedItem;
                int noSecteur = secteurSelectionne.GetNoSecteur();
                ChargerLiaisons(noSecteur);
            }
        }
    }
}
