using System;
using Microsoft.Data.SqlClient;

namespace SQL_4
{
    internal class SQL_4_4
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string query = @"
                SELECT EmployeeID, (Salary * 12) AS AnnualSalary, (Salary * 12) * 0.10 AS Bonus
                FROM Employees;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["EmployeeID"]}, Annual Salary: {reader["AnnualSalary"]}, Bonus: {reader["Bonus"]}");
                }
            }
        }
    }
}