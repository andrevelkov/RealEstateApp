using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ModelsLibrary.Models
{
    public class Warehouse : Commercial
    {
        public int StorageCapacity { get; set; }

        public Warehouse() { }

        public Warehouse(int cubicMeters)
        {
            StorageCapacity = cubicMeters;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Warehouse with {SquareMeters} m2 " +
                             $"and a storage capacity of {StorageCapacity} m3\n\n" +
                             $"{Address}\n";

            return details;
        }

        public override string GetObjectDetail()
        {
            return StorageCapacity.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                StorageCapacity = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
