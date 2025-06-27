using SQLTest;
using System;

namespace SQLTest
{
    class SQL_1_P

    {
        static void Main(string[] args)
    {
        Console.WriteLine("Enter exercise number to run (1-5):");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SQL_1_1.Run();
                break;
            case "2":
                SQL_1_2.Run();
                break;
            case "3":
                SQL_1_3.Run();
                break;
            case "4":
                SQL_1_4.Run();
                break;
            case "5":
                SQL_1_5.Run();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
}

