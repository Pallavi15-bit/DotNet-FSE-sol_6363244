using System;
using Microsoft.Data.SqlClient;

namespace SQL_Test
{
    internal class SQL_2_1
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Query before Non-Clustered Index creation:");
                string queryBefore = "SELECT * FROM Products WHERE ProductName = 'Laptop';";
                ExecuteQuery(connection, queryBefore);

                string createIndex = "CREATE NONCLUSTERED INDEX IX_ProductName ON Products(ProductName);";
                new SqlCommand(createIndex, connection).ExecuteNonQuery();
                Console.WriteLine("\nNon-Clustered Index created on ProductName.\n");

                Console.WriteLine("Query after Non-Clustered Index creation:");
                ExecuteQuery(connection, queryBefore);
            }
        }

        private static void ExecuteQuery(SqlConnection connection, string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ProductID: {reader["ProductID"]}, ProductName: {reader["ProductName"]}, Category: {reader["Category"]}, Price: {reader["Price"]}");
            }
            reader.Close();
        }
    }
}
