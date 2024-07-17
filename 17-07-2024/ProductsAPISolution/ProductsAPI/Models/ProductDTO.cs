namespace ProductsAPI.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public ProductDTO(int id, string imageUrl, string productName, double price)
        {
            ProductId = id;
            ImageUrl = imageUrl;
            ProductName = productName;
            Price = price;
        }
    }
}
