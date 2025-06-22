using System.Windows;
using BusinessLogicLayer.DTOs;
using GiaWPF.ViewModels;

namespace GiaWPF.Views
{
    public partial class CustomerDashboard : Window
    {
        public CustomerDashboard(CustomerDto customer)
        {
            InitializeComponent();
            DataContext = new CustomerDashboardViewModel(customer);
        }
    }
}
