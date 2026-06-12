namespace ESPEJIC.UserControl_Document
{
    partial class Ajouter_Document
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
            this.label2 = new System.Windows.Forms.Label();
            this.ID_label = new System.Windows.Forms.Label();
            this.fileIdTextBox = new System.Windows.Forms.TextBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ajouter de Document";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 473);
            this.label2.Margin = new System.Windows.Forms.Padding(40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 40);
            this.label2.TabIndex = 24;
            this.label2.Text = "Document";
            // 
            // ID_label
            // 
            this.ID_label.AutoSize = true;
            this.ID_label.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_label.Location = new System.Drawing.Point(164, 387);
            this.ID_label.Margin = new System.Windows.Forms.Padding(40);
            this.ID_label.Name = "ID_label";
            this.ID_label.Size = new System.Drawing.Size(285, 40);
            this.ID_label.TabIndex = 23;
            this.ID_label.Text = "Nom du chemin       ";
            // 
            // fileIdTextBox
            // 
            this.fileIdTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileIdTextBox.Location = new System.Drawing.Point(453, 387);
            this.fileIdTextBox.Margin = new System.Windows.Forms.Padding(40);
            this.fileIdTextBox.Multiline = true;
            this.fileIdTextBox.Name = "fileIdTextBox";
            this.fileIdTextBox.Size = new System.Drawing.Size(426, 40);
            this.fileIdTextBox.TabIndex = 21;
            // 
            // uploadButton
            // 
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadButton.Location = new System.Drawing.Point(453, 474);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(426, 46);
            this.uploadButton.TabIndex = 25;
            this.uploadButton.Text = "cliquez pour télécharger le fichier";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downloadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.ForeColor = System.Drawing.Color.White;
            this.downloadButton.Location = new System.Drawing.Point(407, 854);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(226, 56);
            this.downloadButton.TabIndex = 26;
            this.downloadButton.Text = "Ajouter";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 297);
            this.label3.Margin = new System.Windows.Forms.Padding(40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 40);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nom de Document";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(453, 297);
            this.textBox1.Margin = new System.Windows.Forms.Padding(40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(426, 40);
            this.textBox1.TabIndex = 28;
            // 
            // Ajouter_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_label);
            this.Controls.Add(this.fileIdTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Ajouter_Document";
            this.Size = new System.Drawing.Size(1048, 985);
            this.Load += new System.EventHandler(this.Ajouter_Document_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ID_label;
        private System.Windows.Forms.TextBox fileIdTextBox;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}
