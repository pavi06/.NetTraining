using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary
{
    public class Customer : IComparable<Customer>
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

        public int CompareTo(Customer? other)
        {
            if (this.Id == other.Id)
                return 0;
            else if (this.Id < other.Id)
                return -1;
            else
                return 1;
           
        }

        public override bool Equals(object? obj)
        {
            Customer obj1 = obj as Customer;
            return this.Name == obj1.Name && this.PhoneNumber == obj1.PhoneNumber && this.Address == obj1.Address;
        }


        public override string ToString()
        {
            return Id + " " + Name + " " + PhoneNumber ;
        }

        public class SortCustomerByName : IComparer<Customer>
        {
            public int Compare(Customer? x, Customer? y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
