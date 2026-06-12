using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using ESPEJIC.DataSet;
using ESPEJIC.Ficher_a_imprimer;
using ESPEJIC.UserControl_Fichiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC
{
    public partial class list_report : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True;Encrypt=False");
        private string fil;
        private int dat = DateTime.Now.Year - 1;
        public static string Cls,Month;

        public list_report()
        {
            InitializeComponent();
        }

        private void list_report_Load(object sender, EventArgs e)
        {
            Cls = ListeAbs.Classe;
            Month = ListeAbs.Mois;
            SqlCommand cmd1 = new SqlCommand("Select Nom_fill from Filiére",con);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                fil = dr[0].ToString();
            }
            con.Close();
            try
            {
                string sql = "Select CIN_Stagaire,Nom_stagaire,Pre_stagaire from Stagaire where Type_stagaire='" + Cls + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                System.Data.DataSet dts = new System.Data.DataSet();
                dt.Fill(dts, "Stagaire_Abs");
                //string reportPath = Path.Combine(Application.StartupPath, "Liste_de_Presence.rpt");
                ReportDocument rd = new ReportDocument();
                //rd.Load(reportPath);
                string reportPath = Path.Combine(Application.StartupPath,"Liste_de_Presence.rpt");
                string modiferpath = "\\bin\\Debug";
                string newpath = reportPath.Replace(modiferpath, string.Empty);
                rd.Load(newpath);
                rd.SetDataSource(dts);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
                con.Close();
                SetTextObjectValue(rd, "Text7", Month);
                SetTextObjectValue(rd, "Text5", fil);
                SetTextObjectValue(rd, "Text9", dat.ToString());
                crystalReportViewer1.ReportSource = rd;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void SetTextObjectValue(ReportDocument report, string textObjectName, string value)
        {
            TextObject textObject = (TextObject)report.ReportDefinition.ReportObjects[textObjectName];
            textObject.Text = value;
        }
    }
}
