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

namespace ESPEJIC.UseControl_Quiffance
{
    public partial class Modifier_Qui : UserControl
    {

        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");

        public Modifier_Qui()
        {
            InitializeComponent();
        }

        private void Modifier_Qui_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Quiff from Quiffance where Type_EX='CC'",cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();

                }
            }
            cn.Close();

            SqlCommand cmd1 = new SqlCommand("Select Quiff from Quiffance where Type_EX='EFCE_thero'", cn);
            cn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    textBox2.Text = dr1[0].ToString();

                }
            }
            cn.Close();

            SqlCommand cmd2 = new SqlCommand("Select Quiff from Quiffance where Type_EX='EFCE_prat'", cn);
            cn.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.HasRows)
            {
                while (dr2.Read())
                {
                    textBox3.Text = dr2[0].ToString();

                }
            }
            cn.Close();

            SqlCommand cmd3 = new SqlCommand("Select Quiff from Quiffance where Type_EX='PFE'", cn);
            cn.Open();
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.HasRows)
            {
                while (dr3.Read())
                {
                    textBox4.Text = dr3[0].ToString();

                }
            }
            cn.Close();
        }

        private void Mdf_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Quiffance set Quiff='"+int.Parse(textBox1.Text) + "' where Type_EX='CC'",cn);
            cn.Open();
            cmd.ExecuteReader();
            cn.Close();

            SqlCommand cmd1 = new SqlCommand("Update Quiffance set Quiff='" + int.Parse(textBox2.Text) + "' where Type_EX='EFCE_thero'", cn);
            cn.Open();
            cmd1.ExecuteReader();
            cn.Close();

            SqlCommand cmd2 = new SqlCommand("Update Quiffance set Quiff='" + int.Parse(textBox3.Text) + "' where Type_EX='EFCE_prat'", cn);
            cn.Open();
            cmd2.ExecuteReader();
            cn.Close();

            SqlCommand cmd3 = new SqlCommand("Update Quiffance set Quiff='" + int.Parse(textBox4.Text) + "' where Type_EX='PFE'", cn);
            cn.Open();
            cmd3.ExecuteReader();
            MessageBox.Show("Modifié avec succès.");
            cn.Close();
        }
    }
}
