using Microsoft.EntityFrameworkCore;
using EF_Labs_Solution.Models;

namespace EF_Labs_Solution
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=EFLabsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
