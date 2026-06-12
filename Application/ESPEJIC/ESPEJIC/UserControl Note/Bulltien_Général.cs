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
    public partial class Bulltien_Général : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        String connectionString1 = "Data Source=.;Initial Catalog=Archive1;Integrated Security=True";
        double Moyenn1, moyeen2,CC1,CC2,ET2,ET1,EP1,EP2,PFE;
        int quiforcc, quiforep, quiforct,quiforPFE,Total;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Adjust font size for the first column
                e.CellStyle.Font = new Font(dataGridView1.Font.FontFamily, 11);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            dataGridView1.Columns[0].Width = 320;
        }

        private string CIN;
        public Bulltien_Général()
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
        private void Bulltien_Général_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString)) 
            {
                string query = "Select Type_stagaire from Classe where Type_stagaire='2émé année'";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                cn.Open();
                adapter.Fill(dataTable);
                cn.Close();
                comboBox2.DataSource = dataTable;
                comboBox2.DisplayMember = "Type_stagaire";
            }
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label6.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dataGridView1.Rows.Clear();
                string query = "Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where Statut_Stg='active' and Type_stagaire='" + comboBox2.Text + "'";
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "Nom";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int b;
            string query6 = "Select m.ID_Matiére ,m.Nom_Mat from Matiére m left join Note n on m.ID_Matiére = n.ID_Matiére\r\nleft join Stagaire st on st.CIN_Stagaire = n.CIN_Stagaire\r\nwhere (n.EFCE_prat IS NULL OR n.Control_C IS NULL OR n.EFCE_thero IS NULL) AND st.Nom_stagaire+' '+st.Pre_stagaire='" + comboBox1.Text + "'";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query6, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        b = 0;
                    }
                    else
                    {
                        b = 1;
                    }
                    cn.Close();
                }
            }
            if(b== 0)
            {
                dataGridView1.Rows.Clear();
                note.Text = "";
                status.Text = "";
                MessageBox.Show("Les notes de cet élève, « " + comboBox1.Text + " »,sont incomplètes.\nVeuillez entrer tous les notes pour voir la Bulletin général de notes");
            }
            if (b == 1)
            {
                string query5 = "";
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query1 = "Select Quiff from Quiffance where Type_EX='CC'";
                    string query2 = "Select Quiff from Quiffance where Type_EX='EFCE_thero'";
                    string query3 = "Select Quiff from Quiffance where Type_EX='EFCE_prat'";
                    string query4 = "Select Quiff from Quiffance where Type_EX='PFE'";
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
                using (SqlConnection cn = new SqlConnection(connectionString))
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
                using (SqlConnection cn = new SqlConnection(connectionString1))
                {
                    string query = @"
                                    SELECT 
                                    SUM(Control_C) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '1er année' and statu_mat='Active'),
                                    SUM(EFCE_thero) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '1er année' and statu_mat='Active'),
                                    SUM(EFCE_prat) / (SELECT COUNT(ID_Matiére) FROM Matiére WHERE Type_stagaire = '1er année' and statu_mat='Active') 
                                    FROM Note as n inner join Matiére as m on m.ID_Matiére = n.ID_Matiére
                                    WHERE CIN_Stagaire = @CIN and m.statu_mat = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@CIN", CIN);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CC1 = dr.IsDBNull(0) ? 0.0 : dr.GetDouble(0);
                                ET1 = dr.IsDBNull(1) ? 0.0 : dr.GetDouble(1);
                                EP1 = dr.IsDBNull(2) ? 0.0 : dr.GetDouble(2);
                            }
                        }
                        cn.Close();
                    }

                }
                dataGridView1.Rows.Add("Moyenne des notes obtenues en 1ère Année", CC1, ET1, EP1, "N/A");
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select SUM(Control_C)/(Select COUNT(ID_Matiére) from Matiére where Type_stagaire = '2émé année'  and statu_mat = 'Active'),SUM(EFCE_thero)/(select COUNT(ID_Matiére) from Matiére where Type_stagaire = '2émé année'  and statu_mat = 'Active'),SUM(EFCE_prat)/(select COUNT(ID_Matiére) from Matiére where Type_stagaire = '2émé année'  and statu_mat = 'Active') from Note where CIN_Stagaire= '" + CIN + "'";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@CIN", CIN);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CC2 = dr.IsDBNull(0) ? 0.0 : dr.GetDouble(0);
                                ET2 = dr.IsDBNull(1) ? 0.0 : dr.GetDouble(1);
                                EP2 = dr.IsDBNull(2) ? 0.0 : dr.GetDouble(2);
                            }
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
                            PFE = Convert.ToDouble(dr.GetValue(0));
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
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query5, cn))
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
        }
    }
}
