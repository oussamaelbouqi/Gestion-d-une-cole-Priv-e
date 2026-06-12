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

namespace ESPEJIC
{
    public partial class Filiére : Form
    {
        SqlCommand Cmd;
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Filiére()
        {
            InitializeComponent();
        }

        private void Btn_ajou_stagaire_Click(object sender, EventArgs e)
        {
            con.Open();
            Cmd = new SqlCommand(" Update Filiére set Nom_fill='"+ textBox1.Text+ "', Cap ='"+ textBox2.Text + "', Niveau='"+ textBox3.Text+ "' ,Nom_Full='"+textBox4.Text+"'", con);
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Ce Filière a été mis à jour");
            con.Close();

        }

        private void Filiére_Load(object sender, EventArgs e)
        {
            con.Open();
            Cmd = new SqlCommand("select Nom_fill, Cap, Niveau,Nom_Full from Filiére", con);
            dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox4.Text = dr["Nom_Full"].ToString();
                textBox1.Text = dr["Nom_fill"].ToString();
                textBox2.Text = dr["Cap"].ToString();
                textBox3.Text = dr["Niveau"].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            autre at = new autre();
            at.Show();
            this.Hide();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }
    }
}
