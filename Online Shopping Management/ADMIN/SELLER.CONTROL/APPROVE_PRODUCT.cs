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
    public partial class APPROVE_PRODUCT : Form
    {
        public APPROVE_PRODUCT()
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

        private void APPROVE_PRODUCT_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select * from TEMPORARYPRODUCTTABLE", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();


            
            string pid = null;

            


            try
            {
                string q = "select ADMIN_PASSWORD from ADMINTABLE where ADMIN_PASSWORD='" + textBox3.Text + "'";
                string q1 = "select PRODUCT_ID from TEMPORARYPRODUCTTABLE where PRODUCT_ID='" + textBox1.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                SqlDataAdapter sd1 = new SqlDataAdapter(q1, con);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                sd.Fill(dt1);
                sd1.Fill(dt2);
                if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                {
                    if (textBox1.Equals(pid))
                    {
                        MessageBox.Show("INVALID PRODUCT ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox3.Clear();
                    }
                    else
                    {

                        
                        SqlCommand sq2 = new SqlCommand("INSERT INTO PRODUCTTABLE_1 SELECT * FROM TEMPORARYPRODUCTTABLE where PRODUCT_ID='" + textBox1.Text + "'", con);
                        sq2.ExecuteNonQuery();
                        SqlCommand sq3 = new SqlCommand("delete from TEMPORARYPRODUCTTABLE where PRODUCT_ID='" + textBox1.Text + "'", con);
                        sq3.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("PRODUCT ADDED.");
                        textBox1.Clear();
                        textBox3.Clear();

                    }
                }
                else
                {
                    MessageBox.Show("INVALID ADMIN PASSWORD or PRODUCT ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox3.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select * from TEMPORARYPRODUCTTABLE", con);
            DataTable dt2 = new DataTable();

            SqlDataReader sdr1 = sq5.ExecuteReader();
            dt2.Load(sdr1);

            dataGridView1.DataSource = dt2;
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
