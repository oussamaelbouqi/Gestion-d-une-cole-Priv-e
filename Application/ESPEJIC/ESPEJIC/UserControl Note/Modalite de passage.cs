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

namespace ESPEJIC.UserControl_Note
{
    public partial class Modalite_de_passage : UserControl
    {
        string con = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        public SqlCommand cmd;
        public SqlDataReader dr;
        private int Num, CC, EFCF_t, EFCE_p, PFE, Total;

        public Modalite_de_passage()
        {

            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn=new SqlConnection(con);
            string query1 = "Select Quiff from Quiffance where Type_EX='CC'";
            string query2 = "Select Quiff from Quiffance where Type_EX='EFCE_thero'";
            string query3 = "Select Quiff from Quiffance where Type_EX='EFCE_prat'";
            string query4 = "Select Quiff from Quiffance where Type_EX='PFE'";
            SqlCommand cmd = new SqlCommand(query1, cn);
            SqlCommand cmd1 = new SqlCommand(query2, cn);
            SqlCommand cmd2 = new SqlCommand(query3, cn);
            SqlCommand cmd3 = new SqlCommand(query4, cn);
            cn.Open();
            SqlDataReader dr6 = cmd.ExecuteReader();
            if (dr6.HasRows)
            {
                while (dr6.Read())
                {
                    CC = Convert.ToInt32(dr6[0].ToString());
                }
            }
            dr6.Close();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    EFCF_t = Convert.ToInt32(dr1[0].ToString());
                }
            }
            dr1.Close();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    EFCE_p = Convert.ToInt32(dr2[0].ToString());
                }
            }
            dr2.Close();
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.HasRows)
            {
                while (dr3.Read())
                {
                    PFE = Convert.ToInt32(dr3[0].ToString());
                }
            }
            Total = CC + EFCF_t + EFCE_p + PFE;
            cn.Close();
            dataGridView1.Rows.Clear();
            string query6 = "";
            if(comboBox2.Text == "1er année")
            {
                query6 = "declare @Number_mat int = (Select COUNT(ID_Matiére) from Matiére where Type_stagaire='" + comboBox2.Text + "' and statu_mat='Active') SELECT Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire AS 'Nom et Prénom',CAST(ROUND(SUM(Control_C)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'Control Continus',CAST(ROUND(SUM(Note.EFCE_prat)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'EFCE pratique',CAST(ROUND(SUM(Note.EFCE_thero)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'EFCE theorique',CAST(ROUND(((SUM(Note.Control_C/@Number_mat) * '" + CC + "' + SUM(Note.EFCE_prat/@Number_mat) * '" + EFCE_p + "' + SUM(Note.EFCE_thero/@Number_mat) * '" + EFCF_t + "')/ '" + (Total - PFE) + "'), 2) AS DECIMAL(10,2)) AS 'Total', CASE   WHEN ROUND(((SUM(Note.Control_C / @Number_mat) + SUM(Note.EFCE_prat / @Number_mat) + SUM(Note.EFCE_thero / @Number_mat)) / 3), 2) <= 10 THEN 'Stagiaire Ajourné' ELSE 'Stagiaire Admis' END AS 'Status'FROM Note INNER JOIN Stagaire ON Stagaire.CIN_Stagaire = Note.CIN_Stagaire where Stagaire.Type_stagaire = '" + comboBox2.Text + "' GROUP BY Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire";
            }
            else
            {
                query6 = "declare @Number_mat int = (Select COUNT(ID_Matiére) from Matiére where Type_stagaire='" + comboBox2.Text + "' and statu_mat='Active') SELECT Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire AS 'Nom et Prénom',CAST(ROUND(SUM(Control_C)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'Control Continus',CAST(ROUND(SUM(Note.EFCE_prat)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'EFCE pratique',CAST(ROUND(SUM(Note.EFCE_thero)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'EFCE theorique',CAST(ROUND((((SUM(Note.Control_C/@Number_mat) * '" + CC + "' + SUM(Note.EFCE_prat/@Number_mat) * '" + EFCE_p + "' + SUM(Note.EFCE_thero/@Number_mat) * '" + EFCF_t + "') + (Select PFE * '" + PFE+"' from PFE) ) / '" + Total + "'), 2) AS DECIMAL(10,2)) AS 'Total', CASE   WHEN ROUND(((SUM(Note.Control_C / @Number_mat) + SUM(Note.EFCE_prat / @Number_mat) + SUM(Note.EFCE_thero / @Number_mat)) / 3), 2) <= 10 THEN 'Stagiaire Ajourné' ELSE 'Stagiaire Admis' END AS 'Status'FROM Note INNER JOIN Stagaire ON Stagaire.CIN_Stagaire = Note.CIN_Stagaire where Stagaire.Type_stagaire = '" + comboBox2.Text + "' GROUP BY Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire";
            }
            cmd = new SqlCommand(query6,cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
            }
            cn.Close();
        }
        private void CenterBottun()
        {
            //int centerX = (Width - panel3.Width) / 2;
            //panel3.Location = new Point(centerX, 50);
        }
        private void CenterLabel()
        {
            int centerX = (Width - label4.Width) / 2;
            label4.Location = new Point(centerX, 50);
        }
        private void Modalite_de_passage_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                string query = "Select Type_stagaire from Classe";
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    comboBox2.DataSource = table;
                    comboBox2.DisplayMember = "Type_stagaire";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
             int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            string typee_stg = "Type_stagaire='" + comboBox2.Text + "' ";
            label6.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";


        }

        private void Modalite_de_passage_Resize(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.WindowState == FormWindowState.Maximized)
            {
                CenterLabel();
                CenterBottun();
            }
        }
    }
}

