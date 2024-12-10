using System.Diagnostics;
using System.Windows;
using ModelsLibrary.Models;



namespace EstateApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        /// <summary>
        /// Adds Estate to ListVIew
        /// </summary>
        /// <param name="estate"> Estate Object </param>
        public void AddItemtoListView(Estate estate)
        {
            //ListViewEstates.Items.Add(estate);
            estates.Add(estate);
        }

        public void UpdateListView()
        {
            estates.Clear();    // Clear current estates in ListView

            foreach (Estate e in serviceManager.GetListEstates())
            {
                AddItemtoListView(e);   // Add each new Estate to ListView
            }
        }

        /// <summary>
        /// Loads ComboBox items for Estate and Country
        /// </summary>
        private void LoadCboxEstateAndCountry()
        {
            EstateTypeEnum opt = (EstateTypeEnum)CboxEstateType.SelectedIndex;

            switch (opt)
            {
                case EstateTypeEnum.Residential:
                    LoadResidentialEstates();
                    break;
                case EstateTypeEnum.Commercial:
                    LoadCommercialEstates();
                    break;
                case EstateTypeEnum.Institutional:
                    LoadInstitutionalEstates();
                    break;
            }

            // Load Countries
            CboxCountries.ItemsSource = Enum.GetValues(typeof(Countries));
        }

        // Changes label text of Category type input
        private void ChangeCategoryLabel()
        {
            EstateTypeEnum type = (EstateTypeEnum)CboxEstateType.SelectedIndex;

            string new_text = type switch
            {
                EstateTypeEnum.Residential => "Num Rooms",
                EstateTypeEnum.Commercial => "Sq. Meters",
                EstateTypeEnum.Institutional => "Facilities",
                _ => "Category",
            };
            labelCategory.Content = new_text;
        }

        #region << Loading Estate Types into ComboBox >>

        private void LoadResidentialEstates()
        {
            CboxEstate.Items.Clear();

            var resEstates = Enum.GetValues(typeof(EstateEnum))
                        .Cast<EstateEnum>().Where(e =>
                        e == EstateEnum.Apartment ||
                        e == EstateEnum.Villa ||
                        e == EstateEnum.Townhouse);

            foreach (var estate in resEstates)
            {
                CboxEstate.Items.Add(estate);
            }
        }

        private void LoadCommercialEstates()
        {
            CboxEstate.Items.Clear();

            var resEstates = Enum.GetValues(typeof(EstateEnum))
                        .Cast<EstateEnum>().Where(e =>
                        e == EstateEnum.Hotel ||
                        e == EstateEnum.Shop ||
                        e == EstateEnum.Warehouse ||
                        e == EstateEnum.Factory);

            foreach (var estate in resEstates)
            {
                CboxEstate.Items.Add(estate);
            }
        }

        private void LoadInstitutionalEstates()
        {
            CboxEstate.Items.Clear();

            var resEstates = Enum.GetValues(typeof(EstateEnum))
                        .Cast<EstateEnum>().Where(e =>
                        e == EstateEnum.Hospital ||
                        e == EstateEnum.School ||
                        e == EstateEnum.University);

            foreach (var estate in resEstates)
            {
                CboxEstate.Items.Add(estate);
            }
        }

        #endregion

        #region << Enable/Disable/Clear TextBoxes & Buttons etc. >>

        // Empties and clears all textBoxes and ComboBoxes
        private void EmptyInputBoxes()
        {
            //Estate Type
            CboxEstateType.SelectedIndex = -1;
            CboxLegalForm.SelectedIndex = -1;
            CboxEstate.SelectedIndex = -1;
            CboxSortType.SelectedIndex = -1;
            // Address 
            textBoxStreet.Clear();
            textBoxCity.Clear();
            textBoxZipCode.Clear();
            CboxCountries.SelectedIndex = -1;
            // Details 
            textBoxCat.Clear();
            textBoxSpecific.Clear();
        }

        // Enables/Disables all input boxes, except first -> Type of Estate
        private void EnableBoxes(bool e)
        {
            CboxLegalForm.IsEnabled = e;
            CboxEstate.IsEnabled = e;
            GboxAddress.IsEnabled = e;
            GboxDetails.IsEnabled = e;
        }

        // Enables/Disables buttons
        private void EnableButtons(bool e)
        {
            BtnAdd.IsEnabled = e;
            BtnDelete.IsEnabled = e;
            BtnEdit.IsEnabled = e;
        }

        #endregion << END >>


        // Dictionary for the objects specific attribute label for when setting the Specific label txt
        private readonly Dictionary<EstateEnum, string> labelMap = new()
        {
            { EstateEnum.Apartment, "On Floor" },
            { EstateEnum.Villa, "Sq Meters" },
            { EstateEnum.Townhouse, "Num of floors" },

            { EstateEnum.Factory, "Factory Type" },
            { EstateEnum.Hotel, "Num of Rooms" },
            { EstateEnum.Warehouse, "Capacity m3" },
            { EstateEnum.Shop, "Factory Type" },

            { EstateEnum.School, "Num of Classrooms" },
            { EstateEnum.Hospital, "Num of Beds" },
            { EstateEnum.University, "Num of Buildings" },
        };

    }
}