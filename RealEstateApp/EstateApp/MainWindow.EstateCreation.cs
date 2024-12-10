using System.Diagnostics;
using System.Windows;
using Utilities;
using EstateDataDTO;


namespace EstateApp
{
    /// <summary>
    /// Interaction logic for MainWindow for Estate Creation
    /// </summary>
    public partial class MainWindow : Window
    {

        // Creation of estate object //
        private void CreateEstate()
        {
            EstateTypeEnum estateTypeOption = (EstateTypeEnum) CboxEstateType.SelectedItem;
            EstateEnum estateOption = (EstateEnum) CboxEstate.SelectedItem;

            switch (estateTypeOption)
            {
                case EstateTypeEnum.Residential:

                    Residential(estateOption);
                    break;

                case EstateTypeEnum.Commercial:

                    Commercial(estateOption);
                    break;

                case EstateTypeEnum.Institutional:

                    Institutional(estateOption);
                    break;
            }
        }

        private void Residential(EstateEnum option)
        {
            // Fetch object specific data
            int specInput1 = StringHelper.ToInt(textBoxSpecific.Text, out int val) ? val : 0;
            serviceManager.CreateResidential(option, specInput1);
        }

        private void Commercial(EstateEnum option)
        {
            int specInput1 = StringHelper.ToInt(textBoxSpecific.Text, out int val) ? val : 0;
            string specInput2 = textBoxSpecific.Text;
            serviceManager.CreateCommercial(option, specInput1, specInput2);
        }

        private void Institutional(EstateEnum option)
        {
            int specInput1 = StringHelper.ToInt(textBoxSpecific.Text, out int val) ? val : 0;
            serviceManager.CreateInstitutional(option, specInput1);
        }

        // Sets Estate Object information
        private void AddInfo()
        {   // Set info to DTO
            EstateDTO estateDTO = new()
            {
                LegalForm = (LegalFormEnum) CboxLegalForm.SelectedIndex,
                Street = textBoxStreet?.Text ?? string.Empty,
                City = textBoxCity?.Text ?? string.Empty,
                ZipCode = textBoxZipCode?.Text ?? string.Empty,
                Country = (Countries) CboxCountries.SelectedItem,
                Image = pictureBox.Source,
            };

            // Fetch estate type ex. Residential, and category detail info
            EstateTypeEnum category = (EstateTypeEnum)CboxEstateType.SelectedItem;
            int catInput1 = StringHelper.ToInt(textBoxCat.Text, out int value) ? value : 0;

            // Add to estate obj
            serviceManager.AddEstateInfo(estateDTO, category, catInput1);
        }

    }
}