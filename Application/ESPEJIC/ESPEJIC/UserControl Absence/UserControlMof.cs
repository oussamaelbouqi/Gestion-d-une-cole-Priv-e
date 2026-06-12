using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ESPEJIC.Usercontrol_Absence
{
    public partial class UserControlMof : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        private static DateTime dat;
        public UserControlMof()
        {
            InitializeComponent();
        }
        private void Empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvstagaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dgvstagaire.CurrentRow.Index;
            this.textBox3.Text = this.dgvstagaire.Rows[position].Cells[0].Value.ToString();
            this.textBox1.Text = this.dgvstagaire.Rows[position].Cells[1].Value.ToString();
            this.textBox2.Text = this.dgvstagaire.Rows[position].Cells[2].Value.ToString();
            this.textBox4.Text = this.dgvstagaire.Rows[position].Cells[3].Value.ToString();
            this.comboBox1.Text = this.dgvstagaire.Rows[position].Cells[4].Value.ToString();
            this.dateTimePicker1.Text = this.dgvstagaire.Rows[position].Cells[5].Value.ToString();
            string dateString = this.dgvstagaire.Rows[position].Cells[5].Value.ToString();
            dat = DateTime.Parse(dateString);
        }

        private void Mdf_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
            {
                return;
            }
            try
            {
                string formattedOldDate = dat.ToString("yyyy-MM-dd HH:mm:ss");

                if (textBox3.Text == "")
                {
                    MessageBox.Show("Veuillez sélectionner le formateur que vous souhaitez modifier.");
                    return;
                }

                cn.Open();

                // Use parameterized query to avoid conversion issues
                string updateQuery = "update Absence_For set Date_Abs = @Date_Abs, Pre = @Pre, Jour = @Jour where CIN_for = @CIN_for and Date_Abs = @OldDate_Abs";
                using (SqlCommand cmd1 = new SqlCommand(updateQuery, cn))
                {
                    cmd1.Parameters.AddWithValue("@Date_Abs", dateTimePicker1.Value);
                    cmd1.Parameters.AddWithValue("@Pre", textBox4.Text);
                    cmd1.Parameters.AddWithValue("@Jour", comboBox1.Text);
                    cmd1.Parameters.AddWithValue("@CIN_for", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@OldDate_Abs", formattedOldDate);

                    cmd1.ExecuteNonQuery();
                }

                MessageBox.Show("L'absence de formateur a été modifiée");

                cn.Close();

                Empty();
                dgvstagaire.Rows.Clear();

                string selectQuery = "select Formateur.CIN_for, Nom_for, Pre_for, Pre, Jour, Date_Abs from Absence_For inner join Formateur ON Formateur.CIN_for = Absence_For.CIN_for";
                using (SqlCommand cmd = new SqlCommand(selectQuery, cn))
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            
            try
            {
                string formattedOldDate = dat.ToString("yyyy-MM-dd HH:mm:ss");
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Veuillez sélectionner le fourmateur que vous souhaitez supprimer.");
                    return;
                }
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("Delete From Absence_For where CIN_for='"+textBox3.Text+ "' and Date_Abs='"+formattedOldDate+"'", cn);
                dr = cmd.ExecuteReader();
                dr.Close();
                cn.Close();
                MessageBox.Show("L'absence de formateur a été Supprimer!");
                Empty();
                dgvstagaire.Rows.Clear();
                SqlCommand cmd1 = new SqlCommand("select Formateur.CIN_for,Nom_for ,Pre_for,Pre,Jour,Date_Abs from Absence_For inner join Formateur ON Formateur.CIN_for = Absence_For.CIN_for", cn);
                cn.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControlMof_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Matin");
            comboBox1.Items.Add("Soir");
            SqlCommand cmd1 = new SqlCommand("select Formateur.CIN_for,Nom_for ,Pre_for,Pre,Jour,Date_Abs from Absence_For inner join Formateur ON Formateur.CIN_for = Absence_For.CIN_for", cn);
            cn.Open();
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
                cn.Close();
            }  
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox4.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un nombre de Present invalide.");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1;
            bool isNumber2 = int.TryParse(textBox4.Text, out number1);

            if (isNumber2)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vous avez entré un nombre de Present invalide. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }
    }
}
