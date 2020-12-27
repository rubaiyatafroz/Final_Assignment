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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["Dayerii"].ConnectionString);
            cone.Open();
            string q = "Delete  from Events where Name='" + textBox1.Text + "' ";
            SqlCommand command = new SqlCommand(q, cone);
            command.ExecuteNonQuery();
            cone.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Dayerii"].ConnectionString);
            c.Open();
            string que = "Update dbo.Events set " + textBox2.Text + " ='" + textBox3.Text + "' where Username = '" + textBox4.Text + "' ";



            SqlCommand command = new SqlCommand(que, c);
            command.ExecuteNonQuery();
            c.Close();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Dayerii"].ConnectionString);
            c.Open();
            

            string query = "Select * from Events where Username='" + textBox5.Text + "'";
            SqlCommand command = new SqlCommand(query, c);
            SqlDataReader reader = command.ExecuteReader();
            List<Class1> list = new List<Class1>();
            while (reader.Read())
            {
                Class1 cw = new Class1();
                cw.Name = reader["Name"].ToString();
                cw.Date = reader["Date"].ToString();

                cw.Pictures = reader["Pictures"].ToString();
                cw.Description = reader["Description"].ToString();
                cw.Username = reader["Username"].ToString();

                list.Add(cw);
            }
            c.Close();
            dataGridView1.DataSource = list;
            reader.Close();
        }
    }
}
