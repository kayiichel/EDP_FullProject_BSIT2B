using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp3
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        MyDatabase db = new MyDatabase();

        private void Form7_Load(object sender, EventArgs e)

        {
            this.Refresh();
            string query = "SELECT tbluserinformation.userID, tbllogincredentials.LoginID, tbluserinformation.firstname, tbluserinformation.middlename, tbluserinformation.lastname, tbluserinformation.emailAddress, tbluserinformation.homeAddress, tbluserinformation.birthDate, tbllogincredentials.user_username as 'Username', tbllogincredentials.user_password as 'Password' FROM tbllogincredentials INNER JOIN tbluserinformation ON tbllogincredentials.userID = tbluserinformation.userID;";

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.DataSource = db.ExecuteReturnQuery(query);
            dgvUsers.Columns[0].Visible = false;
            dgvUsers.Columns[1].Visible = false;
            if (dgvUsers.Columns.Count > 8)
            {
                foreach (DataGridViewRow row in dgvUsers.Rows)
                {
                    if (row.Cells[8].Value != null)
                    {
                        row.Cells[8].Value = new string('*', row.Cells[8].Value.ToString().Length);
                    }
                }
            }
        }
            

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO tbluserinformation (firstname, middlename, lastname, emailAddress, homeAddress, birthDate) 
                VALUES (@fname, @mname, @lname, @email, @hadd, @bDate);
                INSERT INTO tbllogincredentials (userID, user_username, user_password) 
                VALUES (LAST_INSERT_ID(), @username, @password);";

            int affectedRowCount = db.ExecuteNoReturnQuery(query,
                new MySqlParameter("@fname", tbFname.Text),
                new MySqlParameter("@mname", tbMname.Text),
                new MySqlParameter("@lname", tbLname.Text),
                new MySqlParameter("@email", tbEmailAdd.Text),
                new MySqlParameter("@hadd", tbHomeAdd.Text),
                new MySqlParameter("@bDate", dtpBirthDate.Value),
                new MySqlParameter("@username", tbUsername.Text),
                new MySqlParameter("@password", tbPassword.Text)
            );

            if (affectedRowCount > 0)
            {
                MessageBox.Show("Data Inserted!");
                Form7_Load(null, null);
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
