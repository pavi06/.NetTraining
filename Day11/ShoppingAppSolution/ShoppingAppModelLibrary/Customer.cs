using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;

        public Customer() { }

        public Customer( string name,string phoneNumber, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public Customer(int id, string name,string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
