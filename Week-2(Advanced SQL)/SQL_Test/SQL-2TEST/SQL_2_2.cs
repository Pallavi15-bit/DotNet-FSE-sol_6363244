using System;
using Microsoft.Data.SqlClient;

namespace SQL_Test
{
    internal class SQL_2_2
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string queryBefore = @"
                SELECT * FROM Orders WHERE OrderDate = '2023-01-15';
            ";

            string dropIndexQuery = @"
                IF EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_OrderDate')
                DROP INDEX IX_OrderDate ON Orders;
            ";

            string createIndexQuery = @"
                CREATE NONCLUSTERED INDEX IX_OrderDate ON Orders (OrderDate);
            ";

            string queryAfter = @"
                SELECT * FROM Orders WHERE OrderDate = '2023-01-15';
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Query before Non-Clustered Index creation on OrderDate:");
                SqlCommand commandBefore = new SqlCommand(queryBefore, connection);
                SqlDataReader readerBefore = commandBefore.ExecuteReader();
                while (readerBefore.Read())
                {
                    Console.WriteLine($"OrderID: {readerBefore["OrderID"]}, CustomerID: {readerBefore["CustomerID"]}, OrderDate: {readerBefore["OrderDate"]}");
                }
                readerBefore.Close();

                Console.WriteLine("\nDropping existing index (if exists)...");
                SqlCommand dropCommand = new SqlCommand(dropIndexQuery, connection);
                dropCommand.ExecuteNonQuery();

                Console.WriteLine("\nCreating NON-Clustered Index on OrderDate...");
                SqlCommand indexCommand = new SqlCommand(createIndexQuery, connection);
                indexCommand.ExecuteNonQuery();

                Console.WriteLine("\nQuery after Non-Clustered Index creation on OrderDate:");
                SqlCommand commandAfter = new SqlCommand(queryAfter, connection);
                SqlDataReader readerAfter = commandAfter.ExecuteReader();
                while (readerAfter.Read())
                {
                    Console.WriteLine($"OrderID: {readerAfter["OrderID"]}, CustomerID: {readerAfter["CustomerID"]}, OrderDate: {readerAfter["OrderDate"]}");
                }
                readerAfter.Close();
            }
        }
    }
}
