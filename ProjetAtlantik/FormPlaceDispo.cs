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
    public partial class FormPlaceDispo : Form
    {
        private MySqlConnection maCnx;
        public FormPlaceDispo(MySqlConnection connexion)
        {
            InitializeComponent();
            this.maCnx = connexion;
            lbxPlaceDispoSecteur.SelectedIndexChanged += lbxPlaceDispoSecteur_SelectedIndexChanged;
        }

        private void FormPlaceDispo_Load(object sender, EventArgs e)
        {
            ChargerSecteurs();
            dtpPlaceDispo.CustomFormat = "MM/dd/yyyy";
            dtpPlaceDispo.Format = DateTimePickerFormat.Custom;
            if (lbxPlaceDispoSecteur.Items.Count > 0)
            {
                lbxPlaceDispoSecteur.SelectedIndex = 0;
                ChargerLiaisons(((Secteur)lbxPlaceDispoSecteur.SelectedItem).GetNoSecteur());
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
                        lbxPlaceDispoSecteur.Items.Add(s);
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
            cmbPlaceDispoLiaison.Items.Clear();
            cmbPlaceDispoLiaison.Text = null;
            int i = 0;

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
                    i++;
                    string nomPortDepart = jeuEnr.GetString("nom_port_depart");
                    string nomPortArrivee = jeuEnr.GetString("nom_port_arrivee");
                    Liaison l = new Liaison(jeuEnr.GetInt32("noport_depart"), jeuEnr.GetInt32("noport_arrivee"), jeuEnr.GetInt32("nosecteur"), jeuEnr.GetInt32("noliaison"), nomPortDepart, nomPortArrivee);
                    cmbPlaceDispoLiaison.Items.Add(l);
                }
                jeuEnr.Close();
                if (!hasResults)
                {
                    cmbPlaceDispoLiaison.Items.Clear();
                    cmbPlaceDispoLiaison.Text = "Aucune liaison pour ce secteur.";
                    cmbPlaceDispoLiaison.Enabled = false;
                }
                else
                {
                    cmbPlaceDispoLiaison.Text = i + " liaisons disponibles.";
                    cmbPlaceDispoLiaison.Enabled = true;
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
        private void ChargerPlaceDispo()
        {
            if (cmbPlaceDispoLiaison.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une liaison.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Liaison liaisonSelectionnee = (Liaison)cmbPlaceDispoLiaison.SelectedItem;
            DateTime dateSelectionnee = dtpPlaceDispo.Value.Date;

            string query = @"SELECT 
    t.NOTRAVERSEE, 
    t.DATEHEUREDEPART AS HEURE_DEPART, 
    b.NOM AS NOM_BATEAU,
    -- Nombre de places disponibles pour les passagers A
    (c.CAPACITEMAX - IFNULL(SUM(CASE WHEN e.LETTRECATEGORIE = 'A' THEN e.QUANTITERESERVEE ELSE 0 END), 0)) AS A_PASSAGER,
    -- Nombre de places disponibles pour les véhicules inférieurs à 2m (B)
    (c.CAPACITEMAX - IFNULL(SUM(CASE WHEN e.LETTRECATEGORIE = 'B' THEN e.QUANTITERESERVEE ELSE 0 END), 0)) AS B_VEH_INF_2M,
    -- Nombre de places disponibles pour les véhicules supérieurs à 2m (C)
    (c.CAPACITEMAX - IFNULL(SUM(CASE WHEN e.LETTRECATEGORIE = 'C' THEN e.QUANTITERESERVEE ELSE 0 END), 0)) AS C_VEH_SUP_2M
FROM 
    traversee t
JOIN 
    bateau b ON t.NOBATEAU = b.NOBATEAU
JOIN 
    contenir c ON b.NOBATEAU = c.NOBATEAU
LEFT JOIN 
    enregistrer e ON e.NOTRAVERSEE = t.NOTRAVERSEE
JOIN 
    liaison l ON t.NOLIAISON = l.NOLIAISON
WHERE 
    l.NOLIAISON = @LiaisonId
    AND t.DATEHEUREDEPART >= @Date
GROUP BY 
    t.NOTRAVERSEE, t.DATEHEUREDEPART, b.NOM, c.CAPACITEMAX
ORDER BY 
    t.DATEHEUREDEPART;
";

            try
            {
                if (maCnx.State == ConnectionState.Closed)
                    maCnx.Open();

                MySqlCommand cmd = new MySqlCommand(query, maCnx);
                cmd.Parameters.AddWithValue("@LiaisonId", liaisonSelectionnee.GetNoLiaison());
                cmd.Parameters.AddWithValue("@Date", dateSelectionnee);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataView dataView = new DataView(dt);
                dataView.ToTable(true, "NOTRAVERSEE", "HEURE_DEPART", "NOM_BATEAU", "A_PASSAGER", "B_VEH_INF_2M", "C_VEH_SUP_2M");

                dgvPlaceDispo.DataSource = dataView;

                dgvPlaceDispo.Columns["NOTRAVERSEE"].HeaderText = "No traversée";
                dgvPlaceDispo.Columns["HEURE_DEPART"].HeaderText = "Heure";
                dgvPlaceDispo.Columns["NOM_BATEAU"].HeaderText = "Bateau";
                dgvPlaceDispo.Columns["A_PASSAGER"].HeaderText = "A passager";
                dgvPlaceDispo.Columns["B_VEH_INF_2M"].HeaderText = "B véh.inf.2m";
                dgvPlaceDispo.Columns["C_VEH_SUP_2M"].HeaderText = "C véh.sup.2m";

                dgvPlaceDispo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPlaceDispo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors du chargement des places disponibles : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (maCnx.State == ConnectionState.Open)
                    maCnx.Close();
            }
        }


        private void lbxPlaceDispoSecteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxPlaceDispoSecteur.SelectedItem != null)
            {
                Secteur secteurSelectionne = (Secteur)lbxPlaceDispoSecteur.SelectedItem;
                int noSecteur = secteurSelectionne.GetNoSecteur();
                ChargerLiaisons(noSecteur);
            }
        }
        private void btnPlaceDispoAfficher_Click(object sender, EventArgs e)
        {
            ChargerPlaceDispo();
        }
    }
}
