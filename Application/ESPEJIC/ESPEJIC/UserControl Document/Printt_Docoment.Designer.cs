namespace ESPEJIC.UserControl_Document
{
    partial class Printt_Docoment
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
            this.label1 = new System.Windows.Forms.Label();
            this.namefile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ID_label = new System.Windows.Forms.Label();
            this.fileIdTextBox = new System.Windows.Forms.TextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(541, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imprimer de Document";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // namefile
            // 
            this.namefile.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namefile.Location = new System.Drawing.Point(470, 424);
            this.namefile.Margin = new System.Windows.Forms.Padding(40);
            this.namefile.Multiline = true;
            this.namefile.Name = "namefile";
            this.namefile.ReadOnly = true;
            this.namefile.Size = new System.Drawing.Size(426, 40);
            this.namefile.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(134, 424);
            this.label4.Margin = new System.Windows.Forms.Padding(40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 40);
            this.label4.TabIndex = 45;
            this.label4.Text = "Nom de Document       :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 348);
            this.label3.Margin = new System.Windows.Forms.Padding(40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 40);
            this.label3.TabIndex = 44;
            this.label3.Text = "Choisissez votre fichier :";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(470, 348);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(426, 40);
            this.comboBox1.TabIndex = 43;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ID_label
            // 
            this.ID_label.AutoSize = true;
            this.ID_label.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_label.Location = new System.Drawing.Point(134, 504);
            this.ID_label.Margin = new System.Windows.Forms.Padding(40);
            this.ID_label.Name = "ID_label";
            this.ID_label.Size = new System.Drawing.Size(332, 40);
            this.ID_label.TabIndex = 42;
            this.ID_label.Text = "Nom du chemin            :";
            // 
            // fileIdTextBox
            // 
            this.fileIdTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileIdTextBox.Location = new System.Drawing.Point(470, 505);
            this.fileIdTextBox.Margin = new System.Windows.Forms.Padding(40);
            this.fileIdTextBox.Multiline = true;
            this.fileIdTextBox.Name = "fileIdTextBox";
            this.fileIdTextBox.ReadOnly = true;
            this.fileIdTextBox.Size = new System.Drawing.Size(426, 40);
            this.fileIdTextBox.TabIndex = 41;
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downloadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.ForeColor = System.Drawing.Color.White;
            this.downloadButton.Location = new System.Drawing.Point(401, 763);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(226, 56);
            this.downloadButton.TabIndex = 47;
            this.downloadButton.Text = "Exporter";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // Printt_Docoment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.namefile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ID_label);
            this.Controls.Add(this.fileIdTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Printt_Docoment";
            this.Size = new System.Drawing.Size(1048, 985);
            this.Load += new System.EventHandler(this.Printt_Docoment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namefile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label ID_label;
        private System.Windows.Forms.TextBox fileIdTextBox;
        private System.Windows.Forms.Button downloadButton;
    }
}
