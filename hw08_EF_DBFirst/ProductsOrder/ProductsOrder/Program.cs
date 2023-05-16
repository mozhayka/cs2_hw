using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProductsOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClearAll();
            Init();
            AddProductOrder(SomeObjects.product1, SomeObjects.order1);

            Test1();
            Test2();
            Test3();

            Console.WriteLine("Tests passed");
        }

        static void ClearAll()
        {
            using (var context = new ProductOrderEntities())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM OrderProduct");
                context.Database.ExecuteSqlCommand("DELETE FROM Product");
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Order]");
                
                context.SaveChanges(); 
            }
        }

        static void Init()
        {
            using (var context = new ProductOrderEntities())
            {
                var prod1 = context.Product.Add(SomeObjects.product1);
                var prod2 = context.Product.Add(SomeObjects.product2);
                var prod3 = context.Product.Add(SomeObjects.product3);

                var ord1 = context.Order.Add(SomeObjects.order1);
                var ord2 = context.Order.Add(SomeObjects.order2);
                context.SaveChanges();
            }
        }

        static void AddProductOrder(Product product, Order order)
        {
            using (var context = new ProductOrderEntities())
            {
                var prod1 = context.OrderProduct.Add(new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    amount = 1,
                    price = product.Price,
                });

                context.SaveChanges(); 
            }
        }

        static void Test1()
        {
            using (var context = new ProductOrderEntities())
            {
                var productId = context.Product.First(x => x.Name == "Foo").Id;
                var op = context.OrderProduct.First(x => x.ProductId == productId);
                Assert.IsTrue(op.total == 1);
            }
        }

        static void Test2()
        {
            using (var context = new ProductOrderEntities())
            {
                AddProductOrder(SomeObjects.product2, SomeObjects.order2);
                var op = context.OrderProduct.First(x => x.ProductId == SomeObjects.product2.Id);
                Assert.IsTrue(op.total == 100);
            }
        }

        static void Test3()
        {
            using (var context = new ProductOrderEntities())
            {
                AddProductOrder(SomeObjects.product3, SomeObjects.order2);
                var op = context.OrderProduct.First(x => x.ProductId == SomeObjects.product3.Id && x.OrderId == SomeObjects.order2.Id);
                op.amount = 2;
                context.SaveChanges();

                Assert.IsTrue(op.total == 20);
            }
        }
    }
}
