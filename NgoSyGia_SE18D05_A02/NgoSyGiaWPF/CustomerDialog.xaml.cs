using BusinessObject;
using System.Windows;

namespace NgoSyGiaWPF
{
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; set; }
        private readonly bool isUpdate = false;

        public CustomerDialog()
        {
            InitializeComponent();
            Customer = new Customer { EmailAddress = "" }; // Fix: Initialize required property
        }

        public CustomerDialog(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            isUpdate = true;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            lblTitle.Text = "Update Customer";
            txtFullName.Text = Customer.CustomerFullName;
            txtEmail.Text = Customer.EmailAddress;
            txtPhone.Text = Customer.Telephone;
            dpBirthday.SelectedDate = Customer.CustomerBirthday;
            txtPassword.Password = Customer.Password ?? "";
            chkStatus.IsChecked = Customer.CustomerStatus == 1;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if (!isUpdate)
                {
                    Customer = new Customer { EmailAddress = txtEmail.Text.Trim() };
                }

                Customer.CustomerFullName = txtFullName.Text.Trim();
                Customer.EmailAddress = txtEmail.Text.Trim();
                Customer.Telephone = txtPhone.Text.Trim();
                Customer.CustomerBirthday = dpBirthday.SelectedDate;
                Customer.Password = txtPassword.Password; // Lấy password từ PasswordBox
                Customer.CustomerStatus = (byte)(chkStatus.IsChecked == true ? 1 : 0);

                DialogResult = true;
                Close();
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e) // Fix: Renamed from btnCancel_Click
        {
            DialogResult = false;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email address is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // VALIDATION CHO PASSWORD
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
