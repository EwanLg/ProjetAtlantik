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
    public partial class FormModifierBateau : Form
    {
        private MySqlConnection maCnx;
        public FormModifierBateau(MySqlConnection connexion)
        {
            InitializeComponent();
            this.maCnx = connexion;
        }

        private void FormModifierBateau_Load(object sender, EventArgs e)
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
                        cmbModifierBateau.Items.Add(b);
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
        private void ChargerCapacite(int noBateau)
        {
            gbxCapacitesModifierBateau.Controls.Clear();
            try
                {

                    if (maCnx.State == ConnectionState.Closed)
                        maCnx.Open();

                    string query = "SELECT * FROM categorie";
                    int i = 1;
                    MySqlCommand cmd = new MySqlCommand(query, maCnx);
                    MySqlDataReader jeuEnr = cmd.ExecuteReader();
                    {
                        while (jeuEnr.Read())
                        {
                            Label lblCategorie = new Label();
                            lblCategorie.Text = jeuEnr["lettrecategorie"] + " (" + jeuEnr["libelle"] + " ) : ";
                            lblCategorie.Location = new Point(10, i * 50);
                            gbxCapacitesModifierBateau.Controls.Add(lblCategorie);

                            TextBox tbxCategorie = new TextBox();
                            tbxCategorie.Text = jeuEnr["lettrecategorie"] + " (" + jeuEnr["libelle"] + " ) : ";
                            tbxCategorie.Tag = jeuEnr["lettrecategorie"];
                            tbxCategorie.Location = new Point(125, i * 50);
                            gbxCapacitesModifierBateau.Controls.Add(tbxCategorie);
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

        private void cmbModifierBateau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModifierBateau.SelectedItem != null)
            {
                Bateau bateauSelectionner = (Bateau)cmbModifierBateau.SelectedItem;
                int noBateau = bateauSelectionner.GetNoBateau();
                ChargerCapacite(noBateau);
            }
        }
    }
    }
