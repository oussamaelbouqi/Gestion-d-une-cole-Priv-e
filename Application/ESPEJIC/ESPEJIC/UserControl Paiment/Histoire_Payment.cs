using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.IO;
using CrystalDecisions.Shared;
namespace ESPEJIC
{
    public partial class Histoire_Payment : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        private ReportDocument reportDocument;
        static public DateTime dat;
        static public float payment;
        public Histoire_Payment()
        {
            reportDocument = new ReportDocument();
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select Nom_stagaire+' '+Pre_stagaire from Stagaire where Type_stagaire ='" + comboBox1.Text + "' ", conn);
            conn.Open();    
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            conn.Close();
        }
        private void FillDataGridView(string CIN,string Fullname)
        {
            conn.Close();
            dgvstagaire1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_de_paiment,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire='" + Fullname + "' and Stagaire.Type_stagaire= '" + CIN + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                }
                conn.Close();
            }
            conn.Close();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            dgvstagaire1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select Stagaire.CIN_Stagaire,Nom_stagaire ,Pre_stagaire,Sexe,Date_de_paiment,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire='" + comboBox3.Text + "' and Stagaire.Type_stagaire= '" + comboBox1.Text + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvstagaire1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                }
                conn.Close();
            }
            conn.Close();
        }

        private void Histoire_Payment_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label19.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Vous devez choisir le stagiaire avant de Extraire le reçu");
                return;
            }
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath, "Recu.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            SqlCommand cmd = new SqlCommand("select ID_paimet,Nom_stagaire+' '+Pre_stagaire as Fullname,N_Insc,Type_stagaire,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where Stagaire.CIN_Stagaire = '" + textBox1.Text + "' AND Date_de_paiment='"+ formattedDateTime + "'", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            adp.Fill(dataSet);
            reportDocument.SetDataSource(dataSet);
            DataTable dt = dataSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                TextObject textObject = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text4"];
                textObject.Text = dt.Rows[0]["Fullname"].ToString();
                TextObject textObjec2 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text5"];
                textObjec2.Text = dt.Rows[0]["N_Insc"].ToString();
                TextObject textObjec3 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text9"];
                textObjec3.Text = dt.Rows[0]["Type_stagaire"].ToString();
                TextObject textObjec4 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text6"];
                textObjec4.Text = dt.Rows[0]["Monant_par_m"].ToString();
                TextObject textObjec5 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text7"];
                textObjec5.Text = dt.Rows[0]["Mont_an"].ToString();
                TextObject textObjec6 = (TextObject)reportDocument.ReportDefinition.ReportObjects["Text8"];
                textObjec6.Text = dt.Rows[0]["ID_paimet"].ToString();
            }
            rp.crystalReportViewer1.ReportSource = reportDocument;
        }

        private void dgvstagaire1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dgvstagaire1.CurrentRow.Index;
            this.textBox1.Text = this.dgvstagaire1.Rows[position].Cells[0].Value.ToString();
            this.textBox2.Text = this.dgvstagaire1.Rows[position].Cells[1].Value.ToString();
            this.textBox3.Text = this.dgvstagaire1.Rows[position].Cells[2].Value.ToString();
            this.Payment_txt.Text = this.dgvstagaire1.Rows[position].Cells[5].Value.ToString();
            payment = float.Parse(this.dgvstagaire1.Rows[position].Cells[5].Value.ToString());
            this.rest_txt.Text = this.dgvstagaire1.Rows[position].Cells[6].Value.ToString();
            this.dateTimePicker1.Text = this.dgvstagaire1.Rows[position].Cells[4].Value.ToString();
            string dateString = this.dgvstagaire1.Rows[position].Cells[4].Value.ToString();
            dat = DateTime.Parse(dateString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedOldDate = dat.ToString("yyyy-MM-dd HH:mm:ss");
            float pay = float.Parse(Payment_txt.Text);
            float motant = 0;
            try
            {
                string query2 = "SELECT Mont_an FROM Stagaire WHERE CIN_Stagaire = @CIN_Stagaire";
                using (SqlCommand cmd = new SqlCommand(query2, conn))
                {
                    cmd.Parameters.AddWithValue("@CIN_Stagaire", textBox1.Text);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        motant = float.Parse(dr[0].ToString());
                    }
                    conn.Close();
                }
                motant = (motant + payment) - pay;
                string query = "UPDATE Paiment SET Monant_par_m = @MonantParM, Date_de_paiment = @NewDateDePaiment WHERE Date_de_paiment = @OldDateDePaiment AND CIN_Stagaire = @CINStagaire";
                string query1 = "UPDATE Stagaire SET Mont_an = @MontAn WHERE CIN_Stagaire = @CIN_Stagaire";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MonantParM", Payment_txt.Text);
                    cmd.Parameters.AddWithValue("@NewDateDePaiment", formattedDateTime);
                    cmd.Parameters.AddWithValue("@OldDateDePaiment", formattedOldDate);
                    cmd.Parameters.AddWithValue("@CINStagaire", textBox1.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@MontAn", motant);
                    cmd.Parameters.AddWithValue("@CIN_Stagaire", textBox1.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("La modification a été effectuée avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            dgvstagaire1.Rows.Clear();
            FillDataGridView(comboBox1.Text, comboBox3.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            float pay = float.Parse(Payment_txt.Text);
            float motant = 0;
            try
            {
                string query2 = "SELECT Mont_an FROM Stagaire WHERE CIN_Stagaire = @CIN_Stagaire";
                using (SqlCommand cmd = new SqlCommand(query2, conn))
                {
                    cmd.Parameters.AddWithValue("@CIN_Stagaire", textBox1.Text);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        motant = float.Parse(dr[0].ToString());
                    }
                    conn.Close();
                }
                motant = motant + pay;
                string query = "Delete from Paiment where CIN_Stagaire = @CIN and Date_de_paiment = @Date_dp";
                string query1 = "UPDATE Stagaire SET Mont_an = @MontAn WHERE CIN_Stagaire = @CIN_Stagaire";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CIN", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date_dp", selectedDateTime);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@MontAn", motant);
                    cmd.Parameters.AddWithValue("@CIN_Stagaire", textBox1.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Le paiement a été supprimé avec succès");
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
            dgvstagaire1.Rows.Clear();
            FillDataGridView(comboBox1.Text, comboBox3.Text);
        }
    }
}
