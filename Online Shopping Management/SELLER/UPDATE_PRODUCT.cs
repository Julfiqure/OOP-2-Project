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
    public partial class UPDATE_PRODUCT : Form
    {
        string sellerId;
        public UPDATE_PRODUCT()
        {
            InitializeComponent();
        }
        public UPDATE_PRODUCT(string sellerId)
        {
            this.sellerId = sellerId;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SELLER_PANEL sp = new SELLER_PANEL();
            sp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void UPDATE_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
