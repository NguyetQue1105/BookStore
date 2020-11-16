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
    public partial class frmChangeAccount : Form
    {
        public frmChangeAccount()
        {
            InitializeComponent();
        }
        public Employee Employee { get; set; }
        public frmChangeAccount (string ID, string Password):this()
        {
            txtID.Text = ID;
            txtPassword.Text = Password;
        }
        public void InitData()
        {
            txtID.Text = Employee.EmpID;
            txtPassword.Text = Employee.EmpPassword;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string Password = txtPassword.Text;
            EmployeeData db = new EmployeeData();
            bool result;
            result = db.UpdatePassword(ID, Password);
            if(result == true)
            {
                MessageBox.Show("Save succesfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Save failed!");
            }
        }
    }
}
