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

namespace ESPEJIC.UserController
{
    public partial class La_liste : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        private string lb;
        public La_liste()
        {
            InitializeComponent();
        }
        private void CenterLabel()
        {
            int centerX = (Width - label3.Width) / 2;
            label3.Location = new Point(centerX, 50);
        }
        private void La_liste_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ID_Stagaire", "ID Stagaire");
            dataGridView1.Columns.Add("N_Insc", "N Insc");
            dataGridView1.Columns.Add("Nom_Stagaire", "Nom");
            dataGridView1.Columns.Add("Pre_Stagaire", "Prénom");
            dataGridView1.Columns.Add("CIN_Stagaire", "N°CIN");
            dataGridView1.Columns.Add("Date_Ins", "Date Inscription");
            dataGridView1.Columns.Add("N_Scolaire", "Niveau de scolaire");
            dataGridView1.Columns.Add("Addrs", "Addresse");
            dataGridView1.Columns.Add("Date_naissance", "Date de Naissance");
            dataGridView1.Columns.Add("Lieu_naissance", "Lieu de Naissance");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Tele", "Tele");
            FillInformationEcole();
            SqlCommand cmd;
            SqlDataAdapter dt = new SqlDataAdapter();
            cmd = new SqlCommand("Select Type_stagaire from Classe", cn);
            dt.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            dt.Fill(table1);
            typebox.DataSource = table1;
            typebox.DisplayMember = "Type_stagaire";
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }
        public void FillInformationEcole()
        {
            string query = "Select Nom_eco from Ecole";
            string query1 = "Select Nom_Full from Filiére";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label13.Text = reader[0].ToString();
                }
                cn.Close();
            }
            using (SqlCommand cmd = new SqlCommand(query1, cn))
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label15.Text = reader[0].ToString();
                }
                cn.Close();
            }
        }

        private void PopulateDatagridview(string classes)
        {
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Stagaire WHERE Type_stagaire = '"+classes+"'", cn);

            // SqlDataAdapter to fill DataTable
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);

            // Format Date_Ins and Date_naissance columns
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt1.Rows)
            {
                string formattedDate = string.Empty;
                string formatdatenais = string.Empty;
                if (dr["Date_Ins"] != DBNull.Value)
                {
                    DateTime dateIns = Convert.ToDateTime(dr["Date_Ins"]);
                    formattedDate = dateIns.ToString("yyyy-MM-dd");
                }
                if (dr["Date_naissance"] != DBNull.Value)
                {
                    DateTime dateNaissance = Convert.ToDateTime(dr["Date_naissance"]);
                    formatdatenais = dateNaissance.ToString("yyyy-MM-dd");
                }
                dataGridView1.Rows.Add(
                    dr["ID_Stagaire"].ToString(),
                    dr["N_Insc"].ToString(),
                    dr["Nom_Stagaire"].ToString(),
                    dr["Pre_Stagaire"].ToString(),
                    dr["CIN_Stagaire"].ToString(),
                    formattedDate,
                    dr["N_Scolaire"].ToString(),
                    dr["Addrs"].ToString(),
                   formatdatenais,
                    dr["Lieu_naissance"].ToString(),
                    dr["Email"].ToString(),
                    dr["Tele"].ToString()
                );
            }
        }
        private void typebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDatagridview(typebox.Text);
        }

        private void La_liste_Resize(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.WindowState == FormWindowState.Maximized)
            {
                CenterLabel();
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int hgh = 36;
            dataGridView1.Rows[e.RowIndex].Height = hgh;
        }
    }
}
