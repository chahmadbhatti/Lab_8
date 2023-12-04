using System;
using System.Data;
using System.Data.SqlClient;

namespace E3
{
    class Program
    {
        static void Main(string[] args)
        {
            string customerConnection = "Data Source=AUMC-LAB1-17\\SQLEXPRESS;Initial Catalog=ex;Integrated Security=True";
            string orderConnection = "Data Source = AUMC - LAB1 - 17\\SQLEXPRESS; Initial Catalog = ex; Integrated Security = True";

            SqlDataAdapter customerAdapter = new SqlDataAdapter("SELECT * FROM Customers", customerConnection);
            SqlDataAdapter orderAdapter = new SqlDataAdapter("SELECT * FROM Orders", orderConnection);



            DataSet customerOrders = new DataSet();
            customerAdapter.Fill(customerOrders, "Customers");
            orderAdapter.Fill(customerOrders, "Orders");

            DataRelation relation = customerOrders.Relations.Add("CustOrders", customerOrders.Tables["Customers"].Columns["CustomerID"], customerOrders.Tables["Orders"].Columns["CustomerID"]);


            foreach (DataRow pRow in customerOrders.Tables["Customers"].Rows)
            {
                Console.WriteLine(pRow["CustomerID"]);
                foreach (DataRow cRow in pRow.GetChildRows(relation))
                {
                    Console.WriteLine("\t" + cRow["OrderID"]);
                }
            }
        }
    }
}