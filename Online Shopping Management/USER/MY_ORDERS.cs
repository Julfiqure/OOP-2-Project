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
    public partial class MY_ORDERS : Form
    {
        public string x;
        public MY_ORDERS()
        {
            InitializeComponent();
        }
        public MY_ORDERS(string x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void MY_ORDERS_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select ORDER_ID,ORDER_PRODUCT_NAME,ORDER_QUANTITY,ORDER_UNIT_PRICE,ORDER_TOTAL_PRICE,ORDER_BILLING_ADDRESS,ORDER_DATE,ORDER_EXPECTED_DELIVERY_DATE,ORDER_STATUS,ORDER_PAYMENT,ORDER_PRODUCT_ID from ORDERTABLE WHERE USER_ID = '" + x + "'", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_PANEL up1 = new USER_PANEL();
            up1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN us1 = new USER_SIGN_IN();
            us1.Show();
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
    }
}
