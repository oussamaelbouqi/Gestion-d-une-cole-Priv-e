namespace ESPEJIC.UserControl_Fichers
{
    partial class Demande_de_stage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.N_Ins = new System.Windows.Forms.TextBox();
            this.Cin_txt = new System.Windows.Forms.TextBox();
            this.Nom_label = new System.Windows.Forms.Label();
            this.Pre_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pre_label = new System.Windows.Forms.Label();
            this.Cin_label = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Nom_txt = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.75F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(785, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 33);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.75F, System.Drawing.FontStyle.Bold);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(786, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(228, 33);
            this.comboBox2.TabIndex = 22;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(609, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nom du Stagiaire :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(704, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Classe :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(427, 744);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 58);
            this.panel2.TabIndex = 71;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Image = global::ESPEJIC.Properties.Resources.Scanner;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-13, -19);
            this.button1.Margin = new System.Windows.Forms.Padding(40);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(30, 15, 15, 15);
            this.button1.Size = new System.Drawing.Size(212, 96);
            this.button1.TabIndex = 25;
            this.button1.Text = "      Imprimer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(190, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 40);
            this.label5.TabIndex = 70;
            this.label5.Text = "N°inscription";
            // 
            // N_Ins
            // 
            this.N_Ins.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.N_Ins.Location = new System.Drawing.Point(414, 226);
            this.N_Ins.Margin = new System.Windows.Forms.Padding(40);
            this.N_Ins.Multiline = true;
            this.N_Ins.Name = "N_Ins";
            this.N_Ins.Size = new System.Drawing.Size(386, 57);
            this.N_Ins.TabIndex = 53;
            // 
            // Cin_txt
            // 
            this.Cin_txt.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cin_txt.Location = new System.Drawing.Point(414, 476);
            this.Cin_txt.Margin = new System.Windows.Forms.Padding(40);
            this.Cin_txt.Multiline = true;
            this.Cin_txt.Name = "Cin_txt";
            this.Cin_txt.Size = new System.Drawing.Size(386, 57);
            this.Cin_txt.TabIndex = 58;
            // 
            // Nom_label
            // 
            this.Nom_label.AutoSize = true;
            this.Nom_label.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nom_label.Location = new System.Drawing.Point(190, 311);
            this.Nom_label.Margin = new System.Windows.Forms.Padding(40);
            this.Nom_label.Name = "Nom_label";
            this.Nom_label.Size = new System.Drawing.Size(82, 40);
            this.Nom_label.TabIndex = 54;
            this.Nom_label.Text = "Nom";
            // 
            // Pre_txt
            // 
            this.Pre_txt.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pre_txt.Location = new System.Drawing.Point(414, 390);
            this.Pre_txt.Margin = new System.Windows.Forms.Padding(40);
            this.Pre_txt.Multiline = true;
            this.Pre_txt.Name = "Pre_txt";
            this.Pre_txt.Size = new System.Drawing.Size(386, 57);
            this.Pre_txt.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(190, 564);
            this.label4.Margin = new System.Windows.Forms.Padding(40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 40);
            this.label4.TabIndex = 75;
            this.label4.Text = "Date début";
            // 
            // pre_label
            // 
            this.pre_label.AutoSize = true;
            this.pre_label.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pre_label.Location = new System.Drawing.Point(190, 395);
            this.pre_label.Margin = new System.Windows.Forms.Padding(40);
            this.pre_label.Name = "pre_label";
            this.pre_label.Size = new System.Drawing.Size(120, 40);
            this.pre_label.TabIndex = 56;
            this.pre_label.Text = "Prénom";
            // 
            // Cin_label
            // 
            this.Cin_label.AutoSize = true;
            this.Cin_label.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cin_label.Location = new System.Drawing.Point(190, 481);
            this.Cin_label.Margin = new System.Windows.Forms.Padding(40);
            this.Cin_label.Name = "Cin_label";
            this.Cin_label.Size = new System.Drawing.Size(98, 40);
            this.Cin_label.TabIndex = 59;
            this.Cin_label.Text = "N°CIN";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Location = new System.Drawing.Point(414, 565);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(386, 39);
            this.dateTimePicker1.TabIndex = 72;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Location = new System.Drawing.Point(414, 636);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(386, 39);
            this.dateTimePicker2.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 632);
            this.label3.Margin = new System.Windows.Forms.Padding(40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 40);
            this.label3.TabIndex = 74;
            this.label3.Text = "Date fin";
            // 
            // Nom_txt
            // 
            this.Nom_txt.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nom_txt.Location = new System.Drawing.Point(414, 308);
            this.Nom_txt.Margin = new System.Windows.Forms.Padding(40);
            this.Nom_txt.Multiline = true;
            this.Nom_txt.Name = "Nom_txt";
            this.Nom_txt.Size = new System.Drawing.Size(386, 57);
            this.Nom_txt.TabIndex = 55;
            // 
            // Demande_de_stage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.N_Ins);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cin_label);
            this.Controls.Add(this.pre_label);
            this.Controls.Add(this.Nom_txt);
            this.Controls.Add(this.Pre_txt);
            this.Controls.Add(this.Nom_label);
            this.Controls.Add(this.Cin_txt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Demande_de_stage";
            this.Size = new System.Drawing.Size(1048, 870);
            this.Load += new System.EventHandler(this.Demande_de_stage_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox N_Ins;
        private System.Windows.Forms.TextBox Cin_txt;
        private System.Windows.Forms.Label Nom_label;
        private System.Windows.Forms.TextBox Pre_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label pre_label;
        private System.Windows.Forms.Label Cin_label;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Nom_txt;
    }
}
