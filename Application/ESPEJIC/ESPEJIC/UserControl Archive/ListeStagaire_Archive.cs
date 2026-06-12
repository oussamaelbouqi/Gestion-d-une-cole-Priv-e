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
    public partial class ListeStagaire_Archive : Form
    {
        SqlCommand cmd;
        SqlDataReader rd;

        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Archive1;Integrated Security=True");
        public ListeStagaire_Archive()
        {
            InitializeComponent();
        }

        private void ListeStagaire_Archive_Load(object sender, EventArgs e)
        {
            try { 
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Type_stagaire from Classe ", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                   
                    typebox.Items.Add(rd[0].ToString());
                }
                cmd.Dispose();
            rd.Close();
                conn.Close();
           conn.Open();
            SqlCommand cmd1 = new SqlCommand("select distinct years from Stagaire ", conn);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                anne.Items.Add(rd1[0].ToString());
               
            }
            cmd1.Dispose();
            rd1.Close();
            conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur!!!", "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void anne_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            typebox.Items.Clear();
            dataGridView1.Controls.Clear(); 
            conn.Open();
            cmd = new SqlCommand("select distinct Type_stagaire from Stagaire", conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                typebox.Items.Add(rd[0].ToString());
            }
            conn.Close();
            typebox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void typebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                DataTable dataTable = new DataTable();
                string query = "SELECT ID_Stagaire,CIN_Stagaire ,N_Insc,Nom_stagaire,Pre_stagaire,Date_Ins,N_scolaire,Addrs,Email,Tele,Type_stagaire,Sexe,[Mont_an],[Statut_Stg],[pro]  FROM Stagaire where Type_stagaire ='" + typebox.Text + "'   and years ='" + anne.Text + "' ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void anne_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(anne.Text))
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("année vide", "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void typebox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(typebox.Text) && string.IsNullOrEmpty(anne.Text))
                {

                    dataGridView1.DataSource = null;
                    MessageBox.Show("Type stagaire vide", "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "faild", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
