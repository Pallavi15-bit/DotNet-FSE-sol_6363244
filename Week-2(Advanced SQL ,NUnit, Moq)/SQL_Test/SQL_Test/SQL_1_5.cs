using System;
using Microsoft.Data.SqlClient;

namespace SQLTest
{
    public class SQL_1_5
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string query = @"
                WITH CustomerOrderCounts AS (
                    SELECT 
                        o.CustomerID,
                        COUNT(o.OrderID) AS OrderCount
                    FROM Orders o
                    GROUP BY o.CustomerID
                )
                SELECT 
                    c.CustomerID,
                    c.Name,
                    coc.OrderCount
                FROM CustomerOrderCounts coc
                JOIN Customers c ON c.CustomerID = coc.CustomerID
                WHERE coc.OrderCount > 3;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"CustomerID: {reader["CustomerID"]}, Name: {reader["Name"]}, Orders: {reader["OrderCount"]}");
                }
            }
        }
    }
}
