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
    public partial class Bulletin : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        private string CIN_st;
        private int Num, CC, EFCF_t, EFCE_p,PFE,Total;
        float Note_PFE;
        public Bulletin()
        {
            InitializeComponent();
        }
        private void Bulletin_Load(object sender, EventArgs e)
        {
            string query =  "Select Type_stagaire from Classe";
            string query1 = "Select Quiff from Quiffance where Type_EX='CC'";
            string query2 =  "Select Quiff from Quiffance where Type_EX='EFCE_thero'";
            string query3 =  "Select Quiff from Quiffance where Type_EX='EFCE_prat'";
            string query4 =  "Select Quiff from Quiffance where Type_EX='PFE'";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query1, cn);
                SqlCommand cmd1 = new SqlCommand(query2, cn);
                SqlCommand cmd2 = new SqlCommand(query3, cn);
                SqlCommand cmd3 = new SqlCommand(query4 , cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CC = Convert.ToInt32(dr[0].ToString());
                    }
                }
                dr.Close();                
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
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter(query,cn);
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
            label6.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire ='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query,cn);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CIN_st = dr[0].ToString();
                    }
                    dr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                string query6 = "Select PFE from PFE where CIN_Stagaire = '" + CIN_st + "'";
                SqlCommand cmd = new SqlCommand(query6,cn);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Note_PFE = float.Parse(dr[0].ToString());
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
            string query5 = "Select m.ID_Matiére ,m.Nom_Mat from Matiére m left join Note n on m.ID_Matiére = n.ID_Matiére\r\nleft join Stagaire st on st.CIN_Stagaire = n.CIN_Stagaire\r\nwhere (n.EFCE_prat IS NULL OR n.Control_C IS NULL OR n.EFCE_thero IS NULL) AND st.Nom_stagaire+' '+st.Pre_stagaire='"+comboBox1.Text+ "' and statu_mat = 'Active'";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query5, cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dataGridView1.Rows.Clear();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MessageBox.Show("Les notes de cet élève, « "+comboBox1.Text+ " »,sont incomplètes.\nVeuillez entrer tous les notes pour voir la Bulletin de notes");
                    }
                    else
                    {
                        dataGridView1.Rows.Clear();
                        string query = "Select Matiére.Nom_Mat , Control_C,EFCE_thero,EFCE_prat from Note inner join Matiére on Matiére.ID_Matiére = Note.ID_Matiére where CIN_Stagaire='" + CIN_st + "' and statu_mat = 'Active' ORDER BY Matiére.ID_Matiére ASC ";
                        SqlCommand cmd1 = new SqlCommand(query, cn);
                        double MoyenT = 0;
                        double MoyenP = 0;
                        double MoyenC = 0;
                        try
                        {
                            cn.Close();
                            cn.Open();
                            SqlDataReader dr1 = cmd1.ExecuteReader();
                            while (dr1.Read())
                            {
                                string Module = dr1["Nom_Mat"].ToString();
                                string Control_C = dr1["Control_C"].ToString();
                                string EFCE_t = dr1["EFCE_thero"].ToString();
                                string EFCE_p = dr1["EFCE_prat"].ToString();
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                        if (comboBox2.Text == "1er année")
                        {
                            using (SqlConnection cn1 = new SqlConnection(connectionString))
                            {
                                string quers = "Select COUNT(ID_Matiére) from Matiére where Type_stagaire ='" + comboBox2.Text + "' and statu_mat='Active'";
                                SqlCommand cmd2 = new SqlCommand(quers, cn1);
                                try
                                {
                                    cn1.Open();
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        Num = Convert.ToInt32(dr2[0].ToString());
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
                                string quers = "Select COUNT(ID_Matiére) from Matiére where Type_stagaire ='" + comboBox2.Text + "' and statu_mat = 'Active'";
                                SqlCommand cmd3 = new SqlCommand(quers, cn1);
                                try
                                {
                                    cn1.Open();
                                    SqlDataReader dr3 = cmd3.ExecuteReader();
                                    while (dr3.Read())
                                    {
                                        Num = Convert.ToInt32(dr3[0].ToString());
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
                    cn.Close();
                }
            }   
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                dataGridView1.Rows.Clear();
                string query = "Select Nom_stagaire+' '+Pre_stagaire as Nom from Stagaire where Statut_Stg='active' and Type_stagaire='" + comboBox2.Text + "'";
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter(query,cn);
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

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int hgh = 36;
            dataGridView1.Rows[e.RowIndex].Height = hgh;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float value;
            string query1 = "update Stagaire set pro = @pro where CIN_Stagaire='"+CIN_st+"' ";
            if (float.TryParse(textBox1.Text, out value))
            {
                if(value >= 10)
                {
                    textBox2.Text = "Stagiaire Admis";
                }
                else if(value < 10)
                {
                    textBox2.Text = "Stagiaire Ajourné";
                }
            }
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query1, cn))
                {
                    cn.Open();
                    cmd.Parameters.AddWithValue("@pro", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
    }
}
