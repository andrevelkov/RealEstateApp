using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace EstateDataAccess
{
    public class JsonSerializationList<T>
    {
        public List<T> list { get; set; } = [];
        // Saves to folder 'SaveFiles' as a default if error or no input
        private readonly string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\SaveFiles\JsonList.json"));

        // Saves to 'bin/Debug'
        // private string filePath = Environment.CurrentDirectory + @"\JasonList.json";

        // JSON formatting settings
        private readonly JsonSerializerSettings settings = new() 
        { 
            Formatting = Newtonsoft.Json.Formatting.Indented,
            Converters = { new StringEnumConverter() }, // StringEnumConverter
            // States to not use, security risk, cant find other solution
            TypeNameHandling = TypeNameHandling.Auto,
        };

        public JsonSerializationList() { }

        // Serializes list of objects to JSON file within user set path
        public void SerializeData(string newName = null)
        {
            try
            {
                // if filepath is null or empty saves to default path
                string filepath = string.IsNullOrEmpty(newName) ? path : newName;
                string jsonString = JsonConvert.SerializeObject(list, settings);
                File.WriteAllText(filepath, jsonString);
            } 
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        // Deserializes list of objects from user selected JSON file into List of Estates
        public void DeserializeData(string filePath) 
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                list = JsonConvert.DeserializeObject<List<T>>(jsonString, settings);
            } 
            catch (Exception ex) 
            { Console.WriteLine(ex.Message); }
        }

    }
}
