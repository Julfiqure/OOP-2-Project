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
    public partial class ACCOUNT_INFORMATION : Form
    {
        private string x;
        public ACCOUNT_INFORMATION()
        {
            InitializeComponent();
        }
        public ACCOUNT_INFORMATION(string x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void ACCOUNT_INFORMATION_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Project\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shahriar Zaman\Desktop\PROJECT\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julfiqure Antor\Desktop\Finally\Online Shopping Management\DATABASE\MASTERDB.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            
            SqlCommand sq5 = new SqlCommand("select * from USERTABLE WHERE USER_ID ='" + x + "'", con);
            DataTable dt4 = new DataTable();

            SqlDataReader sdr = sq5.ExecuteReader();
            dt4.Load(sdr);

            dataGridView1.DataSource = dt4;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            USER_PANEL up1 = new USER_PANEL(x);
            up1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN usi3 = new USER_SIGN_IN();
            usi3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UPDATE_USER_INFORMATION uui = new UPDATE_USER_INFORMATION(x);
            uui.Show();
            this.Hide();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            USER_RESET_PASSWORD urp = new USER_RESET_PASSWORD(x);
            urp.Show();
            this.Hide();
        }
    }
}
