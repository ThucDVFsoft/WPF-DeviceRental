using DeviceRental.Model;
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

namespace DeviceRental.View
{
    /// <summary>
    /// Interaction logic for Rental.xaml
    /// </summary>
    public partial class Rental : UserControl
    {
        public Rental()
        {
            InitializeComponent();
            var dbContext = new Entities();
            var blogs = dbContext.Employees.ToList();

            RentalDeviceDataGrid.ItemsSource = blogs;
        }
    }
}
