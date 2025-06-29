using System;
using Microsoft.Data.SqlClient;

namespace SQLTest
{
    public class SQL_1_2
    {
        public static void Run()
    {

        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string query = @"
                SELECT 
                    Region,
                    Category,
                    SUM(Quantity) AS TotalQuantity
                FROM Orders
                JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
                JOIN Customers ON Orders.CustomerID = Customers.CustomerID
                JOIN Products ON OrderDetails.ProductID = Products.ProductID
                GROUP BY GROUPING SETS ((Region), (Category), (Region, Category))";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Region: {reader["Region"]}, Category: {reader["Category"]}, Total Quantity: {reader["TotalQuantity"]}");
                }
            }
        }
    }
}

