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
    public partial class SELLER_LOG_IN : Form
    {
        public SELLER_LOG_IN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string S_ID, S_PASS;
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            try
            {
                string q = "select SELLER_ID from SELLERTABLE where SELLER_ID = '" + textBox1.Text + "'and SELLER_PASSWORD='" + textBox2.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    S_ID = textBox1.Text;
                    S_PASS = textBox2.Text;
                    SELLER_PANEL sp = new SELLER_PANEL(textBox1.Text);
                    sp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INVALID SELLER ID or PASSWORD!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
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
            SIGN_UP su = new SIGN_UP();
            su.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void SELLER_LOG_IN_Load(object sender, EventArgs e)
        {

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
