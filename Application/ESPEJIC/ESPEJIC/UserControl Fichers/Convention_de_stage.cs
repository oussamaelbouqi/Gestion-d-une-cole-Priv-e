using CrystalDecisions.CrystalReports.Engine;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ESPEJIC.UserControl_Fichers
{
    public partial class Convention_de_stage : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        ReportDocument reportDocument = new ReportDocument();
        private string Fax, telep, adrs, email, Abre;
        public Convention_de_stage()
        {
            InitializeComponent();
        }

        private void Convention_de_stage_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where Type_stagaire='" + comboBox1.Text + "'", conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Nom";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            SqlCommand cmd;
            cmd = new SqlCommand("Select Stage.CIN_Stagaire,Stagaire.Nom_stagaire,Stagaire.Pre_stagaire,Nom_Entr,Addrs_Ent,Stage.Tele,Date_d,Date_f from Stage inner join Stagaire on Stage.CIN_Stagaire = Stagaire.CIN_Stagaire where Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire = '" + comboBox2.Text+"'", conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string Nom_stagaire = dr["Nom_stagaire"].ToString();
                string Pre_stagaire = dr["Pre_stagaire"].ToString();
                string CIN_Stagaire = dr["CIN_Stagaire"].ToString();
                string Nom_Entr = dr["Nom_Entr"].ToString();
                string addrs = dr["Addrs_Ent"].ToString();
                string telep = dr["Tele"].ToString();
                string date_d = dr["Date_d"].ToString();
                string date_f = dr["Date_f"].ToString();
                textBox4.Text = CIN_Stagaire;
                textBox1.Text = Nom_stagaire;
                textBox3.Text = Pre_stagaire;
                textBox2.Text = Nom_Entr;
                textBox6.Text = addrs;
                textBox5.Text = telep;
                dateTimePicker1.Text = date_d;
                dateTimePicker3.Text = date_f;
            }
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            string adress = "";
            string NomEcole = "";
            string date_d = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string date_f = dateTimePicker3.Value.ToString("dd/MM/yyyy");
            string vlue = "Le stage se déroulera du : " + date_d + " au " + date_f;
            string query = "Select Email,Fax,Tele,Addrs ,Abre from Ecole";
            string query1 = "Select Addrs from Stagaire where Nom_stagaire+' '+Pre_stagaire = '" + comboBox2.Text+"'";
            string query2 = "Select Nom_eco from Ecole";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Fax = dr["Fax"].ToString();
                    telep = dr["Tele"].ToString();
                    adrs = dr["Addrs"].ToString();
                    email = dr["Email"].ToString();
                    Abre = dr["Abre"].ToString() ;
                }
                conn.Close();
            }
            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                conn.Close();
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    adress = dr[0].ToString();
                }
                conn.Close();
            }
            using (SqlCommand cmd = new SqlCommand(query2, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NomEcole = reader[0].ToString();
                }
                conn.Close();
            }
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath, "Convention_de_stg.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text66"];
            textObject.Text = email;
            TextObject textObject0 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text52"];
            textObject0.Text = email;
            TextObject textObjec2 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text67"];
            textObjec2.Text = telep;
            TextObject textObjec02 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text54"];
            textObjec02.Text = telep;
            TextObject textObjec03 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text53"];
            textObjec03.Text = Fax;
            TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text8"];
            textObjec3.Text = textBox2.Text;
            TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text11"];
            textObjec4.Text = textBox6.Text;
            TextObject textObject5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text12"];
            textObject5.Text = textBox5.Text;
            TextObject textObject6 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text28"];
            textObject6.Text = "Nom : "+textBox1.Text+"       Prénom : "+textBox3.Text;
            TextObject textObject8 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text33"];
            textObject8.Text = "Addresse : "+adress;
            TextObject textObject9 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text39"];
            textObject9.Text = "Inscrit à "+NomEcole;
            TextObject textObject15 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text6"];
            textObject15.Text = NomEcole;
            TextObject textObject10 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text42"];
            textObject10.Text = vlue;
            TextObject textObject12 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text49"];
            textObject12.Text = textBox2.Text;  
            TextObject textObject13 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text26"];
            textObject13.Text = textBox2.Text + " accepte de prendre dans son Entreprise pour un stage d’initiation l’étudiant(e) :";
            TextObject textObject14 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text65"];
            textObject14.Text = "Pour l’entreprise "+textBox2.Text;
            TextObject textObject16 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text63"];
            textObject16.Text = "Pour L’école "+Abre;
            TextObject textObject17 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text3"];
            textObject17.Text = "Autorisation n°4/06/4/95 du 03/01/2011 – Accréditation n°23/K0410S2/DFP/01 du 31/05/2023\r\n"+adress+" Tél : "+telep+"- Fax : "+Fax+" \r\nSite web : www.espegic.com     -  Email : "+email;
            rp.crystalReportViewer1.ReportSource = reportDocument;
        
        }
    }
}
