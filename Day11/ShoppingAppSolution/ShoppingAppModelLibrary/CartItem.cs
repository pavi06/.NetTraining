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
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public CartItem(int productId, Product product, int quantity, double price, double discount, DateTime priceExpiryDate)
        {
            
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }
        public CartItem(int cartId, int productId, Product product, int quantity, double price, double discount, DateTime priceExpiryDate)
        {
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }
        public CartItem(int id,int cartId, int productId, Product product, int quantity, double price, double discount, DateTime priceExpiryDate)
        {
            Id = id;
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }

        public override string ToString()
        {
            return "Product Id : "+ProductId + " Quantity : "+Quantity+" Price : "+Price+" Discount : "+Discount+"PriceExpiryDate: "+PriceExpiryDate;
        }
    }
}
