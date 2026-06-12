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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Fichiers
{
    public partial class Reçu : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        ReportDocument reportDocument = new ReportDocument();
        public Reçu()
        {
            InitializeComponent();
        }
       
        private void Reçu_Load(object sender, EventArgs e)
        {

            dgvReçu.RowHeadersVisible = false;

            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", conn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Close();
            dgvReçu.Rows.Clear();
            SqlCommand cmd1 = new SqlCommand("Select Stagaire.CIN_Stagaire,Nom_stagaire +' '+ Pre_Stagaire,Date_de_paiment,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where Stagaire.Type_stagaire= '" + comboBox1.Text + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvReçu.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);

                }
                reader.Close();
                conn.Close();
            }
        }
        private void dgvReçu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dgvReçu.CurrentRow.Index;
            this.textBox1.Text = this.dgvReçu.Rows[position].Cells[0].Value.ToString();
            this.textBox2.Text = this.dgvReçu.Rows[position].Cells[1].Value.ToString();
            this.Payment_txt.Text = this.dgvReçu.Rows[position].Cells[3].Value.ToString();
            this.rest_txt.Text = this.dgvReçu.Rows[position].Cells[4].Value.ToString();
            this.dateTimePicker1.Text= this.dgvReçu.Rows[position].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            conn.Close();
            conn.Open();
            reportview rp = new reportview();
            rp.Show();
            string reportPath = Path.Combine(Application.StartupPath, "Recu.rpt");
            string modiferpath = "\\bin\\Debug";
            string newpath = reportPath.Replace(modiferpath, string.Empty);
            reportDocument.Load(newpath);
            SqlCommand cmd = new SqlCommand("select ID_paimet,Nom_stagaire+' '+Pre_stagaire as Fullname,N_Insc,Type_stagaire,Monant_par_m,Mont_an from Paiment inner join Stagaire ON Stagaire.CIN_Stagaire = Paiment.CIN_Stagaire where Stagaire.CIN_Stagaire = '" + textBox1.Text + "' AND Date_de_paiment='" + formattedDateTime + "'", conn);
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
    }    
}
