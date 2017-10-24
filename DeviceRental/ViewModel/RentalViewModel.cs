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
                StatusFilter();
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
                SearchFilter();
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
            editDetailRentalWindow.ShowDialog();
            RefreshData(StatusFunc, SearchFunc);
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
            addDetailRentalWindow.ShowDialog();
            RefreshData(StatusFunc, SearchFunc);
            if (addDetailRentalViewModel.newRental != null)
            {
                SelectedItem = addDetailRentalViewModel.newRental;
            }
        }
        private void SearchFilter()
        {
            SearchFunc = s => s.Employee.Name.ToLower().Contains(SearchText.ToLower())
                                                                || s.Device.Name.ToLower().Contains(SearchText.ToLower());
            Filter(StatusFunc, SearchFunc);
        }

        private void StatusFilter()
        {
            int rentalStatus = 0;
            if (CbStatusSelectedItem == "Not Return") rentalStatus = 1;
            else if (CbStatusSelectedItem == "Returned") rentalStatus = 2;

            StatusFunc = null;
            if (rentalStatus == 1 || rentalStatus == 2)
            {
                StatusFunc = s => s.RentalStatus == rentalStatus;
            }

            Filter(StatusFunc, SearchFunc);
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

        private void Filter(Expression<Func<DeviceRental, bool>> StatusFunc, Expression<Func<DeviceRental, bool>> SearchFunc)
        {
            if (preserveModels == null) return;

            if (SearchFunc == null && StatusFunc == null)
            {
                DeviceRentalModels = preserveModels;
            }
            else if (StatusFunc == null)
            {
                DeviceRentalModels = new ObservableCollection<DeviceRental>(preserveModels.Where(SearchFunc.Compile()));
            }
            else if (SearchFunc == null)
            {
                DeviceRentalModels = new ObservableCollection<DeviceRental>(preserveModels.Where(StatusFunc.Compile()));
            }
            else
            {
                DeviceRentalModels = new ObservableCollection<DeviceRental>(preserveModels.Where(StatusFunc.Compile())
                        .Where(SearchFunc.Compile()));
            }
            UpdateSelectedItem();
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

        private void UpdateSelectedItem()
        {
            try
            {
                SelectedItem = DeviceRentalModels.First(s => s.SId == preserveItem.SId);
            }
            catch
            {
                if (DeviceRentalModels.Any())
                {
                    preserveItem = SelectedItem;
                    SelectedItem = DeviceRentalModels[0];
                }
            }
        }
    }
}
