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
    [Serializable]
    public class Villa : Residential
    {
        public int SqMeters {  get; set; }

        public Villa() { }

        public Villa(int sqMeters)
        {
            SqMeters = sqMeters;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Villa, {SqMeters} m2 with {NumRooms} rooms.\n" +
                             $"{Address}\n";

            return details;
        }

        public override string GetObjectDetail()
        {
            return SqMeters.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                SqMeters = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
