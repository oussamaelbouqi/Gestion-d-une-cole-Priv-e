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

namespace ESPEJIC.UserControl_Formatteur
{
    public partial class Liste_F : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Liste_F()
        {
            InitializeComponent();
            //this.Load += new System.EventHandler(this.Liste_F_Load);
        }

        private void Liste_F_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Matricul", "Matricul");
            dataGridView1.Columns.Add("Nom_for", "Nom");
            dataGridView1.Columns.Add("Pre_for", "Prenom");
            dataGridView1.Columns.Add("CIN_for", "CIN");
            dataGridView1.Columns.Add("Sexe", "Sexe");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Tele", "Telephone");
            dataGridView1.Columns.Add("Addr_for", "Adresse");
            dataGridView1.Columns.Add("Date_Naissance", "Date Naissance");
            dataGridView1.Columns.Add("Statut_for", "Statut");
            dataGridView1.Columns.Add("Exper_for", "Experience");
            dataGridView1.Columns.Add("N_Scolaire", "Niveau de Scolaire");
            dataGridView1.Columns.Add("Sold_par_h", "Sold par heure");
            FillInformationEcole();
            Fillinformationfourmatteur();
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }
        private void Fillinformationfourmatteur()
        {
            SqlCommand cmd1 = new SqlCommand("SELECT Matricul, Nom_for, Pre_for, CIN_for, Sexe, Email, Addr_for, Tele, Date_Naissance, Exper_for, Statut_for, Sold_par_h, N_scolaire FROM Formateur", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            dataGridView1.Rows.Clear();

            foreach (DataRow dr in dt1.Rows)
            {
                string formattedDate = string.Empty;
                if (dr["Date_Naissance"] != DBNull.Value)
                {
                    DateTime dateNaissance = Convert.ToDateTime(dr["Date_Naissance"]);
                    formattedDate = dateNaissance.ToString("yyyy-MM-dd");
                }
                dataGridView1.Rows.Add(
                    dr["Matricul"].ToString(),
                    dr["Nom_for"].ToString(),
                    dr["Pre_for"].ToString(),
                    dr["CIN_for"].ToString(),
                    dr["Sexe"].ToString(),
                    dr["Email"].ToString(),
                    dr["Tele"].ToString(),
                    dr["Addr_for"].ToString(),
                    formattedDate,
                    dr["Statut_for"].ToString(),
                    dr["Exper_for"].ToString(),
                    dr["N_scolaire"].ToString(),
                    dr["Sold_par_h"].ToString()
                );
            }
        }
        private void CenterLabel()
        {
            int centerX = (Width - label3.Width) / 2;
            label3.Location = new Point(centerX, 50);
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

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int hgh = 36;
            dataGridView1.Rows[e.RowIndex].Height = hgh;
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.WindowState == FormWindowState.Maximized)
            {
                CenterLabel();
            }
        }
    }
}
