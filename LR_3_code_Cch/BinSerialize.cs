using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LR_3_code_Cch
{
    static class BinSerialize
    {
        public static void Serealize<T>(T serializableObj, string fileName) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(fileName+".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, serializableObj);
            }
        }

        public static T DeSerealize<T>(string filepath) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filepath+ ".dat", FileMode.OpenOrCreate))
            {
                return (T) formatter.Deserialize(fs);
            }
        }
    }
}
