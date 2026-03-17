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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string[,] userCredentials =
        {
            {"admin", "hahaha"},
            {"admin", "kayii"},
            {"admin", "wowowow"},
            {"Admin Department", "Staff Deparment"}
        };

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter username");
                tbUsername.Focus();
            }

            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter password");
                tbPassword.Focus();
            }

            else
            {
                for (int x = 0; x < userCredentials.Length; x++)
                {
                    if (userCredentials[0, x] == tbUsername.Text)
                    {
                        if (userCredentials[1, x] == tbPassword.Text)
                        {
                            MessageBox.Show("Welcome " + userCredentials[2, x] + " from " + userCredentials[3, x]);
                            frmHome frm = new frmHome();
                            this.Hide();
                            frm.Show();


                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username/password");
                        break;
                    }
                }
            }
        }
    }
}