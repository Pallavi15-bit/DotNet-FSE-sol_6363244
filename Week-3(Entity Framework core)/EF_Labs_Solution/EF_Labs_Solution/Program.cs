using System;

namespace EF_Labs_Solution
{
    internal class Program
    {
        static async Task Main(string[] args)

        {
            Console.WriteLine("Choose Lab to Run (1-7):");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunLab1();
                    break;
                case "2":
                    RunLab2();
                    break;
                case "3":
                    RunLab3();
                    break;
                case "4":
                    new Lab4_InsertData().Insert();
                    break;
                case "5":
                    new Lab5_RetrieveData().Retrieve();
                    break;
                case "6":
                    await new Lab6_UpdateDelete().RunAsync();
                    break;
                case "7":
                    await new Lab7_LINQQueries().RunAsync();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void RunLab1()
        {
            Console.WriteLine("\n========== Lab 1: Understanding ORM & EF Core ==========\n");

            Console.WriteLine("1. What is ORM?");
            Console.WriteLine("ORM (Object Relational Mapping) maps C# classes to database tables.");
            Console.WriteLine("It allows developers to work with databases using C# objects instead of raw SQL.\n");
            Console.WriteLine("Benefits of ORM:");
            Console.WriteLine("- Increased Productivity");
            Console.WriteLine("- Better Maintainability");
            Console.WriteLine("- Abstraction from complex SQL queries\n");

            Console.WriteLine("2. EF Core vs EF Framework:");
            Console.WriteLine("- EF Core: Cross-platform, lightweight, modern features like LINQ, async queries, compiled models.");
            Console.WriteLine("- EF Framework (EF6): Mature but Windows-only, limited for modern development.\n");

            Console.WriteLine("3. EF Core 8.0 Key Features:");
            Console.WriteLine("- JSON column mapping support");
            Console.WriteLine("- Improved performance through compiled models");
            Console.WriteLine("- Interceptors for better control");
            Console.WriteLine("- Efficient bulk operations\n");

            Console.WriteLine("=========================================================\n");
        }

        static void RunLab2()
        {
            Console.WriteLine("\n========== Lab 2: Setting Up DbContext ==========\n");
            Console.WriteLine("DbContext and model classes have been defined in the project.");
            Console.WriteLine("The connection string is configured inside AppDbContext.cs.");
            Console.WriteLine("EF Core uses this to connect the C# models to the SQL Server database.");
            Console.WriteLine("=========================================================\n");
        }

        static void RunLab3()
        {
            Console.WriteLine("\n========== Lab 3: Using EF Core CLI ==========\n");
            Console.WriteLine("EF Core CLI commands for managing migrations:");
            Console.WriteLine("1. Add migration:   dotnet ef migrations add InitialCreate");
            Console.WriteLine("2. Apply migration: dotnet ef database update");
            Console.WriteLine("These commands generate migration files and create/update the database schema.");
            Console.WriteLine("=========================================================\n");
        }
    }
}
