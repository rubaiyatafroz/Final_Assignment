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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Dayerii"].ConnectionString);
            c.Open();
            string q = "Insert Into Events(Name,Date,Pictures,Description,Username)" + "Values('" + textBox1.Text + "','" + date.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox2.Text + "')";
            SqlCommand cm = new SqlCommand(q, c);

            cm.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("Event Added Successfully!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
            
        }
    }
}
