namespace ShoppingAppModelLibrary
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int QuantityInHand { get; set; }
        public override string ToString()
        {
            return "Id : " + Id +
                "\nName : " + Name +
                "\n Category : "+Category +
                "\nPrice : $" + Price +
                "\nNos in Stock : " + QuantityInHand;
        }

        public bool Equals(Product? other)
        {
            return this.Id.Equals(other.Id);
        }

        public Product()
        {

        }
        public Product(string name, double price, string catagory, int quantityInHand)
        {
            Price = price;
            Name = name;
            Category = catagory;
            QuantityInHand = quantityInHand;
        }

        public Product(int id, string name, double price, string catagory, int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
            Category = catagory;
            QuantityInHand = quantityInHand;
        }
        public Product(int id, double price, string name, string catagory, string? image, int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
            Category = catagory;
            Image = image;
            QuantityInHand = quantityInHand;
        }

    }
}
