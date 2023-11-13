using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebCommerce.Models;

namespace WebCommerce.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WebCommerce.Models.CustomerAddress>? CustomerAddress { get; set; }

    }
}
