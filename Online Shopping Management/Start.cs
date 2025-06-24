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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADMIN admin1 = new ADMIN();
            admin1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN usi1 = new USER_SIGN_IN();
            usi1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SELLER_LOG_IN sli1 = new SELLER_LOG_IN();
            sli1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log_IN  dL1 = new Log_IN();
            dL1.Show();
            this.Hide();

        }

        private void Start_Load(object sender, EventArgs e)
        {

        }
    }
}
