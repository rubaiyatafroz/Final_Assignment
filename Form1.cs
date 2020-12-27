
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AssignmentDefinitiveEdition
{

    public partial class Form1 : Form
    {
        
       
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
          
        }
      

        private void button1_Click(object sender, EventArgs e)//create
        {
            {
                
                Class1 cls = new Class1();
              
                {
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Dayerii"].ConnectionString);
                    connection.Open();
                    string query = "Select * from Userdata where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();


                    if (!reader.HasRows)
                    {

                        MessageBox.Show("Wrong Username or password");
                    }
                    else
                    {


                        textBox1.Text = null;
                        textBox2.Text = null;

                        Form2 f = new Form2();
                        f.Show();
                        this.Hide();
                        
                        reader.Close();
                        connection.Close();

                    }
                }

             


            }

        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
    }
}
