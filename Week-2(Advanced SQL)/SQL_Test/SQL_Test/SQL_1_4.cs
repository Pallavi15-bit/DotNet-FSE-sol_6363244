using System;
using Microsoft.Data.SqlClient;

namespace SQLTest
{
    public class SQL_1_4

    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string pivotQuery = @"
                SELECT *
                FROM (
                    SELECT ProductName, MONTH(OrderDate) AS SaleMonth, Quantity
                    FROM Orders
                    JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
                    JOIN Products ON OrderDetails.ProductID = Products.ProductID
                ) AS SourceTable
                PIVOT (
                    SUM(Quantity) FOR SaleMonth IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])
                ) AS PivotTable;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(pivotQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Product: {reader["ProductName"]}");
                }
            }
        }
    }
}

