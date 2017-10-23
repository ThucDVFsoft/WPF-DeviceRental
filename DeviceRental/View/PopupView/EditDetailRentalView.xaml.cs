using DeviceRentalManagement.ViewModel.PopupViewModel;
using System.Windows;

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
