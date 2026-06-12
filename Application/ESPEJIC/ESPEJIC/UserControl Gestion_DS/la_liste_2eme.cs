using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.gestion_de_stage
{
    public partial class la_liste_2eme : UserControl
    {
        public SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True;Encrypt=False");
        public SqlCommand cmd;
        SqlDataReader dr;
        public la_liste_2eme()
        {
            InitializeComponent();
        }
        public void FillInformationEcole()
        {
            string query = "Select Nom_eco from Ecole";
            string query1 = "Select Nom_Full from Filiére";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label13.Text = reader[0].ToString();
                }
                cn.Close();
            }
            using (SqlCommand cmd = new SqlCommand(query1, cn))
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label15.Text = reader[0].ToString();
                }
                cn.Close();
            }
        }
        private void la_liste_2eme_Load(object sender, EventArgs e)
        {
            FillInformationEcole();
            cn.Open();
            cmd = new SqlCommand("Select Stage.CIN_Stagaire,Stagaire.Nom_stagaire,Stagaire.Pre_stagaire,Stagaire.Type_stagaire,Nom_Entr,Addrs_Ent,Stage.Tele,Date_d,Date_f , DATEDIFF(MONTH, Date_d, Date_f) from Stage inner join Stagaire on Stage.CIN_Stagaire = Stagaire.CIN_Stagaire where Type_stagaire='2émé année'", cn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string date_d = DateTime.Parse(dr["Date_d"].ToString()).ToString("yyyy-MM-dd");
                    string date_f = DateTime.Parse(dr["Date_f"].ToString()).ToString("yyyy-MM-dd");

                    this.dataGridView1.Rows.Add(dr["CIN_Stagaire"], dr["Nom_stagaire"], dr["Pre_stagaire"], dr["Type_stagaire"], dr["Nom_Entr"], dr["Addrs_Ent"], dr["Tele"], date_d, date_f, dr[9]);
                }
                cn.Close();
            }
            else
            {
                MessageBox.Show("La table de stage pour cette classe est vide !");
                cn.Close();
            }
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.Print();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bitmap, e.MarginBounds);
        }
    }
}
