using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadCustomerManagement();
        }

        private void LoadCustomerManagement()
        {
            CustomerFrame.Content = new CustomerManagementPage();
            txtStatus.Text = "Customer Management loaded";
        }

        private void LoadRoomManagement()
        {
            try
            {
                RoomFrame.Content = new RoomManagementPage();
                txtStatus.Text = "Room Management loaded";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Room Management: {ex.Message}", "Error");
            }
        }

        private void LoadBookingManagement()
        {
            try
            {
                BookingFrame.Content = new BookingManagementPage();
                txtStatus.Text = "Booking Management loaded";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Booking Management: {ex.Message}", "Error");
            }
        }

        // FIX: Thêm method LoadReports
        private void LoadReports()
        {
            try
            {
                ReportFrame.Content = new ReportsPage();
                txtStatus.Text = "Reports loaded";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Reports: {ex.Message}", "Error");
                txtStatus.Text = "Error loading Reports";
            }
        }

        // FIX: Thêm TabControl event handler
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl tabControl)
            {
                var selectedTab = tabControl.SelectedItem as TabItem;
                if (selectedTab != null)
                {
                    string headerText = selectedTab.Header.ToString();

                    if (headerText.Contains("Customer Management"))
                    {
                        LoadCustomerManagement();
                    }
                    else if (headerText.Contains("Room Management"))
                    {
                        LoadRoomManagement();
                    }
                    else if (headerText.Contains("Booking Management"))
                    {
                        LoadBookingManagement();
                    }
                    else if (headerText.Contains("Reports"))
                    {
                        LoadReports(); // FIX: Load Reports page
                    }
                }
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var loginWindow = new MainWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
