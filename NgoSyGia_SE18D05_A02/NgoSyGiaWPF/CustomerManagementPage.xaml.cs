using BusinessObject;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class CustomerManagementPage : Page
    {
        private readonly CustomerRepository customerRepository; // Fix: Use concrete type
        private List<Customer> customers = [];

        public CustomerManagementPage()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                customers = customerRepository.GetCustomers().ToList();
                dgCustomers.ItemsSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) // Fix: Renamed
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm) || searchTerm == "Search by name, email, or phone...")
            {
                LoadCustomers();
                return;
            }

            try
            {
                var filteredCustomers = customerRepository.SearchCustomers(searchTerm);
                dgCustomers.ItemsSource = filteredCustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) // Fix: Renamed
        {
            var addDialog = new CustomerDialog();
            if (addDialog.ShowDialog() == true)
            {
                var customer = addDialog.Customer;
                try
                {
                    customerRepository.AddCustomer(customer);
                    LoadCustomers();
                    MessageBox.Show("Customer added successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding customer: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e) // Fix: Renamed
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                var updateDialog = new CustomerDialog(selectedCustomer);
                if (updateDialog.ShowDialog() == true)
                {
                    var customer = updateDialog.Customer;
                    try
                    {
                        customerRepository.UpdateCustomer(customer);
                        LoadCustomers();
                        MessageBox.Show("Customer updated successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating customer: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) // Fix: Renamed
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show($"Are you sure you want to delete customer '{selectedCustomer.CustomerFullName}'?",
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        customerRepository.DeleteCustomer(selectedCustomer);
                        LoadCustomers();
                        MessageBox.Show("Customer deleted successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
