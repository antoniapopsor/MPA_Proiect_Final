using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartphoneShop.Models
{
    public class Smartphone
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<StoreSmartphone> StoreSmartphones { get; set; }

    }
}