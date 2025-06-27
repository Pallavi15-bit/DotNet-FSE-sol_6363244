using SQL_4;
using System;

namespace SQL_4
{
    internal class SQL_4_P
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Exercise:\n1. Exercise 1 - Total Sales by Region\n4. Exercise 4 - Top Selling Product\n5. Exercise 5 - Customers with Multiple Orders");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SQL_4_1.Run();
                    break;
                case "4":
                    SQL_4_4.Run();
                    break;
                case "5":
                    SQL_4_5.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}