using BusinessLogicLayer.DTOs;
using GiaWPF.Commands;
using System.Windows.Input;

namespace GiaWPF.ViewModels
{
    public class CustomerDialogViewModel : BaseViewModel
    {
        public CustomerDialogViewModel(CustomerDto? customer = null)
        {
            Customer = customer != null ? CloneCustomer(customer) : new CustomerDto
            {
                CustomerBirthday = DateTime.Now.AddYears(-25),
                CustomerStatus = 1
            };

            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
            CancelCommand = new RelayCommand(ExecuteCancel);

            IsEditMode = customer != null;
            Title = IsEditMode ? "Edit Customer" : "Add New Customer";
        }

        #region Properties

        public CustomerDto Customer { get; set; }
        public bool IsEditMode { get; }
        public string Title { get; }
        public bool DialogResult { get; set; }

        #endregion

        #region Commands

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler? RequestClose;

        #endregion

        #region Command Implementations

        private bool CanExecuteSave()
        {
            return !string.IsNullOrWhiteSpace(Customer.CustomerFullName) &&
                   !string.IsNullOrWhiteSpace(Customer.EmailAddress) &&
                   !string.IsNullOrWhiteSpace(Customer.Password) &&
                   Customer.CustomerBirthday < DateTime.Now.AddYears(-18);
        }

        private void ExecuteSave()
        {
            try
            {
                ClearError();

                // Basic validation
                if (string.IsNullOrWhiteSpace(Customer.CustomerFullName))
                {
                    SetError("Full name is required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Customer.EmailAddress))
                {
                    SetError("Email is required");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Customer.Password))
                {
                    SetError("Password is required");
                    return;
                }

                if (Customer.CustomerBirthday >= DateTime.Now.AddYears(-18))
                {
                    SetError("Customer must be at least 18 years old");
                    return;
                }

                DialogResult = true;
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                SetError($"Validation failed: {ex.Message}");
            }
        }

        private void ExecuteCancel()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Helper Methods

        #region Helper Methods

        private static CustomerDto CloneCustomer(CustomerDto original)
        {
            return new CustomerDto
            {
                CustomerID = original.CustomerID,
                CustomerFullName = original.CustomerFullName,
                Telephone = original.Telephone,
                EmailAddress = original.EmailAddress,
                CustomerBirthday = original.CustomerBirthday,
                CustomerStatus = original.CustomerStatus,
                Password = original.Password
            };
        }

        #endregion


        #endregion
    }
}
