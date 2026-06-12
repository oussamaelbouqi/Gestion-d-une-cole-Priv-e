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

namespace ESPEJIC.UserControl_Archive.UserControl_Ficher_Arch
{
    public partial class Attestation_scol_arch : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Archive1;Integrated Security=True;Encrypt=False");
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        ReportDocument reportDocument = new ReportDocument();
        private string Fax, telep, adrs, email, Abre;

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
            SqlConnection cn = new SqlConnection(connectionString);
            string query = "Select Email,Fax,Tele,Addrs from Ecole";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Close();
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Fax = dr["Fax"].ToString();
                    telep = dr["Tele"].ToString();
                    adrs = dr["Addrs"].ToString();
                    email = dr["Email"].ToString();
                }
                cn.Close();
            }
            string datein = dateTimePicker1.Value.ToString("yyyy");
            string mergde = N_Ins.Text + " le " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string annee = datein + "/" + (Convert.ToInt32(datein) + 1);
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath, "Attestation_de_scolarite.rpt");
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where years='" + comboBox3.Text + "' and Type_stagaire='"+comboBox1.Text+"'", conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Nom";
        }

        public Attestation_scol_arch()
        {
            InitializeComponent();
        }

        private void Attestation_scol_arch_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct years from Stagaire", conn);
            DataTable table1 = new DataTable();
            ad.Fill(table1);
            comboBox3.DataSource = table1;
            comboBox3.DisplayMember = "years";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select distinct Type_stagaire from Stagaire where years='" + comboBox3.Text + "'", conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "Type_stagaire";
        }
    }
}
