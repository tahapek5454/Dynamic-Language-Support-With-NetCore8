using DynamicLanguage.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicLanguage.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
    }
}
