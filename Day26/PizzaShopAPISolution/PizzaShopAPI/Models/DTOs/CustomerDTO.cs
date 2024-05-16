namespace PizzaShopAPI.Models.DTOs
{
    public class CustomerDTO : Customer
    {
        public CustomerDTO(int custId, string custName, string custPhone, string address, string city) : base(custId, custName, custPhone, address, city)
        {
        }

        public  string Password { get; set; }
    }
}
