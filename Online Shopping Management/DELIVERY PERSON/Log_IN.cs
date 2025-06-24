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

namespace Online_Shopping_Management
{
    public partial class Log_IN : Form
    {
        public Log_IN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Log_IN_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string D_ID, D_PASS;
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            try
            {
                string q = "select DELEVERY_PERSON_ID from DELIVERYPERSONTABLE where DELEVERY_PERSON_ID = '" + textBox1.Text + "'and DELIVERY_PERSON_PASSWORD='" + textBox2.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    D_ID = textBox1.Text;
                    D_PASS = textBox2.Text;
                    DELIVERY_PERSON_PANEL up1 = new DELIVERY_PERSON_PANEL();
                    up1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INVALID DELIVERY PERSON ID or PASSWORD!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    //textBox1.Focus();
                }

            }
            catch
            {
                MessageBox.Show("ERROR!!\nINVALID INPUT!!");
            }
            finally
            {
                con.Close();
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DELIVERY_PERSON_SIGNUP dps1 = new DELIVERY_PERSON_SIGNUP();
            dps1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start s1 = new Start();
            s1.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
