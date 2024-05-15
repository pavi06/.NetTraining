using System.ComponentModel.DataAnnotations;

namespace PizzaShopAPI.Models
{
    public class Ingredient
    {
        [Key]
        public int IngrId { get; set; }
        public string IngrName { get; set;}
        public double QuantityInStock { get; set; }

    }
}
