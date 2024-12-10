using ModelsLibrary.Models;
using ModelsLibrary;
using ServiceL;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

// Test files available within project "EstateAppWPF/SaveFiles/" folder
// *View 'all file types' to show files

namespace EstateApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Estate> estates;      // Observable Collection for ListView
        private readonly ServiceManager serviceManager = new();
        private readonly ButtonActionsUI btnActions;
        private Estate? selectedEstate = null;
        private bool IsDataSaved = true;

        public MainWindow()
        {
            InitializeComponent();

            estates = [];
            btnActions = new ButtonActionsUI(this, serviceManager);
            ListViewEstates.ItemsSource = estates;

            MainWindow_Load();
        }

        public void MainWindow_Load()
        {
            InitializeWindow();

            // load the list view from DB
            List<Estate> list = serviceManager.GetListFromDB();
            foreach (var e in list)
            {
                estates.Add(e);
            }
            
            // CREATE TEST ESTATE OBJECTS
            //TestCreateEstate();
            //TestCreateEstate2();
        }

        #region << HardCoded Estate Obj, Testing >>
        private void TestCreateEstate()
        {
            // Hardcoded values for testing
            CboxEstateType.SelectedItem = EstateTypeEnum.Residential;
            CboxEstate.SelectedItem = EstateEnum.Villa;
            textBoxSpecific.Text = "3";                               // Specific input for the Villa
            textBoxStreet.Text = "123 Main St";                       // Address inputs
            textBoxCity.Text = "Springfield";
            textBoxZipCode.Text = "12345";
            CboxCountries.SelectedItem = Countries.Sverige;
            CboxLegalForm.SelectedIndex = (int)LegalFormEnum.Rental;
            textBoxCat.Text = "5";                                    // Number of rooms for Residential

            // Simulate button click
            BtnAdd_Click(null!, null!);
        }

        //private void TestCreateEstate2()
        //{
        //    // Hardcoded values for testing
        //    CboxEstateType.SelectedItem = EstateTypeEnum.Commercial;
        //    CboxEstate.SelectedItem = EstateEnum.Shop;
        //    textBoxSpecific.Text = "2";                               // Specific input for the Villa
        //    textBoxStreet.Text = "123 Street";                       // Address inputs
        //    textBoxCity.Text = "Hollywood";
        //    textBoxZipCode.Text = "12345";
        //    CboxCountries.SelectedItem = Countries.Sverige;
        //    CboxLegalForm.SelectedIndex = (int)LegalFormEnum.Ownership;
        //    textBoxCat.Text = "500";

        //    // Simulate button click
        //    BtnAdd_Click(null, null);
        //}
        #endregion << END >>

        private void InitializeWindow()
        {
            // Load ComboBox Items
            CboxEstateType.ItemsSource = Enum.GetValues(typeof(EstateTypeEnum));
            CboxLegalForm.ItemsSource = Enum.GetValues(typeof(LegalFormEnum));
            CboxSortType.ItemsSource = Enum.GetValues(typeof(LegalFormEnum));
            // Clear and disable buttons and boxes
            EmptyInputBoxes();
            EnableBoxes(false);
            EnableButtons(false);
            BtnLoadImg.IsEnabled = false;
        }

        // Restarts the Application
        private static void ReInitializeProgram()
        {
            System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            App.Current.Shutdown();
        }

        #region << ListView >>

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewEstates.SelectedItem != null)
            {
                BtnDelete.IsEnabled = true;
                BtnEdit.IsEnabled = true;

                // Fetch the selected Estate object
                selectedEstate = ListViewEstates.SelectedItem as Estate;

                // Display Estate information and image
                labelInfo.Text = selectedEstate?.DisplayDetails();
                pictureBox.Source = selectedEstate?.Image;
            }
        }

        // If focus lost from list view
        private void ListView_Leave(object sender, EventArgs e)
        {
            labelInfo.Text = string.Empty;
            pictureBox.Source = null;
        }

        // If focus gained from list view
        private void ListView_Enter(object sender, EventArgs e)
        {
            BtnAdd.IsEnabled = false;
            BtnLoadImg.IsEnabled = false;
            EmptyInputBoxes();
        }

        #endregion << END >>

        #region << ComboBoxes >>

        private void CboxEstateType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Reset the Estate input -> makes it blank
            CboxEstate.SelectedIndex = -1;
            // Loads Estates based on selected Estate type
            LoadCboxEstateAndCountry();
            CboxLegalForm.IsEnabled = true;

            // Clear previously displayed txt and img
            labelInfo.Text = null;
            pictureBox.Source = null;

            // Change the Category input label accordingly
            ChangeCategoryLabel();
        }

        private void CboxLegalForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If comboBox empty, disable buttons and other input boxes
            // else enable and clear previously viewed text
            if (CboxLegalForm.SelectedIndex == -1)
            {
                EnableBoxes(false);
                EnableButtons(false);
                BtnLoadImg.IsEnabled = false;
            }
            else
            {
                EnableButtons(false);
                CboxEstate.IsEnabled = true;
            }
        }

        private void CboxEstate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Enables input boxes and buttons
            EnableBoxes(true);
            BtnAdd.IsEnabled = true;
            BtnLoadImg.IsEnabled = true;
            CboxCountries.SelectedIndex = 0;

            // Update the Label for the specific Object information
            if (CboxEstate.SelectedIndex != -1)
            {
                EstateEnum estate = (EstateEnum) CboxEstate.SelectedItem;

                if (labelMap.TryGetValue(estate, out string? label))
                {
                    labelSpecific.Content = label;
                }
                else
                {
                    labelSpecific.Content = "Specific";
                }
            }
        }

        #endregion << END >>

        #region << ButtonClicks >>

        // Create the Estate object
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateEstate();                                // Creates the Estate Object
            AddInfo();                                     // Adds information to Estate Obj
            serviceManager.AddToDb();                      // Adds estate to Database
            AddItemtoListView(serviceManager.GetEstate()); // Update List View
            EmptyInputBoxes();                             // Clear Inputs
            pictureBox.Source = null;
            IsDataSaved = false;                           // Update Flag
        }

        // Enables edit of selected estate
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEstate != null)
            {
                btnActions.Edit(selectedEstate);
            }
        }

        // Saves estate information after edit and updates UI
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEstate != null)
            {
                btnActions.SaveValues(selectedEstate);   // Saves new inputs to Estate
                selectedEstate = null;                   // Reset attribute after save
            }

            // Clear all inputs
            EmptyInputBoxes();
            pictureBox.Source = null;
            BtnSave.Visibility = Visibility.Hidden; // Hide Save button

            // Enable Estate Type CBox and other buttons
            GboxEstate.IsEnabled = true;
            CboxEstateType.IsEnabled = true;
            BtnDelete.IsEnabled = true;
            BtnEdit.IsEnabled = true;
            ListViewEstates.IsEnabled = true;

            IsDataSaved = false;    //Update Flag
        }

        // Deletes Estate obj
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEstate != null)
            {
                // Remove estate from Estate Manager list
                if (selectedEstate is Estate estate)
                {
                    serviceManager.RemoveEstate(estate);
                }

                // Refresh the ListView
                estates.Remove(selectedEstate);
                labelInfo.Text = string.Empty;
            }
            else { Console.WriteLine("Selected Item is null"); }
        }

        // Loads image to pictureBox and sets it to Estate Obj
        private void BtnLoadImg_Click(object sender, RoutedEventArgs e)
        {
            btnActions.LoadImage();
        }

        // Sorts and displays Estates with a specific Legal Form
        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            // Fetch list of Estate objects with the selected Legal Form
            List<Estate> list = serviceManager.GetListSortedEstates((LegalFormEnum) CboxSortType.SelectedIndex);
            // Clear current items and add new from sorted estates
            estates.Clear();
            
            foreach (var item in list)
            {
                AddItemtoListView(item);
            }
        }

        // Restores ListView Estates to previous list of obj
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            List<Estate> list = serviceManager.GetListEstates();
            // Clear current items and add previous estates from the list
            estates.Clear();
            foreach (var item in list)
            {
                AddItemtoListView(item);
            }
        }

        #endregion << END >>

        #region << MenuStrip Option Clicks >>

        // ReInitializes the program if data is saved, else -> prompt
        private void MenuFileNew_Click(object sender, RoutedEventArgs e)
        {
            if (IsDataSaved) // if data is saved to file
            {
                ReInitializeProgram();
            }
            else
            {
                SaveWarningWindow window = new()
                {
                    Owner = this
                };

                var result = window.ShowDialog();

                if (result == true)
                {
                    ReInitializeProgram();
                }
                else if (result == false)
                {
                    // Nothing, return
                    return;
                }
            }
        }

        // Opens and loads user selected JSON file
        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            btnActions.Open();
            IsDataSaved = true;
        }

        // Saves opened file, else create new json file and save
        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
            // Save Objects to JSON
            btnActions.Save_Json();
        }

        // Saves As , saves and creates new file
        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            btnActions.SaveAs_Json();
        }

        // Terminates the application.
        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuFileSaveXML_Click(object sender, RoutedEventArgs e)
        {
            btnActions.SaveXML();
        }

        #endregion << END >>

    }
}