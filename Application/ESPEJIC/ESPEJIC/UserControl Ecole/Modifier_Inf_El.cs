using ESPEJIC.UserControl_Formatteur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace ESPEJIC.UserControl_Ecole
{
    public partial class Modifier_Inf_El : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Modifier_Inf_El()
        {
            InitializeComponent();
        }

        private void Ajouter_btn_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
            {
                return;
            }
            string txt = Nom_txt.Text;
            string mdf = txt.Replace("'","''");
            try
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("Update Ecole set Nom_eco='" + mdf + "',Abre ='" + abr_txt.Text + "',Addrs='" + Addr_text.Text + "',Email='" + Email_text.Text + "',Fax='"+Fax_text.Text+ "',Tele='"+Tele_text.Text+"',Tele_fix='"+Tele_fix_text.Text+"'", cn);
                SqlDataReader dr;
                dr = cmd1.ExecuteReader();
                MessageBox.Show("Les information d'école' à été modifier!");
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Modifier_Inf_El_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select Nom_eco,Abre,Addrs,Email,Fax,Tele,Tele_fix from Ecole", cn);
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.SelectCommand = cmd;
            DataTable table = new DataTable();
            dt.Fill(table);
            SqlDataReader dr;
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string Nom_eco = dr["Nom_eco"].ToString();
                string Abre = dr["Abre"].ToString();
                string Addrs = dr["Addrs"].ToString();
                string Email= dr["Email"].ToString();
                string Fax = dr["Fax"].ToString();
                string Tele = dr["Tele"].ToString();
                string Tele_fix = dr["Tele_fix"].ToString();


                Nom_txt.Text = Nom_eco;
                abr_txt.Text = Abre;
                Addr_text.Text = Addrs;
                Email_text.Text = Email;
                Fax_text.Text = Fax;
                Tele_text.Text = Tele;
                Tele_fix_text.Text =Tele_fix;
            }
            cn.Close();
        }

        private void Tele_text_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Tele_text.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro de téléphone invalide");
            }
        }

        private void Fax_text_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(Fax_text.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un numéro de FIX invalide");
            }
        }

        private void Tele_fix_text_Leave(object sender, EventArgs e)
        {
            //int number1;
            //bool isNumber1 = int.TryParse(Tele_fix_text.Text, out number1);
            //if (!isNumber1)
            //{
            //    MessageBox.Show("Vous avez entré un numéro de Telephone FIX invalide");
            //}
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2, number3;
            bool isNumber1 = int.TryParse(Tele_text.Text, out number1);
            bool isNumber2 = int.TryParse(Fax_text.Text, out number2);
            //bool isNumber3 = int.TryParse(Tele_fix_text.Text, out number3);

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
