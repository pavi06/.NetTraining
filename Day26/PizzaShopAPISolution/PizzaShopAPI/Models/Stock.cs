using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShopAPI.Models
{
    [Keyless]
    public class Stock
    {
        
        public int PizzaId { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
        public int QuantityInStock { get; set; }
    }
}
