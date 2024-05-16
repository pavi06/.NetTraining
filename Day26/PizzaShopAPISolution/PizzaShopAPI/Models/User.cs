using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShopAPI.Models
{
    public class User
    {
        [Key]
        public int CustId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }
        public string Status { get; set; }

        [ForeignKey("CustId")]
        public Customer Customer { get; set; }
    }
}
