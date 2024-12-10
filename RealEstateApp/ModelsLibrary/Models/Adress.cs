using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ModelsLibrary
{
    [Serializable]
    public class Address : INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        [XmlIgnore]
        public int Id { get; set; } // Primary key for DB

        private string? street;
        private string? city;
        private string? zipCode;

        public Countries Country { get; set; }

        public string Street
        {
            get => street!;
            set
            {
                if (street != value)
                {
                    street = value;
                    OnPropertyChanged(nameof(Street)); // Notify UI of change
                }
            }
        }

        public string City
        {
            get => city!;
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged(nameof(City)); // Notify UI of change
                }
            }
        }

        public string ZipCode
        {
            get => zipCode!;
            set
            {
                if (zipCode != value)
                {
                    zipCode = value;
                    OnPropertyChanged(nameof(ZipCode)); // Notify UI of change
                }
            }
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public Address() { }

        public Address(string street, string city, string zipcode, Countries country) 
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
            Country = country;
        }

        public override string ToString()
        {
            return $"Address: {Street}, {City}, {ZipCode}, {Country}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
