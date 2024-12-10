using EstateDataAccess;
using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateLogic
{
    public class FileManager
    {
        private readonly JsonSerializationList<Estate> json = new JsonSerializationList<Estate>();
        private readonly XmlSerializationList<Estate> xml = new XmlSerializationList<Estate>();

        public FileManager() { }

        // Deserializes file from opened file path and returns list of Estate objects
        public List<Estate> DeserializeJsonToList(string path)
        {
            json.DeserializeData(path);
            return json.list;
        }

        // Deserializes file from opened file path and returns list of Estate objects
        public List<Estate> DeserilizeXML(string path)
        {
            xml.DeserializeData(path);
            return xml.list;
        }

        // Sets list of objects and serializes to JSON
        // Saves to opened file path
        public void SaveJsonFile(List<Estate> list, string openedFilePath)
        {
            json.list = list;                       // Set the list with objects to be serialized
            json.SerializeData(openedFilePath);     // Saves to opened file path
        }

        // Sets list of objects and serializes to JSON
        // Saves to set path -> Save As
        public void SaveAsJsonFile(List<Estate> list, string path)
        {
            json.list = list;           // Insert list for serialization
            json.SerializeData(path);
        }

        // Sets list of objects and serializes to XML
        // Saves to set path -> Save As
        public void SaveXML_File(List<Estate> list, string path)
        {
            xml.list = list;
            xml.SerializeData(path);
        }


    }
}
