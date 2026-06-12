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

namespace ESPEJIC.UserControl_Note_Arch
{
    public partial class modilateV2 : UserControl
    {
        string con = "Data Source=.;Initial Catalog=Archive1;Integrated Security=True";
        public SqlCommand cmd;
        public SqlDataReader dr;
        public modilateV2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(con))
            {
                string query = "Select distinct Type_stagaire from Stagaire where years ='"+ comboBox1.Text + "'";
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
            cmd.Dispose();

            string typee_stg = "Type_stagaire='" + comboBox2.Text + "' ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlConnection cn = new SqlConnection(con);
            cmd = new SqlCommand("declare @Number_mat int = (Select COUNT(ID_Matiére) from Matiére where Type_stagaire='" + comboBox2.Text + "' and  years ='"+comboBox1.Text+"') SELECT Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire AS 'Nom et Prénom',CAST(ROUND(SUM(Control_C)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'Control Continus',CAST(ROUND(SUM(Note.EFCE_prat)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'EFCE pratique',CAST(ROUND(SUM(Note.EFCE_thero)/@Number_mat, 2) AS DECIMAL(10,2)) AS 'EFCE theorique',CAST(ROUND(((SUM(Note.Control_C/@Number_mat) + SUM(Note.EFCE_prat/@Number_mat) + SUM(Note.EFCE_thero/@Number_mat))/3), 2) AS DECIMAL(10,2)) AS 'Total', CASE   WHEN ROUND(((SUM(Note.Control_C / @Number_mat) + SUM(Note.EFCE_prat / @Number_mat) + SUM(Note.EFCE_thero / @Number_mat)) / 3), 2) <= 10 THEN 'Stagiaire Ajourné' ELSE 'Stagiaire Admis' END AS 'Status'FROM Note INNER JOIN Stagaire ON Stagaire.CIN_Stagaire = Note.CIN_Stagaire where Stagaire.Type_stagaire = '" + comboBox2.Text + "' and  Stagaire.years  ='" + comboBox1.Text+"' GROUP BY Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire", cn);
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

        private void Modilate_de_Passage_Arch_Load(object sender, EventArgs e)
        {


            SqlConnection cn = new SqlConnection(con);
            
                string query = "Select distinct years from Stagaire";
              cn.Open();
             cmd = new SqlCommand(query, cn);
               SqlDataReader dr = cmd.ExecuteReader();
             while (dr.Read())
                    {
                        comboBox1.Items.Add(dr[0].ToString());
                    }
                   
                    comboBox1.DisplayMember = "years";
            cmd.Dispose();
            cn.Close();
               

        }

        private void Modilate_de_Passage_Arch_Resize(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.WindowState == FormWindowState.Maximized)
            {
                CenterLabel();
                CenterBottun();
            }
        }
    }
}
