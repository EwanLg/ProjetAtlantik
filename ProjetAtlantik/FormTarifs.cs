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
    public partial class FormTarifs : Form
    {
        private MySqlConnection maCnx;
        private List<Secteur> secteurs = new List<Secteur>();
        private List<Port> ports = new List<Port>();
        private List<Periode> periodes = new List<Periode>();
        public FormTarifs(MySqlConnection connexion)
        {
            InitializeComponent();
            this.maCnx = connexion;
            ChargerSecteurs();
            ChargerPorts();
            ChargerPeriode();
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
                    lbxTarifsSecteur.Items.Add(s);
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
                    cmbTarifsPort.Items.Add(p);
                }
            }
        }
        private void ChargerPeriode()
        {

            string query = "SELECT datedebut, datefin, noperiode FROM periode";

            using (MySqlCommand cmd = new MySqlCommand(query, maCnx))
            using (MySqlDataReader jeuEnr = cmd.ExecuteReader())
            {
                while (jeuEnr.Read())
                {
                    Periode pe = new Periode(jeuEnr.GetDateTime("datedebut"), jeuEnr.GetDateTime("datefin"), jeuEnr.GetInt32("noPeriode"));
                    periodes.Add(pe);
                    cmbTarifsPeriode.Items.Add(pe);
                }
            }
        }
    }
}
