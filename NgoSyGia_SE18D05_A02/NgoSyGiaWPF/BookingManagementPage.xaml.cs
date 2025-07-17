using BusinessObject;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class BookingManagementPage : Page
    {
        private readonly BookingReservationRepository bookingRepository;
        private readonly BookingDetailRepository bookingDetailRepository;
        private readonly CustomerRepository customerRepository;
        private List<BookingReservation> bookings = [];

        public BookingManagementPage()
        {
            InitializeComponent();
            bookingRepository = new BookingReservationRepository();
            bookingDetailRepository = new BookingDetailRepository();
            customerRepository = new CustomerRepository();
            LoadBookings();
            InitializeDatePickers();
        }

        private void InitializeDatePickers()
        {
            dpStartDate.SelectedDate = DateTime.Today.AddDays(-30);
            dpEndDate.SelectedDate = DateTime.Today.AddDays(30);
        }

        private void LoadBookings()
        {
            try
            {
                bookings = bookingRepository.GetBookingReservations().ToList();
                dgBookings.ItemsSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                try
                {
                    var startDate = dpStartDate.SelectedDate.Value;
                    var endDate = dpEndDate.SelectedDate.Value;

                    if (startDate > endDate)
                    {
                        MessageBox.Show("Start date cannot be greater than end date.", "Date Validation Error",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    var filteredBookings = bookingRepository.GetBookingReservationsByDateRange(startDate, endDate);
                    dgBookings.ItemsSource = filteredBookings;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error filtering bookings: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select both start and end dates.", "Date Selection Required",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addDialog = new BookingDialog();
            if (addDialog.ShowDialog() == true)
            {
                try
                {
                    var booking = addDialog.BookingReservation;

                    // FIX: Use transaction to save both BookingReservation and BookingDetails
                    using var context = new DataAccess.FUMiniHotelManagementContext();
                    using var transaction = context.Database.BeginTransaction();

                    try
                    {
                        // Save BookingReservation
                        context.BookingReservations.Add(booking);
                        context.SaveChanges();

                        // Save BookingDetails from dialog
                        var checkIn = addDialog.dpCheckIn.SelectedDate!.Value;
                        var checkOut = addDialog.dpCheckOut.SelectedDate!.Value;
                        var nights = (checkOut - checkIn).Days;

                        foreach (RoomInformation room in addDialog.lstAvailableRooms.SelectedItems)
                        {
                            var bookingDetail = new BookingDetail
                            {
                                BookingReservationID = booking.BookingReservationID,
                                RoomID = room.RoomID,
                                StartDate = checkIn,
                                EndDate = checkOut,
                                ActualPrice = (room.RoomPricePerDay ?? 0) * nights
                            };

                            context.BookingDetails.Add(bookingDetail);
                        }

                        context.SaveChanges();
                        transaction.Commit();

                        LoadBookings();
                        MessageBox.Show("Booking created successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating booking: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookings.SelectedItem is BookingReservation selectedBooking)
            {
                var updateDialog = new BookingDialog(selectedBooking);
                if (updateDialog.ShowDialog() == true)
                {
                    try
                    {
                        LoadBookings();
                        MessageBox.Show("Booking updated successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating booking: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to update.", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookings.SelectedItem is BookingReservation selectedBooking)
            {
                var result = MessageBox.Show($"Are you sure you want to cancel booking #{selectedBooking.BookingReservationID} for {selectedBooking.Customer?.CustomerFullName}?",
                    "Confirm Cancel Booking", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        selectedBooking.BookingStatus = 0; // 0 = Cancelled
                        bookingRepository.UpdateBookingReservation(selectedBooking);
                        LoadBookings();
                        MessageBox.Show("Booking cancelled successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to cancel.", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // FIX: Simplified view details - just show message for now
        private void BtnViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BookingReservation booking)
            {
                var message = $"Booking Details:\n" +
                             $"ID: {booking.BookingReservationID}\n" +
                             $"Customer: {booking.Customer?.CustomerFullName ?? "Unknown"}\n" +
                             $"Date: {booking.BookingDate:dd/MM/yyyy}\n" +
                             $"Total: {booking.TotalPrice:C}\n" +
                             $"Status: {booking.BookingStatus}";

                MessageBox.Show(message, "Booking Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // FIX: Simplified view rooms - just show message for now
        private void BtnViewRooms_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BookingReservation booking)
            {
                MessageBox.Show($"Room details for Booking #{booking.BookingReservationID} will be implemented later.",
                    "Room Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
