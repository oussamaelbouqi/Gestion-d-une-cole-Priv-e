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

namespace ESPEJIC.UserControl_Fichers
{
    public partial class Attestation_omog : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        ReportDocument reportDocument = new ReportDocument();
        private string Fax, telep, adrs,email;
        public Attestation_omog()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            SqlCommand cmd1, cmd3;
            cmd1 = new SqlCommand("Select N_Insc,Nom_stagaire,Pre_stagaire,CIN_Stagaire,Date_Ins,N_scolaire,Type_stagaire,Addrs,Email,Tele ,Date_naissance,Lieu_naissance from Stagaire where Nom_stagaire+' '+Pre_stagaire ='" + comboBox2.Text + "'", conn);
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
                string Date_n = dr["Date_naissance"].ToString();
                string Lieu_n = dr["Lieu_naissance"].ToString();
                N_Ins.Text = N_Insc;
                Nom_txt.Text = Nom_stagaire;
                Pre_txt.Text = Pre_stagaire;
                Cin_txt.Text = CIN_Stagaire;
                comboBox5.Text = N_scolaire;
                Adr_txt.Text = Addrs;
                Email_txt.Text = Email;
                Tele_txt.Text = Tele;
                dateTimePicker1.Text = Date_Ins;
                dateTimePicker2.Text = Date_n;
                textBox1.Text = Lieu_n;
            }
            conn.Close();
        }

        private void Cin_label_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where Type_stagaire='" + comboBox1.Text + "'", conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Nom";
        }

        private void Attestation_omog_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            string query = "Select Email,Fax,Tele,Addrs from Ecole";
            using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Fax = dr["Fax"].ToString();
                    telep = dr["Tele"].ToString();
                    adrs = dr["Addrs"].ToString();
                    email = dr["Email"].ToString();
                }
                conn.Close();
            } 
            string date_n = dateTimePicker2.Value.ToString("dd/MM/yyyy") +" à " + textBox1.Text;
            string datein = dateTimePicker1.Value.ToString("yyyy");
            string mergde = N_Ins.Text + " le " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string annee = (Convert.ToInt32(datein) - 1).ToString() + "/" + datein;
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath, "ATTESTATION_omologé.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text14"];
            textObject.Text = comboBox2.Text;
            TextObject textObjec2 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text7"];
            textObjec2.Text = date_n;
            TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text13"];
            textObjec3.Text = mergde;
            TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text1"];
            textObjec4.Text = annee;
            TextObject textObjec5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text23"];
            textObjec5.Text = mergde;
            TextObject textObjec6 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text25"];
            textObjec6.Text = annee;
            TextObject textObjec10 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text28"];
            textObjec10.Text = "Autorisation n°4 / 06 / 4 / 95 du 03 / 01 / 2011 – Accréditation n°23 / K0410S2 / DFP / 01 du 31 / 05 / 2023\r\n" + adrs + " Tél: " + telep + " - Fax : " + Fax + " \r\nSite web : www.espegic.com - Email : " + email;
            rp.crystalReportViewer1.ReportSource = reportDocument;
        }
    }
}
