﻿using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ModelsLibrary.Models
{
    public class Hotel : Commercial
    {
        public int Num_hotel_rooms {  get; set; }

        public Hotel() { }

        public Hotel(int rooms)
        {
            Num_hotel_rooms = rooms;
        }

        public override string DisplayDetails()
        {
            string details = $"{LegalForm} Hotel with {SquareMeters} m^2 and {Num_hotel_rooms} rooms.\n\n" +
                             $"{Address}\n";

            return details;
        }

        public override string GetObjectDetail()
        {
            return Num_hotel_rooms.ToString();
        }

        public override void SetObjectDetail(string s)
        {
            if (StringHelper.ToInt(s, out int value))
            {
                Num_hotel_rooms = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}