using EF_Labs_Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Labs_Solution
{
    public class Lab6_UpdateDelete
    {
        public async Task RunAsync()
        {
            using var context = new AppDbContext();

            // Update Product Price
            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (product != null)
            {
                product.Price = 70000;
                await context.SaveChangesAsync();
                Console.WriteLine("Updated price of Laptop to RS.70000.");
            }
            else
            {
                Console.WriteLine("Product 'Laptop' not found.");
            }

            // Delete Product
            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            if (toDelete != null)
            {
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                Console.WriteLine("Deleted product 'Rice Bag'.");
            }
            else
            {
                Console.WriteLine("Product 'Rice Bag' not found.");
            }
        }
    }
}
