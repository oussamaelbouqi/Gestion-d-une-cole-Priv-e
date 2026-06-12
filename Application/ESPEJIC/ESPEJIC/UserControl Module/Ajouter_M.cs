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
    public partial class Ajouter_M : UserControl
    {
        SqlCommand Cmd;
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Ajouter_M()
        {
            InitializeComponent();
        }

        private void Ajouter_M_Load(object sender, EventArgs e)
        {
            string query = "Select TOP 1 ID_Matiére from Matiére order by ID_Matiére desc";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID_txt.Text = reader[0].ToString();
                    }
                    reader.Close();
                    ID_txt.Text = (Convert.ToInt32(ID_txt.Text) + 1).ToString();
                }
                else
                {
                    ID_txt.Text = "1";
                }
                con.Close();
            }

            comboBox1.Items.Clear();
            con.Open();
            Cmd = new SqlCommand("select Type_stagaire from Classe",con);
            dr = Cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
             
            comboBox2.Items.Clear();
            con.Open();
            Cmd = new SqlCommand("select statu_mat from Active ", con);
            dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void Btn_ajou_stagaire_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
            {
                return;
            }
            con.Open();
            Cmd = new SqlCommand(" insert into Matiére (ID_Matiére,Nom_Mat,Quiffance,N_heurs,Type_stagaire,statu_mat) values('" + int.Parse(ID_txt.Text) + "','" + textBox1.Text +"','"+textBox2.Text+"','"+ textBox3.Text+"','"+ comboBox1.Text+"','"+ comboBox2.Text+"')",con);
            dr = Cmd.ExecuteReader();
            MessageBox.Show("Un Matiére a été ajouté");
            con.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox2.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un Nombre d'heures invalide.");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2;
            bool isNumber1 = int.TryParse(textBox2.Text, out number1);
            bool isNumber2 = int.TryParse(textBox3.Text, out number2);

            if (isNumber1 && isNumber2)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Une ou plusieurs zones de texte ne contiennent pas de nombres valides. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox3.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré une Quiffance invalide.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Nom_label_Click(object sender, EventArgs e)
        {

        }
    }
}
