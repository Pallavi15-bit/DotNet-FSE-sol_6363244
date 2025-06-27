using System;
using Microsoft.Data.SqlClient;

namespace SQL_4
{
    internal class SQL_4_1
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            string query = "SELECT EmployeeID, FirstName, LastName, Salary FROM Employees;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Salary: {reader["Salary"]}");
                }
            }
        }
    }
}