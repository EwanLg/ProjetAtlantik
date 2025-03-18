using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            maCnx.Open();
            try
            {
                ChargerSecteurs();
                ChargerPorts();
                ChargerPeriode();
                Button btn;
                int i;
                for (i = 1; i <= 5; i++)
                {
                    btn = new Button();
                    btn.Text = i.ToString();
                    btn.Location = new Point(0, i * 25);
                    gbxTarifsType.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                maCnx.Close();
            }
        }
        private void ChargerSecteurs()
        {
            string query = "SELECT noSecteur, nom FROM secteur";
            maCnx.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
                using (MySqlDataReader jeuEnr = cmd.ExecuteReader())
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
                maCnx.Close();
            }
        }
        private void ChargerPorts()
        {
            string query = "SELECT noPort, nom FROM port";
            maCnx.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
                using (MySqlDataReader jeuEnr = cmd.ExecuteReader())
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
                maCnx.Close();
            }
        }
        private void ChargerPeriode()
        {
            string query = "SELECT datedebut, datefin, noperiode FROM periode";
            maCnx.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
                using (MySqlDataReader jeuEnr = cmd.ExecuteReader())
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
                maCnx.Close();
            }
        }
    }
}