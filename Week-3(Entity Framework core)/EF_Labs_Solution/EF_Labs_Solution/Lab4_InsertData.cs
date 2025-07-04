using EF_Labs_Solution.Models;

namespace EF_Labs_Solution
{
    public class Lab4_InsertData
    {
        public void Insert()
        {
            using var context = new AppDbContext();

            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            context.Categories.AddRange(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            context.Products.AddRange(product1, product2);
            context.SaveChanges();

            Console.WriteLine("Data inserted successfully.");
        }
    }
}
