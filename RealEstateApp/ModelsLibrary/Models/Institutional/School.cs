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
    public class School : Institutional
    {
        public int Num_classrooms { get; set; }
        public School() { }

        public School(int classrooms)
        {
            Num_classrooms = classrooms;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} School with {NumFacilities} facilities and {Num_classrooms} classrooms.\n" +
                             $"{Address}\n";

            return details;
        }

        public override string GetObjectDetail()
        {
            return Num_classrooms.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                Num_classrooms = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
