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
    [Serializable]
    public class Shop : Commercial
    {
        public int Num_employees {  get; set; }
        
        public Shop() { }
        
        public Shop(int sqMeters)
        {
            Num_employees = sqMeters;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Shop with {SquareMeters} m^2 and {Num_employees} employees.\n\n" +
                             $"{Address}\n";
            return details;
        }

        public override string GetObjectDetail()
        {
            return Num_employees.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                Num_employees = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}

