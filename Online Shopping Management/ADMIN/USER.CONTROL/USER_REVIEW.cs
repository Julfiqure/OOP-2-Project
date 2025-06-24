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
    public partial class USER_REVIEW : Form
    {
        public USER_REVIEW()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_CONTROL uc1 = new USER_CONTROL();
            uc1.Show();
            this.Hide();
        }

        private void USER_REVIEW_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select USER_REVIEW from USERTABLE", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string uid = null;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();


            try
            {
                string q1 = "select USER_ID from USERTABLE where USER_ID='" + textBox1.Text + "'";
                SqlDataAdapter sd1 = new SqlDataAdapter(q1, con);
                DataTable dt2 = new DataTable();
                sd1.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    if (textBox1.Equals(uid))
                    {
                        MessageBox.Show("INVALID USER ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                    }
                    else
                    {
                        SqlCommand sq4 = new SqlCommand("select USER_REVIEW from USERTABLE where USER_ID='" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();

                        SqlDataReader sdr = sq4.ExecuteReader();
                        dt.Load(sdr);

                        dataGridView1.DataSource = dt;
                        con.Close();


                        textBox1.Clear();


                    }
                }
                else
                {
                    MessageBox.Show("INVALID USER ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
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
        }
    }
}
