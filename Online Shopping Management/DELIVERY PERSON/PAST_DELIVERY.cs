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
    public partial class PAST_DELIVERY : Form
    {
        public PAST_DELIVERY()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log_IN li2 = new Log_IN();
            li2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DELIVERY_PERSON_PANEL dpp1 = new DELIVERY_PERSON_PANEL();
            dpp1.Show();
            this.Hide();
        }

        private void PAST_DELIVERY_Load(object sender, EventArgs e)
        {

        }
    }
}
