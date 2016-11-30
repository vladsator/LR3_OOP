using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3_code_Cch
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();

            var addingProduct = new Product("Колбаса", DateTime.Today, new DateTime(2017, 3, 24));            
            productList.Add(addingProduct);

            addingProduct = new Product("Хлеб", new DateTime(2016, 11, 29), DateTime.Today);
            productList.Add(addingProduct);

            addingProduct = new Product("Молоко", new DateTime(2016, 10, 14), new DateTime(2016, 10, 20));
            productList.Add(addingProduct);

            foreach (var product in productList)
            {
                Console.WriteLine(product);    
            }
            Console.ReadLine();
        }
    }
}
