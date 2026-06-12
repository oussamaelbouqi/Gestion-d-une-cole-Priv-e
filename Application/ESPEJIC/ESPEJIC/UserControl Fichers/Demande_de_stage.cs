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
    public partial class Demande_de_stage : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        ReportDocument reportDocument = new ReportDocument();
        private string Fax, telep, adrs, email, Abre;

        public Demande_de_stage()
        {
            InitializeComponent();
        }

        private void Demande_de_stage_Load(object sender, EventArgs e)
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
            cmd = new SqlCommand("Select N_Insc,Nom_stagaire,Pre_stagaire,CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire ='" + comboBox2.Text + "'", conn);
            SqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string N_Insc = dr["N_Insc"].ToString();
                string Nom_stagaire = dr["Nom_stagaire"].ToString();
                string Pre_stagaire = dr["Pre_stagaire"].ToString();
                string CIN_Stagaire = dr["CIN_Stagaire"].ToString();  
                N_Ins.Text = N_Insc;
                Nom_txt.Text = Nom_stagaire;
                Pre_txt.Text = Pre_stagaire;
                Cin_txt.Text = CIN_Stagaire;
                N_Ins.Text = N_Insc;
                Nom_txt.Text = Nom_stagaire;
                Pre_txt.Text = Pre_stagaire;
                Cin_txt.Text = CIN_Stagaire;
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select Email,Fax,Tele,Addrs ,Abre from Ecole";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Close();
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Fax = dr["Fax"].ToString();
                    telep = dr["Tele"].ToString();
                    adrs = dr["Addrs"].ToString();
                    email = dr["Email"].ToString();
                    Abre = dr["Abre"].ToString();
                }
                conn.Close();
            }
            string n_v;
            if(comboBox1.Text == "1er année")
            {
                n_v = "TSDI1";
            }
            else
            {
                n_v = "TSDI2";
            }
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath, "Demande_de_stagea.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text3"];
            textObject.Text = $"{comboBox2.Text} niveau {n_v} en stage pour une durée déterminée, dans le cas d'un accord de votre part nous vous sourions gré de bien vouloir nous informer pour arrêter avec lui (elle) les modalités du stage.";
            TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text12"];
            textObjec3.Text = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text14"];
            textObjec4.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            TextObject textObjec5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text7"];
            textObjec5.Text = "Autorisation n°4/06/4/95 du 03/01/2011 – Accréditation n°23/K0410S2/DFP/01 du 31/05/2023\r\n" + adrs + " Tél : " + telep + "- Fax : " + Fax + " \r\nSite web : www.espegic.com     -  Email : " + email;
            rp.crystalReportViewer1.ReportSource = reportDocument;
        }
    }
}
