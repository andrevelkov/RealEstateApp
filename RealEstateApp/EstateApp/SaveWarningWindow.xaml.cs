using System.Windows;


namespace EstateApp
{
    /// <summary>
    /// Interaction logic for SaveWarningWindow.xaml
    /// </summary>
    public partial class SaveWarningWindow : Window
    {
        public SaveWarningWindow()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
