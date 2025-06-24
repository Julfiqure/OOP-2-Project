using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Shopping_Management
{
    public partial class SIGN_UP : Form
    {
        public SIGN_UP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli1 = new SELLER_LOG_IN();
            sli1.Show();
            this.Hide();
        }
        public static string y;

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern;
            pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string phone;
            phone = @"^01[0-9]{9}$";
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            SqlCommand sq1 = new SqlCommand("insert into TEMPORARYSELLERTABLE(SELLER_ID,SELLER_NAME,SELLER_SHOP_NAME,SELLER_EMAIL,SELLER_SHOP_ADDRESS,SELLER_GENDER,SELLER_PHONE_NO,TRADE_LICENSE,SELLER_PASSWORD) values(@SELLER_ID,@SELLER_NAME,@SELLER_SHOP_NAME,@SELLER_EMAIL,@SELLER_SHOP_ADDRESS,@SELLER_GENDER,@SELLER_PHONE_NO,@TRADE_LICENSE,@SELLER_PASSWORD)", con);
            try
            {
                if (textBox1.Text.Length == 0 || textBox10.Text.Length == 0 || textBox2.Text.Length == 0)
                {
                    MessageBox.Show("Provide all valid details");
                }

                else if (textBox5.Text == textBox8.Text)
                {
                    if (radioButton1.Checked)
                    {
                        if (textBox5.Text.Length < 8 || !Regex.IsMatch(textBox5.Text, "[A-Z]") || !Regex.IsMatch(textBox5.Text, "[a-z]")
                             || !Regex.IsMatch(textBox5.Text, "[0-9]") || !Regex.IsMatch(textBox5.Text, "[!@#$%^&*(),.?\":{}|<>]"))
                        {
                            if (Regex.IsMatch(textBox3.Text, pattern))
                            {
                                if (Regex.IsMatch(textBox4.Text, phone))
                                {
                                    MessageBox.Show("Provide a strong Password according to the format");
                                    textBox5.Clear();
                                    textBox8.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Phone Number and Password");
                                    textBox5.Clear();
                                    textBox8.Clear();
                                    textBox4.Clear();
                                }
                            }
                            else
                            {
                                if (Regex.IsMatch(textBox4.Text, phone))
                                {
                                    MessageBox.Show("Invalid Email and Password");
                                    textBox5.Clear();
                                    textBox8.Clear();
                                    textBox3.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Email, Phone Number and Password");
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox8.Clear();
                                }
                            }
                        }

                        else
                        {
                            if (Regex.IsMatch(textBox3.Text, pattern))
                            {
                                if (Regex.IsMatch(textBox4.Text, phone))
                                {
                                    y = "S-" + textBox4.Text;
                                    sq1.Parameters.AddWithValue("@SELLER_ID", y);
                                    sq1.Parameters.AddWithValue("@SELLER_NAME", textBox1.Text);
                                    sq1.Parameters.AddWithValue("@SELLER_SHOP_NAME", textBox10.Text);
                                    sq1.Parameters.AddWithValue("@SELLER_EMAIL", textBox3.Text);
                                    sq1.Parameters.AddWithValue("@SELLER_SHOP_ADDRESS", textBox2.Text);
                                    sq1.Parameters.AddWithValue("@TRADE_LICENSE", textBox9.Text);
                                    sq1.Parameters.AddWithValue("@SELLER_PHONE_NO", textBox4.Text);
                                    if (radioButton2 != null)
                                    {
                                        sq1.Parameters.AddWithValue("@SELLER_GENDER", radioButton2.Text);
                                    }
                                    else
                                    {
                                        sq1.Parameters.AddWithValue("@SELLER_GENDER", radioButton3.Text);
                                    }
                                    sq1.Parameters.AddWithValue("@SELLER_PASSWORD", textBox5.Text);

                                    sq1.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("YOU ARE GOOD TO GO!\nYOUR USER ID is: S-" + textBox4.Text + "\nADMIN WILL APPROVE YOU SOON.");

                                    SELLER_LOG_IN sli = new SELLER_LOG_IN();
                                    sli.Show();
                                    this.Hide();

                                }
                                else
                                {
                                    MessageBox.Show("Invalid Phone number");
                                    textBox3.Clear();
                                }
                            }
                            else
                            {
                                if (Regex.IsMatch(textBox4.Text, phone))
                                {
                                    MessageBox.Show("Invalid Email");
                                    textBox3.Clear();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Email and Phone number");
                                    textBox3.Clear();
                                    textBox5.Clear();
                                    textBox8.Clear();
                                }


                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please accept our terms and conditions");
                    }
                }
                else
                {
                    MessageBox.Show("YOUR PASSWORD DOESN'T MATCH.");
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("This Phone No is Already Taken. Enter a new Phone Number.");
                textBox4.Clear();
            }
            finally
            {
                con.Close();
            }
        }

        private void SIGN_UP_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox8.UseSystemPasswordChar = false;
            }
            else
            {
                textBox8.UseSystemPasswordChar = true;
            }
        }
    }
}