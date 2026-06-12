using ESPEJIC.UserController_Stagaire;
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
    public partial class Modifer_Stg : Form
    {
        public Modifer_S mainForm;
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public static string TextPassed1;
        public Modifer_Stg(Modifer_S modifer_S)
        {
            InitializeComponent();
            mainForm = modifer_S;
        }

        private void Modifer_Stg_Load(object sender, EventArgs e)
        {
            Cin_txt.Text = Modifer_S.TextPassed1;
            SqlCommand cmd1, cmd3, cmd4, cmd5;
            cmd1 = new SqlCommand("Select ID_Stagaire,N_Insc,Nom_stagaire,Pre_stagaire,Date_Ins,N_scolaire,Statut_Stg,Addrs,Email,Tele,Sexe,Mont_an from Stagaire where CIN_Stagaire ='" + Cin_txt.Text + "'", cn);
            SqlDataAdapter dt1, dt2, dt3;
            dt1 = new SqlDataAdapter();
            dt2 = new SqlDataAdapter();
            dt3 = new SqlDataAdapter();
            cmd3 = new SqlCommand("Select N_scolaire from Diplome", cn);
            cmd4 = new SqlCommand("Select Statut_Stg from Status_stg", cn);
            cmd5 = new SqlCommand("Select Sexe from Genre", cn);
            dt1.SelectCommand = cmd3;
            dt2.SelectCommand = cmd4;
            dt3.SelectCommand = cmd5;
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            dt1.Fill(table1);
            dt2.Fill(table2);
            dt3.Fill(table3);
            N_Scolaire_txt.DataSource = table1;
            N_Scolaire_txt.DisplayMember = "N_scolaire";
            Status.DataSource = table2;
            Status.DisplayMember = "Statut_Stg";
            Sexe_txt.DataSource = table3;
            Sexe_txt.DisplayMember = "Sexe";
            SqlDataReader dr;
            cn.Open();
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string ID_Stagaire = dr["ID_Stagaire"].ToString();
                string N_Insc = dr["N_Insc"].ToString();
                string Nom_stagaire = dr["Nom_stagaire"].ToString();
                string Pre_stagaire = dr["Pre_stagaire"].ToString();
                string Date_Ins = dr["Date_Ins"].ToString();
                string N_scolaire = dr["N_scolaire"].ToString();
                string Statue = dr["Statut_Stg"].ToString();
                string Addrs = dr["Addrs"].ToString();
                string Email = dr["Email"].ToString();
                string Tele = dr["Tele"].ToString();
                string Sexe = dr["Sexe"].ToString();
                string Mont_an = dr["Mont_an"].ToString() ;
                ID_txt.Text = ID_Stagaire;
                N_Ins.Text = N_Insc;
                Nom_txt.Text = Nom_stagaire;
                Pre_txt.Text = Pre_stagaire;
                N_Scolaire_txt.Text = N_scolaire;
                Status.Text = Statue;
                Adr_txt.Text = Addrs;
                Email_txt.Text = Email;
                Tele_txt.Text = Tele;
                Sexe_txt.Text = Sexe;
                dateTimePicker1.Text = Date_Ins;
                Montant_txt.Text = Mont_an;
            }
            cn.Close();
        }

        private void Ajouter_btn_Click(object sender, EventArgs e)
        {
            string oldCIN = Modifer_S.TextPassed1;
            if (!ValidateTextBoxes())
            {
                return;
            }
            try
            {
                cn.Open();

                string query = "UPDATE Stagaire SET " +
                               "ID_Stagaire = @ID_Stagaire, " +
                               "Nom_stagaire = @Nom_stagaire, " +
                               "Pre_stagaire = @Pre_stagaire, " +
                               "Sexe = @Sexe, " +
                               "Email = @Email, " +
                               "Addrs = @Addrs, " +
                               "Tele = @Tele, " +
                               "Date_Ins = @Date_Ins, " +
                               "N_scolaire = @N_scolaire, " +
                               "N_Insc = @N_Insc, " +
                               "Statut_Stg = @Statut_Stg, " +
                               "Mont_an = @Mont_an, " +
                               "CIN_Stagaire = @CIN_Stagaire " +
                               "WHERE CIN_Stagaire = @OldCIN";

                using (SqlCommand cmd1 = new SqlCommand(query, cn))
                {
                    cmd1.Parameters.AddWithValue("@ID_Stagaire", ID_txt.Text);
                    cmd1.Parameters.AddWithValue("@Nom_stagaire", Nom_txt.Text);
                    cmd1.Parameters.AddWithValue("@Pre_stagaire", Pre_txt.Text);
                    cmd1.Parameters.AddWithValue("@Sexe", Sexe_txt.Text);
                    cmd1.Parameters.AddWithValue("@Email", Email_txt.Text);
                    cmd1.Parameters.AddWithValue("@Addrs", Adr_txt.Text);
                    cmd1.Parameters.AddWithValue("@Tele", Tele_txt.Text);
                    cmd1.Parameters.AddWithValue("@Date_Ins", dateTimePicker1.Value);
                    cmd1.Parameters.AddWithValue("@N_scolaire", N_Scolaire_txt.Text);
                    cmd1.Parameters.AddWithValue("@N_Insc", N_Ins.Text);
                    cmd1.Parameters.AddWithValue("@Statut_Stg", Status.Text);
                    cmd1.Parameters.AddWithValue("@Mont_an", Montant_txt.Text);
                    cmd1.Parameters.AddWithValue("@CIN_Stagaire", Cin_txt.Text);
                    cmd1.Parameters.AddWithValue("@OldCIN", oldCIN);
                    cmd1.ExecuteNonQuery();
                }
                cn.Close();
                MessageBox.Show("Les informations du stagiaire ont été modifiées !");
                mainForm.fillcombobox();
                mainForm.RefreshListView();
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

        private void Montant_txt_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Montant_txt.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro invalide");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2;
            bool isNumber1 = int.TryParse(Tele_txt.Text, out number1);
            bool isNumber2 = int.TryParse(Montant_txt.Text, out number2);

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

    }
}
