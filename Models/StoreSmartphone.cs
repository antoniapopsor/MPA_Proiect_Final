using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartphoneShop.Models
{
    public class StoreSmartphone
    {
        public int StoreID { get; set; }
        public int SmartphoneID { get; set; }
        public Store Store { get; set; }
        public Smartphone Smartphone { get; set; }
    }
}
