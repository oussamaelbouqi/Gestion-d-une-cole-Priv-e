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
using System.Windows.Forms;

namespace ESPEJIC.UserController_Stagaire
{
    public partial class Modifer_S : UserControl
    {
        public static string TextPassed1;
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public Modifer_S()
        {
            InitializeComponent();
            RefreshListView();
        }

        private void Mdf_Click(object sender, EventArgs e)
        {
            TextPassed1 = textBox1CIN_stg.Text;
            if (textBox1CIN_stg.Text.Length == 0)
            {
                MessageBox.Show("Please Enter CIN.");
            }
            else
            {
                Modifer_Stg modifer_Stg = new Modifer_Stg(this);
                modifer_Stg.Show();
            }
        }

        public void RefreshListView()
        {
            listView1.Items.Clear();
            SqlCommand cmd1 = new SqlCommand("Select * from Stagaire where Nom_stagaire+' '+Pre_stagaire = '" + comboBox3.Text + "'", cn);
            SqlCommand cmd2 = new SqlCommand("Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire = '" + comboBox3.Text + "'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            listView1.Items.Clear();
            foreach (DataRow dr in dt1.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ID_Stagaire"].ToString());
                item.SubItems.Add(dr["N_Insc"].ToString());
                item.SubItems.Add(dr["Nom_stagaire"].ToString());
                item.SubItems.Add(dr["Pre_stagaire"].ToString());
                item.SubItems.Add(dr["CIN_Stagaire"].ToString());
                item.SubItems.Add(dr["Date_Ins"].ToString());
                item.SubItems.Add(dr["N_scolaire"].ToString());
                item.SubItems.Add(dr["Addrs"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["Tele"].ToString());
                item.SubItems.Add(dr["Type_stagaire"].ToString());
                item.SubItems.Add(dr["Sexe"].ToString());
                listView1.Items.Add(item);
            }
            cn.Open();
            SqlDataReader dr1 = cmd2.ExecuteReader();
            while (dr1.Read())
            {
                textBox1CIN_stg.Text = dr1[0].ToString();
            }
            cn.Close();
            dr1.Close();
        }
        public void fillcombobox()
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", cn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
        }
        private void Supprimer_Click(object sender, EventArgs e)
        {
            string CIN_stg = textBox1CIN_stg.Text;
            try
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("Delete_Student", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CIN_Stagaire",CIN_stg);
                    string msg = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(msg);
                }
                cn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox3.Items.Clear();
            SqlCommand cmd1 = new SqlCommand("Select Nom_stagaire+' '+Pre_stagaire from Stagaire where Type_stagaire ='" + comboBox1.Text + "' ", cn);
            cn.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cn.Close();
            RefreshListView();
        }

        private void Modifer_S_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Type_stagaire from Classe", cn);
            SqlDataAdapter dt1 = new SqlDataAdapter();
            dt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            dt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select * from Stagaire where Nom_stagaire+' '+Pre_stagaire = '" + comboBox3.Text + "'", cn);
            SqlCommand cmd2 = new SqlCommand("Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire = '" + comboBox3.Text + "'",cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            listView1.Items.Clear();
            foreach (DataRow dr in dt1.Rows)
            {
                ListViewItem item = new ListViewItem(dr["ID_Stagaire"].ToString());
                item.SubItems.Add(dr["N_Insc"].ToString());
                item.SubItems.Add(dr["Nom_stagaire"].ToString());
                item.SubItems.Add(dr["Pre_stagaire"].ToString());
                item.SubItems.Add(dr["CIN_Stagaire"].ToString());
                item.SubItems.Add(dr["Date_Ins"].ToString());
                item.SubItems.Add(dr["Tele"].ToString());
                item.SubItems.Add(dr["N_scolaire"].ToString());
                item.SubItems.Add(dr["Addrs"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["Tele"].ToString());
                item.SubItems.Add(dr["Type_stagaire"].ToString());
                item.SubItems.Add(dr["Sexe"].ToString());
                listView1.Items.Add(item);
            }
            cn.Open();
            SqlDataReader dr1 = cmd2.ExecuteReader();
            while (dr1.Read())
            {
                textBox1CIN_stg.Text = dr1[0].ToString();
            }
            cn.Close();
            dr1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select Nom_stagaire+' '+Pre_stagaire from Stagaire where Type_stagaire ='" + comboBox1.Text + "' ", cn);
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
    }
}
