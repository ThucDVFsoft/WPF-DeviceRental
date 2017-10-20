using DeviceRentalManagement.ViewModel.PopupViewModel;
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
using System.Windows.Shapes;

namespace DeviceRentalManagement.View.PopupView
{
    /// <summary>
    /// Interaction logic for EditDetailRental.xaml
    /// </summary>
    public partial class EditDetailRentalView : Window
    {
        public EditDetailRentalView(EditDetailRentalViewModel vm)
        {
            InitializeComponent();
            vm.ClosingRequest += (sender, e) => this.Close();
        }
        
    }
}
