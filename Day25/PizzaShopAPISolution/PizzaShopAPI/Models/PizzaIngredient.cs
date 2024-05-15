using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShopAPI.Models
{
    public class PizzaIngredient
    {
        public int PizzaId { get; set; }
        public int IngrId { get; set; }

        [ForeignKey("IngrId")]
        public Ingredient Ingredient { get; set; }
        public double QuantityNeeded { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
    }
}
