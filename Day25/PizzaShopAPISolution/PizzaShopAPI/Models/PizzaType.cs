using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShopAPI.Models
{
    public class PizzaType
    {
        public int PizzaId { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
