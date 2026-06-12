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

namespace ESPEJIC.Usercontrol_Absence
{
    public partial class UserControlLis : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        private string a;
        private int x;
        public UserControlLis()
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
        private void UserControlLis_Load(object sender, EventArgs e)
        {
            FillInformationEcole();
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
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
            comboBox2.Items.Add("Decembre");
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox2.Text == "Janvier")
            //{
            //    x = 1;
            //}
            //else if (comboBox2.Text == "Février")
            //{
            //    x = 2;
            //}
            //else if (comboBox2.Text == "Mars")
            //{
            //    x = 3;
            //}
            //else if (comboBox2.Text == "Avril")
            //{
            //    x = 4;
            //}
            //else if (comboBox2.Text == "Mai")
            //{
            //    x = 5;
            //}
            //else if (comboBox2.Text == "Juin")
            //{
            //    x = 6;
            //}
            //else if (comboBox2.Text == "Juillet")
            //{
            //    x = 7;
            //}
            //else if (comboBox2.Text == "Août")
            //{
            //    x = 8;
            //}
            //else if (comboBox2.Text == "Septembre")
            //{
            //    x = 9;
            //}
            //else if (comboBox2.Text == "Octobre")
            //{
            //    x = 10;
            //}
            //else if (comboBox2.Text == "Novembre")
            //{
            //    x = 11;
            //}
            //else if (comboBox2.Text == "Décembre")
            //{
            //    x = 12;
            //}

            //dgvstagaire1.Rows.Clear();
            //SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_abs,Nombre_h,Matiére.Nom_Mat ,Justify.Justify from Absence_stagaire inner join Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire inner join Matiére on Matiére.ID_Matiére = Absence_stagaire.ID_Matiére  inner join Justify on Justify.Justify = Absence_stagaire.Justify where MONTH(Date_abs) = '"+x+"' and Stagaire.Type_stagaire='" + comboBox1.Text+"'", conn);
            //conn.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5],reader[6], reader[7]);
            //    }
            //    conn.Close();
            //}
            //else
            //{

            //    conn.Close();
            //}
            Dictionary<string, int> monthMapping = new Dictionary<string, int>
{
    { "Janvier", 1 },
    { "Février", 2 },
    { "Mars", 3 },
    { "Avril", 4 },
    { "Mai", 5 },
    { "Juin", 6 },
    { "Juillet", 7 },
    { "Août", 8 },
    { "Septembre", 9 },
    { "Octobre", 10 },
    { "Novembre", 11 },
    { "Décembre", 12 }
};

            // Get the selected month number from the dictionary
            if (monthMapping.TryGetValue(comboBox2.Text, out int x))
            {
                dgvstagaire1.Rows.Clear();

                string query = "SELECT Stagaire.CIN_Stagaire, Nom_stagaire, Pre_stagaire, Sexe, Date_abs, Nombre_h, Matiére.Nom_Mat, Justify.Justify " +
                               "FROM Absence_stagaire " +
                               "INNER JOIN Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire " +
                               "INNER JOIN Matiére ON Matiére.ID_Matiére = Absence_stagaire.ID_Matiére " +
                               "INNER JOIN Justify ON Justify.Justify = Absence_stagaire.Justify " +
                               "WHERE MONTH(Date_abs) = @Month AND Stagaire.Type_stagaire = @TypeStagaire";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@Month", x);
                    cmd.Parameters.AddWithValue("@TypeStagaire", comboBox1.Text);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            comboBox3.Items.Clear();
            conn.Close();
            SqlCommand cmd1 = new SqlCommand("Select DISTINCT Nom_stagaire+' '+Pre_stagaire from Absence_stagaire inner join Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire where MONTH(Date_abs) = '" + x + "' and Type_stagaire='"+comboBox1.Text+"'", conn);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire = '"+comboBox3.Text+ "' ", conn);
            conn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if(dr1.HasRows)
            {
                while (dr1.Read())
                {
                    a = dr1[0].ToString();
                }
            }
            conn.Close();
            dr1.Close();
            dgvstagaire1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_abs,Nombre_h,Matiére.Nom_Mat ,Justify.Justify from Absence_stagaire inner join Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire inner join Matiére on Matiére.ID_Matiére = Absence_stagaire.ID_Matiére inner join Justify on Justify.Justify = Absence_stagaire.Justify where Stagaire.CIN_Stagaire = '" + a+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
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
