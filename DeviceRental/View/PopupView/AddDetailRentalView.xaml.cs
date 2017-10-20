using DeviceRentalManagement.ViewModel.PopupViewModel;
using System.Windows;

namespace DeviceRentalManagement.View.PopupView
{
    /// <summary>
    /// Interaction logic for AddDetailRental.xaml
    /// </summary>
    public partial class AddDetailRentalView : Window
    {
        public AddDetailRentalView(AddDetailRentalViewModel vm)
        {
            InitializeComponent();
            vm.ClosingRequest += (sender, e) => this.Close();
        }
    }
}
