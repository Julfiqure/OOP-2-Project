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
    public partial class REMOVE_USER : Form
    {
        public REMOVE_USER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_CONTROL uc1 = new USER_CONTROL();
            uc1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            string A_PASS;
            string uid = null;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
              

            try
            {
                string q = "select ADMIN_PASSWORD from ADMINTABLE where ADMIN_PASSWORD='" + textBox2.Text + "'";
                string q1 = "select USER_ID from USERTABLE where USER_ID='" + textBox1.Text + "'";
                SqlDataAdapter sd = new SqlDataAdapter(q, con);
                SqlDataAdapter sd1 = new SqlDataAdapter(q1, con);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                sd.Fill(dt1);
                sd1.Fill(dt2);
                if (dt1.Rows.Count > 0 && dt2.Rows.Count>0)
                {
                    if (textBox1.Equals(uid) )
                    {
                        MessageBox.Show("INVALID USER ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    { 

                        A_PASS = textBox2.Text;
                        SqlCommand sq3 = new SqlCommand("delete from USERTABLE where USER_ID=@USER_ID", con);
                        sq3.Parameters.AddWithValue("@USER_ID", (textBox1.Text));

                        sq3.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("USER REMOVED.");
                        textBox1.Clear();
                        textBox2.Clear();

                    }
                }
                else
                {
                    MessageBox.Show("INVALID ADMIN PASSWORD or USER ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = e.RowIndex;
            //DataGridViewRow selectedrow = dataGridView1.Rows[index];
            //textBox1.Text = selectedrow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();
        }
        private void REMOVE_USER_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq4 = new SqlCommand("select * from USERTABLE", con);
            DataTable dt = new DataTable();

            SqlDataReader sdr = sq4.ExecuteReader();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;
            con.Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select * from USERTABLE", con);
            DataTable dt2 = new DataTable();

            SqlDataReader sdr1 = sq5.ExecuteReader();
            dt2.Load(sdr1);

            dataGridView1.DataSource = dt2;
            con.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
