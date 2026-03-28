using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form6().Show();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form7().Show();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form8().Show();
            this.Show();
        }
    }
}
