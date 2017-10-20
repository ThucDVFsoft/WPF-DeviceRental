using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DeviceRentalManagement.Model;
using DeviceRentalManagement.ModelEF;
using DeviceRentalManagement.Support;
using DeviceRentalManagement.ModelEF.Repository;
using DeviceRentalManagement.View.PopupView;
using DeviceRentalManagement.ViewModel.PopupViewModel;
using System.Data.Entity;
using System.Windows;
using System.Threading;

namespace DeviceRentalManagement.ViewModel
{
    class DeviceRentalViewModel : BaseViewModel
    {
        private Expression<Func<DeviceRental, bool>> StatusFunc;
        private Expression<Func<DeviceRental, bool>> SearchFunc;
        private ObservableCollection<DeviceRental> reserveModels;

        public DeviceRentalViewModel() 
        {
            DeviceRentalModels = GetRentals();
            reserveModels = DeviceRentalModels;
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
        }
        private void SearchFilter()
        {
            SearchFunc = s => s.Employee.Name.Contains(SearchText) 
                                                                || s.Device.Name.Contains(SearchText);
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
            var selected = SelectedItem;
            
            if (reserveModels == null) return;
            if (SearchFunc == null && StatusFunc == null)
            {
                DeviceRentalModels = reserveModels;
            }
            else if (StatusFunc == null)
            {
                DeviceRentalModels = new ObservableCollection<DeviceRental>(reserveModels.Where(SearchFunc.Compile()));
            }
            else if (SearchFunc == null)
            {
                DeviceRentalModels = new ObservableCollection<DeviceRental>(reserveModels.Where(StatusFunc.Compile()));
            }
            else
            {
                DeviceRentalModels = new ObservableCollection<DeviceRental>(reserveModels.Where(StatusFunc.Compile())
                        .Where(SearchFunc.Compile()));
            }
            UpdateSelectedItem(selected);
        }

        private async Task RefreshData(Expression<Func<DeviceRental, bool>> StatusFunc, Expression<Func<DeviceRental, bool>> SearchFunc)
        {
            //ThrobberVisible = Visibility.Visible;
            var selected = SelectedItem;

            //await Task.Delay(3000);
            var deviceRentals = await rentalRepository.GetListAsync(StatusFunc, SearchFunc);
            DeviceRentalModels = new ObservableCollection<DeviceRental>(deviceRentals);
            reserveModels = DeviceRentalModels;

            UpdateSelectedItem(selected);
            //ThrobberVisible = Visibility.Collapsed;
        }

        private void UpdateSelectedItem(DeviceRental selected)
        {
            try
            {
                SelectedItem = DeviceRentalModels.First(s => s.SId == selected.SId);
            }
            catch
            {
                if (DeviceRentalModels.Any())
                    SelectedItem = DeviceRentalModels[0];
            }
        }
    }
}
