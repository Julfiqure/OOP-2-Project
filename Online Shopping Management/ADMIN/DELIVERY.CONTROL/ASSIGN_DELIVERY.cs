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
    public partial class ASSIGN_DELIVERY : Form
    {
        public ASSIGN_DELIVERY()
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

        private void ASSIGN_DELIVERY_Load(object sender, EventArgs e)
        {

        }
    }
}
