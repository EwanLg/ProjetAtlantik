﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetAtlantik
{
    public partial class FormAjouterSecteur : Form
    {
        private MySqlConnection conn;
        public FormAjouterSecteur(MySqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }
        private void btnAjouterSecteur_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO secteur (nom) VALUES (@NomSecteur)";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
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
        }
    }
}
