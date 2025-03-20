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
                ChargerPorts();
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
            finally
            {
                if (maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }
        }

        private void ChargerPorts()
        {
            string query = "SELECT noPort, nom FROM port";

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
                        Port p = new Port(jeuEnr.GetString("nom"), jeuEnr.GetInt32("noPort"));
                        cmbTarifsPort.Items.Add(p);
                    }
                }
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
