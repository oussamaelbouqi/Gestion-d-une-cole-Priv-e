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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC
{
    public partial class Paiment_liste : Form
    {
        public Paiment_liste()
        {
            InitializeComponent();
        }
        private int x;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public void FillInformationEcole()
        {
            string query = "Select Nom_eco from Ecole";
            string query1 = "Select Nom_Full from Filiére";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label13.Text = reader[0].ToString();
                }
                conn.Close();
            }
            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label15.Text = reader[0].ToString();
                }
                conn.Close();
            }
        }
        private void Paiment_liste_Load(object sender, EventArgs e)
        {
            FillInformationEcole();
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter(cmd1);
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
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
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Janvier")
            {
                x = 1;
            }
            else if(comboBox2.Text == "Février")
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
            dgvstagaire1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_de_paiment,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where MONTH(Date_de_paiment) = '" + x.ToString()+"' and Stagaire.Type_stagaire= '" + comboBox1.Text+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                }
                conn.Close();
            }
            conn.Close ();
            SqlCommand cmd1 = new SqlCommand("Select SUM(Monant_par_m) from Paiment inner join Stagaire on Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where MONTH(Date_de_paiment) = '"+x+"' and Stagaire.Type_stagaire='" + comboBox1.Text + "'", conn);
            conn.Open();
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    textBox1.Text = reader1[0].ToString();
                    if (textBox1.Text == "")
                    {
                        textBox1.Text = "0";
                    }
                }
            }         
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
