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

namespace ESPEJIC.UserController
{
    public partial class Ajouter : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Ajouter()
        {
            InitializeComponent();
        }
        private void IncrementID()
        {
            string query = "Select TOP 1 ID_Stagaire from Stagaire order by ID_Stagaire desc";
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
        }
        private void Ajouter_Load(object sender, EventArgs e)
        {
            IncrementID();
            SqlCommand cmd,cmd1;
            SqlDataAdapter dt, dt1;
            dt = new SqlDataAdapter();
            dt1 = new SqlDataAdapter();
            cmd = new SqlCommand("Select N_scolaire from Diplome", con);
            cmd1 = new SqlCommand("Select Sexe from Genre", con);
            dt.SelectCommand = cmd;
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            dt.Fill(table1);
            dt1.Fill(table2);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "N_scolaire";
            comboBox3.DataSource = table2;
            comboBox3.DisplayMember= "Sexe";
            textBox2.Text = "1er année";
        }

        private bool ChekInfo()
        {
            if (ID_txt.Text.Equals(string.Empty) ||
                N_Ins.Text.Equals(string.Empty) ||
                Nom_txt.Text.Equals(string.Empty) ||
                Pre_txt.Text.Equals(string.Empty) ||
                Cin_txt.Text.Equals(string.Empty) ||
                dateTimePicker1.Value.ToString().Equals(string.Empty) ||
                comboBox1.Text.Equals(string.Empty) ||
                Adr_txt.Text.Equals(string.Empty) ||
                Email_txt.Text.Equals(string.Empty) ||
                Tele_txt.Text.Equals(string.Empty))
                return false;
            return true;
        }

        private void Btn_ajou_stagaire_Click(object sender, EventArgs e)
        {
            DateTime SelectDateNais = dateTimePicker1.Value.Date;
            string formateDataNais = SelectDateNais.ToString("yyyy-MM-dd");
            DateTime selectedDate = dateTimePicker2.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            if (!ValidateTextBoxes())
            {
                return;
            }
            SqlCommand cmd;
            SqlDataReader rd;
            try
            {
                if (!ChekInfo())
                {
                    MessageBox.Show("Veuillez remplir toutes les informations.");
                    return;
                }
                con.Open(); 
                cmd = new SqlCommand("insert into Stagaire (ID_Stagaire,N_Insc,Nom_stagaire,Pre_stagaire,CIN_Stagaire,Date_Ins,N_scolaire,Type_stagaire,Addrs,Email,Tele,Sexe,Mont_an,Statut_Stg,Mont_total,Date_naissance,Lieu_naissance) values ('" + ID_txt.Text + "','"+N_Ins.Text+"','" + Nom_txt.Text + "','" + Pre_txt.Text + "','" + Cin_txt.Text + "','" + formateDataNais + "','"+comboBox1.Text+"','"+textBox2.Text+"','" + Adr_txt.Text + "','" + Email_txt.Text + "','" + Tele_txt.Text + "','"+comboBox3.Text+"','"+textBox1.Text+"','Active','"+textBox1.Text+"','"+ formattedDate + "','"+textBox3.Text+"')", con);
                rd = cmd.ExecuteReader();
                MessageBox.Show("Un stagaire a été ajouté");
                con.Close();
                rd.Close();
                ID_txt.Text = string.Empty;
                N_Ins.Text = string.Empty;
                Nom_txt.Text = string.Empty;
                Pre_txt.Text = string.Empty;
                Cin_txt.Text = string.Empty;
                dateTimePicker1.Text = string.Empty;
                comboBox1.Text = string.Empty;
                Adr_txt.Text = string.Empty;
                Email_txt.Text = string.Empty;
                Tele_txt.Text = string.Empty;
                comboBox3.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox3.Text = string.Empty;
                dateTimePicker2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                con.Close();
            }
            IncrementID();
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2;
            bool isNumber1 = int.TryParse(Tele_txt.Text, out number1);
            bool isNumber2 = int.TryParse(textBox1.Text, out number2);

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

        private void Tele_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Tele_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro de téléphone invalide");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox1.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro invalide");
            }
        }
    }
}
