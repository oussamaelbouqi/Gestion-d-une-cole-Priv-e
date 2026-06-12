using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.UserControl_Document
{
    public partial class Modifier_Document : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        private string selectedFilePath;
        private int ID_doc;
        public Modifier_Document()
        {
            InitializeComponent();
        }

        private void Modifier_Document_Load(object sender, EventArgs e)
        {
            string query = "Select File_name from Documents";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
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

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*";
            fileDialog.Title = "Select a file";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = fileDialog.FileName;
                fileIdTextBox.Text = Path.GetFileName(selectedFilePath);
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            string query1 = "Select ID_document from Documents where File_name='"+comboBox1.Text+"'";
            string query = "";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@query1, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ID_doc = dr.GetInt32(0);
                    }
                    cn.Close();
                }
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                byte[] fileData = null;
                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (FileStream fileStream = File.OpenRead(selectedFilePath))
                        {
                            fileStream.CopyTo(memoryStream);
                        }
                        fileData = memoryStream.ToArray();
                    }
                }
                string filename = Path.GetFileName(selectedFilePath);
                if (fileData != null)
                {
                    query = "UPDATE Documents set File_name = @File_name,File_name_path = @File_name_path, File_data = @File_data where ID_document = @ID_document";
                }
                else if (fileData == null)
                {
                    query = "UPDATE Documents set File_name = @File_name where ID_document = @ID_document";
                }
                SqlCommand cmd = new SqlCommand (query, cn);
                cmd.Parameters.AddWithValue("@ID_document", ID_doc);
                cmd.Parameters.AddWithValue("@File_name",namefile.Text);
                if(fileData != null)
                {
                    cmd.Parameters.AddWithValue("@File_name_path", fileIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@File_data", fileData);
                }
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("le nom du fichier " + comboBox1.Text + " a été modifiér avec succès");
            }
            fileIdTextBox.Text = "";
            namefile.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "Delete from Documents where ID_document = @ID_document";
                string query1 = "Select ID_document from Documents where File_name='" + comboBox1.Text + "'";
                using (SqlCommand cmd = new SqlCommand(@query1, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ID_doc = dr.GetInt32(0);
                    }
                    cn.Close();
                }
                using(SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@ID_document", ID_doc);
                    cn.Open();
                    cmd.ExecuteNonQuery ();
                    cn.Close();
                    MessageBox.Show("le nom du fichier " + comboBox1.Text + " a été supprimé avec succès");
                }
            }
        }
    }
}
