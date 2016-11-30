using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerialization
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

            var formatter = new XmlSerializer(typeof(List<Product>));
            using (var fs = new FileStream("Product.xml",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, productList);
            }

            using (var fs = new FileStream("Product.xml", FileMode.OpenOrCreate))
            {
                deDerializeList = (List<Product>)formatter.Deserialize(fs);
            }
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
