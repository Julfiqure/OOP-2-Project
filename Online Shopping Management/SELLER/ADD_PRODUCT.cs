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
    public partial class ADD_PRODUCT : Form
    {
        string sellerId;
        public ADD_PRODUCT()
        {
            InitializeComponent();
        }
        public ADD_PRODUCT(string sellerId)
        {
            this.sellerId = sellerId;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SELLER_PANEL sp = new SELLER_PANEL();
            sp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            SqlCommand sq1 = new SqlCommand("insert into TEMPORARYPRODUCTTABLE(PRODUCT_ID,PRODUCT_NAME,PRODUCT_CATEGORY,PRODUCT_PRICE,PRODUCT_DESCRIPTION,PRODUCT_STOCK,SELLER_ID) values(@PRODUCT_ID,@PRODUCT_NAME,@PRODUCT_CATEGORY,@PRODUCT_PRICE,@PRODUCT_DESCRIPTION,@PRODUCT_STOCK,@SELLER_ID)", con);

            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || richTextBox1.Text.Length == 0)
                {
                    MessageBox.Show("Provide all valid details.");
                }
                if(radioButton1.Checked)
                {
                    sq1.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_NAME", textBox3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_CATEGORY", radioButton1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_PRICE", textBox2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_STOCK", textBox4.Text);
                    sq1.Parameters.AddWithValue("@SELLER_ID", sellerId);

                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PRODUCT ADDED.\nADMIN WILL APPROVE YOUR PRODUCT SOON.");
                }
               else if (radioButton2.Checked)
                {
                    sq1.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_NAME", textBox3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_CATEGORY", radioButton2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_PRICE", textBox2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_STOCK", textBox4.Text);
                    sq1.Parameters.AddWithValue("@SELLER_ID", sellerId);

                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PRODUCT ADDED.\nADMIN WILL APPROVE YOUR PRODUCT SOON.");
                }
                else if (radioButton3.Checked)
                {
                    sq1.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_NAME", textBox3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_CATEGORY", radioButton3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_PRICE", textBox2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_STOCK", textBox4.Text);
                    sq1.Parameters.AddWithValue("@SELLER_ID", sellerId);

                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PRODUCT ADDED.\nADMIN WILL APPROVE YOUR PRODUCT SOON.");
                }
                else if (radioButton4.Checked)
                {
                    sq1.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_NAME", textBox3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_CATEGORY", radioButton4.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_PRICE", textBox2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_STOCK", textBox4.Text);
                    sq1.Parameters.AddWithValue("@SELLER_ID", sellerId);

                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PRODUCT ADDED.\nADMIN WILL APPROVE YOUR PRODUCT SOON.");
                }
                else if (radioButton5.Checked)
                {
                    sq1.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_NAME", textBox3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_CATEGORY", radioButton5.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_PRICE", textBox2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_STOCK", textBox4.Text);
                    sq1.Parameters.AddWithValue("@SELLER_ID", sellerId);

                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PRODUCT ADDED.\nADMIN WILL APPROVE YOUR PRODUCT SOON.");
                }
                
                else
                {
                    sq1.Parameters.AddWithValue("@PRODUCT_ID", textBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_NAME", textBox3.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_CATEGORY", radioButton6.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_PRICE", textBox2.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@PRODUCT_STOCK", textBox4.Text);
                    sq1.Parameters.AddWithValue("@SELLER_ID", sellerId);

                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PRODUCT ADDED.\nADMIN WILL APPROVE YOUR PRODUCT SOON.");
                }



            }
            catch
            {
                MessageBox.Show("INVALID DATA.");
            }
            finally
            {
                con.Close();
            }
            }

        private void ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }
    }
}
