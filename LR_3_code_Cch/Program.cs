using System;
using System.Collections.Generic;

namespace LR_3_code_Cch
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

            BinSerialize.Serealize(productList,"productList");

            var deDerializeList = BinSerialize.DeSerealize<List<Product>>("productList");

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
