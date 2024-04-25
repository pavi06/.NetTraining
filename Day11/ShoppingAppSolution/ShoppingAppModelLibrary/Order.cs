using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppModelLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public  Customer Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string OrderStatus { get; set; }
        public double TotalAmount { get; set; }
    }
}
