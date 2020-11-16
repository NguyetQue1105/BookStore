using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class BookData
    {
        string strConnection;
        public BookData()
        {
            strConnection = getConnectionString();
        }
        public string getConnectionString()
        {
            string strConnection = "server=SE140090;database=BookSystem;uid=sa;pwd=123456";
            return strConnection;
        }
        public DataTable GetBooks()
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBooks = new DataTable();
            try
            {
                if(cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtBooks);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dtBooks;
        }
        public bool AddBooks(Book book)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "INSERT Books values (@ID,@Name,@Price)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            try
            {
                if (cnn.State == ConnectionState.Closed)
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
        public bool UpdateBooks(Book book)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "UPDATE Books SET BookName=@Name, BookPrice=@Price WHERE BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
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
        public bool DeleteBook(Book book)
        {
            bool result = false;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "DELETE Books WHERE BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
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
