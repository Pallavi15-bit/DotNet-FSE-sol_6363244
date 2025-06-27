using System;
using Microsoft.Data.SqlClient;

namespace SQLTest
{
    public class SQL_1_1

    {
        public static void Run()
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

        string query = @"
                WITH RankedProducts AS (
                    SELECT 
                        Category,
                        ProductName,
                        Price,
                        ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum,
                        RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum,
                        DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
                    FROM Products
                )
                SELECT * FROM RankedProducts WHERE RowNum <= 3;
            ";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Category: {reader["Category"]}, Product: {reader["ProductName"]}, Price: {reader["Price"]}, RowNum: {reader["RowNum"]}, Rank: {reader["RankNum"]}, DenseRank: {reader["DenseRankNum"]}");
            }
        }
    }
}
}
