using System;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    [Serializable]
    public class Product:ISerializable
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

        protected Product(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("Id");
            Name = info.GetString("Name");
            ManufactureDate = info.GetDateTime("ManufactureDate");
            ExpirationDate = info.GetDateTime("ExpirationDate");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("ManufactureDate", ManufactureDate);
            info.AddValue("ExpirationDate", ExpirationDate);
        }
    }
}
