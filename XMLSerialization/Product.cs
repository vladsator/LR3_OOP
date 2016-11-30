using System;
using System.Xml.Serialization;

namespace XMLSerialization
{
    [Serializable]
    public class Product
    {
        private static int _objCount;        public int Id { get; }
        public string Name { get;}
        public DateTime ManufactureDate { get; }
        public DateTime ExpirationDate { get; } 

        public Product()
        {
            
        }

        public Product(string name, DateTime manufactureDate, DateTime expirationDate)
        {
            Id = _objCount++;
            Name = name;
            ManufactureDate = manufactureDate;
            if (expirationDate > ManufactureDate)
            {
                ExpirationDate = expirationDate;
            }
            else throw new ArgumentException("Expiration date < Manufacture date");
        }

        public bool PossibleToEat()
        {
            return ExpirationDate >= DateTime.Today;
        }

        public override string ToString()
        {
            return string.Format("ID = {0} Name = {1}\nManufacture date = {2:d} Expiration date = {3:d}\nPossible to eat = {4}\n", Id, Name, ManufactureDate, ExpirationDate, PossibleToEat());
        }
    }
}
