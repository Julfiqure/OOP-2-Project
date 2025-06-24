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
    public partial class ORDERS : Form
    {
        public string sellerId;
        public ORDERS()
        {
            InitializeComponent();
        }
        public ORDERS(string sellerId)
        {
            this.sellerId = sellerId;
            InitializeComponent();
        }
        private void ORDERS_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select ORDER_ID,ORDER_PRODUCT_NAME,ORDER_QUANTITY,ORDER_UNIT_PRICE,ORDER_TOTAL_PRICE,ORDER_BILLING_ADDRESS,ORDER_DATE,ORDER_EXPECTED_DELIVERY_DATE,ORDER_STATUS,ORDER_PAYMENT,ORDER_PRODUCT_ID,UT.USER_NAME FROM ORDERTABLE OT JOIN USERTABLE UT ON OT.USER_ID = UT.USER_ID WHERE OT.SELLER_ID ='" + sellerId + "'", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SELLER_PANEL sp = new SELLER_PANEL();
            sp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
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
            textBox3.Text = selectedrow.Cells[4].Value.ToString();
            textBox4.Text = selectedrow.Cells[8].Value.ToString();

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            try
            {
                if(textBox4.Text== "Sent for Delivery")
                {
                    MessageBox.Show("Already sent for delivery!");
                }
                else
                {
                    SqlCommand sq = new SqlCommand("UPDATE ORDERTABLE SET ORDER_STATUS = @ORDER_STATUS WHERE ORDER_ID = '" + textBox1.Text + "'", con);
                    sq.Parameters.AddWithValue("@ORDER_STATUS", "Sent for Delivery");
                    sq.ExecuteNonQuery();

                    MessageBox.Show("Order sent for delivery!");
                }

            }
            catch
            {
                MessageBox.Show("SELECT AN ORDER!");
            }
            finally
            {
                SqlCommand sq5 = new SqlCommand("select ORDER_ID,ORDER_PRODUCT_NAME,ORDER_QUANTITY,ORDER_UNIT_PRICE,ORDER_TOTAL_PRICE,ORDER_BILLING_ADDRESS,ORDER_DATE,ORDER_EXPECTED_DELIVERY_DATE,ORDER_STATUS,ORDER_PAYMENT,ORDER_PRODUCT_ID,UT.USER_NAME FROM ORDERTABLE OT JOIN USERTABLE UT ON OT.USER_ID = UT.USER_ID WHERE OT.SELLER_ID ='" + sellerId + "'", con);
                DataTable dt4 = new DataTable();

                SqlDataReader sdr = sq5.ExecuteReader();
                dt4.Load(sdr);

                dataGridView1.DataSource = dt4;
                con.Close();
            }
            

        }
    }
}
