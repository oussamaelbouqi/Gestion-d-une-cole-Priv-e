using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.UserControl_Document
{
    public partial class Ajouter_Document : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        private string selectedFilePath = null;
        public Ajouter_Document()
        {
            InitializeComponent();
        }

        private void Ajouter_Document_Load(object sender, EventArgs e)
        {

        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*";
            fileDialog.Title = "Select a file";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = fileDialog.FileName;
                fileIdTextBox.Text= Path.GetFileName(selectedFilePath);
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            byte[] fileData2 = File.ReadAllBytes(selectedFilePath);
            string query = "INSERT INTO Documents (File_name,File_name_path, File_data) VALUES (@File_name,@File_name_path, @File_data)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@File_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@File_name_path", fileIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@File_data", fileData2);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Le fichier "+ textBox1.Text+ "a été téléchargé avec succès.");
                    textBox1.Text = "";
                    fileIdTextBox.Text = "";
                }
            }
        }
    }
}
