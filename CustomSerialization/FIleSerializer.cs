using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CustomSerialization
{
    public static class FileSerializer
    {
        public static void Serialize(string filename, object objectToSerialize)
        {
            if (objectToSerialize == null)
                throw new ArgumentNullException($"objectToSerialize cannot be null");
            Stream stream = null;
            try
            {
                stream = File.Open(filename, FileMode.Create);
                var bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
            }
            finally
            {
                stream?.Close();
            }
        }

        public static T Deserialize<T>(string filename)
        {
            T objectToSerialize = default(T);
            Stream stream = null;
            try
            {
                stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (T)bFormatter.Deserialize(stream);
            }
            catch (Exception err)
            {
                MessageBox.Show("The application failed to retrieve the inventory - " + err.Message);
            }

            finally
            {
                stream?.Close();
            }
            return objectToSerialize;
        }
    }
}
