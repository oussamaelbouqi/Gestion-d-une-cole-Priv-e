using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.Usercontrol_Absence
{
    public partial class usercontrolforAbf : UserControl
    {
        public SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public usercontrolforAbf()
        {
            InitializeComponent();
        }

        private bool ChekInfo()
        {
            if (textBox4.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void usercontrolforAbf_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select CIN_for,Nom_for,Pre_for,Sexe from Formateur", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    this.dgvstagaire.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
            }
            comboBox1.Items.Add("Matin");
            comboBox1.Items.Add("Soir");
            dateTimePicker1.Value = DateTime.Now;
        }

        private void dgvstagaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dgvstagaire.CurrentRow.Index;
            this.textBox3.Text = this.dgvstagaire.Rows[position].Cells[0].Value.ToString();
            this.textBox1.Text = this.dgvstagaire.Rows[position].Cells[1].Value.ToString();
            this.textBox2.Text = this.dgvstagaire.Rows[position].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
            {
                return;
            }
            conn.Close();
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

                if (!ChekInfo())
                {
                    MessageBox.Show("Veuillez remplir toutes les informations.");
                    return;
                }
                cmd = new SqlCommand("Insert into Absence_For (CIN_for,Pre,Date_abs,Jour) values('" + textBox3.Text + "','" + textBox4.Text + "','" + formattedDate + "','"+comboBox1.Text+"')", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Une absence a été saisie avec succès");
                conn.Close();
                textBox3.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox4.Text = string.Empty;
                comboBox1 .Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
                conn.Close();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox4.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré une Durée de Pré invalide.");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox4.Text, out number1);

            if (isNumber1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vous avez entré une Durée de Pré invalide. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }
    }
}
