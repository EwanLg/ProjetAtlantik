namespace ProjetAtlantik
{
    partial class FormTraversée
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxSecteurTraversée = new System.Windows.Forms.ListBox();
            this.cmbLiaisonTraversée = new System.Windows.Forms.ComboBox();
            this.cmbNomBateauTraversée = new System.Windows.Forms.ComboBox();
            this.btnAjouterTraversée = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxSecteurTraversée
            // 
            this.lbxSecteurTraversée.AccessibleName = "lbxSecteurTraversée";
            this.lbxSecteurTraversée.FormattingEnabled = true;
            this.lbxSecteurTraversée.Location = new System.Drawing.Point(82, 63);
            this.lbxSecteurTraversée.Name = "lbxSecteurTraversée";
            this.lbxSecteurTraversée.Size = new System.Drawing.Size(120, 238);
            this.lbxSecteurTraversée.TabIndex = 0;
            this.lbxSecteurTraversée.SelectedIndexChanged += new System.EventHandler(this.lbxSecteurTraversée_SelectedIndexChanged);
            // 
            // cmbLiaisonTraversée
            // 
            this.cmbLiaisonTraversée.AccessibleName = "cmbLiaisonTraversée";
            this.cmbLiaisonTraversée.FormattingEnabled = true;
            this.cmbLiaisonTraversée.Location = new System.Drawing.Point(82, 346);
            this.cmbLiaisonTraversée.Name = "cmbLiaisonTraversée";
            this.cmbLiaisonTraversée.Size = new System.Drawing.Size(133, 21);
            this.cmbLiaisonTraversée.TabIndex = 1;
            // 
            // cmbNomBateauTraversée
            // 
            this.cmbNomBateauTraversée.AccessibleName = "cmbNomBateauTraversée";
            this.cmbNomBateauTraversée.FormattingEnabled = true;
            this.cmbNomBateauTraversée.Location = new System.Drawing.Point(404, 63);
            this.cmbNomBateauTraversée.Name = "cmbNomBateauTraversée";
            this.cmbNomBateauTraversée.Size = new System.Drawing.Size(133, 21);
            this.cmbNomBateauTraversée.TabIndex = 2;
            // 
            // btnAjouterTraversée
            // 
            this.btnAjouterTraversée.AccessibleName = "btnAjouterTraversée";
            this.btnAjouterTraversée.Location = new System.Drawing.Point(462, 344);
            this.btnAjouterTraversée.Name = "btnAjouterTraversée";
            this.btnAjouterTraversée.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterTraversée.TabIndex = 3;
            this.btnAjouterTraversée.Text = "Ajouter";
            this.btnAjouterTraversée.UseVisualStyleBackColor = true;
            // 
            // FormTraversée
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAjouterTraversée);
            this.Controls.Add(this.cmbNomBateauTraversée);
            this.Controls.Add(this.cmbLiaisonTraversée);
            this.Controls.Add(this.lbxSecteurTraversée);
            this.Name = "FormTraversée";
            this.Text = "FormTraversée";
            this.Load += new System.EventHandler(this.FormTraversée_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxSecteurTraversée;
        private System.Windows.Forms.ComboBox cmbLiaisonTraversée;
        private System.Windows.Forms.ComboBox cmbNomBateauTraversée;
        private System.Windows.Forms.Button btnAjouterTraversée;
    }
}