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

namespace ESPEJIC.UserControl_Paiment
{
    public partial class Paiment_Stagaire : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Paiment_Stagaire()
        {
            InitializeComponent();
        }

        public bool a = true;

        private void button2_Click(object sender, EventArgs e)
        {
            Paiment_liste liste = new Paiment_liste();
            liste.Show();
        }

        private void Paiment_Stagaire_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private bool ChekInfo()
        {
            if(Payment_txt.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void dgvstagaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dgvstagaire.CurrentRow.Index;
            this.textBox2.Text = this.dgvstagaire.Rows[position].Cells[1].Value.ToString();
            this.textBox3.Text = this.dgvstagaire.Rows[position].Cells[2].Value.ToString();
            this.comboBox2.Text = this.dgvstagaire.Rows[position].Cells[0].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            dgvstagaire.Rows.Clear();

            if (comboBox1.Text == "1er année")
            {
                SqlCommand cmd = new SqlCommand("Select CIN_Stagaire from Stagaire where Type_stagaire = '1er année'", conn);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable table1 = new DataTable();
                dt.Fill(table1);
                comboBox2.DataSource = table1;
                comboBox2.DisplayMember = "CIN_Stagaire";

                SqlCommand cmd1 = new SqlCommand("Select CIN_Stagaire, Nom_stagaire, Pre_stagaire, Type_stagaire, Sexe, Mont_an from Stagaire where Type_stagaire = '1er année'", conn);
                conn.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                }
                else
                {
                    MessageBox.Show("La table de Stagaire est vide !");
                }
                reader.Close();
                conn.Close();
            }
            else if (comboBox1.Text == "2émé année")
            {
                SqlCommand cmd = new SqlCommand("Select CIN_Stagaire from Stagaire where Type_stagaire = '2émé année'", conn);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable table1 = new DataTable();
                dt.Fill(table1);
                comboBox2.DataSource = table1;
                comboBox2.DisplayMember = "CIN_Stagaire";

                SqlCommand cmd3 = new SqlCommand("Select CIN_Stagaire, Nom_stagaire, Pre_stagaire, Type_stagaire, Sexe, Mont_an from Stagaire where Type_stagaire = @TypeStagaire", conn);
                cmd3.Parameters.AddWithValue("@TypeStagaire", comboBox1.Text);

                conn.Open();
                SqlDataReader reader = cmd3.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                }
                reader.Close();
                conn.Close();
            }
        }

        private void Btn_ajou_form_Click(object sender, EventArgs e)
        {
            Paiment_liste paiment_Liste = new Paiment_liste();
            paiment_Liste.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string mony = "";
            string query = "Select Mont_an from Stagaire where CIN_Stagaire ='"+comboBox2.Text+"'";
            using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mony = dr[0].ToString();
                }
                dr.Close();
                conn.Close();
            }
            if (!string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(Payment_txt.Text))
            {
                string Mont = "";
                string query2 = "Select Mont_an from Stagaire where CIN_Stagaire = '" + comboBox2.Text + "'";
                using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                {
                    conn.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    if (dr2.Read())
                    {
                        if (!dr2.IsDBNull(0))  // Check if the value is not null
                        {
                            Mont = dr2[0].ToString();  // Assuming the first column is of type int
                        }
                        else
                        {
                            // Handle case where the value is null, if needed
                            Mont = "0";  // Default value or handle as appropriate
                        }
                    }

                    dr2.Close();
                    conn.Close();
                }
                if(Mont == "0")
                {
                    MessageBox.Show("Ce Stagiaire a déjà payé ses frais.");
                    return;
                }
                int Montant = Convert.ToInt32(mony) - Convert.ToInt32(Payment_txt.Text);
                SqlCommand cmd, cmd1;
                SqlDataReader dr, dr1;
                Payment_txt.ReadOnly = false;
                try
                {
                    if (!ChekInfo())
                    {
                        MessageBox.Show("Veuillez remplir toutes les informations.");
                        return;
                    }

                    // Formatting the date and time
                    string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    if(int.Parse(Payment_txt.Text)> int.Parse(Mont))
                    {
                        MessageBox.Show("Vous avez saisi un montant supérieur au montant total");
                        return;
                    }
                    // Insert command
                    cmd = new SqlCommand("INSERT INTO Paiment (CIN_Stagaire, Date_de_paiment, Monant_par_m) VALUES (@cin, @date, @montant)", conn);
                    cmd.Parameters.AddWithValue("@cin", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@date", formattedDate);
                    cmd.Parameters.AddWithValue("@montant", Payment_txt.Text);

                    // Update command
                    cmd1 = new SqlCommand("UPDATE Stagaire SET Mont_an = @montant WHERE CIN_Stagaire = @cin", conn);
                    cmd1.Parameters.AddWithValue("@montant", Montant);
                    cmd1.Parameters.AddWithValue("@cin", comboBox2.Text);

                    // Opening connection and executing insert command
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Opening connection and executing update command
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();

                    // Success message
                    MessageBox.Show("Le paiement pour ce mois a été effectué avec succès");

                    // Clearing text boxes
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    Payment_txt.Text = string.Empty;

                    // Clearing DataGridView rows
                    dgvstagaire.Rows.Clear();

                    // Loading the updated data into DataGridView
                    SqlCommand cmd3 = new SqlCommand("SELECT CIN_Stagaire, Nom_stagaire, Pre_stagaire, Type_stagaire, Sexe, Mont_an FROM Stagaire WHERE Type_stagaire = @type", conn);
                    cmd3.Parameters.AddWithValue("@type", comboBox1.Text);

                    conn.Open();
                    SqlDataReader reader = cmd3.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Paiment Failed", "Error donnée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string montan = "";
            conn.Close();
            SqlCommand cmd = new SqlCommand("Select Nom_stagaire,Pre_stagaire,Mont_an From Stagaire where CIN_Stagaire = '" + comboBox2.Text + "'", conn);
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    textBox2.Text = r[0].ToString();
                    textBox3.Text = r[1].ToString();
                    montan = r[2].ToString();
                }
                conn.Close();
                r.Close();
            }
        }

        private void Payment_txt_Leave(object sender, EventArgs e)
        {
            try { 
            int price = Convert.ToInt32(Payment_txt.Text);
            int rest = Convert.ToInt32(Payment_txt.Text);
            string query = "Select Mont_an from Stagaire where CIN_Stagaire = '" + comboBox2.Text+ "'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Close() ;
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    rest = int.Parse(r[0].ToString());
                }
                conn.Close() ;
                r.Close();
            }
            if (Payment_txt.Text == null)
            {
                Payment_txt.Text = "0";
            }
            else
            {
                if (int.TryParse(Payment_txt.Text, out int value))
                {
                    if (value >= 0)
                    {
                        Payment_txt.Text = value.ToString();
                    }
                    else
                    {
                        Payment_txt.Text = "0";
                    }
                }
                else
                {
                    Payment_txt.Text = "0";
                }
            }
            if (price > rest)
            {
                Payment_txt.Text = "0";
                return;
            }
            else if(price == rest)
            {
                MessageBox.Show("Cet stagiaire a payé la totalité des frais de scolarité pour cette année");
            }
            }
            catch
            {
                Payment p = new Payment();
                p.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Histoire_Payment hs = new Histoire_Payment();
            hs.Show();
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                if (comboBox2.Items.Count > 1)
                {
                    comboBox2.SelectedIndex = 1;
                }
                else
                {
                    comboBox2.Text = string.Empty;
                }
            }
        }
    }
}
