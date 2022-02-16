using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartphoneShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int SmartphoneID { get; set; }
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
        public Smartphone Smartphone { get; set; }
    }
}