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
    public partial class CARD_PAYMENT : Form
    {
        public CARD_PAYMENT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PAYMENT_METHOD pm = new PAYMENT_METHOD();
            pm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOUR ORDER IS PLACED SUCCESSFULLY!\nCHECK YOUR ORDER INVOICE IN 'MY ORDERS'");
            USER_PANEL up = new USER_PANEL();
            up.Show();
            this.Hide();
        }

        private void CARD_PAYMENT_Load(object sender, EventArgs e)
        {

        }
    }
}
