using ESPEJIC;
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
    public partial class Admin : Form
    {
        private const string cn ="Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        private const int MaxTry = 3;
        private int At = MaxTry;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            if (Valid(username, password))
            {
                MessageBox.Show("La connexion est un succèss");
                ESPEJIC.Menu mn = new ESPEJIC.Menu();
                mn.Show();
                this.Hide();
            }
            else
            {
                At--;
                if (At > 0)
                {
                    MessageBox.Show($"La connexion a échoué. \nL'identifiant ou le mot de passe est incorrect.Il reste {At} tentatives.");
                    textBox3.Text = "";
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Vous avez dépassé le nombre maximum de tentatives. L'application sera fermée.");
                    this.Close();
                }
            }
        }
        private bool Valid(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(cn))
            {
                string query = "SELECT COUNT(*) FROM admin WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Resert_password mtp = new Resert_password();
            mtp.Show();
        }
    }
}
