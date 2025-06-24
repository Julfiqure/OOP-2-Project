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
    public partial class SELLER_CONTROL : Form
    {
        public SELLER_CONTROL()
        {
            InitializeComponent();
        }

        private void SELLER_CONTROL_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            APPROVE_PRODUCT ap1 = new APPROVE_PRODUCT();
            ap1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ADMIN_PANEL ap1 = new ADMIN_PANEL();
            ap1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD_SELLER as1 = new ADD_SELLER();
            as1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            REMOVE_SELLER rs1 = new REMOVE_SELLER();
            rs1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CHECK_STATUS cs1 = new CHECK_STATUS();
            cs1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SELLER_REVIEW sr1 = new SELLER_REVIEW();
            sr1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SELLER_SHOP_ORDER sso = new SELLER_SHOP_ORDER();
            sso.Show();
            this.Hide();
        }
    }
}
