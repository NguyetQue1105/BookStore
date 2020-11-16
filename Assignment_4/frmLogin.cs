using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        EmployeeData db = new EmployeeData();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string Password = txtPassword.Text;
            bool check = db.CheckEmp(ID, Password);
            Employee employee = new Employee { EmpID = ID, EmpPassword = Password, EmpRole = check };
            if (check == true)
            {
                bool role = db.CheckRole(ID, Password);
                if (role == false)
                {
                    this.Hide();
                    frmChangeAccount frmChangeAccount = new frmChangeAccount(ID, Password);
                    frmChangeAccount.ShowDialog();
                    this.Close();
                }
                else if (role == true)
                {
                    //this.Hide();
                    //var frmMaintainBooks = new frmMaintainBooks();
                    //frmMaintainBooks.Closed += (s, args) => this.Close();
                    //frmMaintainBooks.Show();

                    this.Hide();
                    frmMaintainBooks frmMaintainBooks = new frmMaintainBooks();
                    frmMaintainBooks.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid ID & Password");
            }
        }
    }
}
