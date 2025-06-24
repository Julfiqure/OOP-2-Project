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
    public partial class DELIVERY_PERSON_PANEL : Form
    {
        public DELIVERY_PERSON_PANEL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PAST_DELIVERY pd1 = new PAST_DELIVERY();
            pd1.Show();
            this.Hide();
        }

        private void DELIVERY_PERSON_PANEL_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Log_IN li1 = new Log_IN();
            li1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            REMAINING_DELIVERY rd1 = new REMAINING_DELIVERY();
            rd1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UPDATE_INFORMATION ui1 = new UPDATE_INFORMATION();
            ui1.Show();
            this.Hide();
        }
    }
}
