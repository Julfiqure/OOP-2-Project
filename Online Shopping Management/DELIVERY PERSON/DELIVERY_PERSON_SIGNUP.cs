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
    public partial class DELIVERY_PERSON_SIGNUP : Form
    {
        public DELIVERY_PERSON_SIGNUP()
        {
            InitializeComponent();
        }

        private void DELIVERY_PERSON_SIGNUP_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_IN  li1 = new Log_IN ();
            li1.Show();
            this.Hide();
        }
        public static String z;
        private void button2_Click(object sender, EventArgs e)
        {
            string pattern;
            pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string phone;
            phone = @"^01[0-9]{9}$";

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            SqlCommand sq3 = new SqlCommand("insert into TEMPORARYDELIVERYPERSONTABLE(DELEVERY_PERSON_ID,DELIVERY_PERSON_NAME,DELIVERY_PERSON_PHONE_NO,DELIVERY_PERSON_NID,DELIVERY_PERSON_ADDRESS,DELIVERY_PERSON_EMAIL,DELIVERY_PERSON_DOB,DELIVERY_PERSON_GENDER,DELIVERY_PERSON_PASSWORD) values(@DELEVERY_PERSON_ID,@DELIVERY_PERSON_NAME,@DELIVERY_PERSON_PHONE_NO,@DELIVERY_PERSON_NID,@DELIVERY_PERSON_ADDRESS,@DELIVERY_PERSON_EMAIL,@DELIVERY_PERSON_DOB,@DELIVERY_PERSON_GENDER,@DELIVERY_PERSON_PASSWORD)", con);
            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox9.Text.Length == 0)
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
                                    z = "D-" + textBox4.Text;
                                    sq3.Parameters.AddWithValue("@DELEVERY_PERSON_ID", z);
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_NAME", textBox1.Text);
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_PHONE_NO", textBox4.Text);
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_NID", textBox9.Text);
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_ADDRESS", textBox2.Text);
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_EMAIL", textBox3.Text);
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_DOB", dateTimePicker2.Text);
                                    if (radioButton2 != null)
                                    {
                                        sq3.Parameters.AddWithValue("@DELIVERY_PERSON_GENDER", radioButton2.Text);
                                    }
                                    else
                                    {
                                        sq3.Parameters.AddWithValue("@DELIVERY_PERSON_GENDER", radioButton3.Text);
                                    }
                                    sq3.Parameters.AddWithValue("@DELIVERY_PERSON_PASSWORD", textBox5.Text);

                                    sq3.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("YOU ARE GOOD TO GO!\nYOUR USER ID is: D-" + textBox4.Text + "\nYOU CAN SIGN IN.");

                                    Log_IN di = new Log_IN();
                                    di.Show();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox5.UseSystemPasswordChar = false;
                textBox8.UseSystemPasswordChar = false;
            }
            else
            {
                textBox5.UseSystemPasswordChar = true;
                textBox8.UseSystemPasswordChar = true;
            }
        }
    }
}
