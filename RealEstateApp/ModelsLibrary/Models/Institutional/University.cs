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
    public class University : Institutional
    {
        public int Num_buildings {  get; set; }

        public University() { }

        public University(int buildings)
        {
            Num_buildings = buildings;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Univerity with {NumFacilities} facilities and {Num_buildings} buildings.\n" +
                             $"{Address}\n";

            return details;
        }

        public override string GetObjectDetail()
        {
            return Num_buildings.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                Num_buildings = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
