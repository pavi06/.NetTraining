using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public List<CartItem> CartItems { get; set; } 
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountAmount { get; set; }
        public double ShippingCharges { get; set; }

        public Cart() { }

        public Cart(int customerId,Customer customer,List<CartItem> cartItems,double totalAmount,double discount,double shippingCharges)
        {
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
            TotalAmount = totalAmount;
            Discount = discount;
            ShippingCharges = shippingCharges;
        }
        public Cart(int id, int customerId,Customer customer,List<CartItem> cartItems, double totalAmount,double discount, double shippingCharges)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
            TotalAmount = totalAmount;
            Discount = discount;
            ShippingCharges = shippingCharges;
        }

        public override bool Equals(object? obj)
        {
            Cart Obj1 = obj as Cart;
            return this.CustomerId == Obj1.CustomerId && this.Customer == Obj1.Customer && this.CartItems == Obj1.CartItems;
        }

        public override string ToString()
        {
            return "Id: "+Id+"Customer ID : "+CustomerId;
        }
    }
}
