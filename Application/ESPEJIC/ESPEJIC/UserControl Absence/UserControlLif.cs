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

namespace ESPEJIC.Usercontrol_Absence
{
    public partial class UserControlLif : UserControl
    {
        private int x;
        private string a;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public UserControlLif()
        {
            InitializeComponent();
        }
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
        private void UserControlLif_Load(object sender, EventArgs e)
        {
            FillInformationEcole();
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
            comboBox2.Items.Add("Decembre");
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
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

            dgvstagaire1.Rows.Clear();
            comboBox3.Items.Clear();
            SqlCommand cmd = new SqlCommand("select Formateur.CIN_for,Nom_for ,Pre_for,Sexe,Pre,Jour,Date_Abs from Absence_For inner join Formateur ON Formateur.CIN_for = Absence_For.CIN_for where MONTH(Date_Abs) = '" + x+"'", conn);
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
            else
            {
                conn.Close();
            }    
            conn.Close();
            SqlCommand cmd1 = new SqlCommand("select DISTINCT Formateur.Nom_for+' '+Formateur.Pre_for from Absence_For inner join Formateur on Formateur.CIN_for = Absence_For.CIN_for where MONTH(Date_Abs) ='"+x+"';", conn);
            conn.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString());
                }
            }
            conn.Close();
            dr.Close();      
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select CIN_for from Formateur where Nom_for+' '+Pre_for = '" + comboBox3.Text + "'", conn);
            conn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    a = dr1[0].ToString();
                }
            }
            conn.Close();
            dr1.Close();
            dgvstagaire1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select Formateur.CIN_for,Nom_for ,Pre_for,Sexe,Pre,Jour,Date_Abs from Absence_For inner join Formateur ON Formateur.CIN_for = Absence_For.CIN_for where Formateur.CIN_for = '" + a + "'", conn);
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
            else
            {

                conn.Close();
            }
        }
    }
}
