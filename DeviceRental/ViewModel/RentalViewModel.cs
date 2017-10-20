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
        private readonly RentalRepository repository;
        Expression<Func<DeviceRental, bool>> StatusFunc;
        Expression<Func<DeviceRental, bool>> SearchFunc;

        public DeviceRentalViewModel() 
        {
            repository = new RentalRepository(EntitiesManager.GetEntitiesInstance());
            CbStatusSelectedItem = Const.RentalStatus[0];
            GridSelectedIndex = 0;
            EditCommand = new RelayCommand<string>(EditRentalMethod);
            ReturnCommand = new RelayCommand<string>(ReturnRentalMethod);
            AddNewCommand = new RelayCommand<string>(AddNewRentalMethod);
        }

        private ObservableCollection<DeviceRentalModel> deviceRentalModels;
        public ObservableCollection<DeviceRentalModel> DeviceRentalModels
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

        private int gridSelectedIndex;
        public int GridSelectedIndex
        {
            get { return gridSelectedIndex; }
            set
            {
                gridSelectedIndex = value;
                OnPropertyChanged();
            }
        }

        private DeviceRentalModel gridSelectedItem;
        public DeviceRentalModel GridSelectedItem
        {
            get { return gridSelectedItem; }
            set
            {
                gridSelectedItem = value;
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
            var editDetailRentalViewModel = new EditDetailRentalViewModel(GridSelectedItem);
            var editDetailRentalWindow = new EditDetailRentalView(editDetailRentalViewModel);
            editDetailRentalWindow.DataContext = editDetailRentalViewModel;
            editDetailRentalWindow.ShowDialog();
            RefreshData(StatusFunc, SearchFunc);
        }

        private void ReturnRentalMethod(string type)
        {
            var rental = repository.DbSet.Find(GridSelectedItem.SId);
            rental.RentalStatus = 2;
            rental.RentalDate = DateTime.Now;
            repository.Update(rental);
            RefreshData(StatusFunc, SearchFunc);
        }

        private void AddNewRentalMethod(string type)
        {
            //var addDetailRentalViewModel = new AddDetailRentalViewModel(GridSelectedItem);
            var addDetailRentalWindow = new AddDetailRentalView();
            //editDetailRentalWindow.DataContext = editDetailRentalViewModel;
            addDetailRentalWindow.ShowDialog();
        }
        private void SearchFilter()
        {
            SearchFunc = s => s.Employee.Name.Contains(SearchText) 
                                                                || s.Device.Name.Contains(SearchText);
            RefreshData(StatusFunc, SearchFunc);
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

            RefreshData(StatusFunc, SearchFunc);
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

        private async Task RefreshData(Expression<Func<DeviceRental, bool>> StatusFunc, Expression<Func<DeviceRental, bool>> SearchFunc)
        {
            //ThrobberVisible = Visibility.Visible;

            var temp = GridSelectedItem;

            //await Task.Delay(3000);
            var deviceRentals = await repository.GetListAsync(StatusFunc, SearchFunc);
            var deviceRentalModels = deviceRentals.Select(s => new DeviceRentalModel(s)).ToList();
            DeviceRentalModels = new ObservableCollection<DeviceRentalModel>(deviceRentalModels);

            var temp2 = DeviceRentalModels.Where(s => s.SId == temp.SId).ToList();
            if (temp2.Any()) GridSelectedItem = temp2[0];
            else GridSelectedItem = temp;

            //ThrobberVisible = Visibility.Collapsed;
        }
    }
}
