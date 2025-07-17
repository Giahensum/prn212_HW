using Microsoft.Extensions.Configuration;
using Repository;
using System.Windows;
using System.IO;

namespace NgoSyGiaWPF
{
    public partial class MainWindow : Window
    {
        private readonly CustomerRepository customerRepository;
        private readonly IConfiguration configuration;

        public MainWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration = builder.Build();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Get configuration values with fallback
                var adminEmail = configuration["AdminAccount:Email"] ?? "admin@FUMiniHotelSystem.com";
                var adminPassword = configuration["AdminAccount:Password"] ?? "@@abc123@@";

                // Check admin account
                if (email == adminEmail && password == adminPassword)
                {
                    var adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                    return;
                }

                // Check customer account
                var customer = customerRepository.GetCustomerByEmail(email);
                // Trong BtnLogin_Click method, thay đổi customer login logic:
                if (customer != null && customer.Password == password)
                {
                    if (customer.CustomerStatus == 1)
                    {
                        var customerWindow = new CustomerWindow(customer);
                        customerWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your account is inactive. Please contact administrator.",
                            "Account Inactive", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }


                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
