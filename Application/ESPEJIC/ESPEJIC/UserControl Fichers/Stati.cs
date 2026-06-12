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

namespace ESPEJIC.UserControl_Fichiers
{
    public partial class Stati : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        String connectionString1 = "Data Source=.;Initial Catalog=Archive1;Integrated Security=True";
        ReportDocument reportDocument = new ReportDocument();
        string nombre_par, nombre_vacat, nombre_entr, nomb_le, nomb_abon, nomb_ajour, nomb1er, nomber2eme, nomberfill1er, nomber2emefill, total, nombrepaserl, capa;
        string nomfil, nuveau;
        public Stati()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView4.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 44;
            dataGridView2.RowTemplate.Height = 44;
            dataGridView4.RowTemplate.Height = 44;
        }

        private void Stati_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query7 = "Select COUNT(CIN_Stagaire) from Stagaire where Type_stagaire = '1er année'";
                string query8 = "Select COUNT(CIN_Stagaire) from Stagaire where Sexe = 'F' AND Type_stagaire = '1er année'";
                string query9 = "Select COUNT(CIN_Stagaire) from Stagaire where Type_stagaire = '2émé année'";
                string query10 = "Select COUNT(CIN_Stagaire) from Stagaire where Type_stagaire = '2émé année' and Sexe = 'F'";
                string query11 = "Select COUNT(ID_Stagaire) from Stagaire";
                using (SqlCommand cmd = new SqlCommand(query7, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomb1er = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query8, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomberfill1er = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query9, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomber2eme = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query10, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nomber2emefill = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query11, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        total = dr[0].ToString();
                    }
                    cn.Close();
                }
                string query1 = "Select COUNT(Matricul) from Formateur where Statut_for = 'Permanent'";
                string query2 = "Select COUNT(Matricul) from Formateur where Statut_for = 'VACATAIRE'";
                string query3 = "Select COUNT(Nom_Entr) from Stage as nombre_entr";
                using (SqlCommand cmd = new SqlCommand(query1, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nombre_par = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nombre_vacat = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query3, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nombre_entr = dr[0].ToString();
                    }
                    cn.Close();
                }
            }
            using (SqlConnection cn = new SqlConnection(connectionString1))
            {
                string query3 = "Select COUNT(CIN_Stagaire) from Stagaire where N_scolaire ='tech'";
                string query4 = "Select COUNT(CIN_Stagaire) from Stagaire where pro = 'Stagiaire Admis' and Type_stagaire = '2émé année'";
                string query5 = "Select COUNT(CIN_Stagaire) from Stagaire where Statut_Stg = 'Abandonné' and Type_stagaire = '2émé année'";
                string query6 = "Select COUNT(CIN_Stagaire) from Stagaire where pro = 'Stagiaire Ajourné' and Type_stagaire = '2émé année'";
                using (SqlCommand cmd = new SqlCommand(query3, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nombrepaserl = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query4, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nomb_le = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query5, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nomb_abon = dr[0].ToString();
                    }
                    cn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query6, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nomb_ajour = dr[0].ToString();
                    }
                    cn.Close();
                }
            }
            dataGridView2.Rows.Add(nomb1er, nomberfill1er, nomber2eme, nomber2emefill, total, nombrepaserl);
            dataGridView4.Rows.Add(nombre_par, nombre_vacat, nombre_entr, nomb_le, nomb_abon, nomb_ajour);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Nom_fill,Niveau,Cap from Filiére  ", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nomfil = dr[0].ToString();
                        nuveau = dr[1].ToString();
                        capa = dr[2].ToString();
                        this.dataGridView1.Rows.Add(dr[0], dr[1], dr[2]);
                    }
                    dr.Close();

                }
                conn.Close();
            }

        }


        private void Ajouter_btn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Close();
                conn.Open();
                reportview rp = new reportview();
                rp.Show();
                //string reportPath = Path.Combine(Application.StartupPath,"Ficher a imprimer", "Statistique.rpt");
                string reportPath = Path.Combine(Application.StartupPath,"Statistique.rpt");
                string modiferpath = "\\bin\\Debug";
                string newpath = reportPath.Replace(modiferpath, string.Empty);
                reportDocument.Load(newpath);
                TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text3"];
                textObject.Text = nomfil;
                TextObject textObjec2 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text10"];
                textObjec2.Text = nuveau;
                TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text31"];
                textObjec3.Text = capa;
                TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text35"];
                textObjec4.Text = nomb1er;
                TextObject textObjec5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text36"];
                textObjec5.Text = nomberfill1er;
                TextObject textObjec6 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text19"];
                textObjec6.Text = nomber2eme;
                TextObject textObjec7 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text32"];
                textObjec7.Text = nomber2emefill;
                TextObject textObjec8 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text28"];
                textObjec8.Text = total;
                TextObject textObjec9 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text33"];
                textObjec9.Text = nombre_par;
                TextObject textObjec10 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text29"];
                textObjec10.Text = nombre_vacat;
                TextObject textObjec11 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text38"];
                textObjec11.Text = nombre_entr;
                TextObject textObjec12 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text30"];
                textObjec12.Text = nomb_le;
                TextObject textObjec13 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text34"];
                textObjec13.Text = nomb_abon;
                TextObject textObjec14 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text40"];
                textObjec14.Text = nomb_ajour;
                TextObject textObjec15 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text37"];
                textObjec15.Text = nombrepaserl;
                rp.crystalReportViewer1.ReportSource = reportDocument;
            }
        }
    }
}
