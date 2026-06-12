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
    public partial class Liste_de_prs : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SousiShop;Integrated Security=True;Encrypt=False");
        public Liste_de_prs()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
