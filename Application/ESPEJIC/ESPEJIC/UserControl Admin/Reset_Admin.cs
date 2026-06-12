using ESPIGIC;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ESPEJIC.UserControl_Admin
{
    public partial class Reset_Admin : UserControl
    {
        public Reset_Admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Admin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Svg_btn_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-G5EFBQM;Initial Catalog=ESPEGIC;Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                conn2.Open();
                cmd = new SqlCommand("if ('" + ID_txt.Text + "' = (select ID from admin)) begin Update admin set Username = '" + username_txt.Text + "',Password = '" + password_txt.Text + "'end", conn2);
                dr = cmd.ExecuteReader();
                MessageBox.Show("Admin est mis à jour !");
                dr.Close();
                conn2.Close();
            }
            catch
            {
                MessageBox.Show("ID is inccorect");
                conn2.Close();
            }

        }
    }
}
