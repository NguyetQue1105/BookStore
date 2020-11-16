using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Employee
    {
        public string EmpID { get; set; }
        public string EmpPassword { get; set; }
        public bool EmpRole { get; set; }

        public Employee()
        {
            EmpID = "";
            EmpPassword = "";
            EmpRole = false;
        }
        public Employee (string ID, string Password, bool Role)
        {
            EmpID = ID;
            EmpPassword = Password;
            EmpRole = Role;
        }
    }
}
