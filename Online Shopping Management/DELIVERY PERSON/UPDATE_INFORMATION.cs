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
    public partial class UPDATE_INFORMATION : Form
    {
        public UPDATE_INFORMATION()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DELIVERY_PERSON_PANEL dpp3 = new DELIVERY_PERSON_PANEL();
            dpp3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log_IN li4 = new Log_IN();
            li4.Show();
            this.Hide();
        }

        private void UPDATE_INFORMATION_Load(object sender, EventArgs e)
        {

        }
    }
}
