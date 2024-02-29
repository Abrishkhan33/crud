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
    public partial class Form1 : Form


    {

        SqlConnection connectdb = new SqlConnection("Data Source=.;Initial Catalog=crud_desktopapp; User ID =sa; Password = aptech");
        public Form1()
        {

            InitializeComponent();

            try
            {
                connectdb.Open();

                MessageBox.Show("database connected");
            }
            catch (Exception errorcatch)
            {
                MessageBox.Show(errorcatch.Message);
            }

        
    }


        private void label4_Click(object sender, EventArgs e)
        {
            LOGIN loginform = new LOGIN();
            loginform.Show();

            this.Hide();
        }

       
        private void REGISTER_Click(object sender, EventArgs e)
        {
            string enter_username = USERNAME.Text;
            string enter_useremail = USEREMAIL.Text;
            string enter_password = USERPASSWORD.Text;

             


             string insertquery = ("insert into crudd values('"+enter_username+"' , '"+enter_useremail+"' , '"+enter_password+"' ) ");

             SqlCommand dlvryboy = new SqlCommand(insertquery, connectdb);

             dlvryboy.ExecuteNonQuery();

             MessageBox.Show("data inserted!!");



           
            LOGIN loginform = new LOGIN();
            loginform.Show();

            this.Hide();




        }
    }
}
