using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Book_Rental_System
{
    public class DatabaseManager
    {
        SqlConnection SqlConn = new SqlConnection("Data Source=DPKASTG-05\\SQLEXPRESS;Initial Catalog=LibrarySystem;Integrated Security=True");
        SqlCommand SqlStr = new SqlCommand();
        string SqlStmt;

        public DataTable ListBooks(string bookname)
        {
            DataTable dt = new DataTable();
            SqlDataReader SqlReader;
            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Select * from Books where BookName like '%'+ @BookName +'%'";
                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@BookName", bookname);
                    SqlConn.Open();
                    SqlReader = SqlStr.ExecuteReader();
                    if (SqlReader.HasRows)
                    {
                        dt.Load(SqlReader);
                    }
                    SqlConn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                SqlConn.Close();
                return null;
            }
        }

        public bool AddBooks(string bookname, string author)
        {
            bool addbook = false;
            try
            {
                SqlStr.Connection = SqlConn;
                SqlStmt = "Insert into Books (BookName,Author, Available) values (@BookName, @Author, @Available) ";
                using (SqlStr = new SqlCommand(SqlStmt, SqlConn))
                {
                    SqlStr.Parameters.AddWithValue("@BookName", bookname);
                    SqlStr.Parameters.AddWithValue("@Author", author);
                    SqlStr.Parameters.AddWithValue("@Available", "Yes");
                    SqlConn.Open();
                    int SqlReader = SqlStr.ExecuteNonQuery();
                    if (SqlReader > 0)
                    {
                        addbook = true;
                    }
                    SqlConn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                SqlConn.Close();
            }
            return addbook;
        }

    }
}
