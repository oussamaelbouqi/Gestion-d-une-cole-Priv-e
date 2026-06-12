using CrystalDecisions.CrystalReports.Engine;
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

namespace ESPEJIC.UserControl_Archive.UserControl_Ficher_Arch
{
    public partial class Bulettin_arch : UserControl
    {
        String connectionString1 = "Data Source=.;Initial Catalog=Archive1;Integrated Security=True";
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        ReportDocument reportDocument = new ReportDocument();
        private string Fax, telep, adrs, email, Abre, CIN, years1, years,Nom_fill, anne;
        double Moyenn1, moyeen2, CC1, CC2, ET2, ET1, EP1, EP2, PFE;
        int quiforcc, quiforep, quiforct, quiforPFE, Total;

        private void Imprimer_Bul_Click(object sender, EventArgs e)
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
            string query1 = "Select Nom_Full from Filiére";
            SqlConnection conn = new SqlConnection(connectionString1);
            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nom_fill = reader[0].ToString();
                }
                conn.Close();
            }
            int currentYear = DateTime.Now.Year;
            string N_inc = "";
            string query2 = "Select N_Insc from Stagaire where Nom_stagaire+' '+Pre_stagaire='" + comboBox1.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query2, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    N_inc = reader.GetString(0);
                }
                conn.Close();
            }
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath,"Bulttletin.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text7"];
            textObject.Text = N_inc;
            TextObject textObjec2 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text8"];
            textObjec2.Text = comboBox1.Text;
            TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text9"];
            textObjec3.Text = Nom_fill;
            TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text10"];
            textObjec4.Text = currentYear.ToString("00.##");
            TextObject textObjec5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text17"];
            textObjec5.Text = CC1.ToString("00.##");
            TextObject textObjec6 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text21"];
            textObjec6.Text = CC2.ToString("00.##");
            TextObject textObjec7 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text16"];
            textObjec7.Text = ET1.ToString("00.##");
            TextObject textObjec8 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text20"];
            textObjec8.Text = ET2.ToString("00.##");
            TextObject textObjec9 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text18"];
            textObjec9.Text = EP1.ToString("00.##");
            TextObject textObjec10 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text22"];
            textObjec10.Text = EP2.ToString("00.##");
            TextObject textObjec11 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text25"];
            textObjec11.Text = ((CC1 + CC2) / 2).ToString("00.##");
            TextObject textObjec12 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text24"];
            textObjec12.Text = ((ET1 + ET2) / 2).ToString("00.##");
            TextObject textObjec13 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text26"];
            textObjec13.Text = ((EP1 + EP2) / 2).ToString("00.##");
            TextObject textObjec14 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text36"];
            textObjec14.Text = "Autorisation n°4 / 06 / 4 / 95 du 03 / 01 / 2011 – Accréditation n°23 / K0410S2 / DFP / 01 du 31 / 05 / 2023\r\n" + adrs + " Tél: " + telep + " - Fax : " + Fax + " \r\nSite web : www.espegic.com - Email : " + email;
            //TextObject textObjec15 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text25"];
            //textObjec15.Text = (((CC1 + CC2) / 2) * quiforcc).ToString("00.##");
            //TextObject textObjec16 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text26"];
            //textObjec16.Text = (((EP1 + EP2) / 2) * quiforep).ToString("00.##");
            //TextObject textObjec17 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text24"];
            //textObjec17.Text = (((ET1 + ET2) / 2) * quiforct).ToString("00.##");
            TextObject textObjec18 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text33"];
            textObjec18.Text = status.Text;
            TextObject textObjec19 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text31"];
            textObjec19.Text = note.Text;
            rp.crystalReportViewer1.ReportSource = reportDocument;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            dataGridView1.Columns[0].Width = 320;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.CellStyle.Font = new Font(dataGridView1.Font.FontFamily, 11);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(connectionString1);
            string query = "Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where years='"+comboBox3.Text+"' and Type_stagaire= '2émé année'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query5 = "";
            using (SqlConnection cn = new SqlConnection(connectionString1))
            {
                string query1 = "Select Quiff from Quiffance where Type_EX='CC' and years ='"+comboBox3.Text+"'";
                string query2 = "Select Quiff from Quiffance where Type_EX='EFCE_thero' and years ='"+comboBox3.Text+"'";
                string query3 = "Select Quiff from Quiffance where Type_EX='EFCE_prat' and years ='"+comboBox3.Text+"'";
                string query4 = "Select Quiff from Quiffance where Type_EX='PFE' and years ='"+comboBox3.Text+"'";
                SqlCommand cmd4 = new SqlCommand(query1, cn);
                SqlCommand cmd1 = new SqlCommand(query2, cn);
                SqlCommand cmd2 = new SqlCommand(query3, cn);
                SqlCommand cmd3 = new SqlCommand(query4, cn);
                cn.Open();
                SqlDataReader dr = cmd4.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        quiforcc = Convert.ToInt32(dr[0].ToString());
                    }
                }
                dr.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        quiforct = Convert.ToInt32(dr1[0].ToString());
                    }
                }
                dr1.Close();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        quiforep = Convert.ToInt32(dr2[0].ToString());
                    }
                }
                dr2.Close();
                SqlDataReader dr3 = cmd3.ExecuteReader();
                if (dr3.HasRows)
                {
                    while (dr3.Read())
                    {
                        quiforPFE = Convert.ToInt32(dr3[0].ToString());
                    }
                }
                Total = quiforct + quiforep + quiforPFE + quiforcc;
                cn.Close();
            }
            dataGridView1.Rows.Clear();
            using (SqlConnection cn = new SqlConnection(connectionString1))
            {
                string query = "Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire = '" + comboBox1.Text + "'";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        CIN = dr[0].ToString();
                    }
                    cn.Close();
                }
            }
            using(SqlConnection cn = new SqlConnection(connectionString1))
            {
            string query = "SELECT CONCAT(CAST(CAST(LEFT(Years, CHARINDEX('/', Years) - 1) AS INT) - 1 AS VARCHAR), '/', CAST(CAST(SUBSTRING(Years, CHARINDEX('/', Years) + 1, LEN(Years)) AS INT) - 1 AS VARCHAR)) AS Years1 FROM Stagaire where CIN_Stagaire='"+CIN+"' and Type_stagaire = '2émé année' ;";
                using(SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        years = dr[0].ToString();
                    }
                    cn.Close();
                }
            string query1 = "Select years from Stagaire where Type_stagaire = '2émé année' and CIN_Stagaire = '" + CIN + "'";
                using(SqlCommand cmd = new SqlCommand(query1, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        years1 = dr[0].ToString();
                    }
                    cn.Close();
                }
            }

            using (SqlConnection cn = new SqlConnection(connectionString1))
            {
                string query = @"SELECT 
                                SUM(Control_C) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '1er année' and statu_mat = 'Active'),
                                SUM(EFCE_thero) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '1er année' and statu_mat = 'Active'),
                                SUM(EFCE_prat) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '1er année' and statu_mat = 'Active') 
                                FROM Note as n inner join Matiére as m on m.ID_Matiére = n.ID_Matiére
                                WHERE CIN_Stagaire = '"+ CIN + "' and m.statu_mat = 'Active' and Type_stagaire = '1er année'";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        CC1 = dr.IsDBNull(0) ? 0.0 : dr.GetDouble(0);
                        ET1 = dr.IsDBNull(1) ? 0.0 : dr.GetDouble(1);
                        EP1 = dr.IsDBNull(2) ? 0.0 : dr.GetDouble(2);
                    }
                    cn.Close();
                }
            }
            dataGridView1.Rows.Add("Moyenne des notes obtenues en 1ère Année", CC1, ET1, EP1, "N/A");
            using (SqlConnection cn = new SqlConnection(connectionString1))
            {
                string query = @"SELECT 
                                SUM(Control_C) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '2émé année' and statu_mat='Active'),
                                SUM(EFCE_thero) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '2émé année' and statu_mat='Active'),
                                SUM(EFCE_prat) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '2émé année' and statu_mat='Active') 
                                FROM Note as n inner join Matiére as m on m.ID_Matiére = n.ID_Matiére
                                WHERE CIN_Stagaire = '"+CIN+"' and m.statu_mat = 'Active' and Type_stagaire= '2émé année'";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CC2 = dr.IsDBNull(0) ? 0.0 : dr.GetDouble(0);
                        ET2 = dr.IsDBNull(1) ? 0.0 : dr.GetDouble(1);
                        EP2 = dr.IsDBNull(2) ? 0.0 : dr.GetDouble(2);
                    }
                    cn.Close();
                }
                string query1 = "Select PFE from PFE where CIN_Stagaire = '" + CIN + "'";
                using (SqlCommand cmd = new SqlCommand(query1, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        PFE = dr.IsDBNull(0) ? 0.0 : Convert.ToDouble(dr.GetValue(0));
                    }
                    cn.Close();
                }
                dataGridView1.Rows.Add("Moyenne des notes obtenues en 2ème Année", CC2, ET2, EP2, PFE);
                dataGridView1.Rows.Add("Moyenne des notes \n 1ère Année+ 2ème Année", (CC1 + CC2) / 2, (ET1 + ET2) / 2, (EP1 + EP2) / 2, PFE);
            }
            note.Text = (((((CC1 + CC2) / 2) * quiforcc) + (((ET1 + ET2) / 2) * quiforct) + (((EP1 + EP2) / 2) * quiforep) + (PFE * quiforPFE)) / Total).ToString("00.##");
            if (Convert.ToDouble(note.Text) >= 10)
            {
                query5 = "Update Stagaire set pro = 'Stagiaire Admis'";
                status.Text = "Stagiaire Admis";
            }
            else
            {
                query5 = "Update Stagaire set pro = 'Stagiaire Ajourné'";
                status.Text = "Stagiaire Ajourné";
            }
            using (SqlConnection cn = new SqlConnection(connectionString1))
            {
                using (SqlCommand cmd = new SqlCommand(query5, cn))
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        public Bulettin_arch()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 85;
            ConfigureDataGridView();
        }
        private void ConfigureDataGridView()
        {
            // Set the default cell style format for the column
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Format = "0.00";
            }
        }

        private void Bulettin_arch_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(connectionString1);
            SqlDataAdapter ad = new SqlDataAdapter("Select DISTINCT years from Stagaire where Type_stagaire = '2émé année'", conn);
            DataTable table1 = new DataTable();
            ad.Fill(table1);
            comboBox3.DataSource = table1;
            comboBox3.DisplayMember = "years";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlConnection conn = new SqlConnection(connectionString1);
            SqlDataAdapter adp = new SqlDataAdapter("Select Type_stagaire from Classe where Type_stagaire='2émé année'", conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Type_stagaire";
        }
    }
}
