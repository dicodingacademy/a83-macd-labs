using BooksCatalogueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalogueAPI.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}