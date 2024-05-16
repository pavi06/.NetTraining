using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.Models;
using System.Numerics;

namespace PizzaShopAPI.Contexts
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { PizzaId = 101, Name = "Margherita Pizza", size = "Regular" , Price = 250.00, IsAvailable = true, Description = "A classic Margherita pizza boasts a perfect harmony of tangy tomato sauce, creamy mozzarella, and fragrant basil on a crispy crust" },
                new Pizza() { PizzaId = 102, Name = "Cheese & Corn Pizza", size = "Regular", Price = 350.00, IsAvailable = true, Description = "A tantalizing fusion of gooey cheese and sweet corn kernels atop a golden crust, delivering a delightful blend of flavors in every bite." },
                new Pizza() { PizzaId = 103, Name = "Barbecue chicken Pizza", size = "Regular", Price = 450.00, IsAvailable = false, Description = "Indulge in smoky perfection with our barbecue chicken pizza, where every bite is a flavor-packed journey" }
                );

        }

    }
}
