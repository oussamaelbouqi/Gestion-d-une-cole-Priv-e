namespace ESPEJIC.UserControl_Formatteur
{
    partial class Modifier_F
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modifier_F));
            this.textBox1CIN = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Matricul = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nom_for = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pre_for = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CIN_for = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sexe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Addr_for = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tele = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date_Naissance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.N_scolaire = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Exper_for = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Statut_for = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sold_par_h = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Mdf = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Supprimer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1CIN
            // 
            this.textBox1CIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1CIN.Location = new System.Drawing.Point(0, 2);
            this.textBox1CIN.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1CIN.Multiline = true;
            this.textBox1CIN.Name = "textBox1CIN";
            this.textBox1CIN.Size = new System.Drawing.Size(10, 38);
            this.textBox1CIN.TabIndex = 0;
            this.textBox1CIN.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.AllowColumnReorder = true;
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Matricul,
            this.Nom_for,
            this.Pre_for,
            this.CIN_for,
            this.Sexe,
            this.Email,
            this.Addr_for,
            this.Tele,
            this.Date_Naissance,
            this.N_scolaire,
            this.Exper_for,
            this.Statut_for,
            this.Sold_par_h});
            this.listView1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.listView1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 323);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1048, 133);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Matricul
            // 
            this.Matricul.Text = "Matrucil";
            this.Matricul.Width = 100;
            // 
            // Nom_for
            // 
            this.Nom_for.Text = "Nom Formatteur";
            this.Nom_for.Width = 140;
            // 
            // Pre_for
            // 
            this.Pre_for.Text = "Prénom Formatteur";
            this.Pre_for.Width = 150;
            // 
            // CIN_for
            // 
            this.CIN_for.Text = "CIN";
            this.CIN_for.Width = 55;
            // 
            // Sexe
            // 
            this.Sexe.Text = "Genre";
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 55;
            // 
            // Addr_for
            // 
            this.Addr_for.Text = "Adresse";
            this.Addr_for.Width = 70;
            // 
            // Tele
            // 
            this.Tele.Text = "Téléphone";
            this.Tele.Width = 85;
            // 
            // Date_Naissance
            // 
            this.Date_Naissance.Text = "Date Naissance";
            this.Date_Naissance.Width = 120;
            // 
            // N_scolaire
            // 
            this.N_scolaire.Text = "N_Scolaire";
            this.N_scolaire.Width = 90;
            // 
            // Exper_for
            // 
            this.Exper_for.Text = "Experience";
            this.Exper_for.Width = 85;
            // 
            // Statut_for
            // 
            this.Statut_for.Text = "Statut";
            this.Statut_for.Width = 70;
            // 
            // Sold_par_h
            // 
            this.Sold_par_h.Text = "Solde par heure";
            this.Sold_par_h.Width = 130;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Mdf);
            this.panel1.Location = new System.Drawing.Point(308, 502);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 49);
            this.panel1.TabIndex = 3;
            // 
            // Mdf
            // 
            this.Mdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.Mdf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mdf.ForeColor = System.Drawing.Color.White;
            this.Mdf.Image = ((System.Drawing.Image)(resources.GetObject("Mdf.Image")));
            this.Mdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Mdf.Location = new System.Drawing.Point(-6, -27);
            this.Mdf.Name = "Mdf";
            this.Mdf.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.Mdf.Size = new System.Drawing.Size(228, 103);
            this.Mdf.TabIndex = 0;
            this.Mdf.Text = "             Modifier";
            this.Mdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Mdf.UseVisualStyleBackColor = false;
            this.Mdf.Click += new System.EventHandler(this.Mdf_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Supprimer);
            this.panel2.Location = new System.Drawing.Point(549, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 49);
            this.panel2.TabIndex = 4;
            // 
            // Supprimer
            // 
            this.Supprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.Supprimer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supprimer.ForeColor = System.Drawing.Color.White;
            this.Supprimer.Image = global::ESPEJIC.Properties.Resources.Delete_User_Male2;
            this.Supprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Supprimer.Location = new System.Drawing.Point(-6, -27);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.Supprimer.Size = new System.Drawing.Size(228, 103);
            this.Supprimer.TabIndex = 0;
            this.Supprimer.Text = "             Supprimer";
            this.Supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Supprimer.UseVisualStyleBackColor = false;
            this.Supprimer.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(499, 37);
            this.label2.TabIndex = 54;
            this.label2.Text = "Modifier les informations du Formateur";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(740, 161);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(279, 38);
            this.comboBox3.TabIndex = 60;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(435, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(301, 30);
            this.label8.TabIndex = 59;
            this.label8.Text = "Recherche par Nom Complet :";
            // 
            // Modifier_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1CIN);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Modifier_F";
            this.Size = new System.Drawing.Size(1042, 985);
            this.Load += new System.EventHandler(this.Modifier_F_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Mdf;
        private System.Windows.Forms.TextBox textBox1CIN;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Matricul;
        private System.Windows.Forms.ColumnHeader Nom_for;
        private System.Windows.Forms.ColumnHeader Pre_for;
        private System.Windows.Forms.ColumnHeader CIN_for;
        private System.Windows.Forms.ColumnHeader Sexe;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Addr_for;
        private System.Windows.Forms.ColumnHeader Tele;
        private System.Windows.Forms.ColumnHeader Date_Naissance;
        private System.Windows.Forms.ColumnHeader N_scolaire;
        private System.Windows.Forms.ColumnHeader Exper_for;
        private System.Windows.Forms.ColumnHeader Statut_for;
        private System.Windows.Forms.ColumnHeader Sold_par_h;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Supprimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
    }
}
