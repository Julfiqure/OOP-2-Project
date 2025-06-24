using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Online_Shopping_Management
{
    public partial class USER_RESET_PASSWORD : Form
    {
        private string x;
        public USER_RESET_PASSWORD()
        {
            InitializeComponent();
        }
        public USER_RESET_PASSWORD(string x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            try
            {
                string q = "select USER_PASSWORD from USERTABLE where USER_PASSWORD='" + textBox1.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                DataTable dt1 = new DataTable();
                sd.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        if (textBox2.Text.Length < 8 || !Regex.IsMatch(textBox2.Text, "[A-Z]") || !Regex.IsMatch(textBox2.Text, "[a-z]")
                            || !Regex.IsMatch(textBox2.Text, "[0-9]") || !Regex.IsMatch(textBox2.Text, "[!@#$%^&*(),.?\":{}|<>]"))
                        {
                            MessageBox.Show("Enter a Strong Password");
                            textBox2.Clear();
                            textBox3.Clear();
                        }
                        else
                        {
                            SqlCommand sq1 = new SqlCommand("UPDATE USERTABLE SET USER_PASSWORD='" + textBox2.Text + "'WHERE USER_ID='" + x + "'", con);
                            sq1.ExecuteNonQuery();
                            MessageBox.Show("Successfully Changed Password");
                            ACCOUNT_INFORMATION ai1 = new ACCOUNT_INFORMATION(x);
                            ai1.Show();
                            this.Hide();
                        }
                    }
                    else

                    {
                        MessageBox.Show("New Password Doesn't match");
                    }
                }
                else
                {
                    MessageBox.Show("Enter your valid old password");
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

        private void button3_Click(object sender, EventArgs e)
        {
            ACCOUNT_INFORMATION ai1 = new ACCOUNT_INFORMATION(x);
            ai1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN usi2 = new USER_SIGN_IN();
            usi2.Show();
            this.Hide();
        }

        private void USER_RESET_PASSWORD_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
