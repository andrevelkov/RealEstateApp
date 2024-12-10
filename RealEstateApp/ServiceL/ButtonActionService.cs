using System;
using System.Collections.Generic;
using System.IO;
using EstateLogic;
using EstateDataDTO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ModelsLibrary.Models;


namespace ServiceL
{
    /// <summary>
    /// ButtonActionService handles estate-related UI actions such as retrieving and updating estate information, 
    /// managing file operations (JSON/XML), and handling images. It interacts with the EstateManager for estate 
    /// data and manages user-triggered operations like saving, loading, and editing estates.
    /// </summary>

    public class ButtonActionService
    {
        private readonly EstateManager estateManager;
        private readonly FileManager fileManager = new();
        private bool fileOpened = false;
        private string openedFilePath = null!;

        public ButtonActionService(EstateManager mngr)
        { 
            estateManager = mngr;
        }

        #region << EDIT BUTTON >>

        /// <summary>
        /// Fetches information from a Estate-Object and sets to EstateDTO
        /// </summary>
        /// <param name="selectedEstate"> Estate </param>
        /// <returns> EstateDTO </returns>
        public EstateDTO GetEstateInfo(Estate selectedEstate)
        {
            EstateDTO estateInfo = new()
            {   // Estate
                EstateType = selectedEstate.GetType().BaseType!.Name,
                LegalForm = selectedEstate.LegalForm,
                EstateName = selectedEstate.GetType().Name,
                // Address
                Street = selectedEstate.Address.Street,
                City = selectedEstate.Address.City,
                ZipCode = selectedEstate.Address.ZipCode,
                Country = selectedEstate.Address.Country,
                SpecificDetails = selectedEstate.GetObjectDetail(),
                // Image
                Image = selectedEstate.Image
            };

            // Set category box with specific category attribute (Details)
            switch (selectedEstate)
            {
                case Residential r:
                    estateInfo.CategoryDetails = r.NumRooms;
                    break;
                case Commercial c:
                    estateInfo.CategoryDetails = c.SquareMeters;
                    break;
                case Institutional i:
                    estateInfo.CategoryDetails = i.NumFacilities;
                    break;
            }

            return estateInfo;
        }

        #endregion << END >>

        #region << SAVE BUTTON >>

        /// <summary>
        /// Sets Information from EstateDTO to a Estate-Object
        /// </summary>
        /// <param name="estate"> Estate </param>
        /// <param name="newInfo"> EstateDTO </param>
        public void SetNewEstateInfo(Estate estate, EstateDTO newInfo)
        {
            // Set Address attributes
            estate.Address.Street = newInfo.Street!;
            estate.Address.City = newInfo.City!;
            estate.Address.ZipCode = newInfo.ZipCode!;
            estate.Address.Country = (Countries)newInfo.Country!;
            // Set Image
            estate.Image = newInfo.Image;

            // Set Object specific attributes
            estate.SetObjectDetail(newInfo.SpecificDetails!);
            // Set Estate Category type attribute
            switch (estate)
            {
                case Residential r:
                    r.NumRooms = (int)newInfo.CategoryDetails!;
                    break;
                case Commercial c:
                    c.SquareMeters = (int)newInfo.CategoryDetails!;
                    break;
                case Institutional i:
                    i.NumFacilities = (int)newInfo.CategoryDetails!;
                    break;
            }
        }

        #endregion << END >>

        #region << LOAD IMG BUTTON >>

        /// <summary>
        /// Retrieve Image from filepath and return Image file
        /// </summary>
        /// <param name="path"> File path </param>
        /// <returns> Image </returns>
        public ImageSource? GetImgFromFilePath(string path)
        {
            try
            {
                //Image img = Image.FromFile(path);
                BitmapImage img = new BitmapImage(new Uri(path, UriKind.Absolute));

                return img;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No file");
                return null;
            }
        }

        #endregion << END >>


        // MenuStrip Buttons //

        #region << OPEN FILE JSON/XML >>

        // Opens File based on selected filepath (json / xml)
        public List<Estate> OpenFile(string path)
        {
            // Check if file exists
            if (File.Exists(path))
            {
                string ext = Path.GetExtension(path).ToLowerInvariant();

                switch (ext)
                {
                    // Opens and deserializes JSON file , returns list of Estate objects
                    case ".json":
                        // Set the opened file path variable and file opened to true
                        openedFilePath = path;
                        fileOpened = true;

                        return fileManager.DeserializeJsonToList(path);

                    // Opens and deserializes XML file , returns list of Estate objects
                    case ".xml":
                        // Set the opened file path variable and file opened to true
                        openedFilePath = path;
                        fileOpened = true;

                        return fileManager.DeserilizeXML(path);

                    default:
                        Console.WriteLine("Unsupported file type.");
                        // Add form popup of unsupported file type.

                        // return empty list
                        return [];
                }
            }
            else 
            {
                Console.WriteLine("File doesnt exist");
                return [];
            }
        }

        #endregion << END >>

        #region << SAVE / SAVE AS / SAVE XML >>

        public bool IsFileInUse()
        {
            return fileOpened;
        }

        // Saves JSON file to the opened file path , else creates new file -> Save As
        public void SaveJson() => fileManager.SaveJsonFile(estateManager.GetList(), openedFilePath);

        // Creates and saves new file in selected location
        public void SaveAsJson(string path)
        {
            fileManager.SaveAsJsonFile(estateManager.GetList(), path);
            openedFilePath = path;
            fileOpened = true;
        }

        // Saves a XML file to default path --> '/SaveFiles/XmlData.xml'
        public void SaveXML(string path)
        {
            fileManager.SaveXML_File(estateManager.GetList(), path);
            openedFilePath = path;
            fileOpened = true;
        }

        #endregion << END >>

    }
}
