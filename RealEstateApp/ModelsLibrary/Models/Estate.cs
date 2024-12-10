using System;
using Newtonsoft.Json;
using System.Xml.Serialization;
using ModelsLibrary.Models;
using System.Windows.Media;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsLibrary.Models
{
    // abstract problems when json serialize -> removed abstract

    [XmlInclude(typeof(Residential))] // Residential
    [XmlInclude(typeof(Villa))]
    [XmlInclude(typeof(Apartment))]
    [XmlInclude(typeof(Townhouse))]
    [XmlInclude(typeof(Commercial))] // Commercial
    [XmlInclude(typeof(Shop))]
    [XmlInclude(typeof(Warehouse))]
    [XmlInclude(typeof(Factory))]
    [XmlInclude(typeof(Hotel))]
    [XmlInclude(typeof(Institutional))] // Institutional
    [XmlInclude(typeof(Hospital))]
    [XmlInclude(typeof(School))]
    [XmlInclude(typeof(University))]

    [Serializable]
    public class Estate : IEstate
    {
        [XmlIgnore]
        [JsonIgnore]
        public int ID { get; set; }
        //public int EstateID { get; set; }
        public Address Address { get; set; }
        public LegalFormEnum LegalForm { get; set; }
        public string BaseType { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [NotMapped]
        public ImageSource? Image { get; set; }

        public Estate()
        {
            BaseType = GetType().BaseType?.Name!; // Auto set Basetype when created
        }

        // Add TypeName and BaseTypeName properties (for XAML)
        public string TypeName => GetType().Name; // Concrete, ex Villa
        public string? BaseTypeName => GetType().BaseType?.Name; // Base type ex Commercial

        // Virtual Methods (prev Abstract)
        public virtual string DisplayDetails() => "Empty";
        public virtual string GetObjectDetail() => "Null";
        public virtual void SetObjectDetail(string s) { }

    }
}
