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
    public partial class SELLER_REVIEW : Form
    {
        public SELLER_REVIEW()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SELLER_CONTROL sc1 = new SELLER_CONTROL();
            sc1.Show();
            this.Hide();
        }

        private void SELLER_REVIEW_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
