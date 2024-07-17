using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using System.Collections.Generic;
using System.Numerics;

namespace ProductsAPI.Contexts
{
    public class ProductContext  : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 101, ProductName = "Pencil", ProductDescription="Wonderful Pencil with various shades available", ImageUrl= "https://paviblobstorage.blob.core.windows.net/product-images/pencil.jpg", Price=10.05 },
                new Product() { ProductId = 102, ProductName = "Color Pencil", ProductDescription = "Wonderful Color Pencils with 7 shades available", ImageUrl = "https://paviblobstorage.blob.core.windows.net/product-images/colorPencil.jpg", Price = 50.05 },
                new Product() { ProductId = 103, ProductName = "Sketch Pens", ProductDescription = "Wonderful Sketch Pens with 7 colors available", ImageUrl = "https://paviblobstorage.blob.core.windows.net/product-images/sketchPen.jpg", Price = 150.05 }
            );
        }
    }
}
