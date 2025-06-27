using System;
using Microsoft.Data.SqlClient;

namespace SQLTest
{
    public class SQL_1_3
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string cteQuery = @"
                WITH Calendar AS (
                    SELECT CAST('2025_01_01' AS DATE) AS CalendarDate
                    UNION ALL
                    SELECT DATEADD(DAY, 1, CalendarDate)
                    FROM Calendar
                    WHERE CalendarDate < '2025_01_31'
                )
                SELECT * FROM Calendar
                OPTION (MAXRECURSION 0);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmdCalendar = new SqlCommand(cteQuery, connection))
                using (SqlDataReader reader = cmdCalendar.ExecuteReader())
                {
                    Console.WriteLine("Generated Calendar Dates:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Date: {reader["CalendarDate"]}");
                    }
                }
            }

            string mergeQuery = @"
                MERGE INTO Products AS Target
                USING StagingProducts AS Source
                ON Target.ProductID = Source.ProductID
                WHEN MATCHED THEN
                    UPDATE SET Target.Price = Source.Price
                WHEN NOT MATCHED BY TARGET THEN
                    INSERT (ProductID, ProductName, Category, Price)
                    VALUES (Source.ProductID, Source.ProductName, Source.Category, Source.Price);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmdMerge = new SqlCommand(mergeQuery, connection))
                {
                    int affectedRows = cmdMerge.ExecuteNonQuery();
                    Console.WriteLine($"Product prices updated using MERGE. Rows affected: {affectedRows}");
                }
            }
        }
    }
}
