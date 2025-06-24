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
    public partial class UPDATE_USER_INFORMATION : Form
    {
        private string x;
        public UPDATE_USER_INFORMATION()
        {
            InitializeComponent();
        }
        public UPDATE_USER_INFORMATION(string x)
        {
            this.x = x;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {



            // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();


            try
            {
                int p = 0;
                string q = "select USER_PASSWORD from USERTABLE where USER_PASSWORD='" + textBox4.Text + "'";
               
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
               
                DataTable dt1 = new DataTable();
                
                sd.Fill(dt1);
              
                if (dt1.Rows.Count > 0 )
                {
                    
                    if(textBox1.Text.Length!=0)
                    {
                        SqlCommand sq1 = new SqlCommand("UPDATE USERTABLE SET USER_NAME='" + textBox1.Text + "'WHERE USER_ID='" + x + "'", con);
                        sq1.ExecuteNonQuery();
                        p++;
                    }
                    if(textBox2.Text.Length != 0)
                    {
                        SqlCommand sq2 = new SqlCommand("UPDATE USERTABLE SET USER_ADDRESS='" + textBox2.Text + "'WHERE USER_ID='" + x + "'", con);
                        sq2.ExecuteNonQuery();
                        p++;
                    }
                    if (dateTimePicker1.Value != dateTimePicker1.MaxDate)
                    {
                        SqlCommand sq3 = new SqlCommand("UPDATE USERTABLE SET USER_DOB='" + dateTimePicker1.Text + "'WHERE USER_ID='" + x + "'", con);
                        sq3.ExecuteNonQuery();
                        p++;
                    }
                    if (p==0)
                    {
                        MessageBox.Show("Please provide the information you want to provide");
                    }
                    else
                    {
                        MessageBox.Show("Updated Successfully.");
                        ACCOUNT_INFORMATION ai1 = new ACCOUNT_INFORMATION(x);
                        ai1.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("INVALID ADMIN PASSWORD or USER ID!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void UPDATE_USER_INFORMATION_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN usi2 = new USER_SIGN_IN();
            usi2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ACCOUNT_INFORMATION ai2 = new ACCOUNT_INFORMATION(x);
            ai2.Show();
            this.Hide();
        }
    }
}
