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

namespace ESPEJIC.UserControl_Note
{
    public partial class Liste_N : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";

        private int a;
        public Liste_N()
        {
            InitializeComponent();
        }

        private void CenterLabel()
        {
            int centerX = (Width - label3.Width) / 2;
            label1.Location = new Point(centerX, 50);
        }

        private void Liste_N_Load(object sender, EventArgs e)
        {
            
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "Select Type_stagaire from Classe";
                    SqlDataAdapter ad = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    comboBox1.DisplayMember = "Type_stagaire";
                    comboBox1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            int currentYear = DateTime.Now.Year;
            int lastYeasr = DateTime.Now.Year - 1;
            label6.Text = $"{currentYear.ToString()} / {lastYeasr.ToString()}";
            dataGridView2.Visible = false;
        }
        private DataTable FetchAllStudentsFromDatabase()
        {
            string query = "SELECT CIN_Stagaire, Nom_stagaire, Pre_stagaire FROM Stagaire where Type_stagaire ='" + comboBox1.Text + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable students = new DataTable();
                        adapter.Fill(students);
                        return students;
                    }
                }
            }
        }

        private DataTable FetchAllSubjectsFromDatabase()
        {
            string query = "SELECT ID_Matiére, Nom_Mat FROM Matiére where Type_stagaire ='" + comboBox1.Text + "' and statu_mat='Active'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable subjects = new DataTable();
                        adapter.Fill(subjects);
                        return subjects;
                    }
                }
            }
        }

        private DataTable FetchAllStudentsFromDatabase1(string Type_stagaire)
        {
            string query = "SELECT CIN_Stagaire, Nom_stagaire, Pre_stagaire FROM Stagaire where Type_stagaire =@Type_stagaire";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type_stagaire", Type_stagaire);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable students = new DataTable();
                        adapter.Fill(students);
                        return students;
                    }
                }
            }
        }

        private DataTable FetchAllSubjectsFromDatabase1(string Type_stagaire)
        {
            string query = "SELECT ID_Matiére, Nom_Mat FROM Matiére where Type_stagaire =@Type_stagaire and statu_mat='Active'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type_stagaire", Type_stagaire);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable subjects = new DataTable();
                        adapter.Fill(subjects);
                        return subjects;
                    }
                }
            }
        }

        private string FetchGradeFromDatabase(string CIN_Stagaire, int ID_Matiére, string type_note)
        {
            Dictionary<string, string> gradeColumnMapping = new Dictionary<string, string>
            {
                { "Controles Continus", "Control_C" },
                { "EFCFT", "EFCE_thero" },
                { "EFCFP", "EFCE_prat" }
            };
            if (gradeColumnMapping.ContainsKey(type_note))
            {
                string columnName = gradeColumnMapping[type_note];
                string query = $"SELECT {columnName} FROM Note WHERE CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CIN_Stagaire", CIN_Stagaire);
                        command.Parameters.AddWithValue("@ID_Matiére", ID_Matiére);
                        connection.Open();
                        var result = command.ExecuteScalar();
                        return result != null ? result.ToString() : "";
                    }
                }
            }
            else
            {
                return "";
            }
        }

        private string FetchGradeFromDatabase1(string CIN_Stagaire, int ID_Matiére, string type_note)
        {
            Dictionary<string, string> gradeColumnMapping = new Dictionary<string, string>
            {
                { "Controles Continus", "Control_C" },
                { "EFCFT", "EFCE_thero" },
                { "EFCFP", "EFCE_prat" }
            };
            if (gradeColumnMapping.ContainsKey(type_note))
            {
                string columnName = gradeColumnMapping[type_note];
                string query = $"SELECT {columnName} FROM Note WHERE CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CIN_Stagaire", CIN_Stagaire);
                        command.Parameters.AddWithValue("@ID_Matiére", ID_Matiére);
                        connection.Open();
                        var result = command.ExecuteScalar();
                        return result != null ? result.ToString() : "";
                    }
                }
            }
            else
            {
                return "";
            }
        }
        private void LoadGrades1()
        {
            DataTable students = FetchAllStudentsFromDatabase1(comboBox1.Text);
            DataTable subjects = FetchAllSubjectsFromDatabase1(comboBox1.Text);
            DataTable gradesTable = new DataTable();
            gradesTable.Columns.Add("Nom ét Prénom", typeof(string));
            foreach (DataRow subjectRow in subjects.Rows)
            {
                string subjectName = subjectRow["Nom_Mat"].ToString();
                gradesTable.Columns.Add(subjectName, typeof(string));
            }
            foreach (DataRow studentRow in students.Rows)
            {
                string studentID = studentRow["CIN_Stagaire"].ToString();
                string firstName = studentRow["Nom_stagaire"].ToString();
                string lastName = studentRow["Pre_stagaire"].ToString();
                string fullName = $"{firstName} {lastName}";
                DataRow newRow = gradesTable.NewRow();
                newRow["Nom ét Prénom"] = fullName;
                foreach (DataRow subjectRow in subjects.Rows)
                {
                    int subjectID = Convert.ToInt32(subjectRow["ID_Matiére"]);
                    string grade = FetchGradeFromDatabase1(studentID, subjectID, comboBox2.Text);
                    newRow[subjectRow["Nom_Mat"].ToString()] = grade;
                }
                gradesTable.Rows.Add(newRow);
            }
            dataGridView1.DataSource = gradesTable;
        }

        private void LoadGrades(string type_note)
        {
            DataTable students = FetchAllStudentsFromDatabase();
            DataTable subjects = FetchAllSubjectsFromDatabase();
            DataTable gradesTable = new DataTable();
            gradesTable.Columns.Add("Nom ét Prénom", typeof(string));
            foreach (DataRow subjectRow in subjects.Rows)
            {
                string subjectName = subjectRow["Nom_Mat"].ToString();
                gradesTable.Columns.Add(subjectName, typeof(string));
            }
            foreach (DataRow studentRow in students.Rows)
            {
                string studentID = studentRow["CIN_Stagaire"].ToString();
                string firstName = studentRow["Nom_stagaire"].ToString();
                string lastName = studentRow["Pre_stagaire"].ToString();
                string fullName = $"{firstName} {lastName}";
                DataRow newRow = gradesTable.NewRow();
                newRow["Nom ét Prénom"] = fullName;
                foreach (DataRow subjectRow in subjects.Rows)
                {
                    int subjectID = Convert.ToInt32(subjectRow["ID_Matiére"]);
                    string grade = FetchGradeFromDatabase(studentID, subjectID, type_note);
                    newRow[subjectRow["Nom_Mat"].ToString()] = grade;
                }
                gradesTable.Rows.Add(newRow);
            }
            dataGridView1.DataSource = gradesTable;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1er année")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Controles Continus");
                comboBox2.Items.Add("EFCFT");
                comboBox2.Items.Add("EFCFP");
            }
            if (comboBox1.Text == "2émé année")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Controles Continus");
                comboBox2.Items.Add("EFCFT");
                comboBox2.Items.Add("EFCFP");
                comboBox2.Items.Add("PFE");
                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;
            }
            else
            {
                if (comboBox1.SelectedIndex == 0 && comboBox2.Items.Contains("PFE"))
                {
                    comboBox2.Items.Remove("PFE");
                }
                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;
            }
            LoadGrades1();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 3)
            {
                dataGridView2.Rows.Clear();
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                string query1 = "Select PFE from PFE as p inner join Stagaire as s on s.CIN_Stagaire = p.CIN_Stagaire where s.Type_Stagaire = '2émé année'";
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query1, cn))
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            a = 1;
                        }
                        else
                        {
                            a = 0;
                        }
                        cn.Close();
                    }
                }
                if (a == 1)
                {
                    string query2 = "Select Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire as 'fullname' , PFE from PFE , Stagaire where Stagaire.CIN_Stagaire = PFE.CIN_Stagaire AND Type_Stagaire = '2émé année'";
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query2, cn))
                        {
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                string Fullname = dr["fullname"].ToString();
                                string PFE = dr["PFE"].ToString();
                                dataGridView2.Rows.Add(Fullname, PFE);
                            }
                            cn.Close();
                        }
                    }
                }
                if (a == 0)
                {
                    DataTable dt = new DataTable();
                    string query = "Select Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire as Fullname  from Stagaire where Type_Stagaire = '2émé année'";
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            cn.Open();
                            SqlDataAdapter dr = new SqlDataAdapter(query, cn);
                            dr.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView2.Rows.Add(row["Fullname"].ToString(), string.Empty);
                    }
                }
            }
            else
            {
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
            }
            string select = comboBox2.SelectedItem.ToString();
            LoadGrades(select);
        }

        private void Liste_N_Resize(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.WindowState == FormWindowState.Maximized)
            {
                CenterLabel();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
