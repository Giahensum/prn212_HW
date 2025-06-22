using System.Windows;
using BusinessLogicLayer.DTOs;
using GiaWPF.ViewModels;

namespace GiaWPF.Views
{
    public partial class CustomerDialog : Window
    {
        private readonly CustomerDialogViewModel _viewModel;

        public CustomerDto? Customer => _viewModel.DialogResult ? _viewModel.Customer : null;

        public CustomerDialog(CustomerDto? customer = null)
        {
            InitializeComponent();

            _viewModel = new CustomerDialogViewModel(customer);
            DataContext = _viewModel;

            _viewModel.RequestClose += OnRequestClose;
        }

        private void OnRequestClose(object? sender, EventArgs e)
        {
            DialogResult = _viewModel.DialogResult;
            Close();
        }
    }
}
