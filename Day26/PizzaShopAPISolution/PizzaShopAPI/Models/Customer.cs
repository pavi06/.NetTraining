using System.ComponentModel.DataAnnotations;

namespace PizzaShopAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string Role { get; set; } = "User";

        public Customer(int custId, string custName, string custPhone, string address, string city)
        {
            CustId = custId;
            CustName = custName;
            CustPhone = custPhone;
            Address = address;
            City = city;
        }
    }
}
