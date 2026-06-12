using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Formatteur
{
    public partial class Ajouter_F : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Ajouter_F()
        {
            InitializeComponent();
        }

        private bool ChekInfo()
        {
            if (Mat_txt.Text.Equals(string.Empty) ||
                N_for.Text.Equals(string.Empty) ||
                CIN_tex.Text.Equals(string.Empty) ||
                Pre_text.Text.Equals(string.Empty) ||
                Email_txt.Text.Equals(string.Empty) ||
                N_Sco_txt.Text.Equals(string.Empty) ||
                Exp_txt.Text.Equals(string.Empty) ||
                Email_txt.Text.Equals(string.Empty) ||
                Addr_txt.Text.Equals(string.Empty) ||
                Sold_par_text.Text.Equals(string.Empty) ||
                Sexe_text.Text.Equals(string.Empty))
                return false;
            return true;
        }
        private void Ajouter_F_Load(object sender, EventArgs e)
        {
            SqlCommand cmd, cmd1, cmd2;
            SqlDataAdapter dt, dt1, dt2;
            dt = new SqlDataAdapter();
            dt1 = new SqlDataAdapter();
            dt2 = new SqlDataAdapter();
            cmd = new SqlCommand("Select Sexe from Genre",cn);
            cmd1 = new SqlCommand("Select N_scolaire from Diplome",cn);
            cmd2 = new SqlCommand("Select Statut_For from Statut_for",cn);
            dt.SelectCommand = cmd;
            dt1.SelectCommand = cmd1;
            dt2.SelectCommand = cmd2;
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            dt.Fill(table1);
            dt1.Fill(table2);
            dt2.Fill(table3);
            Sexe_text.DataSource = table1;
            Sexe_text.DisplayMember = "Sexe";
            N_Sco_txt.DataSource = table2;
            N_Sco_txt.DisplayMember = "N_scolaire";
            Statu_txt.DataSource = table3;
            Statu_txt.DisplayMember = "Statut_For";
        }


        private void Btn_ajou_form_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker2.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            if (!ValidateTextBoxes())
            {
                return;
            }
            cn.Close();
            SqlCommand cmd;
            SqlDataReader rd;
            try
            {
                if (!ChekInfo())
                {
                    MessageBox.Show("Veuillez remplir toutes les informations.");
                    return;
                }
                cn.Open();
                cmd = new SqlCommand("insert into Formateur (Matricul,Nom_for,Pre_for,CIN_for,Sexe,Email,Addr_for,Tele,Date_Naissance,N_scolaire,Exper_for,Statut_for,Sold_par_h) values ('" + Mat_txt.Text + "','" + N_for.Text + "','" + Pre_text.Text + "','" + CIN_tex.Text + "','" + Sexe_text.Text + "','" + Email_txt.Text + "','"+Addr_txt.Text+"','" + tele_txt.Text + "','" + formattedDate + "','" + N_Sco_txt.Text + "','" + Exp_txt.Text + "','" + Statu_txt.Text + "','"+ Sold_par_text.Text+"')",cn);
                rd = cmd.ExecuteReader();
                MessageBox.Show("Cet Formateur a été ajouté avec succès!");
                cn.Close();
                rd.Close();
                Mat_txt.Text = string.Empty;
                N_for.Text = string.Empty;
                Pre_text.Text = string.Empty;
                CIN_tex.Text =string.Empty;
                Email_txt.Text = string.Empty;
                Addr_txt.Text = string.Empty;
                tele_txt.Text= string.Empty;
                Sexe_text.Text = string.Empty;
                dateTimePicker2.Text = string.Empty;
                N_Sco_txt.Text = string.Empty;
                Exp_txt.Text = string.Empty;
                Statu_txt.Text = string.Empty;
                Sold_par_text.Text= string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                cn.Close();
            }
        }

        private void tele_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(tele_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro de téléphone invalide");
            }
        }

        private void Exp_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Exp_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro invalide");
            }
        }

        private void Sold_par_text_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Sold_par_text.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro invalide");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2, number3;
            bool isNumber1 = int.TryParse(tele_txt.Text, out number1);
            bool isNumber2 = int.TryParse(Exp_txt.Text, out number2);
            bool isNumber3 = int.TryParse(Sold_par_text.Text, out number3);

            if (isNumber1 && isNumber2 && isNumber3)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Une ou plusieurs zones de texte ne contiennent pas de nombres valides. \nVeuillez vérifier que les informations privées que vous avez saisies sont correctes.");
                return false;
            }
        }

    }
}
