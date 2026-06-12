using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace ESPEJIC.Usercontrol_Absence
{
    public partial class UserControlAbs : UserControl
    {
        public SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");

        public UserControlAbs()
        {
            InitializeComponent();
        }

        private void UserControlAbs_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlCommand cmd2 = new SqlCommand("Select Justify from Justify", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            SqlDataAdapter dt2 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            dt2.SelectCommand = cmd2;
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            dt1.Fill(table1);
            dt2.Fill(table2);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
            comboBox4.DataSource = table2;
            comboBox4.DisplayMember = "Justify";
            dateTimePicker1.Value = DateTime.Now;
        }

        private bool ChekInfo()
        {
            if (n_h_txt.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox1.Text = string.Empty;
            n_h_txt.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox2.Text = string.Empty;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            using (SqlCommand cmd2 = new SqlCommand("Select Nom_Mat from Matiére where statu_mat='Active' and  Type_stagaire = @Type_stagaire", conn))
            {
                cmd2.Parameters.AddWithValue("@Type_stagaire", comboBox1.Text);

                DataTable table = new DataTable();
                using (SqlDataAdapter dt = new SqlDataAdapter(cmd2))
                {
                    dt.Fill(table);
                }
                comboBox3.DataSource = table;
                comboBox3.DisplayMember = "Nom_Mat";
            }
            conn.Close();
            if (comboBox1.Text == "1er année")
            {
                dgvstagaire.Rows.Clear();
                SqlCommand cmd1 = new SqlCommand("Select CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Type_stagaire,Sexe from Stagaire where Type_stagaire = '1er année'", conn);
                conn.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    conn.Close();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("La table de Stagaire est vide !");
                    conn.Close();
                }
            }
            else if (comboBox1.Text == "2émé année")
            {
                dgvstagaire.Rows.Clear();
                SqlCommand cmd3 = new SqlCommand("Select CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Type_stagaire,Sexe from Stagaire where Type_stagaire = '" + comboBox1.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd3.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    conn.Close();
                    reader.Close();
                }
            }
            else if (comboBox1.Text == "3émé année")
            {
                dgvstagaire.Rows.Clear();
                SqlCommand cmd3 = new SqlCommand("Select CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Type_stagaire,Sexe from Stagaire where Type_stagaire = '" + comboBox1.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd3.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    conn.Close();
                    reader.Close ();
                }
            }
        }

        private void dgvstagaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dgvstagaire.CurrentRow.Index;
            this.comboBox2.Text = this.dgvstagaire.Rows[position].Cells[0].Value.ToString();
            this.textBox1.Text = this.dgvstagaire.Rows[position].Cells[1].Value.ToString();
            this.textBox2.Text = this.dgvstagaire.Rows[position].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
            {
                return;
            }
            string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                if (!ChekInfo())
                {
                    MessageBox.Show("Veuillez remplir toutes les informations.");
                    return;
                }
                string query = "INSERT INTO Absence_stagaire (CIN_Stagaire, ID_Matiére, Nombre_h, Date_abs, Justify) " +
               "VALUES (@CIN_Stagaire, @ID_Matiere, @Nombre_h, @Date_abs, @Justify)";

                using (SqlCommand cmd1 = new SqlCommand(query, conn))
                {
                    // Add parameters with appropriate types
                    cmd1.Parameters.AddWithValue("@CIN_Stagaire", comboBox2.Text);
                    cmd1.Parameters.AddWithValue("@ID_Matiere", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@Nombre_h", n_h_txt.Text);
                    cmd1.Parameters.AddWithValue("@Date_abs", formattedDate);
                    cmd1.Parameters.AddWithValue("@Justify", comboBox4.Text);

                    // Open the connection, execute the query, and close the connection
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();

                    // Show a success message
                    MessageBox.Show("Une absence a été saisie avec succès");
                }
                conn.Close();
                textBox2.Text = string.Empty;
                textBox1.Text = string.Empty;
                n_h_txt.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                conn.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            SqlCommand cmd = new SqlCommand("Select ID_Matiére from Matiére where Nom_Mat ='" + comboBox3.Text + "' ", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr[0].ToString();
            }
            conn.Close();
            dr.Close ();
        }

        private void n_h_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(n_h_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un Nombre d'heures invalide.");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1;
            bool isNumber1 = int.TryParse(n_h_txt.Text, out number1);

            if (isNumber1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vous avez entré un Nombre d'heures invalide. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
