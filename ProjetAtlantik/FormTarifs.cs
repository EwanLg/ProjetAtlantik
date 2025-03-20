using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetAtlantik
{
    public partial class FormTarifs : Form
    {
        private MySqlConnection maCnx;
        public FormTarifs(MySqlConnection connexion)
        {
            InitializeComponent();
            this.maCnx = connexion;
        }

        private void FormTarifs_Load(object sender, EventArgs e)
        {
            if (maCnx.State == ConnectionState.Closed)
            {
                maCnx.Open();
            }

            try
            {
                ChargerSecteurs();
                ChargerLiaisons();
                ChargerPeriode();
                if (maCnx.State == ConnectionState.Closed)
                    maCnx.Open();

                string query = "SELECT * FROM type";
                int i = 1;
                Label lblTarifsTypeCategorieText = new Label();
                lblTarifsTypeCategorieText.Text = "Catégorie - Type";
                lblTarifsTypeCategorieText.Location = new Point(5, i * 25);
                gbxTarifsType.Controls.Add(lblTarifsTypeCategorieText);
                Label lblTarifsTypeCategorieText2 = new Label();
                lblTarifsTypeCategorieText2.Text = "Tarif";
                lblTarifsTypeCategorieText2.Location = new Point(125, i * 25);
                gbxTarifsType.Controls.Add(lblTarifsTypeCategorieText2);
                i++;
                MySqlCommand cmd = new MySqlCommand(query, maCnx);
                MySqlDataReader jeuEnr = cmd.ExecuteReader();
                {
                    while (jeuEnr.Read())
                    {
                        Label lblTarifsTypeCategorie = new Label();
                        lblTarifsTypeCategorie.Text = jeuEnr["lettrecategorie"] +  jeuEnr["notype"].ToString() + " - " + jeuEnr["libelle"];
                        lblTarifsTypeCategorie.Location = new Point(5, i * 25);
                        gbxTarifsType.Controls.Add(lblTarifsTypeCategorie);

                        TextBox tbxTarifsTypeCategorie = new TextBox();
                        tbxTarifsTypeCategorie.Tag = jeuEnr["lettrecategorie"] + jeuEnr["notype"].ToString();
                        tbxTarifsTypeCategorie.Location = new Point(125, i * 25);
                        gbxTarifsType.Controls.Add(tbxTarifsTypeCategorie);
                        i++;
                    }
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

        private void ChargerSecteurs()
        {
            string query = "SELECT noSecteur, nom FROM secteur";

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
                        Secteur s = new Secteur(jeuEnr.GetString("nom"), jeuEnr.GetInt32("noSecteur"));
                        lbxTarifsSecteur.Items.Add(s);

                    }
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

        private void ChargerLiaisons()
        {
            string query = "SELECT l.noliaison, l.noport_depart, l.nosecteur, l.noport_arrivee, p1.nom AS nom_port_depart, p2.nom AS nom_port_arrivee FROM liaison l INNER JOIN port p1 ON l.noport_depart = p1.noport INNER JOIN port p2 ON l.noport_arrivee = p2.noport";

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
                        Liaison l = new Liaison(jeuEnr.GetInt32("noport_depart"), jeuEnr.GetInt32("noport_arrivee"), jeuEnr.GetInt32("nosecteur"), jeuEnr.GetInt32("noliaison"));
                        string nomPortDepart = jeuEnr.GetString("nom_port_depart");
                        string nomPortArrivee = jeuEnr.GetString("nom_port_arrivee");
                        cmbTarifsLiaison.Items.Add(nomPortDepart + " -> " + nomPortArrivee);
                    }
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

        private void ChargerPeriode()
        {
            string query = "SELECT datedebut, datefin, noperiode FROM periode";

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
                        Periode pe = new Periode(jeuEnr.GetDateTime("datedebut"), jeuEnr.GetDateTime("datefin"), jeuEnr.GetInt32("noPeriode"));
                        cmbTarifsPeriode.Items.Add(pe);
                    }
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
    }
}
