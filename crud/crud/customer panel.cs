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

namespace crud
{
    public partial class customer_panel : Form
    {
        SqlConnection connectdb = new SqlConnection("Data Source=.;Initial Catalog=crud_desktopapp; User ID =sa; Password = aptech");

        string cus_loginname;
        string cus_loginemail;

        public customer_panel(string cus_loginname, string cus_loginemail)
        {
            InitializeComponent();
            this.cus_loginname = cus_loginname;
            this.cus_loginemail = cus_loginemail;

            try
            {
                connectdb.Open();

            }
            catch (Exception errorcatch)
            {
                MessageBox.Show(errorcatch.Message);
            }
        }

        private void customer_panel_Load(object sender, EventArgs e)
        {
            customername.Text = cus_loginname;
            customeremail.Text = cus_loginemail;



            string fetchquery = "select * from crudd ";

            SqlCommand savequery = new SqlCommand(fetchquery , connectdb);


            SqlDataAdapter adapt = new SqlDataAdapter(savequery);

            DataTable table = new DataTable();

            adapt.Fill(table);


            dataGridView1.DataSource = table;




        }
    }
}
