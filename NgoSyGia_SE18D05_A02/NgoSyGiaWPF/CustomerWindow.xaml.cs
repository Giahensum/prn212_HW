using BusinessObject;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class CustomerWindow : Window
    {
        private readonly Customer currentCustomer;
        private readonly CustomerRepository customerRepository;
        private readonly BookingReservationRepository bookingRepository;
        private readonly BookingDetailRepository bookingDetailRepository;
        private readonly RoomInformationRepository roomRepository;

        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            customerRepository = new CustomerRepository();
            bookingRepository = new BookingReservationRepository();
            bookingDetailRepository = new BookingDetailRepository();
            roomRepository = new RoomInformationRepository();

            LoadCustomerProfile();
            LoadBookingHistory();
            InitializeBookingDates();
        }

        private void LoadCustomerProfile()
        {
            lblCustomerName.Text = currentCustomer.CustomerFullName ?? "Unknown";
            txtFullName.Text = currentCustomer.CustomerFullName;
            txtEmail.Text = currentCustomer.EmailAddress;
            txtPhone.Text = currentCustomer.Telephone;
            dpBirthday.SelectedDate = currentCustomer.CustomerBirthday;
        }

        private void InitializeBookingDates()
        {
            // Set default dates for booking
            dpCheckInCustomer.SelectedDate = DateTime.Today.AddDays(1);
            dpCheckOutCustomer.SelectedDate = DateTime.Today.AddDays(2);
        }

        private void LoadBookingHistory()
        {
            try
            {
                // Get customer's booking history (DESCENDING order)
                var bookings = bookingRepository.GetBookingReservationsByCustomer(currentCustomer.CustomerID)
                    .OrderByDescending(b => b.BookingDate)
                    .ToList();

                dgBookingHistory.ItemsSource = bookings;
                txtStatus.Text = $"Loaded {bookings.Count} booking records";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking history: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // BOOKING FUNCTIONALITY - NEW
        private void BtnSearchRooms_Click(object sender, RoutedEventArgs e)
        {
            if (dpCheckInCustomer.SelectedDate.HasValue && dpCheckOutCustomer.SelectedDate.HasValue)
            {
                var checkIn = dpCheckInCustomer.SelectedDate.Value;
                var checkOut = dpCheckOutCustomer.SelectedDate.Value;

                if (checkIn >= checkOut)
                {
                    MessageBox.Show("Check-in date must be before check-out date.", "Date Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (checkIn <= DateTime.Today)
                {
                    MessageBox.Show("Check-in date must be after today.", "Date Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    // Use existing GetAvailableRooms method
                    var availableRooms = roomRepository.GetAvailableRooms(checkIn, checkOut);
                    dgAvailableRooms.ItemsSource = availableRooms;
                    txtStatus.Text = $"Found {availableRooms.Count()} available rooms";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching rooms: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select both check-in and check-out dates.", "Date Required",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnBookRoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is RoomInformation selectedRoom)
            {
                var checkIn = dpCheckInCustomer.SelectedDate.Value;
                var checkOut = dpCheckOutCustomer.SelectedDate.Value;
                var nights = (checkOut - checkIn).Days;
                var totalPrice = (selectedRoom.RoomPricePerDay ?? 0) * nights;

                var result = MessageBox.Show(
                    $"Confirm Booking:\n\n" +
                    $"Room: {selectedRoom.RoomNumber} ({selectedRoom.RoomType?.RoomTypeName})\n" +
                    $"Check-in: {checkIn:dd/MM/yyyy}\n" +
                    $"Check-out: {checkOut:dd/MM/yyyy}\n" +
                    $"Nights: {nights}\n" +
                    $"Total Price: {totalPrice:C}\n\n" +
                    $"Your booking will be pending until admin approval.\n" +
                    $"Do you want to proceed?",
                    "Confirm Booking", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        CreateBooking(selectedRoom, checkIn, checkOut, nights, totalPrice);
                        MessageBox.Show("Booking request submitted successfully!\nPlease wait for admin approval.", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadBookingHistory(); // Refresh booking history
                        dgAvailableRooms.ItemsSource = null; // Clear search results
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating booking: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void CreateBooking(RoomInformation room, DateTime checkIn, DateTime checkOut, int nights, decimal totalPrice)
        {
            // Create booking using database transaction
            using var context = new DataAccess.FUMiniHotelManagementContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                // Get next BookingReservationID (manual since no IDENTITY)
                var nextBookingId = bookingRepository.GetNextBookingReservationID();

                // Create BookingReservation - saves to database
                var booking = new BookingReservation
                {
                    BookingReservationID = nextBookingId,
                    CustomerID = currentCustomer.CustomerID,
                    BookingDate = DateTime.Today,
                    TotalPrice = totalPrice,
                    BookingStatus = 2 // Pending - awaiting admin approval
                };

                context.BookingReservations.Add(booking);
                context.SaveChanges();

                // Create BookingDetail with composite key - saves to database
                var bookingDetail = new BookingDetail
                {
                    BookingReservationID = nextBookingId,
                    RoomID = room.RoomID,
                    StartDate = checkIn,
                    EndDate = checkOut,
                    ActualPrice = totalPrice
                };

                context.BookingDetails.Add(bookingDetail);
                context.SaveChanges();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private void BtnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateProfileInput())
            {
                try
                {
                    currentCustomer.CustomerFullName = txtFullName.Text.Trim();
                    currentCustomer.Telephone = txtPhone.Text.Trim();
                    currentCustomer.CustomerBirthday = dpBirthday.SelectedDate;

                    customerRepository.UpdateCustomer(currentCustomer);

                    lblCustomerName.Text = currentCustomer.CustomerFullName ?? "Unknown";
                    txtStatus.Text = "Profile updated successfully";

                    MessageBox.Show("Profile updated successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating profile: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePasswordInput())
            {
                try
                {
                    currentCustomer.Password = txtNewPassword.Password;
                    customerRepository.UpdateCustomer(currentCustomer);

                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                    txtStatus.Text = "Password changed successfully";

                    MessageBox.Show("Password changed successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error changing password: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnViewBookingDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BookingReservation booking)
            {
                var statusText = booking.BookingStatus switch
                {
                    0 => "Cancelled",
                    1 => "Confirmed",
                    2 => "Pending Approval",
                    _ => "Unknown"
                };

                var message = $"Booking Details:\n\n" +
                             $"Booking ID: {booking.BookingReservationID}\n" +
                             $"Booking Date: {booking.BookingDate:dd/MM/yyyy}\n" +
                             $"Total Amount: {booking.TotalPrice:C}\n" +
                             $"Status: {statusText}\n\n" +
                             $"For detailed room information, please contact hotel staff.";

                MessageBox.Show(message, "Booking Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidateProfileInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private bool ValidatePasswordInput()
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Password))
            {
                MessageBox.Show("Current password is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (txtCurrentPassword.Password != currentCustomer.Password)
            {
                MessageBox.Show("Current password is incorrect.", "Password Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Password))
            {
                MessageBox.Show("New password is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (txtNewPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("New password and confirmation do not match.", "Password Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
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
