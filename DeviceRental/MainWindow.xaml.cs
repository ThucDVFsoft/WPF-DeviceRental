using DeviceRentalManagement.ViewModel;
using System.Windows;

namespace DeviceRentalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
            //this.Loaded += OnLoaded;
            //ContentControl.Content = new RentalView();
            //var dbContext = new Entities();
            DataContext = new MainWindowViewModel();
        }
        //public void OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    //(new Login()).ShowDialog();
        //}

    }
}
