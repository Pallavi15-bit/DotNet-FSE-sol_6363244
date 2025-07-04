using EF_Labs_Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Labs_Solution
{
    public class Lab5_RetrieveData
    {
        public void Retrieve()
        {
            using var context = new AppDbContext();

            var products = context.Products.ToList();
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - Rs.{p.Price}");

            var product = context.Products.Find(1);
            Console.WriteLine($"Found: {product?.Name}");

            var expensive = context.Products.FirstOrDefault(p => p.Price > 50000);
            Console.WriteLine($"Expensive: {expensive?.Name}");
        }
    }
}
