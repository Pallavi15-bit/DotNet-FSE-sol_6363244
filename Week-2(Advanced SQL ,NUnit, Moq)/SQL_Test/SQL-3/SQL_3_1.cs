using Microsoft.Data.SqlClient;
using System;

namespace SQL_3
{
    internal class SQL_3_1
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";
            string query = "SELECT * FROM vw_EmployeeBasicInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("EmployeeID | FirstName | LastName | DepartmentName");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmployeeID"]} | {reader["FirstName"]} | {reader["LastName"]} | {reader["DepartmentName"]}");
                }
            }
        }
    }
}
