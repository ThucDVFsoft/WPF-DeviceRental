using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace DeviceRentalManagement.View
{
    /// <summary>
    /// Interaction logic for Rental.xaml
    /// </summary>
    public partial class RentalView : UserControl
    {
        private CollectionView view;
        public RentalView()
        {
            InitializeComponent();
            cbStatus.ItemsSource = Const.RentalStatus;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (view == null)
            {
                view = (CollectionView)CollectionViewSource.GetDefaultView(RentalDeviceDataGrid.ItemsSource);
                if (view != null) view.Filter = FilterMethod;
            }
        }

        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Refresh();
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            var selectedItem = RentalDeviceDataGrid.SelectedItem;

            if (view != null) view.Refresh();
            else
            {
                view = (CollectionView)CollectionViewSource.GetDefaultView(RentalDeviceDataGrid.ItemsSource);
                if (view != null) view.Filter = FilterMethod;
            }

            if (selectedItem != null) RentalDeviceDataGrid.SelectedItem = selectedItem;
        }

        private bool FilterMethod(object item)
        {
            return (TextFilter(item, tbSearch.Text) 
                    && StatusFilter(item, cbStatus.Text));
        }

        private bool TextFilter(object item, string text)
        {
            if (String.IsNullOrEmpty(tbSearch.Text))
                return true;

            return ((item as DeviceRental).Employee.Name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0
                    || (item as DeviceRental).Device.Name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool StatusFilter(object item, string status)
        {
            int index = cbStatus.SelectedIndex;
            var rental = item as DeviceRental;
            if (index == 0 || rental == null) return true;
            if (rental.RentalStatus == index) return true;
            return false;
        }
    }
}
