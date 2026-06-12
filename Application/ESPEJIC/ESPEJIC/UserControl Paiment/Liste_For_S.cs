using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Paiment
{
    public partial class Liste_For_S : Form
    {
        private int x;
        private static DateTime dat;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        static private int a;
        public Liste_For_S()
        {
            InitializeComponent();
        }
        public void FillInformationEcole()
        {
            string query = "Select Nom_eco from Ecole";
            string query1 = "Select Nom_Full from Filiére";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label13.Text = reader[0].ToString();
                }
                conn.Close();
            }
            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label15.Text = reader[0].ToString();
                }
                conn.Close();
            }
        }
        private void Liste_For_S_Load(object sender, EventArgs e)
        {
            a = 0;
            SqlCommand cmd1 = new SqlCommand("Select Validé from Validé", conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            adapter.Fill(table1);
            comboBox2.DataSource = table1;
            comboBox2.DisplayMember = "Validé";
            conn.Close() ;
            FillInformationEcole();
            comboBox.Items.Add("Janvier");
            comboBox.Items.Add("Février");
            comboBox.Items.Add("Mars");
            comboBox.Items.Add("Avril");
            comboBox.Items.Add("Mai");
            comboBox.Items.Add("Juin");
            comboBox.Items.Add("Juillet");
            comboBox.Items.Add("Août");
            comboBox.Items.Add("Septembre");
            comboBox.Items.Add("Octobre");
            comboBox.Items.Add("Novembre");
            comboBox.Items.Add("Décembre");
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }
        private void filldatagridview()
        {
            if (comboBox.Text == "Janvier")
            {
                x = 1;
            }
            else if (comboBox.Text == "Février")
            {
                x = 2;
            }
            else if (comboBox.Text == "Mars")
            {
                x = 3;
            }
            else if (comboBox.Text == "Avril")
            {
                x = 4;
            }
            else if (comboBox.Text == "Mai")
            {
                x = 5;
            }
            else if (comboBox.Text == "Juin")
            {
                x = 6;
            }
            else if (comboBox.Text == "Juillet")
            {
                x = 7;
            }
            else if (comboBox.Text == "Août")
            {
                x = 8;
            }
            else if (comboBox.Text == "Septembre")
            {
                x = 9;
            }
            else if (comboBox.Text == "Octobre")
            {
                x = 10;
            }
            else if (comboBox.Text == "Novembre")
            {
                x = 11;
            }
            else if (comboBox.Text == "Décembre")
            {
                x = 12;
            }
            conn.Close();
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("Select Formateur.CIN_for,Formateur.Nom_for , Formateur.Pre_for ,Formateur.Sexe,Date_S,N_h_p,Formateur.Sold_par_h,Date_d,Date_f,Total,Validé from Salaire inner join Formateur on Formateur.CIN_for = Salaire.CIN_for where MONTH(Date_S) = '" + x.ToString() + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string total = reader[9].ToString() + " DH";
                    this.dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], total, reader[10]);
                }
            }
            comboBox1.Items.Clear();
            conn.Close();
            SqlCommand cmd1 = new SqlCommand("Select Formateur.Nom_for+' '+Formateur.Pre_for from Salaire inner join Formateur on Formateur.CIN_for = Salaire.CIN_for where MONTH(Date_S) = '" + x + "'", conn);
            conn.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0]);
                }
                conn.Close();
                dr.Close();
            }
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Text == "Janvier")
            {
                x = 1;
            }
            else if (comboBox.Text == "Février")
            {
                x = 2;
            }
            else if (comboBox.Text == "Mars")
            {
                x = 3;
            }
            else if (comboBox.Text == "Avril")
            {
                x = 4;
            }
            else if (comboBox.Text == "Mai")
            {
                x = 5;
            }
            else if (comboBox.Text == "Juin")
            {
                x = 6;
            }
            else if (comboBox.Text == "Juillet")
            {
                x = 7;
            }
            else if (comboBox.Text == "Août")
            {
                x = 8;
            }
            else if (comboBox.Text == "Septembre")
            {
                x = 9;
            }
            else if (comboBox.Text == "Octobre")
            {
                x = 10;
            }
            else if (comboBox.Text == "Novembre")
            {
                x = 11;
            }
            else if (comboBox.Text == "Décembre")
            {
                x = 12;
            }
            conn.Close();
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("Select Formateur.CIN_for,Formateur.Nom_for , Formateur.Pre_for ,Formateur.Sexe,Date_S,N_h_p,Formateur.Sold_par_h,Date_d,Date_f,Total,Validé from Salaire inner join Formateur on Formateur.CIN_for = Salaire.CIN_for where MONTH(Date_S) = '" + x.ToString()+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string total = reader[9].ToString() + " DH";
                    this.dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5],reader[6],reader[7],reader[8] ,total, reader[10]);
                }
            }
            conn.Close();
            comboBox1.Items.Clear();
            SqlCommand cmd1 = new SqlCommand("Select DISTINCT  Formateur.Nom_for+' '+Formateur.Pre_for from Salaire inner join Formateur on Formateur.CIN_for = Salaire.CIN_for where MONTH(Date_S) = '" + x+"'",conn);
            conn.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0]);
                }
                conn.Close ();
                dr.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("Select Formateur.CIN_for,Formateur.Nom_for , Formateur.Pre_for ,Formateur.Sexe,Date_S,N_h_p,Formateur.Sold_par_h,Date_d,Date_f,Total,Validé from Salaire inner join Formateur on Formateur.CIN_for = Salaire.CIN_for where MONTH(Date_S) = '" + x.ToString() + "' and Formateur.Nom_for+' '+Formateur.Pre_for ='" + comboBox1.Text+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string total = reader[9].ToString() + " DH";
                    this.dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], total, reader[10]);
                }
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridView1.CurrentRow.Index;
            this.Nom_txt.Text = this.dataGridView1.Rows[position].Cells[1].Value.ToString();
            this.pre_txt.Text = this.dataGridView1.Rows[position].Cells[2].Value.ToString();
            this.Cin_txt.Text = this.dataGridView1.Rows[position].Cells[0].Value.ToString();
            this.dateTimePicker1.Text = this.dataGridView1.Rows[position].Cells[4].Value.ToString();
            this.n_hp_txt.Text = this.dataGridView1.Rows[position].Cells[5].Value.ToString();
            this.Sal_txt.Text = this.dataGridView1.Rows[position].Cells[6].Value.ToString();
            this.dateTimePicker2.Text = this.dataGridView1.Rows[position].Cells[7].Value.ToString();
            this.dateTimePicker3.Text = this.dataGridView1.Rows[position].Cells[8].Value.ToString();
            this.total_txt.Text = this.dataGridView1.Rows[position].Cells[9].Value.ToString();
            this.comboBox2.Text = this.dataGridView1.Rows[position].Cells[10].Value.ToString();
            string dateString = this.dataGridView1.Rows[position].Cells[4].Value.ToString();
            dat = DateTime.Parse(dateString);
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
            string startDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string endDate = dateTimePicker3.Value.ToString("yyyy-MM-dd");

            SqlCommand cmd = new SqlCommand(
                "Select COALESCE(SUM(CASE WHEN Pre IS NULL THEN 0 ELSE Pre END), 0) " +
                "from Absence_For " +
                "where Date_Abs between @StartDate and @EndDate " +
                "and CIN_for = @CIN",
                conn
            );

            // Use parameters to prevent SQL injection and handle dates properly
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string formattedOldDate = dat.ToString("yyyy-MM-dd HH:mm:ss");
                string formattednewDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string Date_d = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                string Date_f = dateTimePicker3.Value.ToString("yyyy-MM-dd");

                // Remove non-numeric characters from total_txt
                string totalValue = total_txt.Text.Replace("DH", "").Trim();

                // Validate numeric fields
                if (!int.TryParse(totalValue, out int total) || !int.TryParse(n_hp_txt.Text, out int nHp))
                {
                    MessageBox.Show("Total or N_h_p contains invalid numeric values.");
                    return;
                }

                string query = "Update Salaire set Date_f = @Date_f, Date_d = @Date_d, Date_S = @Date_S, Validé = @Valide, Total = @Total, N_h_p = @N_h_p where CIN_for = @CIN_for and Date_S = @OldDate_S";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Date_f", Date_f);
                    cmd.Parameters.AddWithValue("@Date_d", Date_d);
                    cmd.Parameters.AddWithValue("@Date_S", formattednewDate);
                    cmd.Parameters.AddWithValue("@Valide", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@N_h_p", nHp);
                    cmd.Parameters.AddWithValue("@CIN_for", Cin_txt.Text);
                    cmd.Parameters.AddWithValue("@OldDate_S", formattedOldDate);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Il a été modifié avec succès");
                    filldatagridview();
                    Cin_txt.Text = "";
                    Nom_txt.Text = "";
                    pre_txt.Text = "";
                    Sal_txt.Text = "";
                    n_hp_txt.Text = "";
                    total_txt.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(Cin_txt.Text == "")
                {
                    MessageBox.Show("Veuillez sélectionner Fourmateur si vous souhaitez supprimer son salaire");
                    return;
                }
                string formattedOldDate = dat.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "Delete from Salaire where CIN_for = '" + Cin_txt.Text + "' and Date_S = '" + formattedOldDate + "'";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open(); cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Il a été supprimé avec succès");
                    filldatagridview();
                    Cin_txt.Text = "";
                    Nom_txt.Text = "";
                    pre_txt.Text = "";
                    Sal_txt.Text = "";
                    n_hp_txt.Text = "";
                    total_txt.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
