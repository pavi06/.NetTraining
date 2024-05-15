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
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaIngredient>()
               .HasKey(pI => new { pI.PizzaId, pI.IngrId });

            modelBuilder.Entity<PizzaType>()
               .HasKey(pt => new { pt.PizzaId, pt.Type});

            modelBuilder.Entity<PizzaIngredient>()
               .HasOne(pI => pI.Pizza)
               .WithMany(p => p.Ingredients)
               .HasForeignKey(pI => pI.PizzaId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
