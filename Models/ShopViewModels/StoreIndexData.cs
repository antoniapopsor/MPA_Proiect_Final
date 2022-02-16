using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartphoneShop.Models.ShopViewModels
{
    public class StoreIndexData
    {
        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<Smartphone> Smartphones { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
