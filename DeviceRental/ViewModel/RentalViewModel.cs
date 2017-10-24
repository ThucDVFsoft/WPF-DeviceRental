using System;
using System.Linq;
using System.Windows;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;
using DeviceRentalManagement.View.PopupView;
using DeviceRentalManagement.ViewModel.PopupViewModel;

namespace DeviceRentalManagement.ViewModel
{
    class DeviceRentalViewModel : BaseViewModel
    {
        private Expression<Func<DeviceRental, bool>> StatusFunc;
        private Expression<Func<DeviceRental, bool>> SearchFunc;
        private ObservableCollection<DeviceRental> preserveModels;
        private DeviceRental preserveItem;

        public DeviceRentalViewModel() 
        {
            DeviceRentalModels = GetRentals();
            preserveModels = DeviceRentalModels;
            CbStatusSelectedItem = Const.RentalStatus[0];
            SelectedInd = 0;
            EditCommand = new RelayCommand<string>(EditRentalMethod);
            ReturnCommand = new RelayCommand<string>(ReturnRentalMethod);
            AddNewCommand = new RelayCommand<string>(AddNewRentalMethod);
        }

        private ObservableCollection<DeviceRental> deviceRentalModels;
        public ObservableCollection<DeviceRental> DeviceRentalModels
        {
            get { return deviceRentalModels; }
            set
            {
                deviceRentalModels = value;
                OnPropertyChanged();
            }
        }

        private string cbStatusSelectedItem;
        public string CbStatusSelectedItem
        {
            get { return cbStatusSelectedItem; }
            set
            {
                cbStatusSelectedItem = value;
                OnPropertyChanged();
            }
        }

        private int selectedInd;
        public int SelectedInd
        {
            get { return selectedInd; }
            set
            {
                selectedInd = value;
                OnPropertyChanged();
            }
        }

        private DeviceRental selectedItem;
        public DeviceRental SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        private string note;
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<string> EditCommand { get; private set; }
        public RelayCommand<string> ReturnCommand { get; private set; }
        public RelayCommand<string> AddNewCommand { get; private set; }
        private void EditRentalMethod(string type)
        {
            var editDetailRentalViewModel = new EditDetailRentalViewModel(SelectedItem);
            var editDetailRentalWindow = new EditDetailRentalView(editDetailRentalViewModel);
            editDetailRentalWindow.DataContext = editDetailRentalViewModel;
            if (editDetailRentalWindow.ShowDialog() == true)
            {
                RefreshData(StatusFunc, SearchFunc);
            }
        }

        private void ReturnRentalMethod(string type)
        {
            var rental = rentalRepository.DbSet.Find(SelectedItem.SId);
            rental.RentalStatus = 2;
            rental.RentalDate = DateTime.Now;
            rentalRepository.Update(rental);
            RefreshData(StatusFunc, SearchFunc);
        }

        private void AddNewRentalMethod(string type)
        {
            var addDetailRentalViewModel = new AddDetailRentalViewModel();
            var addDetailRentalWindow = new AddDetailRentalView(addDetailRentalViewModel);
            addDetailRentalWindow.DataContext = addDetailRentalViewModel;
            if (addDetailRentalWindow.ShowDialog() == true)
            {
                RefreshData(StatusFunc, SearchFunc);
                if (addDetailRentalViewModel.newRental != null)
                {
                    SelectedItem = addDetailRentalViewModel.newRental;
                }
            }
        }

        private Visibility throbberVisible = Visibility.Visible;
        public Visibility ThrobberVisible
        {
            get { return throbberVisible; }
            set
            {
                throbberVisible = value;
                OnPropertyChanged();
            }
        }

        private void RefreshData(Expression<Func<DeviceRental, bool>> StatusFunc, Expression<Func<DeviceRental, bool>> SearchFunc)
        {
            //ThrobberVisible = Visibility.Visible;
            //await Task.Delay(3000);
            preserveItem = SelectedItem;
            var deviceRentals = rentalRepository.GetList(StatusFunc, SearchFunc);
            DeviceRentalModels = new ObservableCollection<DeviceRental>(deviceRentals);
            preserveModels = DeviceRentalModels;
            SelectedItem = preserveItem;
            //ThrobberVisible = Visibility.Collapsed;
        }
    }
}
