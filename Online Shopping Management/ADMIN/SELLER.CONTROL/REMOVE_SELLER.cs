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
    public partial class REMOVE_SELLER : Form
    {
        public REMOVE_SELLER()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SELLER_CONTROL sc1 = new SELLER_CONTROL();
            sc1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string A_PASS;
            string sid = null;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();


            try
            {
                string q = "select ADMIN_PASSWORD from ADMINTABLE where ADMIN_PASSWORD='" + textBox2.Text + "'";
                string q1 = "select SELLER_ID from SELLERTABLE where SELLER_ID='" + textBox1.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                SqlDataAdapter sd1 = new SqlDataAdapter(q1, con);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                sd.Fill(dt1);
                sd1.Fill(dt2);
                if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                {
                    if (textBox1.Equals(sid))
                    {
                        MessageBox.Show("INVALID USER ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {

                        A_PASS = textBox2.Text;
                        SqlCommand sq3 = new SqlCommand("delete from SELLERTABLE where SELLER_ID='" + textBox1.Text + "'", con);
                        
                        sq3.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("SELLER REMOVED.");
                        textBox1.Clear();
                        textBox2.Clear();

                    }
                }
                else
                {
                    MessageBox.Show("INVALID ADMIN PASSWORD or SELLER ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void REMOVE_SELLER_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select * from SELLERTABLE", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select * from SELLERTABLE", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
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
