using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
            List<Product> deDerializeList;

            ListPresenter(productList);

            FileSerializer.Serialize(@"Products.dat", productList);

            deDerializeList = FileSerializer.Deserialize<List<Product>>(@"Products.dat");
            ListPresenter(deDerializeList);
            Console.ReadLine();
        }

        static void ListPresenter<T>(List<T> list) where T : class
        {
            foreach (var obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        
    }
}
