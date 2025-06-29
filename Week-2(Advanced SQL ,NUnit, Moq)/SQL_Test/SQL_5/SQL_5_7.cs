using Microsoft.Data.SqlClient;
using System;


namespace SQL_5
{
    internal class SQL_5_7
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=SQLTestDB;Trusted_Connection=True;Encrypt=False;";

            Console.WriteLine("Enter EmployeeID to get Annual Salary:");
            int employeeId = int.Parse(Console.ReadLine());

            string query = "SELECT dbo.fn_CalculateAnnualSalary(@EmployeeID) AS AnnualSalary;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeId);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    Console.WriteLine($"Annual Salary for EmployeeID {employeeId}: {result}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }
    }
}
