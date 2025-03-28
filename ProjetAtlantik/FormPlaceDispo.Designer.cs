namespace ProjetAtlantik
{
    partial class FormPlaceDispo
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
            this.lbxPlaceDispoSecteur = new System.Windows.Forms.ListBox();
            this.cmbPlaceDispoLiaison = new System.Windows.Forms.ComboBox();
            this.btnPlaceDispoAfficher = new System.Windows.Forms.Button();
            this.dtpPlaceDispo = new System.Windows.Forms.DateTimePicker();
            this.lblPlaceDispoSecteur = new System.Windows.Forms.Label();
            this.lblPlaceDispoLiaison = new System.Windows.Forms.Label();
            this.lblPlaceDispoDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxPlaceDispoSecteur
            // 
            this.lbxPlaceDispoSecteur.AccessibleName = "lbxPlaceDispoSecteur";
            this.lbxPlaceDispoSecteur.FormattingEnabled = true;
            this.lbxPlaceDispoSecteur.Location = new System.Drawing.Point(56, 64);
            this.lbxPlaceDispoSecteur.Name = "lbxPlaceDispoSecteur";
            this.lbxPlaceDispoSecteur.Size = new System.Drawing.Size(146, 251);
            this.lbxPlaceDispoSecteur.TabIndex = 0;
            // 
            // cmbPlaceDispoLiaison
            // 
            this.cmbPlaceDispoLiaison.AccessibleName = "cmbPlaceDispoLiaison";
            this.cmbPlaceDispoLiaison.FormattingEnabled = true;
            this.cmbPlaceDispoLiaison.Location = new System.Drawing.Point(56, 359);
            this.cmbPlaceDispoLiaison.Name = "cmbPlaceDispoLiaison";
            this.cmbPlaceDispoLiaison.Size = new System.Drawing.Size(159, 21);
            this.cmbPlaceDispoLiaison.TabIndex = 1;
            // 
            // btnPlaceDispoAfficher
            // 
            this.btnPlaceDispoAfficher.AccessibleName = "btnPlaceDispoAfficher";
            this.btnPlaceDispoAfficher.Location = new System.Drawing.Point(373, 117);
            this.btnPlaceDispoAfficher.Name = "btnPlaceDispoAfficher";
            this.btnPlaceDispoAfficher.Size = new System.Drawing.Size(182, 23);
            this.btnPlaceDispoAfficher.TabIndex = 2;
            this.btnPlaceDispoAfficher.Text = "Afficher les traversées";
            this.btnPlaceDispoAfficher.UseVisualStyleBackColor = true;
            this.btnPlaceDispoAfficher.Click += new System.EventHandler(this.btnPlaceDispoAfficher_Click);
            // 
            // dtpPlaceDispo
            // 
            this.dtpPlaceDispo.AccessibleName = "dtpPlaceDispo";
            this.dtpPlaceDispo.Location = new System.Drawing.Point(558, 70);
            this.dtpPlaceDispo.Name = "dtpPlaceDispo";
            this.dtpPlaceDispo.Size = new System.Drawing.Size(168, 20);
            this.dtpPlaceDispo.TabIndex = 3;
            // 
            // lblPlaceDispoSecteur
            // 
            this.lblPlaceDispoSecteur.AccessibleName = "lblPlaceDispoSecteur";
            this.lblPlaceDispoSecteur.AutoSize = true;
            this.lblPlaceDispoSecteur.Location = new System.Drawing.Point(56, 45);
            this.lblPlaceDispoSecteur.Name = "lblPlaceDispoSecteur";
            this.lblPlaceDispoSecteur.Size = new System.Drawing.Size(55, 13);
            this.lblPlaceDispoSecteur.TabIndex = 4;
            this.lblPlaceDispoSecteur.Text = "Secteurs :";
            // 
            // lblPlaceDispoLiaison
            // 
            this.lblPlaceDispoLiaison.AccessibleName = "lblPlaceDispoLiaison";
            this.lblPlaceDispoLiaison.AutoSize = true;
            this.lblPlaceDispoLiaison.Location = new System.Drawing.Point(56, 343);
            this.lblPlaceDispoLiaison.Name = "lblPlaceDispoLiaison";
            this.lblPlaceDispoLiaison.Size = new System.Drawing.Size(46, 13);
            this.lblPlaceDispoLiaison.TabIndex = 5;
            this.lblPlaceDispoLiaison.Text = "Liaison :";
            // 
            // lblPlaceDispoDate
            // 
            this.lblPlaceDispoDate.AccessibleName = "lblPlaceDispoDate";
            this.lblPlaceDispoDate.AutoSize = true;
            this.lblPlaceDispoDate.Location = new System.Drawing.Point(400, 70);
            this.lblPlaceDispoDate.Name = "lblPlaceDispoDate";
            this.lblPlaceDispoDate.Size = new System.Drawing.Size(152, 13);
            this.lblPlaceDispoDate.TabIndex = 6;
            this.lblPlaceDispoDate.Text = "Date (par défaut date du jour) :";
            // 
            // FormPlaceDispo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPlaceDispoDate);
            this.Controls.Add(this.lblPlaceDispoLiaison);
            this.Controls.Add(this.lblPlaceDispoSecteur);
            this.Controls.Add(this.dtpPlaceDispo);
            this.Controls.Add(this.btnPlaceDispoAfficher);
            this.Controls.Add(this.cmbPlaceDispoLiaison);
            this.Controls.Add(this.lbxPlaceDispoSecteur);
            this.Name = "FormPlaceDispo";
            this.Text = "FormPlaceDispo";
            this.Load += new System.EventHandler(this.FormPlaceDispo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPlaceDispoSecteur;
        private System.Windows.Forms.ComboBox cmbPlaceDispoLiaison;
        private System.Windows.Forms.Button btnPlaceDispoAfficher;
        private System.Windows.Forms.DateTimePicker dtpPlaceDispo;
        private System.Windows.Forms.Label lblPlaceDispoSecteur;
        private System.Windows.Forms.Label lblPlaceDispoLiaison;
        private System.Windows.Forms.Label lblPlaceDispoDate;
    }
}