using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace EstateDataAccess
{
    public class XmlSerializationList<T>
    {
        public List<T> list { get; set; } = new List<T>();
        private readonly string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\SaveFiles\XmlData.xml"));

        public XmlSerializationList() { }

        // Serializes list of objects to a XML file in the set folder path
        public void SerializeData(string filePath = null)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                // if filepath is null or empty saves to default path
                string userPath = string.IsNullOrEmpty(filePath) ? path : filePath;

                using (StreamWriter writer = new StreamWriter(userPath))
                {
                    serializer.Serialize(writer, list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Console.WriteLine(ex.ToString()); 
            }
        }

        // Deserializes list of objects from user selected XML file into List of estates
        public void DeserializeData(string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                using (Stream reader = new FileStream(path, FileMode.Open))
                {
                    list = (List<T>)serializer.Deserialize(reader);
                    reader.Close();
                }

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

    }
}
