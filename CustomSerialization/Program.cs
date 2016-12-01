using System;
using System.Collections.Generic;

namespace CustomSerialization
{
    class Program
    {
        static void Main()
        {

            var productList = new List<Product>
            {
                new Product("Колбаса", DateTime.Today, new DateTime(2017, 3, 24)),
                new Product("Хлеб", new DateTime(2016, 11, 29), DateTime.Today),
                new Product("Молоко", new DateTime(2016, 10, 14), new DateTime(2016, 10, 20))
            };

            ListPresenter(productList);

            FileSerializer.Serialize(@"Products.dat", productList);

            var deDerializeList = FileSerializer.Deserialize<List<Product>>(@"Products.dat");
            ListPresenter(deDerializeList);
            Console.ReadLine();
        }

        private static void ListPresenter<T>(IEnumerable<T> list) where T : class
        {
            foreach (var obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        
    }
}
