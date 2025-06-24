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
    public partial class MY_CART : Form
    {
        private string x;
        public MY_CART()
        {
            InitializeComponent();
        }
        public MY_CART(string x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            USER_PANEL up1 = new USER_PANEL();
            up1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN usi2 = new USER_SIGN_IN();
            usi2.Show();
            this.Hide();
        }



        private void MY_CART_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select PRODUCT_ID,PRODUCT_NAME,PRODUCT_QUANTITY,UNIT_PRICE,TOTAL_PRICE from TEMPORARYORDERTABLE", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;

            SqlCommand sq3 = new SqlCommand("SELECT SUM(TOTAL_PRICE) AS TOTAL FROM TEMPORARYORDERTABLE", con);

            SqlDataReader sdr1 = sq3.ExecuteReader();
            
            if (sdr1.Read())
            {
                string totalPrice = sdr1["TOTAL"].ToString();
                textBox4.Text = totalPrice;
            }
            else
            {
                textBox4.Text = "0.";
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            int y = Convert.ToInt32(textBox2.Text); 
                double z = Convert.ToDouble(textBox5.Text);
                double t = y * z;

                SqlCommand sq1 = new SqlCommand("UPDATE TEMPORARYORDERTABLE SET PRODUCT_QUANTITY='" + textBox2.Text + "'WHERE PRODUCT_ID='" + textBox3.Text + "'", con);
                sq1.ExecuteNonQuery();
                SqlCommand sq2 = new SqlCommand("UPDATE TEMPORARYORDERTABLE SET TOTAL_PRICE='" + t + "'WHERE PRODUCT_ID='" + textBox3.Text + "'", con);
                sq2.ExecuteNonQuery();
                SqlCommand sq5 = new SqlCommand("select PRODUCT_ID,PRODUCT_NAME,PRODUCT_QUANTITY,UNIT_PRICE,TOTAL_PRICE from TEMPORARYORDERTABLE", con);
                DataTable dt4 = new DataTable();
            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;

            SqlCommand sq3 = new SqlCommand("SELECT SUM(TOTAL_PRICE) AS TOTAL FROM TEMPORARYORDERTABLE", con);

            SqlDataReader sdr1 = sq3.ExecuteReader();
            if (sdr1.Read())
            {
                string totalPrice = sdr1["TOTAL"].ToString();
                textBox4.Text = totalPrice;
            }
            else
            {
                textBox4.Text = "0.";
            }

            con.Close();
                MessageBox.Show("UPDATED");
            textBox1.Clear();  
            textBox2.Clear();  
            textBox3.Clear();    
            textBox5.Clear();  
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq3 = new SqlCommand("delete from TEMPORARYORDERTABLE where PRODUCT_ID='" + textBox3.Text + "'", con);
            sq3.ExecuteNonQuery();
            MessageBox.Show("REMOVED.");
            MY_CART mca = new MY_CART();
            this.Hide();
            mca.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length==0)
            {
                MessageBox.Show("Select a product");
            }
            else
            {
                int j = Convert.ToInt32(textBox2.Text);
                j++;
                textBox2.Text = Convert.ToString(j);
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int j = Convert.ToInt32(textBox2.Text);
            if (j > 1)
            {
                j--;
                textBox2.Text = Convert.ToString(j);
            }
            else
            {
                MessageBox.Show("Minimum Amount Reached.");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox3.Text = selectedrow.Cells[0].Value.ToString();
            textBox1.Text = selectedrow.Cells[1].Value.ToString();
            textBox2.Text = selectedrow.Cells[2].Value.ToString();
            textBox5.Text = selectedrow.Cells[3].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PAYMENT_METHOD pm = new PAYMENT_METHOD(x);
            pm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
