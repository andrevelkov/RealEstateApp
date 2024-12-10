using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ModelsLibrary.Models
{
    public class Hospital : Institutional
    {
        public int Num_beds {  get; set; }

        public Hospital() { }

        public Hospital(int beds)
        {
            Num_beds = beds;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Hospital with {NumFacilities} facilities and {Num_beds} beds.\n\n" +
                             $"{Address}\n";
            return details;
        }

        public override string GetObjectDetail()
        {
            return Num_beds.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value)) {
                Num_beds = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
