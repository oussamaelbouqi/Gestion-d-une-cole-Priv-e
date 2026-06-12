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

namespace ESPEJIC.Usercontrol_Absence
{
    public partial class UserControlMos : UserControl
    {
        public SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public SqlCommand cmd,cmd1;
        private static DateTime dat;
        public UserControlMos()
        {
            InitializeComponent();
        }

        private void Empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            n_h_txt.Text = "";
        }

        private void dgvstagaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand("Select Nom_Mat from Matiére where statu_mat='Active' and Type_stagaire='"+ comboBox1.Text+ "'", cn);
            cmd1 = new SqlCommand("Select Justify from Justify", cn);
            SqlDataAdapter dt = new SqlDataAdapter();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            dt.SelectCommand = cmd;
            da1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            DataTable table = new DataTable();
            dt.Fill(table);
            da1.Fill(table1);
            comboBox3.DataSource = table;
            comboBox3.DisplayMember = "Nom_Mat";
            comboBox4.DataSource = table1;
            comboBox4.DisplayMember = "Justify";
            int position = dgvstagaire.CurrentRow.Index;
            this.textBox3.Text = this.dgvstagaire.Rows[position].Cells[0].Value.ToString();
            this.textBox1.Text = this.dgvstagaire.Rows[position].Cells[1].Value.ToString();
            this.textBox2.Text = this.dgvstagaire.Rows[position].Cells[2].Value.ToString();
            this.n_h_txt.Text = this.dgvstagaire.Rows[position].Cells[3].Value.ToString();
            this.comboBox3.Text = this.dgvstagaire.Rows[position].Cells[4].Value.ToString();
            this.comboBox4.Text = this.dgvstagaire.Rows[position].Cells[5].Value.ToString();
            this.dateTimePicker1.Text = this.dgvstagaire.Rows[position].Cells[6].Value.ToString();
            string dateString = this.dgvstagaire.Rows[position].Cells[6].Value.ToString();
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
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Veuillez sélectionner le stagiaire que vous souhaitez modifier.");
                    return;
                }

                // Format the old date
                string formattedOldDate = dat.ToString("yyyy-MM-dd HH:mm:ss");

                cn.Open();

                // Use parameterized query for update
                cmd = new SqlCommand("UPDATE Absence_stagaire SET Date_abs = @DateAbs, Nombre_h = @NombreH, ID_Matiére = @IDMatiere, Justify = @Justify WHERE CIN_Stagaire = @CINStagaire AND Date_abs = @OldDateAbs", cn);
                cmd.Parameters.AddWithValue("@DateAbs", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@NombreH", n_h_txt.Text);
                cmd.Parameters.AddWithValue("@IDMatiere", textBox4.Text);
                cmd.Parameters.AddWithValue("@Justify", comboBox4.Text);
                cmd.Parameters.AddWithValue("@CINStagaire", textBox3.Text);
                cmd.Parameters.AddWithValue("@OldDateAbs", formattedOldDate);

                SqlDataReader dr = cmd.ExecuteReader();
                MessageBox.Show("L'absence de stagaire a été modifiée");
                dr.Close();
                cn.Close();

                dgvstagaire.Rows.Clear();

                // Use parameterized query for select
                cmd = new SqlCommand("SELECT Stagaire.CIN_Stagaire, Nom_stagaire, Pre_stagaire, Nombre_h, Matiére.Nom_Mat, Justify, Date_abs FROM Absence_stagaire INNER JOIN Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire INNER JOIN Matiére ON Matiére.ID_Matiére = Absence_stagaire.ID_Matiére WHERE Stagaire.Type_stagaire = @TypeStagaire", cn);
                cmd.Parameters.AddWithValue("@TypeStagaire", comboBox1.Text);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    }
                }
                cn.Close();
                Empty();
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
                    MessageBox.Show("Veuillez sélectionner le stagiaire que vous souhaitez supprimer.");
                    return;
                }
                cn.Open();
                SqlDataReader dr;
                cmd = new SqlCommand("Delete From Absence_stagaire where CIN_Stagaire ='" + textBox3.Text + "' and Date_abs = '"+formattedOldDate+"'", cn);
                dr = cmd.ExecuteReader();
                dr.Close();
                cn.Close();
                MessageBox.Show("L'absence de Stagaire a été Supprimer!");
                cn.Close();
                dgvstagaire.Rows.Clear();
                cmd = new SqlCommand("select Stagaire.CIN_Stagaire, Nom_stagaire, Pre_stagaire, Nombre_h, Matiére.Nom_Mat,Justify, Date_abs from Absence_stagaire inner join Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire inner join Matiére on Matiére.ID_Matiére = Absence_stagaire.ID_Matiére where Stagaire.Type_stagaire = '" + comboBox1.Text + "'", cn);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    }
                }
                cn.Close();
                Empty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControlMos_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select Type_stagaire from Classe",cn);     
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            n_h_txt.Text = "";
            cn.Close();
            dgvstagaire.Rows.Clear();
            cmd = new SqlCommand("select Stagaire.CIN_Stagaire, Nom_stagaire, Pre_stagaire, Nombre_h, Matiére.Nom_Mat,Justify, Date_abs from Absence_stagaire inner join Stagaire ON Stagaire.CIN_Stagaire = Absence_stagaire.CIN_Stagaire inner join Matiére on Matiére.ID_Matiére = Absence_stagaire.ID_Matiére where Stagaire.Type_stagaire = '"+comboBox1.Text+"'", cn);
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                }
            }
            cn.Close() ;
            cmd = new SqlCommand("Select Nom_Mat from Matiére where statu_mat='Active' and Type_stagaire='" + comboBox1.Text + "'", cn);
            SqlDataAdapter dt = new SqlDataAdapter();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            dt.SelectCommand = cmd;
            DataTable table = new DataTable();
            dt.Fill(table);
            comboBox3.DataSource = table;
            comboBox3.DisplayMember = "Nom_Mat";
        }

        private void n_h_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(n_h_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un Nombre d'heures invalide.");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1;
            bool isNumber1 = int.TryParse(n_h_txt.Text, out number1);

            if (isNumber1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vous avez entré un Nombre d'heures invalide. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select ID_Matiére from Matiére where Nom_Mat ='" + comboBox3.Text + "' ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox4.Text = dr[0].ToString();
            }
            con.Close();
        }
    }
}
