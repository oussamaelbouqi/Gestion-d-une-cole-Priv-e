namespace ESPEJIC.Usercontrol_Absence
{
    partial class UserControlMos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMos));
            this.dgvstagaire = new System.Windows.Forms.DataGridView();
            this.Cin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_heures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom_de_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Justify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Montant_par_m = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mdf = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.n_h_txt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstagaire)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvstagaire
            // 
            this.dgvstagaire.AllowUserToDeleteRows = false;
            this.dgvstagaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvstagaire.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvstagaire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvstagaire.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvstagaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstagaire.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cin,
            this.Nom,
            this.Prenom,
            this.Nombre_heures,
            this.Nom_de_model,
            this.Justify,
            this.Montant_par_m});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvstagaire.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvstagaire.Location = new System.Drawing.Point(0, 274);
            this.dgvstagaire.Name = "dgvstagaire";
            this.dgvstagaire.ReadOnly = true;
            this.dgvstagaire.Size = new System.Drawing.Size(1042, 317);
            this.dgvstagaire.TabIndex = 26;
            this.dgvstagaire.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstagaire_CellContentClick);
            // 
            // Cin
            // 
            this.Cin.HeaderText = "CIN";
            this.Cin.Name = "Cin";
            this.Cin.ReadOnly = true;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            // 
            // Prenom
            // 
            this.Prenom.HeaderText = "Prenom";
            this.Prenom.Name = "Prenom";
            this.Prenom.ReadOnly = true;
            // 
            // Nombre_heures
            // 
            this.Nombre_heures.HeaderText = "Nombre d\'heures";
            this.Nombre_heures.Name = "Nombre_heures";
            this.Nombre_heures.ReadOnly = true;
            // 
            // Nom_de_model
            // 
            this.Nom_de_model.HeaderText = "Nom de Module";
            this.Nom_de_model.Name = "Nom_de_model";
            this.Nom_de_model.ReadOnly = true;
            // 
            // Justify
            // 
            this.Justify.HeaderText = "Justification";
            this.Justify.Name = "Justify";
            this.Justify.ReadOnly = true;
            // 
            // Montant_par_m
            // 
            this.Montant_par_m.HeaderText = "Date";
            this.Montant_par_m.Name = "Montant_par_m";
            this.Montant_par_m.ReadOnly = true;
            // 
            // Mdf
            // 
            this.Mdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.Mdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Mdf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mdf.ForeColor = System.Drawing.Color.White;
            this.Mdf.Image = ((System.Drawing.Image)(resources.GetObject("Mdf.Image")));
            this.Mdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Mdf.Location = new System.Drawing.Point(288, 894);
            this.Mdf.Name = "Mdf";
            this.Mdf.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.Mdf.Size = new System.Drawing.Size(183, 49);
            this.Mdf.TabIndex = 0;
            this.Mdf.Text = "             Modifier";
            this.Mdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Mdf.UseVisualStyleBackColor = false;
            this.Mdf.Click += new System.EventHandler(this.Mdf_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.Supprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Supprimer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supprimer.ForeColor = System.Drawing.Color.White;
            this.Supprimer.Image = global::ESPEJIC.Properties.Resources.Delete_User_Male2;
            this.Supprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Supprimer.Location = new System.Drawing.Point(581, 894);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.Supprimer.Size = new System.Drawing.Size(183, 49);
            this.Supprimer.TabIndex = 0;
            this.Supprimer.Text = "             Supprimer";
            this.Supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Supprimer.UseVisualStyleBackColor = false;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(141, 652);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 31);
            this.label4.TabIndex = 45;
            this.label4.Text = "CIN:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(212, 703);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(259, 38);
            this.textBox1.TabIndex = 44;
            // 
            // comboBox3
            // 
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(212, 813);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(259, 39);
            this.comboBox3.TabIndex = 43;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Location = new System.Drawing.Point(737, 763);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(259, 29);
            this.dateTimePicker1.TabIndex = 42;
            // 
            // n_h_txt
            // 
            this.n_h_txt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.n_h_txt.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.n_h_txt.Location = new System.Drawing.Point(737, 706);
            this.n_h_txt.Margin = new System.Windows.Forms.Padding(2);
            this.n_h_txt.Name = "n_h_txt";
            this.n_h_txt.Size = new System.Drawing.Size(259, 38);
            this.n_h_txt.TabIndex = 41;
            this.n_h_txt.Leave += new System.EventHandler(this.n_h_txt_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(212, 758);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(259, 38);
            this.textBox2.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(632, 763);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 31);
            this.label9.TabIndex = 39;
            this.label9.Text = "La date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(531, 709);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 31);
            this.label8.TabIndex = 38;
            this.label8.Text = "Nombre d\'heures:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(24, 816);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 31);
            this.label7.TabIndex = 37;
            this.label7.Text = "Nom de model:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(99, 761);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 31);
            this.label6.TabIndex = 36;
            this.label6.Text = "Prenom:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(128, 706);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 31);
            this.label5.TabIndex = 35;
            this.label5.Text = "Nom:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(212, 649);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(259, 38);
            this.textBox3.TabIndex = 46;
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(773, 197);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 45);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(433, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 30);
            this.label2.TabIndex = 47;
            this.label2.Text = "Recherche le stagaire par classe :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(939, 962);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 49;
            this.textBox4.Visible = false;
            // 
            // comboBox4
            // 
            this.comboBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(737, 649);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(259, 39);
            this.comboBox4.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(589, 653);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 31);
            this.label1.TabIndex = 50;
            this.label1.Text = "Justification:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(393, 37);
            this.label3.TabIndex = 54;
            this.label3.Text = "Modifier l\'absence du Stagiaire";
            // 
            // UserControlMos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.n_h_txt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Mdf);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.dgvstagaire);
            this.Name = "UserControlMos";
            this.Size = new System.Drawing.Size(1042, 985);
            this.Load += new System.EventHandler(this.UserControlMos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstagaire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Supprimer;
        private System.Windows.Forms.Button Mdf;
        private System.Windows.Forms.DataGridView dgvstagaire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox n_h_txt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_heures;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom_de_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Justify;
        private System.Windows.Forms.DataGridViewTextBoxColumn Montant_par_m;
        private System.Windows.Forms.Label label3;
    }
}
