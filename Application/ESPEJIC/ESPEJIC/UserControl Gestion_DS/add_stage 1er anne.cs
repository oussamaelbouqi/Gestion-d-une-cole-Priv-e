using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.gestion_de_stage
{
    public partial class stage_1er_anne : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public SqlCommand cmd;
        SqlDataReader dr;
        private string selectedFilePath = null;
        private string selectedFilePath2;
        private string query;
        public stage_1er_anne()
        {
            InitializeComponent();
        }
        private bool Checkout()
        {
            if (textBox1.Text.Equals(string.Empty) ||
                textBox2.Text.Equals(string.Empty) ||
                textBox3.Text.Equals(string.Empty) ||
                textBox5.Text.Equals(string.Empty) ||
                textBox6.Text.Equals(string.Empty) ||
                label14.Text.Equals(string.Empty))
                return false;
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Combine with a directory path to create a full random file path
            if (!ValidateTextBoxes())
            {
                return;
            }
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker3.Value;
            TimeSpan Dif = dt1 - dt2;
            if (Dif.Days > 0)
            {
                MessageBox.Show("Il s'agit d'une erreur, car la date de début est supérieure à la date de fin de stage");
                return;
            }
            else if (Dif.Days == 0)
            {
                MessageBox.Show("Il s'agit d'une erreur, car la date de début est égale à la date de fin de stage");
                return;
            }
            if (!Checkout() == true)
            {
                MessageBox.Show("Veuillez remplir toutes les informations.");
                return;
            }
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
            byte[] fileData2 = File.ReadAllBytes(selectedFilePath2);
            cn.Open();
            string filename = Path.GetFileName(selectedFilePath);
            if (fileData != null)
            {
                query = "insert into Stage values(@CIN_Stagaire,@Date_d,@Date_f,@Nom_Entr,@Addrs_Ent,@Tele,@FileNameAtes, @FileNameDs,@FileDataDs,@FileDataAtes)";
            }
            else if (fileData == null)
            {
                query = "insert into Stage values(@CIN_Stagaire, @Date_d, @Date_f, @Nom_Entr, @Addrs_Ent, @Tele,NULL,@FileNameDs, @FileDataDs,NULL)";
            }
            cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CIN_Stagaire", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Date_d", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@Date_f", dateTimePicker3.Value.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@Nom_Entr", textBox2.Text);
            cmd.Parameters.AddWithValue("@Addrs_Ent", textBox6.Text);
            cmd.Parameters.AddWithValue("@Tele", textBox5.Text);
            cmd.Parameters.AddWithValue("@FileNameDs", Path.GetFileName(selectedFilePath2));
            cmd.Parameters.AddWithValue("@FileDataDs", fileData2);
            if (fileData != null)
            {
                cmd.Parameters.AddWithValue("@FileNameAtes", filename);
                cmd.Parameters.AddWithValue("@FileDataAtes", fileData);
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Des informations ont été ajoutées pour ce stagiaire");
            cn.Close();
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker3.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            label9.Text = "";
            label14.Text = "";
        }


        private void stage_1er_anne_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("select  CIN_Stagaire from Stagaire where Type_stagaire ='1er année'",cn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            DataTable table1 = new DataTable();
            dt1.SelectCommand = cmd;
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "CIN_Stagaire";
            cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cmd = new SqlCommand("select Nom_stagaire,Pre_stagaire from Stagaire where CIN_Stagaire = '" + comboBox1.Text+"'",cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox3.Text = dr[1].ToString();                
                }
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types
            fileDialog.Title = "Select a file";

            // Show the file dialog and check if the user clicked the OK button
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedFilePath = fileDialog.FileName;

                // Process the selected file (e.g., display its path)
                label9.Text = Path.GetFileName(selectedFilePath);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types
            fileDialog.Title = "Select a file";

            // Show the file dialog and check if the user clicked the OK button
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedFilePath2 = fileDialog.FileName;

                // Process the selected file (e.g., display its path)
                label14.Text = Path.GetFileName(selectedFilePath2);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox5.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro de téléphone invalide");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox5.Text, out number1);

            if (isNumber1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vous avez entré un numéro de téléphone invalide. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }
    }
}
