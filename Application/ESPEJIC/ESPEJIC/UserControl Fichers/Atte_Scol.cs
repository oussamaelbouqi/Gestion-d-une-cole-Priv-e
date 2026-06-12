using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ESPEJIC.UserControl_Fichiers
{
    public partial class Atte_Scol : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        ReportDocument reportDocument = new ReportDocument();
        private string Fax, telep, adrs, email, Abre;
        public Atte_Scol()
        {
            InitializeComponent();
        }

        private void Atte_Scol_Load(object sender, EventArgs e)
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
            SqlCommand cmd1, cmd3;
            cmd1 = new SqlCommand("Select N_Insc,Nom_stagaire,Pre_stagaire,CIN_Stagaire,Date_Ins,N_scolaire,Type_stagaire,Addrs,Email,Tele from Stagaire where Nom_stagaire+' '+Pre_stagaire ='" + comboBox2.Text + "'", conn);
            SqlDataAdapter dt1, dt2;
            dt1 = new SqlDataAdapter();
            dt2 = new SqlDataAdapter();
            cmd3 = new SqlCommand("Select N_scolaire from Diplome", conn);
            dt1.SelectCommand = cmd3;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox5.DataSource = table1;
            comboBox5.DisplayMember = "N_scolaire";
            SqlDataReader dr;
            conn.Open();
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string N_Insc = dr["N_Insc"].ToString();
                string Nom_stagaire = dr["Nom_stagaire"].ToString();
                string Pre_stagaire = dr["Pre_stagaire"].ToString();
                string CIN_Stagaire = dr["CIN_Stagaire"].ToString();
                string Date_Ins = dr["Date_Ins"].ToString();
                string N_scolaire = dr["N_scolaire"].ToString();
                string Addrs = dr["Addrs"].ToString();
                string Email = dr["Email"].ToString();
                string Tele = dr["Tele"].ToString();
                N_Ins.Text = N_Insc;
                Nom_txt.Text = Nom_stagaire;
                Pre_txt.Text = Pre_stagaire;
                Cin_txt.Text = CIN_Stagaire;
                comboBox5.Text = N_scolaire;
                Adr_txt.Text = Addrs;
                Email_txt.Text = Email;
                Tele_txt.Text = Tele;
                dateTimePicker1.Text = Date_Ins;
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
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    Fax = dr1["Fax"].ToString();
                    telep = dr1["Tele"].ToString();
                    adrs = dr1["Addrs"].ToString();
                    email = dr1["Email"].ToString();
                    Abre = dr1["Abre"].ToString();
                }
                conn.Close();
            }
            string datein = dateTimePicker1.Value.ToString("yyyy");
            string mergde = N_Ins.Text + " le " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string annee = (Convert.ToInt32(datein) - 1).ToString() + "/" + datein;
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath,"Attestation_de_scolarite.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text6"];
            textObject.Text = comboBox2.Text;
            TextObject textObjec2 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text7"];
            textObjec2.Text = Cin_txt.Text;
            TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text8"];
            textObjec3.Text = mergde;
            TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text13"];
            textObjec4.Text = annee;
            TextObject textObjec5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text12"];
            textObjec5.Text = "Autorisation n°4 / 06 / 4 / 95 du 03 / 01 / 2011 – Accréditation n°23 / K0410S2 / DFP / 01 du 31 / 05 / 2023\r\n" + adrs + " Tél: " + telep + " - Fax : " + Fax + " \r\nSite web : www.espegic.com - Email : " + email;
            rp.crystalReportViewer1.ReportSource = reportDocument;
            conn.Close();
        }
    }
}
