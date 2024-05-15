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
    }
}
