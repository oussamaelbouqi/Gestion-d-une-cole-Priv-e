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

namespace ESPEJIC
{
    public partial class la_liste_M : UserControl
    {
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public la_liste_M()
        {
            InitializeComponent();
        }

        private void la_liste_M_Load(object sender, EventArgs e)
        {
            typebox.Items.Clear();
            cn.Open();
            cmd = new SqlCommand("select Type_stagaire from Classe", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                typebox.Items.Add(dr[0].ToString());
            }
            cn.Close();
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label7.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
        }

        private void typebox_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(typebox.Text == "1er année")
           {
                SqlCommand cmd1 = new SqlCommand("select * from Matiére where Type_stagaire ='1er année'",cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                listView1.Items.Clear();
                foreach (DataRow dr in dt1.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["Nom_Mat"].ToString());
                    item.SubItems.Add(dr["Quiffance"].ToString());
                    item.SubItems.Add(dr["N_heurs"].ToString());
                    item.SubItems.Add(dr["Type_stagaire"].ToString());
                    item.SubItems.Add(dr["statu_mat"].ToString());
                    listView1.Items.Add(item);

                }
           }
           else if (typebox.Text == "2émé année")
           {
                listView1.Items.Clear();

                SqlCommand cmd1 = new SqlCommand("select * from Matiére where Type_stagaire ='2émé année'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["Nom_Mat"].ToString());
                    item.SubItems.Add(dr["Quiffance"].ToString());
                    item.SubItems.Add(dr["N_heurs"].ToString());
                    item.SubItems.Add(dr["Type_stagaire"].ToString());
                    item.SubItems.Add(dr["statu_mat"].ToString());
                    listView1.Items.Add(item);

                }
           }
            else if (typebox.Text == "3émé année")
            {
                listView1.Items.Clear();

                SqlCommand cmd1 = new SqlCommand("select * from Matiére where Type_stagaire ='3émé année'", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                foreach (DataRow dr in dt1.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["Nom_Mat"].ToString());
                    item.SubItems.Add(dr["Quiffance"].ToString());
                    item.SubItems.Add(dr["N_heurs"].ToString());
                    item.SubItems.Add(dr["Type_stagaire"].ToString());
                    item.SubItems.Add(dr["statu_mat"].ToString());
                    listView1.Items.Add(item);

                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
