using System;

namespace SQL_Test
{
    internal class SQL_2_P
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Exercise:\n1. Non-Clustered Index\n2. Clustered Index\n3. Composite Index");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SQL_2_1.Run();
                    break;
                case "2":
                    SQL_2_2.Run();
                    break;
                case "3":
                    SQL_2_3.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
