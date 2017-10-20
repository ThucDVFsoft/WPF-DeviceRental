using DeviceRentalManagement.Support;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
