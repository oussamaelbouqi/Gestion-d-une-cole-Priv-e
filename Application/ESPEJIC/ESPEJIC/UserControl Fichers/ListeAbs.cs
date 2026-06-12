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

namespace ESPEJIC.UserControl_Fichiers
{
    public partial class ListeAbs : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public static string Classe;
        public static string Mois;
        public ListeAbs()
        {
            InitializeComponent();
        }

        private void ListeAbs_Load(object sender, EventArgs e)
        {

            dataGridView_Abs.RowHeadersVisible = false;

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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            dataGridView_Abs.Rows.Clear();
            SqlDataReader dt;
            SqlCommand cmd = new SqlCommand("Select N_Insc,Nom_stagaire +' '+ Pre_Stagaire, CIN_Stagaire,Type_stagaire,Sexe,Tele from Stagaire where Type_stagaire ='" + comboBox1.Text + "'", conn);
            conn.Open();
            dt = cmd.ExecuteReader();
            if (dt.HasRows)
            {
                while (dt.Read())
                {

                    this.dataGridView_Abs.Rows.Add(dt[0], dt[1], dt[2], dt[3], dt[4], dt[5]);
                }
            }          
        }

        private void Imprimer_Liste_Click(object sender, EventArgs e)
        {
            Classe = comboBox1.Text;
            Mois = comboBox2.Text;
            if(comboBox2.Text.Length == 0)
            {
                MessageBox.Show("Veuillez choisir le mois.");
            }
            else
            {
                list_report lst = new list_report();
                lst.Show();
            }
        }
    }
}
