using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models
{
    /// <summary>
    /// Represents a factory, which is a type of commercial estate.
    /// Inherits from the Commercial class.
    /// </summary>
    public class Factory : Commercial
    {
        public string FactoryType { get; set; }

        public Factory() { }

        public Factory(string type)
        {
            FactoryType = type;
        }

        // Returns a string of Factory object information
        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Factory with {SquareMeters} m^2. \n" +
                             $"Type of factory: {FactoryType}\n" +
                             $"{Address}\n";

            return details;
        }

        // Retrieves the factory type attribute
        public override string GetObjectDetail()
        {
            return FactoryType;
        }

        // Sets the Factory type
        public override void SetObjectDetail(string s)
        {
            FactoryType = s;
        }

        // Returns class name as a string
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
