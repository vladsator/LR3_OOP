using System;

namespace CustomSerialization
{
    [Serializable]
    public class Product
    {
        private static int _objCount;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; } 

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
            return
                $"ID = {Id} Name = {Name}\nManufacture date = {ManufactureDate:d} Expiration date = {ExpirationDate:d}\nPossible to eat = {PossibleToEat()}\n";
        }
    }
}
