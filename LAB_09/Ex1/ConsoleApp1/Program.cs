using System;
using System.Data;
using System.Data.SqlClient;

namespace Ex
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Data Source = AUMC - LAB1 - 17\\SQLEXPRESS; Initial Catalog = ex; Integrated Security = True";
            string queryString = "SELECT ProductID, UnitPrice, ProductName from ex " + "WHERE UnitPrice > ? " + "ORDER BY UnitPrice DESC;";
            int paramValue = 5;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, connectionString);
            command.Parameters.AddWithValue("@pricePoint", paramValue);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                { Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]); }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}