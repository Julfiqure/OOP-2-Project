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
    public partial class HELP_SUPPORT : Form
    {
        public HELP_SUPPORT()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            USER_PANEL up1 = new USER_PANEL();
            up1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_SIGN_IN  usi3 = new USER_SIGN_IN ();
            usi3.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HELP_SUPPORT_Load(object sender, EventArgs e)
        {

        }
    }
}
