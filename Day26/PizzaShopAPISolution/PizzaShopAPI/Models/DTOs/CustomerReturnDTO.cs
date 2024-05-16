namespace PizzaShopAPI.Models.DTOs
{
    public class CustomerReturnDTO : Customer
    {
        public CustomerReturnDTO(int custId, string custName, string custPhone, string address, string city) :base(custId, custName, custPhone, address, city)
        {
        }
    }
}
