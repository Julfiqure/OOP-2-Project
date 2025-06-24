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
    public partial class DELIVERY_PERSON_REVIEWS : Form
    {
        public DELIVERY_PERSON_REVIEWS()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DELIVERY_CONTROL dc1 = new DELIVERY_CONTROL();
            dc1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void DELIVERY_PERSON_REVIEWS_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            SqlCommand sq5 = new SqlCommand("select DELIVERY_PERSON_REVIEW from DELIVERYPERSONTABLE", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string did = null;

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\A - 5_Online Shopping Management\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();


            try
            {
                string q1 = "select DELIVERY_PERSON_ID from DELIVERYPERSONTABLE where DELIVERY_PERSON_ID='" + textBox1.Text + "'";
                SqlDataAdapter sd1 = new SqlDataAdapter(q1, con);
                DataTable dt2 = new DataTable();
                sd1.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    if (textBox1.Equals(did))
                    {
                        MessageBox.Show("INVALID DELIVERY PERSON ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                    }
                    else
                    {
                        SqlCommand sq4 = new SqlCommand("select DELIVERY_PERSON_REVIEWS from DELIVERYPERSONTABLE where DELIVERY_PERSON_ID='" + textBox1.Text + "'", con);
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
                    MessageBox.Show("INVALID DELIVERY PERSON ID.!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
