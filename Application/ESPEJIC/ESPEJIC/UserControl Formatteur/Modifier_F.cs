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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Formatteur
{
    public partial class Modifier_F : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public static string TextPassed1;
        public static string CIN;
        public Modifier_F()
        {
            InitializeComponent();
        }

        private void Mdf_Click(object sender, EventArgs e)
        {
            TextPassed1 = textBox1CIN.Text;
            if (textBox1CIN.Text.Length == 0)
            {
                MessageBox.Show("Please Enter CIN.");
            }
            else
            {
                Modifier_For mdf = new Modifier_For(this);
                mdf.Show();
            }      
        }
        public void fillcbmx()
        {
            comboBox3.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select Nom_for+' '+Pre_for from Formateur", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cn.Close();
        }
        private string Fillcombobox()
        {
            string comb = "";
            SqlCommand cmd = new SqlCommand("Select Nom_for+' '+Pre_for from Formateur", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comb += dr[0].ToString();
                }
            }
            dr.Close();
            cn.Close();
            return comb;
        }
        public void Refreshform1()
        {
            string value = Fillcombobox();
            try
            {
                listView1.Items.Clear();
                SqlCommand cmd1 = new SqlCommand("Select Matricul,Nom_for,Pre_for,CIN_for,Sexe,Email,Addr_for,Tele,Date_Naissance,Exper_for,Statut_for,Sold_par_h,N_scolaire from Formateur where Nom_for+' '+Pre_for='" + value + "'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["Matricul"].ToString());
                    item.SubItems.Add(dr["Nom_for"].ToString());
                    item.SubItems.Add(dr["Pre_for"].ToString());
                    item.SubItems.Add(dr["CIN_for"].ToString());
                    item.SubItems.Add(dr["Sexe"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    item.SubItems.Add(dr["Addr_for"].ToString());
                    item.SubItems.Add(dr["Tele"].ToString());
                    DateTime dateNaissance;
                    if (DateTime.TryParse(dr["Date_Naissance"].ToString(), out dateNaissance))
                    {
                        item.SubItems.Add(dateNaissance.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        item.SubItems.Add(dr["Date_Naissance"].ToString());
                    }
                    item.SubItems.Add(dr["N_Scolaire"].ToString());
                    item.SubItems.Add(dr["Exper_for"].ToString());
                    item.SubItems.Add(dr["Statut_for"].ToString());
                    item.SubItems.Add(dr["Sold_par_h"].ToString());
                    listView1.Items.Add(item);
                    comboBox3.Items.Clear();
                    comboBoxNom();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxNom()
        {
            comboBox3.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select Nom_for+' '+Pre_for from Formateur", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cn.Close();
        }
        private void Modifier_F_Load(object sender, EventArgs e)
        {
            comboBoxNom();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("Delete_Formateur", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CIN_for", CIN);
                    string msg = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(msg);
                }
                cn.Close();
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd1 = new SqlCommand("Select Matricul,Nom_for,Pre_for,CIN_for,Sexe,Email,Addr_for,Tele,Date_Naissance,Exper_for,Statut_for,Sold_par_h,N_scolaire from Formateur where CIN_for='" + textBox1CIN.Text + "'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                listView1.Items.Clear();
                foreach(DataRow dataRow in dt1.Rows)
                {
                    ListViewItem item = new ListViewItem(dataRow["Matricul"].ToString());
                    item.SubItems.Add(dataRow["Nom_for"].ToString());
                    item.SubItems.Add(dataRow["Pre_for"].ToString());
                    item.SubItems.Add(dataRow["CIN_for"].ToString());
                    item.SubItems.Add(dataRow["Sexe"].ToString());
                    item.SubItems.Add(dataRow["Email"].ToString());
                    item.SubItems.Add(dataRow["Addr_for"].ToString());
                    item.SubItems.Add(dataRow["Tele"].ToString());
                    DateTime dateNaissance;
                    if (DateTime.TryParse(dataRow["Date_Naissance"].ToString(), out dateNaissance))
                    {
                        item.SubItems.Add(dateNaissance.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        item.SubItems.Add(dataRow["Date_Naissance"].ToString());
                    }
                    item.SubItems.Add(dataRow["N_Scolaire"].ToString());
                    item.SubItems.Add(dataRow["Exper_for"].ToString());
                    item.SubItems.Add(dataRow["Statut_for"].ToString());
                    item.SubItems.Add(dataRow["Sold_par_h"].ToString());
                    listView1.Items.Add(item);
                }
                cn.Close(); 
                comboBoxNom();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Matricul,Nom_for,Pre_for,CIN_for,Sexe,Email,Addr_for,Tele,Date_Naissance,Exper_for,Statut_for,Sold_par_h,N_scolaire from Formateur where Nom_for+' '+Pre_for='" + comboBox3.Text + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            listView1.Items.Clear();
            foreach (DataRow dr in dt1.Rows)
            {
                ListViewItem item = new ListViewItem(dr["Matricul"].ToString());
                item.SubItems.Add(dr["Nom_for"].ToString());
                item.SubItems.Add(dr["Pre_for"].ToString());
                item.SubItems.Add(dr["CIN_for"].ToString());
                CIN = dr["CIN_for"].ToString();
                item.SubItems.Add(dr["Sexe"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["Addr_for"].ToString());
                item.SubItems.Add(dr["Tele"].ToString());
                item.SubItems.Add(dr["Date_Naissance"].ToString());
                item.SubItems.Add(dr["N_Scolaire"].ToString());
                item.SubItems.Add(dr["Exper_for"].ToString());
                item.SubItems.Add(dr["Statut_for"].ToString());
                item.SubItems.Add(dr["Sold_par_h"].ToString());
                listView1.Items.Add(item);
            }
            SqlCommand cmd2 = new SqlCommand("Select CIN_for from Formateur where Nom_for+' '+Pre_for='" + comboBox3.Text + "'", cn);
            cn.Open();
            SqlDataReader dr1 = cmd2.ExecuteReader();
            while (dr1.Read())
            {
                textBox1CIN.Text = dr1[0].ToString();
            }
            cn.Close();
            dr1.Close();
        }
    }
}
