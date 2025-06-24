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
    public partial class PAYMENT_METHOD : Form
    {
        
        public string z;
        public PAYMENT_METHOD()
        {
            InitializeComponent();
        }
        public PAYMENT_METHOD(string p)
        {
            z = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MY_CART mc = new MY_CART();
            mc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int Id = random.Next(400,99999999);
            if (radioButton1.Checked)
            {
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand a = new SqlCommand("SELECT COUNT(seller_count) AS total_sellers FROM (SELECT COUNT(SELLER_ID) AS seller_count FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID) AS subquery", con);
                int rowCount = (int)a.ExecuteScalar();

                if(rowCount>=1)
                {
                    
                    for (int x=0; x<rowCount; x++)
                    {
                        string time = DateTime.Now.ToString();
                        string expectedDelivery = "4-7 working days";
                        string status = "Pending";
                        string payment = "Cash on Delivery";
                        string orderId = "O-" + (Id++.ToString());

                        SqlCommand sq = new SqlCommand("insert into ORDERTABLE(ORDER_ID,ORDER_PRODUCT_NAME,ORDER_QUANTITY,ORDER_UNIT_PRICE,ORDER_TOTAL_PRICE,ORDER_BILLING_ADDRESS,ORDER_DATE,ORDER_EXPECTED_DELIVERY_DATE,ORDER_STATUS,ORDER_PAYMENT,SELLER_ID,ORDER_PRODUCT_ID,USER_ID) values(@ORDER_ID,@ORDER_PRODUCT_NAME,@ORDER_QUANTITY,@ORDER_UNIT_PRICE,@ORDER_TOTAL_PRICE,@ORDER_BILLING_ADDRESS,@ORDER_DATE,@ORDER_EXPECTED_DELIVERY_DATE,@ORDER_STATUS,@ORDER_PAYMENT,@SELLER_ID,@ORDER_PRODUCT_ID,@USER_ID)", con);
                        SqlCommand sq1 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + PRODUCT_ID FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('') ), 1, 2, '') AS Product_ID FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq2 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + PRODUCT_NAME FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('') ), 1, 2, '') AS Product_NAMES FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq3 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + CAST(PRODUCT_QUANTITY AS VARCHAR(MAX)) FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('')), 1, 2, '') AS Product_QUANTITIES FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq4 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + CAST(UNIT_PRICE AS VARCHAR(MAX)) FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('') ), 1, 2, '') AS UNIT_PRICES FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq5 = new SqlCommand("SELECT TOP 1 CAST(SUM(TOTAL_PRICE) AS VARCHAR(MAX)) AS TOTAL_PRICE FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID", con);
                        SqlCommand sq6 = new SqlCommand("SELECT USER_ADDRESS FROM USERTABLE WHERE USER_ID ='" + z + "'", con);
                        SqlCommand sq7 = new SqlCommand("SELECT TOP 1 SELLER_ID FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID", con);


                        sq.Parameters.AddWithValue("@ORDER_ID", orderId);
                        SqlDataReader reader1 = sq2.ExecuteReader();
                        if (reader1.Read())
                        {
                            string productName = reader1["Product_NAMES"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_PRODUCT_NAME", productName);

                        }
                        reader1.Close();
                        SqlDataReader reader2 = sq3.ExecuteReader();
                        if (reader2.Read())
                        {
                            string productQuantity = reader2["Product_QUANTITIES"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_QUANTITY", productQuantity);

                        }
                        reader2.Close();
                        SqlDataReader reader3 = sq4.ExecuteReader();
                        if (reader3.Read())
                        {
                            string unitPrice = reader3["UNIT_PRICES"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_UNIT_PRICE", unitPrice);

                        }
                        reader3.Close();
                        SqlDataReader reader4 = sq5.ExecuteReader();
                        if (reader4.Read())
                        {
                            string productPrice = reader4["TOTAL_PRICE"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_TOTAL_PRICE", productPrice);
                        }
                        reader4.Close();
                        SqlDataReader reader5 = sq6.ExecuteReader();
                        if (reader5.Read())
                        {
                            // string userAddress = reader5["USER_ADDRESS"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_BILLING_ADDRESS", reader5["USER_ADDRESS"].ToString());
                        }
                        reader5.Close();
                        sq.Parameters.AddWithValue("@ORDER_DATE", time);
                        sq.Parameters.AddWithValue("@ORDER_EXPECTED_DELIVERY_DATE", expectedDelivery);
                        sq.Parameters.AddWithValue("@ORDER_STATUS", status);
                        sq.Parameters.AddWithValue("@ORDER_PAYMENT", payment);
                        SqlDataReader reader6 = sq7.ExecuteReader();
                        if (reader6.Read())
                        {
                            string productPrice1 = reader6["SELLER_ID"].ToString();
                            sq.Parameters.AddWithValue("@SELLER_ID", productPrice1);

                        }
                        reader6.Close();
                        SqlDataReader reader = sq1.ExecuteReader();
                        if (reader.Read())
                        {
                            string productId = reader["Product_ID"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_PRODUCT_ID", productId);

                        }
                        reader.Close();

                        sq.Parameters.AddWithValue("@USER_ID", z);

                        sq.ExecuteNonQuery();

                        SqlCommand sq8 = new SqlCommand("DELETE FROM TEMPORARYORDERTABLE WHERE SELLER_ID = (SELECT TOP 1 SELLER_ID FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID)", con);
                        sq8.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("YOUR ORDER IS PLACED SUCCESSFULLY!\nCHECK YOUR ORDER INVOICE IN 'MY ORDERS'");
                USER_PANEL up = new USER_PANEL();
                up.Show();
                this.Hide();

            }
            if (radioButton2.Checked)
            {
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

                con.Open();

                SqlCommand a = new SqlCommand("SELECT COUNT(seller_count) AS total_sellers FROM (SELECT COUNT(SELLER_ID) AS seller_count FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID) AS subquery", con);
                int rowCount = (int)a.ExecuteScalar();

                if (rowCount >= 1)
                {

                    for (int x = 0; x < rowCount; x++)
                    {
                        string time = DateTime.Now.ToString();
                        string expectedDelivery = "4-7 working days";
                        string status = "Pending";
                        string payment = "CARD PAYMENT";
                        string orderId = "O-" + (Id++.ToString());

                        SqlCommand sq = new SqlCommand("insert into ORDERTABLE(ORDER_ID,ORDER_PRODUCT_NAME,ORDER_QUANTITY,ORDER_UNIT_PRICE,ORDER_TOTAL_PRICE,ORDER_BILLING_ADDRESS,ORDER_DATE,ORDER_EXPECTED_DELIVERY_DATE,ORDER_STATUS,ORDER_PAYMENT,SELLER_ID,ORDER_PRODUCT_ID,USER_ID) values(@ORDER_ID,@ORDER_PRODUCT_NAME,@ORDER_QUANTITY,@ORDER_UNIT_PRICE,@ORDER_TOTAL_PRICE,@ORDER_BILLING_ADDRESS,@ORDER_DATE,@ORDER_EXPECTED_DELIVERY_DATE,@ORDER_STATUS,@ORDER_PAYMENT,@SELLER_ID,@ORDER_PRODUCT_ID,@USER_ID)", con);
                        SqlCommand sq1 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + PRODUCT_ID FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('') ), 1, 2, '') AS Product_ID FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq2 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + PRODUCT_NAME FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('') ), 1, 2, '') AS Product_NAMES FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq3 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + CAST(PRODUCT_QUANTITY AS VARCHAR(MAX)) FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('')), 1, 2, '') AS Product_QUANTITIES FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq4 = new SqlCommand("SELECT TOP 1 STUFF((SELECT ', ' + CAST(UNIT_PRICE AS VARCHAR(MAX)) FROM TEMPORARYORDERTABLE AS t2 WHERE t1.SELLER_ID = t2.SELLER_ID FOR XML PATH('') ), 1, 2, '') AS UNIT_PRICES FROM TEMPORARYORDERTABLE AS t1 GROUP BY SELLER_ID", con);
                        SqlCommand sq5 = new SqlCommand("SELECT TOP 1 CAST(SUM(TOTAL_PRICE) AS VARCHAR(MAX)) AS TOTAL_PRICE FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID", con);
                        SqlCommand sq6 = new SqlCommand("SELECT USER_ADDRESS FROM USERTABLE WHERE USER_ID ='" + z + "'", con);
                        SqlCommand sq7 = new SqlCommand("SELECT TOP 1 SELLER_ID FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID", con);


                        sq.Parameters.AddWithValue("@ORDER_ID", orderId);
                        SqlDataReader reader1 = sq2.ExecuteReader();
                        if (reader1.Read())
                        {
                            string productName = reader1["Product_NAMES"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_PRODUCT_NAME", productName);

                        }
                        reader1.Close();
                        SqlDataReader reader2 = sq3.ExecuteReader();
                        if (reader2.Read())
                        {
                            string productQuantity = reader2["Product_QUANTITIES"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_QUANTITY", productQuantity);

                        }
                        reader2.Close();
                        SqlDataReader reader3 = sq4.ExecuteReader();
                        if (reader3.Read())
                        {
                            string unitPrice = reader3["UNIT_PRICES"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_UNIT_PRICE", unitPrice);

                        }
                        reader3.Close();
                        SqlDataReader reader4 = sq5.ExecuteReader();
                        if (reader4.Read())
                        {
                            string productPrice = reader4["TOTAL_PRICE"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_TOTAL_PRICE", productPrice);
                        }
                        reader4.Close();
                        SqlDataReader reader5 = sq6.ExecuteReader();
                        if (reader5.Read())
                        {
                            // string userAddress = reader5["USER_ADDRESS"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_BILLING_ADDRESS", reader5["USER_ADDRESS"].ToString());
                        }
                        reader5.Close();
                        sq.Parameters.AddWithValue("@ORDER_DATE", time);
                        sq.Parameters.AddWithValue("@ORDER_EXPECTED_DELIVERY_DATE", expectedDelivery);
                        sq.Parameters.AddWithValue("@ORDER_STATUS", status);
                        sq.Parameters.AddWithValue("@ORDER_PAYMENT", payment);
                        SqlDataReader reader6 = sq7.ExecuteReader();
                        if (reader6.Read())
                        {
                            string productPrice1 = reader6["SELLER_ID"].ToString();
                            sq.Parameters.AddWithValue("@SELLER_ID", productPrice1);

                        }
                        reader6.Close();
                        SqlDataReader reader = sq1.ExecuteReader();
                        if (reader.Read())
                        {
                            string productId = reader["Product_ID"].ToString();
                            sq.Parameters.AddWithValue("@ORDER_PRODUCT_ID", productId);

                        }
                        reader.Close();

                        sq.Parameters.AddWithValue("@USER_ID", z);

                        sq.ExecuteNonQuery();

                        SqlCommand sq8 = new SqlCommand("DELETE FROM TEMPORARYORDERTABLE WHERE SELLER_ID = (SELECT TOP 1 SELLER_ID FROM TEMPORARYORDERTABLE GROUP BY SELLER_ID)", con);
                        sq8.ExecuteNonQuery();
                    }

                }
                
                CARD_PAYMENT cp = new CARD_PAYMENT();
                cp.Show();
                this.Hide();
            }
        }

        private void PAYMENT_METHOD_Load(object sender, EventArgs e)
        {

        }
    }
}
