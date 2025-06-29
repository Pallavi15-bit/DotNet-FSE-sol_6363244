using System;
using Microsoft.Data.SqlClient;

namespace SQL_3
{
    internal class SQL_3_3
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";
            string query = "SELECT * FROM vw_EmployeeAnnualSalary";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("EmployeeID | DepartmentName | AnnualSalary");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmployeeID"]} | {reader["DepartmentName"]} | {reader["AnnualSalary"]}");
                }
            }
        }
    }
}
