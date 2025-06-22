using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;
using GiaWPF.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GiaWPF.ViewModels
{
    public class CustomerDashboardViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;
        private readonly CustomerDto _currentCustomer;

        public CustomerDashboardViewModel(CustomerDto customer)
        {
            _currentCustomer = customer;
            _customerService = Services.ServiceContainer.GetService<ICustomerService>();
            _roomService = Services.ServiceContainer.GetService<IRoomService>();

            // Initialize collections
            AvailableRooms = new ObservableCollection<RoomDto>();

            // Initialize commands
            LoadDataCommand = new RelayCommand(ExecuteLoadData);
            ViewProfileCommand = new RelayCommand(ExecuteViewProfile);
            LogoutCommand = new RelayCommand(ExecuteLogout);

            // Load initial data
            ExecuteLoadData();
        }

        #region Properties

        public CustomerDto CurrentCustomer => _currentCustomer;
        public ObservableCollection<RoomDto> AvailableRooms { get; set; }

        private string _welcomeMessage = string.Empty;
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }

        #endregion

        #region Commands

        public ICommand LoadDataCommand { get; }
        public ICommand ViewProfileCommand { get; }
        public ICommand LogoutCommand { get; }

        #endregion

        #region Command Implementations

        private void ExecuteLoadData()
        {
            try
            {
                IsBusy = true;
                ClearError();

                WelcomeMessage = $"Welcome back, {_currentCustomer.CustomerFullName}!";

                // Load available rooms
                var rooms = _roomService.GetAvailableRooms();
                AvailableRooms.Clear();
                foreach (var room in rooms)
                {
                    AvailableRooms.Add(room);
                }
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

        private void ExecuteViewProfile()
        {
            MessageBox.Show($"Profile Management will be implemented in future versions.\n\n" +
                          $"Current Info:\n" +
                          $"Name: {_currentCustomer.CustomerFullName}\n" +
                          $"Email: {_currentCustomer.EmailAddress}\n" +
                          $"Phone: {_currentCustomer.Telephone}",
                          "Profile Information",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
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

        #endregion
    }
}
