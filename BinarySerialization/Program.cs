using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
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
            List<Product> deDerializeList = null;

            ListPresenter(productList);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("BinSerialize.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, productList);
            }
            using (FileStream fs = new FileStream("BinSerialize.dat", FileMode.OpenOrCreate))
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
