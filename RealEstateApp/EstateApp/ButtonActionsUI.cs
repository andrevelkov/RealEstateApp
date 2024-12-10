using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using EstateDataDTO;
using Utilities;
using ServiceL;
using ModelsLibrary.Models;

namespace EstateApp
{
    internal class ButtonActionsUI(MainWindow mainWindow, ServiceManager mngr)
    {
        private readonly OpenFileDialog openFile = new();
        private readonly SaveFileDialog saveFile = new();

        #region << EDIT BUTTON >>

        public void Edit(Estate selectedEstate)
        {
            // Fetches and sets all information of the Estate into all forms/controls
            EstateDTO estateInfo = mngr.GetEstateDTO(selectedEstate);

            // Update the form controls with data from the DTO
            mainWindow.CboxEstateType.Text = estateInfo.EstateType;
            mainWindow.CboxLegalForm.SelectedItem = estateInfo.LegalForm;
            mainWindow.CboxEstate.Text = estateInfo.EstateName;
            // Address
            mainWindow.textBoxStreet.Text = estateInfo.Street;
            mainWindow.textBoxCity.Text = estateInfo.City;
            mainWindow.textBoxZipCode.Text = estateInfo.ZipCode;
            mainWindow.CboxCountries.Text = estateInfo.Country!.ToString();
            // Image
            mainWindow.pictureBox.Source = selectedEstate.Image;
            // Other
            mainWindow.textBoxCat.Text = estateInfo.CategoryDetails.ToString();
            mainWindow.textBoxSpecific.Text = estateInfo.SpecificDetails;

            DisableButtonsOnEdit();
        }

        // UI Changes: Disable controllers and Show save btn
        private void DisableButtonsOnEdit()
        {
            mainWindow.GboxEstate.IsEnabled = false;
            mainWindow.ListViewEstates.IsEnabled = false;
            mainWindow.BtnDelete.IsEnabled = false;
            mainWindow.BtnAdd.IsEnabled = false;
            mainWindow.BtnSave.Visibility = Visibility.Visible;
        }

        #endregion << END >>

        #region << SAVE BUTTON >>

        // Saves new input values to EstateDTO
        public void SaveValues(Estate selectedEstate)
        {
            EstateDTO estateInfo = new()
            {
                Street = mainWindow.textBoxStreet?.Text ?? "",
                City = mainWindow.textBoxCity?.Text ?? "",
                ZipCode = mainWindow.textBoxZipCode?.Text ?? "",
                Country = mainWindow.CboxCountries?.SelectedItem is Countries country ? country : default,
                Image = mainWindow.pictureBox?.Source,
                SpecificDetails = mainWindow.textBoxSpecific?.Text ?? ""
            };

            // Set Estate Category type attribute
            // If successfull parsing, return num
            if (StringHelper.ToInt(mainWindow.textBoxCat.Text, out int value))
            {
                switch (selectedEstate)
                {
                    case Residential _:
                        estateInfo.CategoryDetails = value;
                        break;
                    case Commercial _:
                        estateInfo.CategoryDetails = value;
                        break;
                    case Institutional _:
                        estateInfo.CategoryDetails = value;
                        break;
                }
            }

            mngr.SetEstateDTO(selectedEstate, estateInfo);
        }

        #endregion << END >>

        #region << LOAD IMG BUTTON >>

        // Load Image from file into the pictureBox
        public void LoadImage()
        {
            // Clear Image box, in case previously set
            mainWindow.pictureBox.Source = null;

            // Load image from user files, browse and select image
            // Opens Directory -> sets file path
            openFile.ShowDialog();
            string filePath = openFile.FileName;

            if (filePath != null)
            {
                ImageSource img = mngr.GetImage(filePath);
                mainWindow.pictureBox.Source = img;
            }
        }

        #endregion << END >>


        // MenuStrip Buttons //

        #region << OPEN FILE JSON/XML >>

        /// <summary>
        /// Open a JSON/XML file (with Estate Obj)
        /// </summary>
        public void Open()
        {
            openFile.FileName = "";
            if (openFile.ShowDialog() == true)
            {   
                mngr.UpdateEstateList(openFile.FileName);   // Updates list with new Estates from file
                mainWindow.UpdateListView();                // Update ListView items with new Estates
            }
        }

        #endregion << END >>

        #region << SAVE / SAVE AS / SAVE XML >>

        /// <summary>
        /// Saves info to opened file, else create new file -> Save As
        /// </summary>
        public void Save_Json()
        {
            if (mngr.FileInUse())
            {   // Saves to the opened file path
                mngr.SaveFile();
            }
            else
            {   // Saves to user set location
                SaveAs_Json();
            }
        }

        /// <summary>
        /// Creates and saves a new file
        /// </summary>
        public void SaveAs_Json()
        {
            // Set default file name for json
            saveFile.FileName = "new_file.json";
            if (saveFile.ShowDialog() == true)
            {
                string newFilePath = saveFile.FileName;
                mngr.SaveFile(newFilePath);
            }
        }

        /// <summary>
        /// Saves a XML file to set path
        /// </summary>
        public void SaveXML()
        {
            // Set default file name for xml
            saveFile.FileName = "new_XML_file.xml";
            if (saveFile.ShowDialog() == true)
            {
                string newFilePath = saveFile.FileName;
                mngr.SaveXML(newFilePath);
            }
        }

        #endregion << END >>
    }
}
