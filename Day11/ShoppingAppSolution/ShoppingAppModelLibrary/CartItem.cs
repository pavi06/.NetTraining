using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }//Navigation property
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public CartItem(int cartId, int productId, Product product, int quantity, double price,  DateTime priceExpiryDate)
        {
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            PriceExpiryDate = priceExpiryDate;
        }
        public CartItem(int id,int cartId, int productId, Product product, int quantity, double price, DateTime priceExpiryDate)
        {
            Id = id;
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            PriceExpiryDate = priceExpiryDate;
        }
    }
}
