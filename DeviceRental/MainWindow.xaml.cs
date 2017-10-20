using DeviceRentalManagement.Model;
using DeviceRentalManagement.View;
using DeviceRentalManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            //(new Login()).ShowDialog();
        }

    }
}
