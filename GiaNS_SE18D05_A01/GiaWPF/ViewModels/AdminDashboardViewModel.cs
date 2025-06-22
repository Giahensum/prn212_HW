using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;
using GiaWPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace GiaWPF.ViewModels
{
    public class AdminDashboardViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;

        public AdminDashboardViewModel()
        {
            _customerService = Services.ServiceContainer.GetService<ICustomerService>();
            _roomService = Services.ServiceContainer.GetService<IRoomService>();
            _roomTypeService = Services.ServiceContainer.GetService<IRoomTypeService>();

            // Initialize collections
            Customers = new ObservableCollection<CustomerDto>();
            Rooms = new ObservableCollection<RoomDto>();
            RoomTypes = new ObservableCollection<RoomTypeDto>();

            // Initialize commands
            LoadDataCommand = new RelayCommand(ExecuteLoadData);
            SearchCustomersCommand = new RelayCommand(ExecuteSearchCustomers);
            AddCustomerCommand = new RelayCommand(ExecuteAddCustomer);
            EditCustomerCommand = new RelayCommand(ExecuteEditCustomer, CanExecuteEditCustomer);
            DeleteCustomerCommand = new RelayCommand(ExecuteDeleteCustomer, CanExecuteDeleteCustomer);
            RefreshCommand = new RelayCommand(ExecuteRefresh);
            LogoutCommand = new RelayCommand(ExecuteLogout);

            // Load initial data
            ExecuteLoadData();
        }

        #region Properties

        public ObservableCollection<CustomerDto> Customers { get; set; }
        public ObservableCollection<RoomDto> Rooms { get; set; }
        public ObservableCollection<RoomTypeDto> RoomTypes { get; set; }

        private CustomerDto? _selectedCustomer;
        public CustomerDto? SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private string _customerSearchText = string.Empty;
        public string CustomerSearchText
        {
            get => _customerSearchText;
            set
            {
                SetProperty(ref _customerSearchText, value);
                SearchCustomersCommand.Execute(null);
            }
        }

        private string _selectedTab = "Customers";
        public string SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        // Statistics
        private int _totalCustomers;
        public int TotalCustomers
        {
            get => _totalCustomers;
            set => SetProperty(ref _totalCustomers, value);
        }

        private int _totalRooms;
        public int TotalRooms
        {
            get => _totalRooms;
            set => SetProperty(ref _totalRooms, value);
        }

        private int _totalRoomTypes;
        public int TotalRoomTypes
        {
            get => _totalRoomTypes;
            set => SetProperty(ref _totalRoomTypes, value);
        }

        #endregion

        #region Commands

        public ICommand LoadDataCommand { get; }
        public ICommand SearchCustomersCommand { get; }
        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand LogoutCommand { get; }

        #endregion

        #region Command Implementations

        private void ExecuteLoadData()
        {
            try
            {
                IsBusy = true;
                ClearError();

                // Load customers
                var customers = _customerService.GetActiveCustomers();
                Customers.Clear();
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }

                // Load rooms
                var rooms = _roomService.GetActiveRooms();
                Rooms.Clear();
                foreach (var room in rooms)
                {
                    Rooms.Add(room);
                }

                // Load room types
                var roomTypes = _roomTypeService.GetAllRoomTypes();
                RoomTypes.Clear();
                foreach (var roomType in roomTypes)
                {
                    RoomTypes.Add(roomType);
                }

                // Update statistics
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                SetError($"Failed to load data: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ExecuteSearchCustomers()
        {
            try
            {
                var customers = string.IsNullOrWhiteSpace(CustomerSearchText)
                    ? _customerService.GetActiveCustomers()
                    : _customerService.SearchCustomers(CustomerSearchText);

                Customers.Clear();
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                SetError($"Search failed: {ex.Message}");
            }
        }

        //private void ExecuteAddCustomer()
        //{
        //    var dialog = new Views.CustomerDialog();
        //    if (dialog.ShowDialog() == true && dialog.Customer != null)
        //    {
        //        try
        //        {
        //            _customerService.CreateCustomer(dialog.Customer);
        //            ExecuteRefresh();
        //            MessageBox.Show("Customer added successfully!", "Success",
        //                MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Failed to add customer: {ex.Message}", "Error",
        //                MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}

        //private void ExecuteEditCustomer()
        //{
        //    if (SelectedCustomer == null) return;

        //    var dialog = new Views.CustomerDialog(SelectedCustomer);
        //    if (dialog.ShowDialog() == true && dialog.Customer != null)
        //    {
        //        try
        //        {
        //            _customerService.UpdateCustomer(dialog.Customer);
        //            ExecuteRefresh();
        //            MessageBox.Show("Customer updated successfully!", "Success",
        //                MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Failed to update customer: {ex.Message}", "Error",
        //                MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}



        private void ExecuteAddCustomer()
        {
            try
            {
                var dialog = new Views.CustomerDialog();
                dialog.Owner = Application.Current.MainWindow;

                if (dialog.ShowDialog() == true && dialog.Customer != null)
                {
                    _customerService.CreateCustomer(dialog.Customer);
                    ExecuteRefresh();
                    MessageBox.Show("Customer added successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add customer: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecuteEditCustomer()
        {
            if (SelectedCustomer == null) return;

            try
            {
                var dialog = new Views.CustomerDialog(SelectedCustomer);
                dialog.Owner = Application.Current.MainWindow;

                if (dialog.ShowDialog() == true && dialog.Customer != null)
                {
                    _customerService.UpdateCustomer(dialog.Customer);
                    ExecuteRefresh();
                    MessageBox.Show("Customer updated successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update customer: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private bool CanExecuteEditCustomer()
        {
            return SelectedCustomer != null;
        }

        private void ExecuteDeleteCustomer()
        {
            if (SelectedCustomer == null) return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete customer '{SelectedCustomer.CustomerFullName}'?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _customerService.DeleteCustomer(SelectedCustomer.CustomerID);
                    ExecuteRefresh();
                    MessageBox.Show("Customer deleted successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete customer: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CanExecuteDeleteCustomer()
        {
            return SelectedCustomer != null;
        }

        private void ExecuteRefresh()
        {
            ExecuteLoadData();
        }

        private void ExecuteLogout()
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Close current window and show login
                Application.Current.MainWindow?.Close();
                var loginWindow = new Views.LoginWindow();
                loginWindow.Show();
                Application.Current.MainWindow = loginWindow;
            }
        }

        private void UpdateStatistics()
        {
            TotalCustomers = Customers.Count;
            TotalRooms = Rooms.Count;
            TotalRoomTypes = RoomTypes.Count;
        }

        #endregion
    }
}
