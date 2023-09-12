using Emart_final.Models;
using Microsoft.EntityFrameworkCore;

namespace Emart_final.Models.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=Emart;Integrated Security=True");
            }
        }


        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ConfigDetails> Config_Details { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<InvoiceDetails> Invoice_Details { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}

