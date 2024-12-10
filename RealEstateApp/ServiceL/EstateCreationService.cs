using ModelsLibrary.Models;
using ModelsLibrary;
using EstateLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateDataDTO;

namespace ServiceL
{
    /// <summary>
    /// Service for creating various types of estates (Residential, Commercial, Institutional) 
    /// and adding general and category-specific information.
    /// </summary>

    public class EstateCreationService
    {
        public Estate? estate { get; set; }
        private readonly EstateManager estateManager;
        private readonly DbManager db = new();
        private int IdValue = 0;

        public EstateCreationService(EstateManager manager) 
        {
            estateManager = manager;
        }

        public void CreateResidentialEstate(EstateEnum option, int detail)
        {
            switch (option)
            {
                case EstateEnum.Apartment:
                    estate = new Apartment(detail);
                    break;

                case EstateEnum.Villa:
                    estate = new Villa(detail);
                    break;

                case EstateEnum.Townhouse:
                    estate = new Townhouse(detail);
                    break;
            }
            estateManager.Add(estate!); // Adds to list of estates
        }

        public void CreateCommercialEstate(EstateEnum option, int detail, string factoryDetail)
        {
            switch (option)
            {
                case EstateEnum.Hotel:
                    estate = new Hotel(detail);
                    break;

                case EstateEnum.Shop:
                    estate = new Shop(detail);
                    break;

                case EstateEnum.Warehouse:
                    estate = new Warehouse(detail);
                    break;

                case EstateEnum.Factory:
                    estate = new Factory(factoryDetail);
                    break;
            }
            estateManager.Add(estate!);
        }

        public void CreateInstitutionalEstate(EstateEnum option, int detail)
        {
            switch (option)
            {
                case EstateEnum.Hospital:
                    estate = new Hospital(detail);
                    break;

                case EstateEnum.School:
                    estate = new School(detail);
                    break;

                case EstateEnum.University:
                    estate = new University(detail);
                    break;
            }
            estateManager.Add(estate!);
        }

        // Add General Estate information (Apartment, Factory, School etc..)
        public void AddGeneralInfo(EstateDTO estateDTO)
        {
            if (estate != null)
            {
                //estate.EstateID = IdValue;
                estate.LegalForm = (LegalFormEnum)estateDTO.LegalForm!;
                estate.Address = new Address(estateDTO.Street!, estateDTO.City!, estateDTO.ZipCode!, (Countries)estateDTO.Country!);
                estate.Image = estateDTO.Image;
            }

            IdValue++;
        }

        // Add Category specific information (Residential, Commercial etc..)
        public void AddCategoryInfo(EstateTypeEnum category, int catInput1)
        {
            if (estate != null)
            {
                switch (category)
                {
                    case EstateTypeEnum.Residential:

                        ((Residential)estate).NumRooms = catInput1;
                        break;

                    case EstateTypeEnum.Commercial:

                        ((Commercial)estate).SquareMeters = catInput1;
                        break;

                    case EstateTypeEnum.Institutional:

                        ((Institutional)estate).NumFacilities = catInput1;
                        break;
                }
            }
        }

    }
}
