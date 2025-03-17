namespace ProjetAtlantik
{
    partial class FormTarifs
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
            this.lbxTarifsSecteur = new System.Windows.Forms.ListBox();
            this.cmbTarifsPort = new System.Windows.Forms.ComboBox();
            this.cmbTarifsPeriode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbxTarifsSecteur
            // 
            this.lbxTarifsSecteur.AccessibleName = "lbxTarifsSecteur";
            this.lbxTarifsSecteur.FormattingEnabled = true;
            this.lbxTarifsSecteur.Location = new System.Drawing.Point(43, 38);
            this.lbxTarifsSecteur.Name = "lbxTarifsSecteur";
            this.lbxTarifsSecteur.Size = new System.Drawing.Size(120, 212);
            this.lbxTarifsSecteur.TabIndex = 0;
            // 
            // cmbTarifsPort
            // 
            this.cmbTarifsPort.AccessibleName = "cmbTarifsPort";
            this.cmbTarifsPort.FormattingEnabled = true;
            this.cmbTarifsPort.Location = new System.Drawing.Point(43, 306);
            this.cmbTarifsPort.Name = "cmbTarifsPort";
            this.cmbTarifsPort.Size = new System.Drawing.Size(120, 21);
            this.cmbTarifsPort.TabIndex = 1;
            // 
            // cmbTarifsPeriode
            // 
            this.cmbTarifsPeriode.AccessibleName = "cmbTarifsPeriode";
            this.cmbTarifsPeriode.FormattingEnabled = true;
            this.cmbTarifsPeriode.Location = new System.Drawing.Point(201, 362);
            this.cmbTarifsPeriode.Name = "cmbTarifsPeriode";
            this.cmbTarifsPeriode.Size = new System.Drawing.Size(173, 21);
            this.cmbTarifsPeriode.TabIndex = 2;
            // 
            // FormTarifs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTarifsPeriode);
            this.Controls.Add(this.cmbTarifsPort);
            this.Controls.Add(this.lbxTarifsSecteur);
            this.Name = "FormTarifs";
            this.Text = "FormTarifs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTarifsSecteur;
        private System.Windows.Forms.ComboBox cmbTarifsPort;
        private System.Windows.Forms.ComboBox cmbTarifsPeriode;
    }
}