using System.ComponentModel.DataAnnotations;

namespace PizzaShopAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }

        public IList<PizzaIngredient> Ingredients { get; set; }
    }
}
