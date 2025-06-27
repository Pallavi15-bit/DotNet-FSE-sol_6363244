using System;
using Microsoft.Data.SqlClient;

namespace SQL_Test
{
    internal class SQL_2_3
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Query before Composite Index creation:");
                string queryBefore = "SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';";
                ExecuteQuery(connection, queryBefore);

                string createIndex = "CREATE NONCLUSTERED INDEX IX_CustomerID_OrderDate ON Orders(CustomerID, OrderDate);";
                new SqlCommand(createIndex, connection).ExecuteNonQuery();
                Console.WriteLine("\nComposite Index created on CustomerID and OrderDate.\n");

                Console.WriteLine("Query after Composite Index creation:");
                ExecuteQuery(connection, queryBefore);
            }
        }

        private static void ExecuteQuery(SqlConnection connection, string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"OrderID: {reader["OrderID"]}, CustomerID: {reader["CustomerID"]}, OrderDate: {reader["OrderDate"]}");
            }
            reader.Close();
        }
    }

}
