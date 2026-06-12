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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Note_Arch
{
    public partial class Bulletin_Arch : UserControl
    {
        private string CIN_st;
        private int Num, CC, EFCF_t, EFCE_p, PFE, Total;
        float Note_PFE;
        String connectionString = "Data Source=.;Initial Catalog=Archive1;Integrated Security=True";
        public Bulletin_Arch()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int hgh = 36;
            dataGridView1.Rows[e.RowIndex].Height = hgh;
        }

        private void Bulletin_Arch_Load(object sender, EventArgs e)
        {
            string query0 = "Select distinct years from Stagaire";
            string query = "Select distinct Type_stagaire from Stagaire";
            string query1 = "Select DISTINCT Quiff from Quiffance where Type_EX='CC' and years = '"+comboBox3.Text+"'";
            string query2 = "Select DISTINCT Quiff from Quiffance where Type_EX='EFCE_thero' and years = '" + comboBox3.Text+"'";
            string query3 = "Select DISTINCT Quiff from Quiffance where Type_EX='EFCE_prat' and years = '" + comboBox3.Text+"'";
            string query4 = "Select DISTINCT Quiff from Quiffance where Type_EX='PFE' and years = '" + comboBox3.Text+"'";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd0 = new SqlCommand(query0, cn);
                //SqlCommand cmd = new SqlCommand(query1, cn);
                //SqlCommand cmd1 = new SqlCommand(query2, cn);
                //SqlCommand cmd2 = new SqlCommand(query3, cn);
                //SqlCommand cmd3 = new SqlCommand(query4, cn);
                cn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        CC = Convert.ToInt32(dr[0].ToString());
                //    }
                //}
                //dr.Close();

                SqlDataReader dr0 = cmd0.ExecuteReader();
                if (dr0.HasRows)
                {
                    while (dr0.Read())
                    {
                        comboBox3.Items.Add(dr0[0].ToString());
                    }
                }
                dr0.Close();
                //SqlDataReader dr1 = cmd1.ExecuteReader();
                //if (dr1.HasRows)
                //{
                //    while (dr1.Read())
                //    {
                //        EFCF_t = Convert.ToInt32(dr1[0].ToString());
                //    }
                //}
                //dr1.Close();
                //SqlDataReader dr2 = cmd2.ExecuteReader();
                //if (dr2.HasRows)
                //{
                //    while (dr2.Read())
                //    {
                //        EFCE_p = Convert.ToInt32(dr2[0].ToString());
                //    }
                //}
                //dr2.Close();
                //SqlDataReader dr3 = cmd3.ExecuteReader();
                //if (dr3.HasRows)
                //{
                //    while (dr3.Read())
                //    {
                //        PFE = Convert.ToInt32(dr3[0].ToString());
                //    }
                //}
                //Total = CC + EFCF_t + EFCE_p + PFE;
                //cn.Close();
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
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dataGridView1.Rows.Clear();
                string query = "Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where Type_stagaire='" + comboBox2.Text + "' and years ='" + comboBox3.Text + "' ";
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.CellStyle.Font = new Font("Segoe UI,", 11, FontStyle.Regular);
                dataGridView1.Columns[0].Width = 350;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "Select pro from Stagaire where CIN_Stagaire=@CIN";
                string query1 = "Select DISTINCT Quiff from Quiffance where Type_EX='CC' and years = '" + comboBox3.Text + "'";
                string query2 = "Select DISTINCT Quiff from Quiffance where Type_EX='EFCE_thero' and years = '" + comboBox3.Text + "'";
                string query3 = "Select DISTINCT Quiff from Quiffance where Type_EX='EFCE_prat' and years = '" + comboBox3.Text + "'";
                string query4 = "Select DISTINCT Quiff from Quiffance where Type_EX='PFE' and years = '" + comboBox3.Text + "'";
                string query5 = "Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire ='" + comboBox1.Text + "' and years ='"+comboBox3.Text+"'";
                SqlCommand cmd = new SqlCommand(query5, cn);
                try
                {
                    cn.Open();
                    SqlDataReader dr5 = cmd.ExecuteReader();
                    while (dr5.Read())
                    {
                        CIN_st = dr5[0].ToString();
                    }
                    dr5.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                try
                {
                    using(SqlCommand cmd5 = new SqlCommand(query, cn))
                    {
                        cmd5.Parameters.AddWithValue("@CIN", CIN_st);
                        cn.Open();
                        SqlDataReader dr6 = cmd5.ExecuteReader();
                        if (dr6.Read())
                        {
                            textBox2.Text = dr6[0].ToString();
                        }
                        cn.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                SqlCommand cmd1 = new SqlCommand(query1, cn);
                SqlCommand cmd2 = new SqlCommand(query2, cn);
                SqlCommand cmd3 = new SqlCommand(query3, cn);
                SqlCommand cmd4 = new SqlCommand(query4, cn);
                cn.Close(); 
                cn.Open();
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string value = dr[0].ToString();
                        if (int.TryParse(value, out int result))
                        {
                            CC = result;
                        }
                    }
                }
                dr.Close();
                SqlDataReader dr1 = cmd2.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        EFCF_t = Convert.ToInt32(dr1[0].ToString());
                    }
                }
                dr1.Close();
                SqlDataReader dr2 = cmd3.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        EFCE_p = Convert.ToInt32(dr2[0].ToString());
                    }
                }
                dr2.Close();
                SqlDataReader dr3 = cmd4.ExecuteReader();
                if (dr3.HasRows)
                {
                    while (dr3.Read())
                    {
                        PFE = Convert.ToInt32(dr3[0].ToString());
                    }
                }
                Total = CC + EFCF_t + EFCE_p + PFE;
                cn.Close();
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query5 = "Select PFE from PFE where CIN_Stagaire = '" + CIN_st + "'";
                SqlCommand cmd = new SqlCommand(query5, cn);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Note_PFE = float.Parse(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dataGridView1.Rows.Clear();
                string query = "Select Matiére.Nom_Mat , Control_C,EFCE_thero,EFCE_prat from Note inner join Matiére on Matiére.ID_Matiére = Note.ID_Matiére where CIN_Stagaire='" + CIN_st + "' and statu_mat = 'Active'  and Type_stagaire='"+comboBox2.Text+"' ORDER BY Matiére.ID_Matiére ASC ";
                SqlCommand cmd = new SqlCommand(query, cn);
                double MoyenT = 0;
                double MoyenP = 0;
                double MoyenC = 0;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string Module = dr["Nom_Mat"].ToString();
                        string Control_C = dr["Control_C"].ToString();
                        string EFCE_t = dr["EFCE_thero"].ToString();
                        string EFCE_p = dr["EFCE_prat"].ToString();
                        dataGridView1.Rows.Add(Module, Control_C, EFCE_t, EFCE_p);
                        double Control = 0;
                        double thero = 0;
                        double prati = 0;
                        if (double.TryParse(Control_C, out Control))
                        {
                            MoyenC += Control;
                        }
                        if (double.TryParse(EFCE_t, out thero))
                        {
                            MoyenT += thero;
                        }
                        if (double.TryParse(EFCE_p, out prati))
                        {
                            MoyenP += prati;
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                if (comboBox2.Text == "1er année")
                {
                    using (SqlConnection cn1 = new SqlConnection(connectionString))
                    {
                        string quers = "Select COUNT(ID_Matiére) from Matiére where Type_stagaire ='" + comboBox2.Text + "' and statu_mat = 'Active'";
                        SqlCommand cmd1 = new SqlCommand(quers, cn1);
                        try
                        {
                            cn1.Open();
                            SqlDataReader dr = cmd1.ExecuteReader();
                            while (dr.Read())
                            {
                                Num = Convert.ToInt32(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    MoyenC /= Num;
                    MoyenT /= Num;
                    MoyenP /= Num;
                }
                if (comboBox2.Text == "2émé année")
                {
                    using (SqlConnection cn1 = new SqlConnection(connectionString))
                    {
                        string quers = "Select COUNT(ID_Matiére) from Matiére where Type_stagaire ='" + comboBox2.Text + "'  and statu_mat = 'Active'";
                        SqlCommand cmd1 = new SqlCommand(quers, cn1);
                        try
                        {
                            cn1.Open();
                            SqlDataReader dr = cmd1.ExecuteReader();
                            while (dr.Read())
                            {
                                Num = Convert.ToInt32(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    MoyenC /= Num;
                    MoyenT /= Num;
                    MoyenP /= Num;
                }
                dataGridView1.Rows.Add("Moyennes des notes", MoyenC.ToString("0.00"), MoyenT.ToString("0.00"), MoyenP.ToString("0.00"));
                int countrows = dataGridView1.RowCount - 1;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (i == countrows)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC99");
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                if (comboBox2.SelectedIndex == 0)
                {
                    textBox1.Text = (((MoyenC * CC) + (MoyenT * EFCF_t) + (MoyenP * EFCE_p)) / (Total - PFE)).ToString();
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    textBox1.Text = (((MoyenC * CC) + (MoyenT * EFCF_t) + (MoyenP * EFCE_p) + Note_PFE * PFE) / Total).ToString();
                }
                float value;
                if (float.TryParse(textBox1.Text, out value))
                {
                    textBox1.Text = value.ToString("0.00");
                    textBox1.SelectionStart = textBox1.Text.Length;
                }

            }
        }
    }
}
