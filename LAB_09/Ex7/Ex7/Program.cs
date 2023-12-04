using System;
using System.Data.SqlClient;

namespace E7
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=AUMC-LAB1-17\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(connection);

            try
            {
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "SELECT COUNT(Name) FROM Student";
                int totalRowsAffected = (int)cmd.ExecuteScalar();
                Console.WriteLine("Total Students = " + totalRowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}