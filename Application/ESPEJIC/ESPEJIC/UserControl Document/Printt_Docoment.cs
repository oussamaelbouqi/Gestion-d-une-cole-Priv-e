using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ESPEJIC.UserControl_Document
{
    public partial class Printt_Docoment : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        public Printt_Docoment()
        {
            InitializeComponent();
        }

        private void Printt_Docoment_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "Select File_name from Documents";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                cn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "Select File_name_path from Documents where File_name =@File_name";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@File_name", comboBox1.Text);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        fileIdTextBox.Text = dr[0].ToString();
                    }
                    cn.Close();
                }
            }
            namefile.Text = comboBox1.Text;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            string selectedFileName = comboBox1.Text;
            string query = "SELECT ID_document, File_name_path, File_data FROM Documents WHERE File_name = @File_name";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@File_name", selectedFileName);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fileId = reader["ID_document"].ToString(); // Get the FileId
                            string filenamepath = reader["File_name_path"].ToString(); // Get the Filenamepath
                            byte[] fileData = (byte[])reader["File_data"];

                            // Prompt the user to select a location to save the file
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.FileName = filenamepath; // Set the default file name to the Filenamepath
                            saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter files by extension

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string destinationFilePath = saveFileDialog.FileName;
                                File.WriteAllBytes(destinationFilePath, fileData);
                                MessageBox.Show("Fichier téléchargé avec succès");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fichier introuvable.");
                        }
                    }
                    cn.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
