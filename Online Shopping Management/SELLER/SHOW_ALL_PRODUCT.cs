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
    public partial class SHOW_ALL_PRODUCT : Form
    {
        public SHOW_ALL_PRODUCT()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SELLER_PANEL sp = new SELLER_PANEL();
            sp.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli = new SELLER_LOG_IN();
            sli.Show();
            this.Hide();
        }

        private void SHOW_ALL_PRODUCT_Load(object sender, EventArgs e)
        {

        }
    }
}
