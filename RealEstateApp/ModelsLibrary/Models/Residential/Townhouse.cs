using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ModelsLibrary.Models
{
    public class Townhouse : Residential
    {
        public int Floors {  get; set; }

        public Townhouse() { }

        public Townhouse(int floors)
        {
            this.Floors = floors;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Town-House on {Floors} floors with {NumRooms} rooms.\n" +
                             $"{Address}\n";
            return details;
        }

        public override string GetObjectDetail()
        {
            return Floors.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                Floors = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
