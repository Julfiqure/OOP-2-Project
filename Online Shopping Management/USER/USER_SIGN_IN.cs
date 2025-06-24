using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Shopping_Management
{
    public partial class USER_SIGN_IN : Form
    {
        public USER_SIGN_IN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string U_ID,U_PASS;
            // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            try
            {
                string q = "select USER_ID from USERTABLE where USER_ID = '" + textBox1.Text + "'and USER_PASSWORD='" + textBox2.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    U_ID = textBox1.Text;   
                    U_PASS = textBox2.Text;
                    USER_PANEL up1 = new USER_PANEL(U_ID);
                    up1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INVALID USER ID or PASSWORD!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();  
                    textBox2.Clear();
                    textBox1.Focus();  
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

        private void button1_Click(object sender, EventArgs e)
        {
            Start s1 = new Start();
            s1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            USER_SIGN_UP usu1 = new USER_SIGN_UP();
            usu1.Show();
            this.Hide();
        }

        private void USER_SIGN_IN_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
