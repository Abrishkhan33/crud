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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace crud
{
    public partial class LOGIN : Form
    {

        SqlConnection connectdb = new SqlConnection("Data Source=.;Initial Catalog=crud_desktopapp; User ID =sa; Password = aptech");
        public LOGIN()
        {
            InitializeComponent();

            try
            {
                connectdb.Open();

            }
            catch (Exception errorcatch)
            {
                MessageBox.Show(errorcatch.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 regestrationform = new Form1();
            regestrationform.Show();

            this.Hide();
        }

        private void loginform_Click(object sender, EventArgs e)
        {
            string loginemail = USEREMAIL.Text;
            string loginpassword = USERPASSWORD.Text;


            string queryy = "select * from crudd where useremail = '" + loginemail + "'   and   userpassword = '" + loginpassword + "'";

            SqlCommand dlvryy = new SqlCommand(queryy, connectdb);

            //var returnn = dlvryy.ExecuteNonQuery();

            SqlDataReader readerr = dlvryy.ExecuteReader();
            readerr.Read();


            string name = readerr["username"].ToString();
            string email = readerr["useremail"].ToString();
            string password = readerr["userpassword"].ToString();


            //MessageBox.Show(name , email , password);


            customer_panel panel = new customer_panel(name,email);
            panel.Show();
           this.Close();
           



            var breakpoint = "abrish";

        }
    }
}