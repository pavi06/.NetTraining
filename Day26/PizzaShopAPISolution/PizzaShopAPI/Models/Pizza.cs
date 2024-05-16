using System.ComponentModel.DataAnnotations;

namespace PizzaShopAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string size { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }

    }
}
