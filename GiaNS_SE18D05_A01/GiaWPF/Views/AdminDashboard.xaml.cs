using System.Windows;
using GiaWPF.ViewModels;

namespace GiaWPF.Views
{
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
            DataContext = new AdminDashboardViewModel();
        }
    }
}
