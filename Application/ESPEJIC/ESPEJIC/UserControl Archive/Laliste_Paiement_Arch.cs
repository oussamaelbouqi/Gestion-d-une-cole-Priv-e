using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.UserControl_Archive
{
    public partial class Laliste_Paiement_Arch : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=Archive1;Integrated Security=True";
        private int x;
        public Laliste_Paiement_Arch()
        {
            InitializeComponent();
        }

        private void Laliste_Paiement_Arch_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "Select DISTINCT years from Stagaire";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                dt.Fill(table);
                comboBox3.DataSource = table;
                comboBox3.DisplayMember = "years";
                string query1 = "Select Type_stagaire from Classe";
                SqlCommand cmd1 = new SqlCommand(query1, cn);
                SqlDataAdapter dt1 = new SqlDataAdapter(cmd1);
                DataTable table1 = new DataTable();
                dt1.Fill(table1);
                comboBox1.DataSource = table1;
                comboBox1.DisplayMember = "Type_stagaire";
            }
            comboBox2.Items.Add("Janvier");
            comboBox2.Items.Add("Février");
            comboBox2.Items.Add("Mars");
            comboBox2.Items.Add("Avril");
            comboBox2.Items.Add("Mai");
            comboBox2.Items.Add("Juin");
            comboBox2.Items.Add("Juillet");
            comboBox2.Items.Add("Août");
            comboBox2.Items.Add("Septembre");
            comboBox2.Items.Add("Octobre");
            comboBox2.Items.Add("Novembre");
            comboBox2.Items.Add("Décembre");
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Janvier")
            {
                x = 1;
            }
            else if (comboBox2.Text == "Février")
            {
                x = 2;
            }
            else if (comboBox2.Text == "Mars")
            {
                x = 3;
            }
            else if (comboBox2.Text == "Avril")
            {
                x = 4;
            }
            else if (comboBox2.Text == "Mai")
            {
                x = 5;
            }
            else if (comboBox2.Text == "Juin")
            {
                x = 6;
            }
            else if (comboBox2.Text == "Juillet")
            {
                x = 7;
            }
            else if (comboBox2.Text == "Août")
            {
                x = 8;
            }
            else if (comboBox2.Text == "Septembre")
            {
                x = 9;
            }
            else if (comboBox2.Text == "Octobre")
            {
                x = 10;
            }
            else if (comboBox2.Text == "Novembre")
            {
                x = 11;
            }
            else if (comboBox2.Text == "Décembre")
            {
                x = 12;
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dgvstagaire1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_de_paiment,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where MONTH(Date_de_paiment) = '" + x.ToString() + "' and Stagaire.Type_stagaire= '" + comboBox1.Text + "'", cn );
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    }
                    cn.Close();
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dgvstagaire1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_de_paiment,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where MONTH(Date_de_paiment) = '" + x.ToString() + "' and Stagaire.Type_stagaire= '" + comboBox1.Text + "' and Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire = '" + comboBox4.Text+"'", cn);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    }
                    cn.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dgvstagaire1.Rows.Clear();
                string query = "Select Nom_stagaire+' '+Pre_stagaire from Stagaire where Type_stagaire = '" + comboBox1.Text+"'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader[0].ToString());
                }
                cn.Close();
            }
        }
    }
}
