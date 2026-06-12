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

namespace ESPEJIC.UserControl_Formatteur
{
    public partial class Modifier_For : Form
    {
        public Modifier_F mainForms;
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public static string textPassed2;
        public Modifier_For(Modifier_F form1)
        {
            InitializeComponent();
            mainForms = form1;
        }

        private void Modifier_For_Load(object sender, EventArgs e)
        {
            CIN_fo_txt.Text = Modifier_F.TextPassed1;
            SqlCommand cmd1,cmd2,cmd3, cmd4;
            cmd1 = new SqlCommand("Select Matricul,Nom_for,Pre_for,CIN_for,Sexe,Email,Addr_for,Tele,Date_Naissance,Exper_for,Statut_for,Sold_par_h,N_scolaire from Formateur where CIN_for='" + CIN_fo_txt.Text + "'", cn);
            cmd2 = new SqlCommand("Select Statut_For from Statut_for", cn);
            SqlDataAdapter dt, dt1, dt2;
            dt = new SqlDataAdapter();
            dt1 = new SqlDataAdapter();
            dt2 = new SqlDataAdapter();
            cmd3 = new SqlCommand("Select Sexe from Genre", cn);
            cmd4 = new SqlCommand("Select N_scolaire from Diplome", cn);
            dt.SelectCommand = cmd2;
            dt1.SelectCommand = cmd3;
            dt2.SelectCommand = cmd4;
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            dt.Fill(table);
            dt1.Fill(table1);
            dt2.Fill(table2);
            Situation_txt.DisplayMember = "Statut_For";
            Situation_txt.DataSource = table;
            Sexe_txt.DataSource = table1;
            Sexe_txt.DisplayMember = "Sexe";
            N_scolaire_cmb.DataSource = table2;
            N_scolaire_cmb.DisplayMember = "N_scolaire";
            SqlDataReader dr;
            cn.Open();
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string Matricul = dr["Matricul"].ToString();
                string Nom_for = dr["Nom_for"].ToString();
                string Pre_for = dr["Pre_for"].ToString();
                string Sexe = dr["Sexe"].ToString();
                string Email = dr["Email"].ToString();
                string Addr_for = dr["Addr_for"].ToString();
                string Tele = dr["Tele"].ToString();
                string Date_Naissance = dr["Date_Naissance"].ToString();
                string N_scolaire = dr["N_scolaire"].ToString();
                string Exper_for = dr["Exper_for"].ToString();
                string Statut_for = dr["Statut_for"].ToString();
                string Sold_par_h = dr["Sold_par_h"].ToString();
                Matricul_txt.Text = Matricul;
                Nom_for_txt.Text = Nom_for;
                Pre_for_txt.Text = Pre_for;
                Sexe_txt.Text = Sexe;
                Email_txt.Text = Email;
                Addr_txt.Text = Addr_for;
                Tele_txt.Text = Tele;
                dateTimePicker1.Text = Date_Naissance;
                N_scolaire_cmb.Text = N_scolaire;
                Exp_txt.Text = Exper_for;
                Situation_txt.Text = Statut_for;
                Sold_txt.Text = Sold_par_h;
            }
            cn.Close();
        }


        private void Ajouter_btn_Click(object sender, EventArgs e)
        {
            string CIN_fo = Modifier_F.TextPassed1;
            if (!ValidateTextBoxes())
            {
                return;
            }
            try
            {
                string updateQuery = "UPDATE Formateur SET " +
                     "Matricul = @Matricul, " +
                     "Nom_for = @Nom_for, " +
                     "Pre_for = @Pre_for, " +
                     "Sexe = @Sexe, " +
                     "Email = @Email, " +
                     "Addr_for = @Addr_for, " +
                     "Tele = @Tele, " +
                     "Date_Naissance = @Date_Naissance, " +
                     "N_scolaire = @N_scolaire, " +
                     "Exper_for = @Exper_for, " +
                     "Statut_for = @Statut_for, " +
                     "Sold_par_h = @Sold_par_h, " +
                     "CIN_for = @CIN_for_new " +
                     "WHERE CIN_for = @CIN_for";

                using (SqlCommand cmd1 = new SqlCommand(updateQuery, cn))
                {
                    cmd1.Parameters.AddWithValue("@Matricul", Matricul_txt.Text);
                    cmd1.Parameters.AddWithValue("@Nom_for", Nom_for_txt.Text);
                    cmd1.Parameters.AddWithValue("@Pre_for", Pre_for_txt.Text);
                    cmd1.Parameters.AddWithValue("@Sexe", Sexe_txt.Text);
                    cmd1.Parameters.AddWithValue("@Email", Email_txt.Text);
                    cmd1.Parameters.AddWithValue("@Addr_for", Addr_txt.Text);
                    cmd1.Parameters.AddWithValue("@Tele", Tele_txt.Text);
                    cmd1.Parameters.AddWithValue("@Date_Naissance", dateTimePicker1.Value);
                    cmd1.Parameters.AddWithValue("@N_scolaire", N_scolaire_cmb.Text);
                    cmd1.Parameters.AddWithValue("@Exper_for", Exp_txt.Text);
                    cmd1.Parameters.AddWithValue("@Statut_for", Situation_txt.Text);
                    cmd1.Parameters.AddWithValue("@Sold_par_h", Sold_txt.Text);
                    cmd1.Parameters.AddWithValue("@CIN_for_new", CIN_fo_txt.Text);
                    cmd1.Parameters.AddWithValue("@CIN_for", CIN_fo);
                    cn.Open();
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                }
                MessageBox.Show("Formateur est Modifié");
                mainForms.fillcbmx();
                mainForms.Refreshform1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Exp_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Exp_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro invalide");
            }
        }

        private void Sold_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Sold_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro invalide");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2, number3;
            bool isNumber1 = int.TryParse(Tele_txt.Text, out number1);
            bool isNumber2 = int.TryParse(Exp_txt.Text, out number2);
            bool isNumber3 = int.TryParse(Sold_txt.Text, out number3);

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
