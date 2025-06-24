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
    public partial class DELIVERY_CONTROL : Form
    {
        public DELIVERY_CONTROL()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ADMIN_PANEL ap1 = new ADMIN_PANEL();
            ap1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ADMIN a2 = new ADMIN();
            a2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD_DELIVERY_PERSON adp1 = new ADD_DELIVERY_PERSON();
            adp1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            REMOVE_DELIVERY_PERSON rdp1 = new REMOVE_DELIVERY_PERSON();
            rdp1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CHECK_DELIVERY_STATUS cds1 = new CHECK_DELIVERY_STATUS();
            cds1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ASSIGN_DELIVERY ad1 = new ASSIGN_DELIVERY();
            ad1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DELIVERY_PERSON_REVIEWS dpr1 = new DELIVERY_PERSON_REVIEWS();
            dpr1.Show();
            this.Hide();
        }

        private void DELIVERY_CONTROL_Load(object sender, EventArgs e)
        {

        }
    }
}
