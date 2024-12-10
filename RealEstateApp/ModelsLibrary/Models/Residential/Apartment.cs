using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ModelsLibrary.Models
{
    [Serializable]
    public class Apartment : Residential
    {
        public int Floor {  get; set; }

        public Apartment() { }

        public Apartment(int floor)
        {
            this.Floor = floor;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Apartment on floor {Floor} with {NumRooms} rooms.\n" +
                             $"{Address}\n";

            return details;
        }

        public override string GetObjectDetail()
        {
            return Floor.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                Floor = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
