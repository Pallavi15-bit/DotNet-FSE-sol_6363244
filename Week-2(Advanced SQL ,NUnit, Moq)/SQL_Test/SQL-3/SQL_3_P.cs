using System;

namespace SQL_3
{
    internal class SQL_3_P
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Exercise:");
            Console.WriteLine("1. View: Employee Basic Info");
            Console.WriteLine("2. View: Employee Full Name");
            Console.WriteLine("3. View: Employee Annual Salary");
            Console.WriteLine("4. View: Employee Report with Bonus");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SQL_3_1.Run();
                    break;
                case "2":
                    SQL_3_2.Run();
                    break;
                case "3":
                    SQL_3_3.Run();
                    break;
                case "4":
                    SQL_3_4.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
