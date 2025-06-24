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
    public partial class SELLER_PANEL : Form
    {
        string sellerId;
        public SELLER_PANEL()
        {
            InitializeComponent();
        }
        public SELLER_PANEL(string sellerId)
        {
            this.sellerId = sellerId;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD_PRODUCT ap = new ADD_PRODUCT(sellerId);
            ap.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            REMOVE_PRODUCT re = new REMOVE_PRODUCT(sellerId);
            re.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UPDATE_PRODUCT up = new UPDATE_PRODUCT(sellerId);
            up.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UPDATE_INFORMATION_SELLER uis = new UPDATE_INFORMATION_SELLER();
            uis.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SHOW_ALL_PRODUCT sap = new SHOW_ALL_PRODUCT();
            sap.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void SELLER_PANEL_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ORDERS o = new ORDERS(sellerId);
            o.Show();
            this.Hide();
        }
    }
}
