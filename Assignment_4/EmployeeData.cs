using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class EmployeeData
    {
        string strConnection;
        public EmployeeData()
        {
            strConnection = getConnectionString();
        }
        public string getConnectionString()
        {
            string strConnection = "server=SE140090;database=BookSystem;uid=sa;pwd=123456";
            return strConnection;
        }
        public bool CheckEmp(string ID, string Name)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "SELECT EmpRole FROM Employee WHERE EmpID=@ID and EmpPassword=@Password";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Password", Name);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return result;
        }
        public bool CheckRole(string ID, string Name)
        {
            bool role = false;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "SELECT EmpRole FROM Employee WHERE EmpID=@ID and EmpPassword=@Password";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Password", Name);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    role = (bool)reader["EmpRole"];
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            
            return role;
        }
        public bool UpdatePassword(string ID, string Password)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQl = "UPDATE Employee set EmpPassword=@Password WHERE EmpID=@ID";
            SqlCommand cmd = new SqlCommand(SQl, cnn);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                if(cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
    }
}
