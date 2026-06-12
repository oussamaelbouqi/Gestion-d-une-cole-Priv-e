using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace ESPEJIC
{
    public partial class Testor3 : Form
    {
        string arche= "Data Source=.;Initial Catalog=Archive1;Integrated Security=True", esp = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        SqlConnection cn1 = new SqlConnection("Data Source=.;Initial Catalog=Archive1;Integrated Security=True");
        string dat = $"{DateTime.Now.Year}";
        private bool insert=true;
        public Testor3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select m.ID_Matiére ,m.Nom_Mat from Matiére m left join Note n on m.ID_Matiére = n.ID_Matiére left join Stagaire st on st.CIN_Stagaire = n.CIN_Stagaire where (n.EFCE_prat IS NULL OR n.Control_C IS NULL OR n.EFCE_thero IS NULL) AND st.Type_stagaire='2émé année'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("une des notes des exmamens n'a pas été saisie");
                    MessageBox.Show("une des notes des PFE n'a pas été saisie");
                }
                else
                {
                    //MessageBox.Show("Archive");
                    //cn1.Open();
                    //string query1= "insert into [dbo].[Stagaire] select *  from [ESPEGIC].[dbo].[Stagaire]  WHERE  Type_stagaire='2émé année'";
                    //SqlCommand cmd1 =new SqlCommand(query1, cn1);
                    //cmd1.ExecuteNonQuery();
                    //cn1.Close();



                    cn1.Open();
                    string query2 = "insert into [dbo].[Matiére] select *  from [ESPEGIC].[dbo].[Matiére]  WHERE  Type_stagaire='2émé année";
                    SqlCommand cmd2 = new SqlCommand(query2, cn1);
                    cmd2.ExecuteNonQuery();
                    cn1.Close();
                }
                cn.Close();

            }
        }

        private void Testor3_Load(object sender, EventArgs e)
        {
                      progressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)          //"INSERT INTO Filiére (column1, column2, column3, column4, column5, column6) VALUES (@par1, @par2, @par3, @par4, @par5, @par6)";
        {
            int a = 0, b = 0;
            try
            {
                #region  note active
                string query1 = "select * from Stagaire where Type_stagaire = '2émé année'";
                string query = "Select m.ID_Matiére,m.Nom_Mat,n.EFCE_prat,n.EFCE_thero,n.Control_C from Matiére m left join Note n on m.ID_Matiére = n.ID_Matiére left join Stagaire st on st.CIN_Stagaire = n.CIN_Stagaire where (n.EFCE_prat IS  NULL OR n.Control_C IS   NULL OR n.EFCE_thero IS NULL) and m.statu_mat='Active'";
                using (SqlConnection cna = new SqlConnection(esp))
                {
                    using (SqlCommand cmd = new SqlCommand(query1, cna))
                    {
                        cna.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            b = 1;
                        }
                        cna.Close();
                    }
                    if(b == 0)
                    {
                        query += "and m.Type_stagaire = '1er année'";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, cna))
                    {
                        cna.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            insert = true;
                            MessageBox.Show("une des notes des exmamens n'a pas été saisie");
                            return;
                        }
                        else
                        {
                            insert = false;
                        }
                        cna.Close();

                    }
                }
                #endregion
                #region PFE
                string requet = "Select p.PFE from dbo.Stagaire s left join dbo.PFE p on p.CIN_Stagaire=s.CIN_Stagaire where (p.PFE is null) and s.Type_stagaire='2émé année'";
                using (SqlConnection cns = new SqlConnection(esp))
                {
                    cns.Open();
                    using (SqlCommand cmd = new SqlCommand(requet, cns))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            MessageBox.Show("une des notes des PFE n'a pas été saisie");
                            insert = true;
                        }
                        else
                        {
                            insert = false;
                        }
                    }
                    cns.Close();
                }
                #endregion
                progressBar1.Value = 2;
                #region quiffance
                quiffance("insert into  Quiffance select Quiff,[Type_EX],CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4)) from ESPEGIC.dbo.Quiffance ");
                #endregion
                #region check student abondonée
                //absencestagaire
                check_abondonée("delete n from dbo.Stagaire st inner join dbo.Absence_stagaire n on n.CIN_Stagaire=st.CIN_Stagaire where st.Statut_Stg='Abandonné'and st.Type_stagaire = '1er année'");
                //note
                check_abondonée("delete n from dbo.Stagaire st inner join dbo.Note n on n.CIN_Stagaire=st.CIN_Stagaire where st.Statut_Stg='Abandonné'and st.Type_stagaire = '1er année'");
                //Stage
                check_abondonée("delete n from dbo.Stagaire st inner join dbo.Stage n on n.CIN_Stagaire=st.CIN_Stagaire where st.Statut_Stg='Abandonné'and st.Type_stagaire = '1er année'");
                // paiment
                check_abondonée("delete n from dbo.Stagaire st inner join dbo.Paiment n on n.CIN_Stagaire=st.CIN_Stagaire where st.Statut_Stg='Abandonné'and st.Type_stagaire = '1er année'");
                //stagaire
                check_abondonée("delete from dbo.Stagaire where Statut_Stg='Abandonné'and Type_stagaire = '1er année'");
     
                #endregion
                #region check and insert 1er anner 
                checktable("SELECT * FROM Filiére", "SELECT Nom_fill FROM Filiére WHERE Nom_fill = @dr1", "insert into Filiére([ID_Fil],[Nom_fill],[Cap],[Niveau],[Nom_Full],[years]) VALUES (@par1, @par2, @par3, @par4,  @par6,@par5)", "f");
                checktable("SELECT * FROM Matiére", "SELECT Nom_Mat FROM Matiére WHERE Nom_Mat = @dr1", "insert into Matiére VALUES (@par1, @par2, @par3, @par4, @par5, @par6,@par7,@par8)", "m");
                progressBar1.Value = 5;

                #endregion
                #region formateur
                // deleted formateur
                try
                {
                    delete_other("delete from [dbo].[Absence_For]", "e");
                    delete_other("delete from [dbo].[Salaire] ", "e");
                    delete_other("delete from [dbo].[Formateur]", "e");
                    progressBar1.Value=10;
                }
                catch
                {
                    insert = false;
                }
                #endregion
                #region 2eme année
                #region delete 1anné on archive  note and paiment and absence and stage 
                try
                {
                   // delete_other("delete from note  where [CIN_Stagaire] in (select [CIN_Stagaire] from [ESPEGIC].dbo.Stagaire where [Type_stagaire] ='2émé année')", "a");
                    // delete_other("delete from Paiment  where [CIN_Stagaire] in (select [CIN_Stagaire] from [ESPEGIC].dbo.Stagaire where [Type_stagaire] ='2émé année')", "a");
                  //  delete_other("delete from Absence_stagaire  where [CIN_Stagaire] in (select [CIN_Stagaire] from [ESPEGIC].dbo.Stagaire where [Type_stagaire] ='2émé année')", "a");
                  //  delete_other("delete from stage  where [CIN_Stagaire] in (select [CIN_Stagaire] from [ESPEGIC].dbo.Stagaire where [Type_stagaire] ='2émé année')", "a");
                    progressBar1.Value = 24;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(""+ex.Message);
                }
                #endregion
              
                #region insert and delete 2émé année
                try
                {

                    insert_note("2émé année", 'i');
                    insert_paiment("2émé année", 'i');
                    insert_absence("2émé année", 'i');
                    insert_stage("2émé année", 'i');
                    insert_PFE('i');
                    progressBar1.Value = 36;
                  
                    // delete
                   insert_paiment("2émé année", 'd');
                    insert_absence("2émé année", 'd');
                    insert_stage("2émé année", 'd');
                    insert_PFE('d');
                   
                    insert_student("2émé année");
                    insert_note("2émé année", 'd');
                    delete_other("delete from Stagaire where [Type_stagaire] ='2émé année'", "e");
                    progressBar1.Value = 45;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERREUR quand transférer", ex.Message) ;
                }
                #endregion
                progressBar1.Value = 50;
               

                #endregion
                #region 1er année
                //  1er année insert

                // insert note
             
                try
                {
                    insert_student("1er année");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(":","__"+ex.Message);
                }
              
                // delete
                #region  delete and update and insert 1er anner           
                try
                {
                    
                    progressBar1.Value = 60;
                    insert_note("1er année", 'i');
                    insert_absence("1er année", 'i');
                    insert_paiment("1er année", 'i');
                    insert_stage("1er année", 'i');
                    progressBar1.Value = 75;
                    insert_note("1er année", 'd');
                    insert_paiment("1er année", 'd');
                    insert_absence("1er année", 'd');
                    insert_stage("1er année", 'd');
                    update_student("1er année", 'e');
                    progressBar1.Value = 90;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(":",ex.Message);
                }
               
                progressBar1.Value = 100;
                #endregion
                // update 1er to 2eme anner

                #endregion
                DialogResult resul = MessageBox.Show("Transfert avec succès", "transform complet",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (resul == DialogResult.OK)
                {
                   this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            
        }
        private void quiffance(string query)
        {
            try
            {
                using (SqlConnection cns = new SqlConnection("Data Source=.;Initial Catalog=Archive1;Integrated Security=True"))
                {
                    cns.Open();
                    using (SqlCommand cmde = new SqlCommand(query, cns))
                    {
                        cmde.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }


        }
        private void check_abondonée(string query)

        {
        try { 
             using (SqlConnection cns= new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True")) {   
                  cns.Open();
              using(SqlCommand cmde = new SqlCommand(query, cns)) 
                  { 
                        cmde.ExecuteNonQuery();
                    } 
                        cn.Close();
              }
                } catch(Exception ex)
                { MessageBox.Show("" + ex.Message);
                }
            

        }
        private void delete_other(string query, string basedonner)
        {
            try
            {
                // delete any table
                #region Espegic delete
                if (basedonner== "e") { 
             if(cn.State== ConnectionState.Broken || cn.State== ConnectionState.Closed ) { 
             
                    cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
               
                }
                   
                }
              #endregion
                #region archivec delete
                else if (basedonner== "a") {
                    
                    if (cn1.State == ConnectionState.Broken || cn1.State == ConnectionState.Closed)
                    {
                        cn1.Open();
                        SqlCommand cmd1 =new SqlCommand(query, cn1);
                        cmd1.ExecuteNonQuery();
                        cn1.Close();
                        
                    }
                    
                }
                #endregion 
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        // insert student
        private void insert_student(string typestageaire)
        {
            #region insert student in archive
            if(cn1.State==ConnectionState.Broken || cn1.State== ConnectionState.Closed)
            {
            cn1=new SqlConnection (arche);
            cn1.Open();
            string query = "insert into [dbo].[Stagaire] select *,CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4)) from [ESPEGIC].[dbo].[Stagaire] st where [Type_stagaire] = '" + typestageaire + "'";
            SqlCommand cmd = new SqlCommand(query, cn1);
            cmd.ExecuteNonQuery();
            cn1.Close();
                
            }
            #endregion
        }
        // insert PFE
        private void insert_PFE(char type)
        {
           if(type == 'i') {
                try { 
            cn1.Open();
            string query3 = " insert into  PFE  SELECT *,CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4)) as years  FROM [ESPEGIC].DBO.PFE  ";
            SqlCommand cmd3 = new SqlCommand(query3, cn1);
            cmd3.ExecuteNonQuery();
           
            cn1.Close();
                }
                catch(Exception ex)

                {
                    MessageBox.Show(""+ex.Message);
                }
        }
            else if (type == 'd')
            {
                cn.Open();
                string query3 = " delete FROM [ESPEGIC].DBO.PFE  ";
                SqlCommand cmd3 = new SqlCommand(query3, cn);
                cmd3.ExecuteNonQuery();
                cn.Close();
                
            }
        }
        //  insert note
        private void insert_note(string typestageaire,char type)
        {
            // i = insert
            if(type == 'i') { 
            cn1.Open();
            string query3 = "insert into  Note SELECT [ID_Note],n.[CIN_Stagaire],m.[ID_Matiére],N.EFCE_thero,N.EFCE_prat,N.Control_C,CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4))  FROM [ESPEGIC].DBO.Matiére  M INNER JOIN [ESPEGIC].DBO.Note N ON N.ID_Matiére=M.ID_Matiére INNER JOIN [ESPEGIC].DBO.Stagaire ST ON ST.CIN_Stagaire = N.CIN_Stagaire WHERE ST.Type_stagaire='" + typestageaire+"' ";
            SqlCommand cmd3 = new SqlCommand(query3, cn1);
            cmd3.ExecuteNonQuery();
            cn1.Close();
            
            }
            // d= delete
            else if (type == 'd')
            {
                cn.Open();
                string query = " DELETE FROM Note WHERE [CIN_Stagaire] IN (SELECT [CIN_Stagaire] FROM [ESPEGIC].DBO.Stagaire st where st.Type_stagaire = '" + typestageaire + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
             
            }
        }
        //paiment
        private void insert_paiment(string typestageaire, char type)
        {
            if (type == 'i') { 
            cn1.Open();
                string query3 = "insert into Paiment select p.CIN_Stagaire,p.Date_de_paiment,p.Monant_par_m,CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4)) from  [ESPEGIC].dbo.Stagaire s inner join [ESPEGIC].dbo.Paiment p on p.CIN_Stagaire = s.CIN_Stagaire where s.Type_stagaire = '" + typestageaire+"'";
            SqlCommand cmd3 = new SqlCommand(query3, cn1);
            cmd3.ExecuteNonQuery();
            cn1.Close();
              
            }
            else if (type == 'd')
            {
                cn.Open();
                string query = "DELETE FROM Paiment WHERE [CIN_Stagaire] IN (SELECT [CIN_Stagaire] FROM [ESPEGIC].DBO.Stagaire st where st.Type_stagaire ='" + typestageaire + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
               
            }

        }
        //absence
        private void insert_absence(string typestageaire, char type)
        {
            if (type == 'i')
            {
                cn1.Open();
            string query3 = " insert into Absence_stagaire select st.[CIN_Stagaire],[Date_abs],[Nombre_h],[ID_Matiére],[Justify],CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4))   from [ESPEGIC].dbo.Stagaire st inner join [ESPEGIC].dbo.Absence_stagaire ab on ab.CIN_Stagaire = st.CIN_Stagaire where st.Type_stagaire = '" + typestageaire + "'";
            SqlCommand cmd3 = new SqlCommand(query3, cn1);
            cmd3.ExecuteNonQuery();
            cn1.Close();
               
            }
            else if (type == 'd')
            {
                cn.Open();
                string query = "DELETE FROM Absence_stagaire WHERE [CIN_Stagaire] IN (SELECT [CIN_Stagaire] FROM [ESPEGIC].DBO.Stagaire st where st.Type_stagaire ='" + typestageaire + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
               
            }
        }
        // inser stage 
        private void insert_stage(string typestageaire, char type)
        {
            if (type == 'i')
            {
                //select s.[CIN_Stagaire],s.[Date_d],s.Date_f,s.Nom_Entr,s.Addrs_Ent,s.Tele,s.FileNameAtes,s.FileNameDs,S.FileDataDs,s.FileDataAtes from ESPEGIC.dbo.Stage s inner join ESPEGIC.dbo.Stagaire st on st.CIN_Stagaire = s.CIN_Stagaire where st.Type_stagaire='"+typestageaire+"'
                cn1.Open();
            string query3 = " insert into Stage select s.ID_Stage,s.CIN_Stagaire,s.Date_d,s.Date_f,s.Nom_Entr,s.Addrs_Ent,s.Tele,s.[FileNameAtes],s.[FileNameDs],s.[FileDataDs],s.[FileDataAtes],CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4))   from ESPEGIC.dbo.Stage s inner join ESPEGIC.dbo.Stagaire st on st.CIN_Stagaire = s.CIN_Stagaire where st.Type_stagaire ='" + typestageaire+"'";
            SqlCommand cmd3 = new SqlCommand(query3, cn1);
            cmd3.ExecuteNonQuery();
            cn1.Close();
               
            }
            else if (type == 'd')
            {
                cn.Open();
                string query = "DELETE FROM Stage WHERE [CIN_Stagaire] IN (SELECT [CIN_Stagaire] FROM [ESPEGIC].DBO.Stagaire st where st.Type_stagaire = '" + typestageaire + "')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
              
            }

        }
        private void update_student(string type,char basedonner)
        {
            if (basedonner == 'e')
            {
                string query = "update Stagaire set Type_stagaire='2émé année' ,[Mont_an]= [Mont_an]+[Mont_total]  where  Type_stagaire='" + type + "'";
                using (cn)
                {
                        cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
               
                    cn.Close();
                }
            }
            else if (basedonner == 'a')
            {
                string query = "UPDATE Archive1.dbo.Stagaire SET  Type_stagaire= '" + type + "',Mont_an=ss.Mont_an,years=CAST(YEAR(GETDATE()) - 1 AS VARCHAR(4)) + '/' + CAST(YEAR(GETDATE()) AS VARCHAR(4)) FROM ESPEGIC.dbo.Stagaire ss WHERE Archive1.dbo.Stagaire.CIN_Stagaire = ss.CIN_Stagaire and ss.Type_stagaire='" + type + "'";
                using (cn1)
                {
                        cn1.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn1))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    cn1.Close();
              
                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checktable(string select1, string select2, string insert,string choise )
        {
            if(choise=="f")
            {
                cn = new SqlConnection(esp);
                cn.Open();
               
                SqlCommand cmd01 = new SqlCommand(select1, cn);
                SqlDataReader dr1 = cmd01.ExecuteReader();
                while (dr1.Read())
                {  
                    cn1.Open();

                    SqlCommand cmd02 = new SqlCommand(select2, cn1);
                    cmd02.Parameters.AddWithValue("@dr1", dr1[1].ToString());
                    SqlDataReader dr2 = cmd02.ExecuteReader();
                    if (dr2.HasRows == false)
                    {
                        dr2.Close();
                       

                        SqlCommand cmd03 = new SqlCommand(insert, cn1);
                        cmd03.Parameters.AddWithValue("@par1", int.Parse(dr1[0].ToString()));
                        cmd03.Parameters.AddWithValue("@par2", dr1[1].ToString());
                        cmd03.Parameters.AddWithValue("@par3", int.Parse(dr1[2].ToString()));
                        cmd03.Parameters.AddWithValue("@par4", dr1[3].ToString());
                        cmd03.Parameters.AddWithValue("@par6",dr1[4].ToString());
                        cmd03.Parameters.AddWithValue("@par5", dat);
                       
                        cmd03.ExecuteNonQuery();
                    }
                    cn1.Close();
                }
                cn.Close();
             
            }
            else if (choise =="m")
            {
                if(cn.State== ConnectionState.Closed || cn.State==ConnectionState.Broken) { 
                  cn=new SqlConnection(esp);
                    cn.Open();
              

                SqlCommand cmd01 = new SqlCommand(select1, cn);
                SqlDataReader dr1 = cmd01.ExecuteReader();

                // Iterate through each row in the first table
                while (dr1.Read())
                {
                        string previousYear = (DateTime.Now.Year - 1).ToString();
                        string currentYear = DateTime.Now.Year.ToString();
                        string result = previousYear + "/" + currentYear;
                        cn1.Open();

                    SqlCommand cmd02 = new SqlCommand(select2, cn1);
                    cmd02.Parameters.AddWithValue("@dr1", dr1[1].ToString());
                    SqlDataReader dr2 = cmd02.ExecuteReader();
                    if (dr2.HasRows == false)
                    {
                        dr2.Close();
                       
                        SqlCommand cmd03 = new SqlCommand(insert, cn1);
                       
                        int? par7Value = (dr1[6] == null && int.TryParse(dr1[6].ToString(), out int parsedValue)) ? parsedValue : (int?)1;

                        cmd03.Parameters.AddWithValue("@par1", int.Parse(dr1[0].ToString()));
                        cmd03.Parameters.AddWithValue("@par2", dr1[1].ToString());
                        cmd03.Parameters.AddWithValue("@par3", int.Parse(dr1[2].ToString()));
                        cmd03.Parameters.AddWithValue("@par4", int.Parse(dr1[3].ToString()));
                        cmd03.Parameters.AddWithValue("@par5", dr1[4].ToString());
                        cmd03.Parameters.AddWithValue("@par6", dr1[5].ToString());
                        cmd03.Parameters.AddWithValue("@par7", par7Value);
                        cmd03.Parameters.AddWithValue("@par8", result);
                        cmd03.ExecuteNonQuery();
                    }
                    cn1.Close();
                }
                    cn.Close();
                }
            }
           
        }
    }
}
