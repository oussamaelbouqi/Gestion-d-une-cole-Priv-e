namespace ESPEJIC.UserControl_Document
{
    partial class Modifier_Document
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
            this.uploadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ID_label = new System.Windows.Forms.Label();
            this.fileIdTextBox = new System.Windows.Forms.TextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.namefile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "Modifier de Document";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uploadButton
            // 
            this.uploadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadButton.Location = new System.Drawing.Point(464, 547);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(426, 46);
            this.uploadButton.TabIndex = 33;
            this.uploadButton.Text = "cliquez pour télécharger le fichier";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 548);
            this.label2.Margin = new System.Windows.Forms.Padding(40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 40);
            this.label2.TabIndex = 32;
            this.label2.Text = "Document                     :";
            // 
            // ID_label
            // 
            this.ID_label.AutoSize = true;
            this.ID_label.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_label.Location = new System.Drawing.Point(128, 467);
            this.ID_label.Margin = new System.Windows.Forms.Padding(40);
            this.ID_label.Name = "ID_label";
            this.ID_label.Size = new System.Drawing.Size(332, 40);
            this.ID_label.TabIndex = 31;
            this.ID_label.Text = "Nom du chemin            :";
            // 
            // fileIdTextBox
            // 
            this.fileIdTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileIdTextBox.Location = new System.Drawing.Point(464, 468);
            this.fileIdTextBox.Margin = new System.Windows.Forms.Padding(40);
            this.fileIdTextBox.Multiline = true;
            this.fileIdTextBox.Name = "fileIdTextBox";
            this.fileIdTextBox.ReadOnly = true;
            this.fileIdTextBox.Size = new System.Drawing.Size(426, 40);
            this.fileIdTextBox.TabIndex = 30;
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downloadButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.ForeColor = System.Drawing.Color.White;
            this.downloadButton.Location = new System.Drawing.Point(210, 854);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(226, 56);
            this.downloadButton.TabIndex = 36;
            this.downloadButton.Text = "Modifier";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(464, 311);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(426, 40);
            this.comboBox1.TabIndex = 37;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 40);
            this.label3.TabIndex = 38;
            this.label3.Text = "Choisissez votre fichier :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(128, 387);
            this.label4.Margin = new System.Windows.Forms.Padding(40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 40);
            this.label4.TabIndex = 39;
            this.label4.Text = "Nom de Document       :";
            // 
            // namefile
            // 
            this.namefile.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namefile.Location = new System.Drawing.Point(464, 387);
            this.namefile.Margin = new System.Windows.Forms.Padding(40);
            this.namefile.Multiline = true;
            this.namefile.Name = "namefile";
            this.namefile.Size = new System.Drawing.Size(426, 40);
            this.namefile.TabIndex = 40;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(546, 854);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 56);
            this.button1.TabIndex = 46;
            this.button1.Text = "Supprimer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Modifier_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.namefile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_label);
            this.Controls.Add(this.fileIdTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Modifier_Document";
            this.Size = new System.Drawing.Size(1048, 985);
            this.Load += new System.EventHandler(this.Modifier_Document_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ID_label;
        private System.Windows.Forms.TextBox fileIdTextBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox namefile;
        private System.Windows.Forms.Button button1;
    }
}
