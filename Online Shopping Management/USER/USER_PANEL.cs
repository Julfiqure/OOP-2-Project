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
    public partial class USER_PANEL : Form
    {
        private string x;
        public USER_PANEL()
        {
            InitializeComponent();
        }
        public USER_PANEL(string x)
        {
            this.x = x;
            InitializeComponent();
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN us1 = new USER_SIGN_IN();
            us1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ACCOUNT_INFORMATION ai1 = new ACCOUNT_INFORMATION(x);
            ai1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MY_CART mc1 = new MY_CART(x);
            mc1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HELP_SUPPORT hs1 = new HELP_SUPPORT();
            hs1.Show();
            this.Hide();
        }

        private void USER_PANEL_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select PRODUCT_ID,PRODUCT_NAME,PRODUCT_PRICE from PRODUCTTABLE_1", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();
            textBox2.Text = selectedrow.Cells[1].Value.ToString();
            textBox3.Text = selectedrow.Cells[2].Value.ToString();
            textBox6.Text = "1"; 
            string productId = selectedrow.Cells[0].Value.ToString();
            SqlCommand sq5 = new SqlCommand("SELECT PRODUCT_DESCRIPTION FROM PRODUCTTABLE_1 WHERE PRODUCT_ID = @ProductId", con);
            sq5.Parameters.AddWithValue("@ProductId", productId);

            SqlDataReader sdr = sq5.ExecuteReader();
            if (sdr.Read())
            {
                string productDescription = sdr["PRODUCT_DESCRIPTION"].ToString();
                richTextBox1.Text = productDescription;
            }
            else
            {
                richTextBox1.Text = "No description available.";
            }

            con.Close();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int j = Convert.ToInt32(textBox6.Text);
            if (j > 1)
            {
                j--;
                textBox6.Text = Convert.ToString(j);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int j = Convert.ToInt32(textBox6.Text);
            j++;
            textBox6.Text = Convert.ToString(j);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            try
            {
                string q1 = "select PRODUCT_NAME from PRODUCTTABLE_1 where PRODUCT_NAME LIKE'" +"%"+ textBox4.Text+ "%" + "'";
                SqlDataAdapter sd1 = new SqlDataAdapter(q1, con);
                DataTable dt2 = new DataTable();
                sd1.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                        SqlCommand sq4 = new SqlCommand("select PRODUCT_ID,PRODUCT_NAME,PRODUCT_PRICE from PRODUCTTABLE_1 where PRODUCT_NAME LIKE'" + "%" + textBox4.Text + "%" + "'", con);
                        DataTable dt = new DataTable();

                        SqlDataReader sdr = sq4.ExecuteReader();
                        dt.Load(sdr);

                        dataGridView1.DataSource = dt;
                        con.Close();


                        //textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("NO PRODUCT FOUND.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //textBox4.Clear();
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

        private void button15_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select PRODUCT_ID,PRODUCT_NAME,PRODUCT_PRICE from PRODUCTTABLE_1", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
            textBox4.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq2 = new SqlCommand("insert into TEMPORARYORDERTABLE(PRODUCT_ID,PRODUCT_NAME,PRODUCT_QUANTITY,UNIT_PRICE,TOTAL_PRICE,SELLER_ID) values(@PRODUCT_ID,@PRODUCT_NAME,@PRODUCT_QUANTITY,@UNIT_PRICE,@TOTAL_PRICE,@SELLER_ID)", con);

            sq2.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
            sq2.Parameters.AddWithValue("@PRODUCT_NAME", textBox2.Text);
            sq2.Parameters.AddWithValue("@PRODUCT_QUANTITY", textBox6.Text);
            sq2.Parameters.AddWithValue("@UNIT_PRICE", textBox3.Text);
            double j = Convert.ToDouble(textBox6.Text); 
            double k = Convert.ToDouble(textBox3.Text);
            string total = Convert.ToString(j * k); 
            sq2.Parameters.AddWithValue("@TOTAL_PRICE", total);

            SqlCommand sq3 = new SqlCommand("SELECT SELLER_ID FROM PRODUCTTABLE_1 WHERE PRODUCT_ID = '" + textBox1.Text + "'", con);
            
            SqlDataReader reader = sq3.ExecuteReader();
            if(reader.Read())
            {
                string sellerId = reader["SELLER_ID"].ToString();
                sq2.Parameters.AddWithValue("@SELLER_ID", sellerId);
               
            }
            reader.Close();

            sq2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ADDED TO CART."); 
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            MY_ORDERS mo = new MY_ORDERS(x);
            mo.Show();
            this.Hide();
        }
    }
}
