using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC
{
    public partial class Modifier_M : UserControl
    {
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        private int ID;
        private string mdf;
        public Modifier_M()
        {
            InitializeComponent();
        }
        
        private void Modifier_M_Load_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            cn.Open();
            cmd = new SqlCommand("select Type_stagaire from Classe", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

            comboBox3.Items.Clear();
            cn.Open();
            cmd = new SqlCommand("select statu_mat from Active", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("select Nom_Mat,Quiffance,N_heurs,Type_stagaire,statu_mat from Matiére where Type_stagaire ='" + comboBox1.Text+"'", cn);
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    this.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
                }
            }
            dr.Close();
            cn.Close() ;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBoxes())
            {
                return;
            }
            cn.Open();
            cmd = new SqlCommand("update Matiére SET Nom_Mat ='" + mdf + "', Quiffance ='" + textBox1.Text + "', N_heurs ='" + textBox2.Text + "', Type_stagaire= '" + comboBox2.Text + "',statu_mat ='"+ comboBox3.Text+"' where ID_Matiére ='" + ID+"' ", cn);
            dr = cmd.ExecuteReader();
            MessageBox.Show("La Matiére a été modifiée");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dr.Close();
            cn.Close();
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("select Nom_Mat,Quiffance,N_heurs,Type_stagaire,statu_mat from Matiére where Type_stagaire ='" + comboBox1.Text+"'",cn);
            cn.Open() ;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
              while (dr.Read())
                {
                    this.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]) ;
                }
            }
            dr.Close() ; 
            cn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand("select Type_stagaire from Classe", cn);
            SqlDataAdapter dt = new SqlDataAdapter();
            dt.SelectCommand = cmd;
            DataTable table = new DataTable();
            dt.Fill(table);
            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "Type_stagaire";
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox8.Text = row.Cells["Nom_Mat"].Value?.ToString();
                textBox2.Text = row.Cells["Quiffance"].Value?.ToString();
                textBox1.Text = row.Cells["N_heurs"].Value?.ToString();
                comboBox2.Text = row.Cells["Type_stagaire"].Value?.ToString();
                comboBox3.Text = row.Cells["statu_mat"].Value?.ToString();
                string value = textBox8.Text;
                mdf = value.Replace("'", "''");
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                else
                {
                    cmd = new SqlCommand("Select ID_Matiére from Matiére where Nom_Mat='"+mdf+"'", cn);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ID = Convert.ToInt32(dr[0]);
                        }
                    }
                    dr.Close();
                    cn.Close();
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox1.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré un Nombre d'heures invalide.");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int number1;
            bool isNumber1 = int.TryParse(textBox2.Text, out number1);
            if (!isNumber1)
            {
                MessageBox.Show("Vous avez entré une Quiffance invalide.");
            }
        }
        private bool ValidateTextBoxes()
        {
            int number1, number2;
            bool isNumber1 = int.TryParse(textBox1.Text, out number1);
            bool isNumber2 = int.TryParse(textBox2.Text, out number2);

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


