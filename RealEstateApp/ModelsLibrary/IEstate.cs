using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    internal interface IEstate 
    {
        int ID { get; set; }
        //public int EstateID { get; set; }
        Address Address { get; set; }
        LegalFormEnum LegalForm { get; set; }

        //Image Image {  get; set; } 
    }
}
