using EF_Labs_Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Labs_Solution
{
    public class Lab7_LINQQueries
    {
        public async Task RunAsync()
        {
            using var context = new AppDbContext();

            // Filter and Sort Products
            var filtered = await context.Products
                .Where(p => p.Price > 1000)
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            Console.WriteLine("Filtered and Sorted Products (Price > Rs.S1000):");
            foreach (var p in filtered)
            {
                Console.WriteLine($"{p.Name} - Rs.{p.Price}");
            }

            // Project into DTO
            var productDTOs = await context.Products
                .Select(p => new { p.Name, p.Price })
                .ToListAsync();

            Console.WriteLine("\nProduct DTOs:");
            foreach (var dto in productDTOs)
            {
                Console.WriteLine($"{dto.Name} - Rs.{dto.Price}");
            }
        }
    }
}
