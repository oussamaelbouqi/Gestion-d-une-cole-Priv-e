using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Paiment
{
    public partial class Salaire_For : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Salaire_For()
        {
            InitializeComponent();
        }

        private bool ChekInfo()
        {
            if (Sal_txt.Text == string.Empty ||
                total_txt.Text == string.Empty ||
                Cin_txt.Text == string.Empty ||
                Nom_txt.Text == string.Empty ||
                pre_txt.Text == string.Empty ||
                validé.Text == string.Empty ||
                n_hp_txt.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void Salaire_For_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip t1 = new System.Windows.Forms.ToolTip();
            t1.ToolTipIcon = ToolTipIcon.Info;
            t1.IsBalloon = true;
            t1.ShowAlways = true;
            t1.SetToolTip(label2, "Nombre d'heures de présence");

            SqlCommand cmd = new SqlCommand("Select CIN_for,Nom_for,Pre_for,Sexe,Sold_par_h from Formateur", conn);
            SqlCommand cmd1 = new SqlCommand("Select Validé from Validé",conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            adapter.Fill(table1);
            validé.DataSource = table1;
            validé.DisplayMember = "Validé";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvsalaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            SqlDataReader dt;

            try
            {
                if (ChekInfo() == false)
                {
                    MessageBox.Show("Veuillez remplir toutes les informations");
                    return;
                }

                // Adjust the final date to be one day before the selected final date
                DateTime adjustedFinalDate = dateTimePicker3.Value.Date.AddDays(+1);

                string insertQuery = "Insert into Salaire (CIN_for, Validé, Date_S, N_h_p, Total, Date_d, Date_f) " +
                                     "values (@CIN_for, @Validé, @Date_S, @N_h_p, @Total, @Date_d, @Date_f)";

                SqlCommand cmd = new SqlCommand(insertQuery, conn);

                // Use parameters to prevent SQL injection and handle dates properly
                cmd.Parameters.AddWithValue("@CIN_for", Cin_txt.Text);
                cmd.Parameters.AddWithValue("@Validé", validé.Text);
                cmd.Parameters.AddWithValue("@Date_S", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@N_h_p", n_hp_txt.Text);
                cmd.Parameters.AddWithValue("@Total", total_txt.Text);
                cmd.Parameters.AddWithValue("@Date_d", dateTimePicker2.Value.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@Date_f", adjustedFinalDate.ToString("yyyyMMdd"));

                conn.Open();
                dt = cmd.ExecuteReader();
                MessageBox.Show("Les informations pour cet Formateur ont été ajoutées");
                conn.Close();
                dt.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

            Cin_txt.Text = "";
            Nom_txt.Text = "";
            pre_txt.Text = "";
            Sal_txt.Text = "";
            n_hp_txt.Text = "";
            total_txt.Text = "";

        }

        private void dgvsalaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cin_txt.Text = "";
            Nom_txt.Text = "";
            pre_txt.Text = "";
            Sal_txt.Text = "";
            n_hp_txt.Text = "";
            total_txt.Text = "";
            int position = dgvsalaire.CurrentRow.Index;
            this.Nom_txt.Text = this.dgvsalaire.Rows[position].Cells[1].Value.ToString();
            this.pre_txt.Text = this.dgvsalaire.Rows[position].Cells[2].Value.ToString();
            this.Cin_txt.Text = this.dgvsalaire.Rows[position].Cells[0].Value.ToString();
            this.Sal_txt.Text = this.dgvsalaire.Rows[position].Cells[4].Value.ToString();
        }


        private void Btn_ajou_form_Click(object sender, EventArgs e)
        {
            Liste_For_S ls = new Liste_For_S();
            ls.Show();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

            DateTime dt1 = dateTimePicker2.Value;
            DateTime dt2 = dateTimePicker3.Value;
            TimeSpan Dif = dt1 - dt2;
            if (Dif.Days > 0)
            {
                MessageBox.Show("Il s'agit d'une erreur, car la date de début est supérieure à la date de fin de stage");
                return;
            }
            else if (Dif.Days == 0)
            {
                MessageBox.Show("Il s'agit d'une erreur, car la date de début est égale à la date de fin de stage");
                return;
            }
            conn.Close();

            // Adjust the final date to be one day before the selected final date
            DateTime adjustedFinalDate = dateTimePicker3.Value.Date.AddDays(+1);

            SqlCommand cmd = new SqlCommand(
                "Select COALESCE(SUM(CASE WHEN Pre IS NULL THEN 0 ELSE Pre END),0) " +
                "from Absence_For " +
                "where Date_Abs between @StartDate and @FinalDate " +
                "and CIN_for = @CIN",
                conn
            );

            // Use parameters to prevent SQL injection and handle dates properly
            cmd.Parameters.AddWithValue("@StartDate", dateTimePicker2.Value.Date.ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@FinalDate", adjustedFinalDate.ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@CIN", Cin_txt.Text);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    n_hp_txt.Text = dr[0].ToString();
                    total_txt.Text = Convert.ToString(Convert.ToInt32(n_hp_txt.Text) * Convert.ToInt32(Sal_txt.Text));
                }
            }
            conn.Close();

            dr.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}   