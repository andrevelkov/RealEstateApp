
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public enum EstateEnum
{
    Villa, // Residential
    Apartment, // Residential
    Townhouse, // Residential

    Hotel, // Commercial
    Shop, // Commercial
    Warehouse, // Commercial
    Factory, // Commercial

    Hospital, // Institutional
    School, // Institutional
    University // Institutional
}

public enum EstateTypeEnum
{
    Residential,
    Commercial,
    Institutional
}

public enum LegalFormEnum
{
    Ownership,
    Rental,
    Tenement
}