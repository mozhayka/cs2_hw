using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsOrder
{
    internal class SomeObjects
    {
        public static Order order1 = new Order()
        {
            Id = 1,
            Date = new DateTime(2023, 05, 16),
        };

        public static Order order2 = new Order()
        {
            Id = 2,
            Date = new DateTime(2023, 05, 16),
        };

        public static Product product1 = new Product()
        {
            Id = 1,
            Name = "Foo",
            Price = 1,
        };

        public static Product product2 = new Product()
        {
            Id = 2,
            Name = "Bar",
            Price = 100,
        };

        public static Product product3 = new Product()
        {
            Name = "Ree",
            Price = 10,
        };
    }
}
