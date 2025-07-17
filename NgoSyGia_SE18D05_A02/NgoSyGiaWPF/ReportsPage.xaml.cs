using BusinessObject;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class ReportsPage : Page
    {
        private readonly BookingReservationRepository bookingRepository;
        private readonly RoomInformationRepository roomRepository;

        public ReportsPage()
        {
            InitializeComponent();
            bookingRepository = new BookingReservationRepository();
            roomRepository = new RoomInformationRepository();
            InitializeDatePickers();
        }

        private void InitializeDatePickers()
        {
            dpStartDate.SelectedDate = DateTime.Today.AddMonths(-1);
            dpEndDate.SelectedDate = DateTime.Today;
        }

        private void BtnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                var startDate = dpStartDate.SelectedDate.Value;
                var endDate = dpEndDate.SelectedDate.Value;

                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be greater than end date.", "Date Validation",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                GenerateRevenueReport(startDate, endDate);
                GenerateBookingStatistics(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Please select both start and end dates.", "Date Selection Required",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void GenerateRevenueReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                // REQUIREMENT: Sort data in DESCENDING order by date
                var bookings = bookingRepository.GetBookingReservationsByDateRange(startDate, endDate)
                    .Where(b => b.BookingStatus == 1) // Only confirmed bookings
                    .OrderByDescending(b => b.BookingDate) // DESCENDING ORDER as required
                    .ToList();

                dgRevenueReport.ItemsSource = bookings;

                // Calculate summary statistics
                var totalRevenue = bookings.Sum(b => b.TotalPrice ?? 0);
                var totalBookings = bookings.Count;
                var averageBooking = totalBookings > 0 ? totalRevenue / totalBookings : 0;

                lblTotalRevenue.Text = totalRevenue.ToString("C");
                lblTotalBookings.Text = totalBookings.ToString();
                lblAverageBooking.Text = averageBooking.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating revenue report: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateBookingStatistics(DateTime startDate, DateTime endDate)
        {
            try
            {
                var rooms = roomRepository.GetRoomInformations().ToList();
                var bookings = bookingRepository.GetBookingReservationsByDateRange(startDate, endDate)
                    .Where(b => b.BookingStatus == 1)
                    .ToList();

                var roomStats = rooms.Select(room => new
                {
                    RoomNumber = room.RoomNumber,
                    RoomTypeName = room.RoomType?.RoomTypeName ?? "Unknown",
                    TotalBookings = bookings.SelectMany(b => b.BookingDetails ?? new List<BookingDetail>())
                        .Count(bd => bd.RoomID == room.RoomID),
                    TotalRevenue = bookings.SelectMany(b => b.BookingDetails ?? new List<BookingDetail>())
                        .Where(bd => bd.RoomID == room.RoomID)
                        .Sum(bd => bd.ActualPrice ?? 0),
                    OccupancyRate = CalculateOccupancyRate(room.RoomID, startDate, endDate, bookings)
                })
                .OrderByDescending(r => r.TotalRevenue) // DESCENDING ORDER by revenue
                .ToList();

                dgBookingStats.ItemsSource = roomStats;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating booking statistics: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalculateOccupancyRate(int roomId, DateTime startDate, DateTime endDate, List<BookingReservation> bookings)
        {
            var totalDays = (endDate - startDate).Days;
            if (totalDays <= 0) return 0;

            var bookedDays = bookings.SelectMany(b => b.BookingDetails ?? new List<BookingDetail>())
                .Where(bd => bd.RoomID == roomId)
                .Sum(bd => (bd.EndDate - bd.StartDate).Days);

            return (double)bookedDays / totalDays;
        }
    }
}
