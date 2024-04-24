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
        public Customer Customer { get; set; }//Navigation property
        public List<CartItem> CartItems { get; set; }//Navigation property

        public Cart() { }
        public Cart(int id, int customerId, Customer customer, List<CartItem> cartItems)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
        }
    }
}
