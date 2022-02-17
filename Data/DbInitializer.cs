using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartphoneShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SmartphoneShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();

            if (context.Smartphones.Any())
            {
                return;
            }
            var smartphones = new Smartphone[]
            {
                new Smartphone{Model = "Pixel 5", Manufacturer = "Google", Price = Decimal.Parse("3500")},
                new Smartphone{Model = "Galaxy S11", Manufacturer = "Samsung", Price = Decimal.Parse("4100")},
                new Smartphone{Model = "P50 Ultra Pro", Manufacturer = "Huawei", Price = Decimal.Parse("4260")},
                new Smartphone{Model = "iPhone 12", Manufacturer = "Apple", Price = Decimal.Parse("4500")},
                new Smartphone{Model = "Galaxy S11", Manufacturer = "Samsung", Price = Decimal.Parse("3670")},
                new Smartphone{Model = "iPhone 11", Manufacturer = "Apple", Price = Decimal.Parse("3100")},
                new Smartphone{Model = "iPhone X", Manufacturer = "Apple", Price = Decimal.Parse("2550")},
            };
            foreach (Smartphone s in smartphones)
            {
                context.Smartphones.Add(s);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
            new Customer{CustomerID=1050,Name="Popescu Gheorghe",BirthDate=DateTime.Parse("1995-09-01")},
            new Customer{CustomerID=1045,Name="Comsa Ana-Maria",BirthDate=DateTime.Parse("1967-07-08")},
            new Customer{CustomerID=1040,Name="Stanescu Flavia",BirthDate=DateTime.Parse("1997-07-10")},
            new Customer{CustomerID=1035,Name="Stoica Andrei",BirthDate=DateTime.Parse("1989-10-04")},
            new Customer{CustomerID=1030,Name="Marinescu Mirela",BirthDate=DateTime.Parse("1977-06-10")},
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{SmartphoneID=1,CustomerID=1050, OrderDate=DateTime.Parse("12-25-2021")},
                new Order{SmartphoneID=2,CustomerID=1045, OrderDate=DateTime.Parse("01-25-2022")},
                new Order{SmartphoneID=3,CustomerID=1040, OrderDate=DateTime.Parse("02-03-2022")},
                new Order{SmartphoneID=4,CustomerID=1035, OrderDate=DateTime.Parse("02-20-2022")},
                new Order{SmartphoneID=5,CustomerID=1030, OrderDate=DateTime.Parse("03-25-2022")},
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();

            var stores = new Store[]
            {
                new Store{StoreName="Google Store",Adress="Str. Aviatorilor, nr. 40,Bucuresti"},
                new Store{StoreName="Emag",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                new Store{StoreName="Smartphone Shop",Adress="Str. Cascadelor, nr.22, Cluj-Napoca"},
            };
            foreach (Store o in stores)
            {
                context.Stores.Add(o);
            }
            context.SaveChanges();

            var storesmartphones = new StoreSmartphone[]
            {
                new StoreSmartphone { SmartphoneID = smartphones.Single(c => c.Model == "Pixel 5").ID, StoreID = stores.Single(i => i.StoreName == "Google Store").ID },
                new StoreSmartphone { SmartphoneID = smartphones.Single(c => c.Model == "Iphone 11").ID, StoreID = stores.Single(i => i.StoreName == "Emag").ID },
                new StoreSmartphone { SmartphoneID = smartphones.Single(c => c.Model == "Pixel 5").ID, StoreID = stores.Single(i => i.StoreName == "Smartphone Shop").ID },
            };
            foreach (StoreSmartphone sm in storesmartphones)
            {
                context.StoreSmartphones.Add(sm);
            }
            context.SaveChanges();
        }
    }
}
