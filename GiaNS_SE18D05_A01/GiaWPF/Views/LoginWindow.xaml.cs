using System.Windows;
using System.Windows.Controls;
using GiaWPF.ViewModels;
using GiaWPF.Services;
using BusinessLogicLayer.Services;
// Xóa dòng using trùng lặp: using GiaWPF.ViewModels;

namespace GiaWPF.Views
{
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();

            // Configure services first
            ServiceContainer.ConfigureServices();

            _viewModel = new LoginViewModel();
            DataContext = _viewModel;

            _viewModel.LoginSuccess += OnLoginSuccess;

            // Handle password binding
            PasswordBox.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _viewModel.Password = passwordBox.Password;
            }
        }

        private void OnLoginSuccess(object? sender, AuthenticationResult result)
        {
            if (result.Role == UserRole.Admin)
            {
                var adminDashboard = new Views.AdminDashboard();
                adminDashboard.Show();
                this.Close();
            }
            else if (result.Customer != null)
            {
                var customerDashboard = new Views.CustomerDashboard(result.Customer);
                customerDashboard.Show();
                this.Close();
            }
        }





        protected override void OnClosed(EventArgs e)
        {
            ServiceContainer.Dispose();
            base.OnClosed(e);
        }
    }
}
