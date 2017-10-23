using DeviceRentalManagement.Support;
using System.Windows.Controls;

namespace DeviceRentalManagement.View
{
    /// <summary>
    /// Interaction logic for Rental.xaml
    /// </summary>
    public partial class RentalView : UserControl
    {
        public RentalView()
        {
            InitializeComponent();
            cbStatus.ItemsSource = Const.RentalStatus;
        }
    }
}
