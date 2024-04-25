namespace ShoppingAppModelLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int QuantityInHand { get; set; }
        public override string ToString()
        {
            return "Id : " + Id +"|  Name : " + Name +
                "|  Category : "+Category +
                "|  Price : $" + Price +
                "|  Nos in Stock : " + QuantityInHand;
        }

        public override bool Equals(object? obj)
        {
            Product obj1 = obj as Product;
            return this.Name == obj1.Name && this.Price == obj1.Price && this.Category == obj1.Category && this.Image == obj1.Image && this.QuantityInHand==obj1.QuantityInHand;
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
