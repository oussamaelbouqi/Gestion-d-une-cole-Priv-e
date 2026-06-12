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

namespace ESPIGIC
{
    public partial class Resert_password : Form
    { 
        SqlConnection conn2 = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Resert_password()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                conn2.Open();
                cmd = new SqlCommand("if ('" + ID_txt.Text + "' = (select ID from admin)) begin Update admin set Password ='" + Password_txt.Text + "'end", conn2);
                dr=cmd.ExecuteReader();
                MessageBox.Show("le mot de passe est mis à jour !");
                dr.Close();
                conn2.Close();
                this.Close();
            } 
            catch
            {
                MessageBox.Show("ID est incorrect !");
                conn2.Close();
            }
        }
    }
}
