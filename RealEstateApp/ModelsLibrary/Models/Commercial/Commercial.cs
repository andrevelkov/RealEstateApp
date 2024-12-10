using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModelsLibrary.Models
{
    /// <summary>
    /// Abstract class representing a commercial estate property.
    /// Inherits from the Estate base class.
    /// </summary>
    public class Commercial : Estate
    {
        public int SquareMeters { get; set; }

        public Commercial(): base() { }
    }
}
