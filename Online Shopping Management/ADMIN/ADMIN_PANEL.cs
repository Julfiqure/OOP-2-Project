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
    public partial class ADMIN_PANEL : Form
    {
        public ADMIN_PANEL()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            SELLER_CONTROL sc1 = new SELLER_CONTROL();
            sc1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DELIVERY_CONTROL dc2 = new DELIVERY_CONTROL();
            dc2.Show();
            this.Hide();
        }

        private void ADMIN_PANEL_Load(object sender, EventArgs e)
        {

        }
    }
}
