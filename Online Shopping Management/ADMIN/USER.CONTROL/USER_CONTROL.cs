using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Shopping_Management
{
    public partial class USER_CONTROL : Form
    {
        public USER_CONTROL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CHECK_USER_STATUS cus1 = new CHECK_USER_STATUS();
            cus1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ADMIN_PANEL ap1 = new ADMIN_PANEL();
            ap1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            REMOVE_USER ru1 = new REMOVE_USER();
            ru1.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            USER_DETAILS ud1 = new USER_DETAILS();
            ud1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            USER_REVIEW ur1 = new USER_REVIEW();
            ur1.Show();
            this.Hide();
        }

        private void USER_CONTROL_Load(object sender, EventArgs e)
        {

        }
    }
}
