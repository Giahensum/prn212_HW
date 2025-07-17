using BusinessObject;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class BookingDialog : Window
    {
        public BookingReservation BookingReservation { get; set; }
        private readonly bool isUpdate = false;
        private readonly CustomerRepository customerRepository;
        private readonly RoomInformationRepository roomRepository;
        private readonly BookingReservationRepository bookingRepository;
        private readonly BookingDetailRepository bookingDetailRepository;

        public BookingDialog()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            roomRepository = new RoomInformationRepository();
            bookingRepository = new BookingReservationRepository();
            bookingDetailRepository = new BookingDetailRepository();

            BookingReservation = new BookingReservation();
            LoadCustomers();
            InitializeControls();
        }

        public BookingDialog(BookingReservation booking)
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            roomRepository = new RoomInformationRepository();
            bookingRepository = new BookingReservationRepository();
            bookingDetailRepository = new BookingDetailRepository();

            BookingReservation = booking;
            isUpdate = true;
            LoadCustomers();
            LoadBookingData();
        }

        private void InitializeControls()
        {
            dpBookingDate.SelectedDate = DateTime.Today;
            dpCheckIn.SelectedDate = DateTime.Today.AddDays(1);
            dpCheckOut.SelectedDate = DateTime.Today.AddDays(2);
            lstAvailableRooms.SelectionChanged += LstAvailableRooms_SelectionChanged;
            LoadAvailableRooms();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = customerRepository.GetCustomers()
                    .Where(c => c.CustomerStatus == 1)
                    .ToList();
                cboCustomer.ItemsSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error");
            }
        }

        private void LoadBookingData()
        {
            lblTitle.Text = "Update Booking";
            lblBookingID.Visibility = Visibility.Visible;
            txtBookingID.Visibility = Visibility.Visible;

            txtBookingID.Text = BookingReservation.BookingReservationID.ToString();
            cboCustomer.SelectedValue = BookingReservation.CustomerID;
            dpBookingDate.SelectedDate = BookingReservation.BookingDate;

            LoadBookingDetails();
        }

        private void LoadBookingDetails()
        {
            try
            {
                var details = bookingDetailRepository.GetBookingDetailsByBookingReservationId(BookingReservation.BookingReservationID);
                if (details.Any())
                {
                    var firstDetail = details.First();
                    dpCheckIn.SelectedDate = firstDetail.StartDate;
                    dpCheckOut.SelectedDate = firstDetail.EndDate;

                    LoadAvailableRooms();

                    var bookedRoomIds = details.Select(d => d.RoomID).ToList();
                    foreach (var room in lstAvailableRooms.Items.Cast<RoomInformation>())
                    {
                        if (bookedRoomIds.Contains(room.RoomID))
                        {
                            lstAvailableRooms.SelectedItems.Add(room);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}", "Error");
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadAvailableRooms();
            CalculateTotalPrice();
        }

        private void LoadAvailableRooms()
        {
            if (dpCheckIn.SelectedDate.HasValue && dpCheckOut.SelectedDate.HasValue)
            {
                try
                {
                    var checkIn = dpCheckIn.SelectedDate.Value;
                    var checkOut = dpCheckOut.SelectedDate.Value;

                    if (checkIn >= checkOut)
                    {
                        lstAvailableRooms.ItemsSource = null;
                        return;
                    }

                    var availableRooms = roomRepository.GetAvailableRooms(checkIn, checkOut);

                    if (isUpdate)
                    {
                        var currentBookingRooms = bookingDetailRepository
                            .GetBookingDetailsByBookingReservationId(BookingReservation.BookingReservationID)
                            .Select(d => d.RoomInformation)
                            .Where(r => r != null)
                            .Cast<RoomInformation>();

                        var allRooms = availableRooms.Union(currentBookingRooms).ToList();
                        lstAvailableRooms.ItemsSource = allRooms;
                    }
                    else
                    {
                        lstAvailableRooms.ItemsSource = availableRooms;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading available rooms: {ex.Message}", "Error");
                }
            }
        }

        private void LstAvailableRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (dpCheckIn.SelectedDate.HasValue && dpCheckOut.SelectedDate.HasValue)
            {
                var checkIn = dpCheckIn.SelectedDate.Value;
                var checkOut = dpCheckOut.SelectedDate.Value;
                var nights = (checkOut - checkIn).Days;

                if (nights > 0)
                {
                    lblNights.Text = nights.ToString();
                    lblRoomCount.Text = lstAvailableRooms.SelectedItems.Count.ToString();

                    decimal totalPrice = 0;
                    foreach (RoomInformation room in lstAvailableRooms.SelectedItems)
                    {
                        totalPrice += (room.RoomPricePerDay ?? 0) * nights;
                    }

                    lblTotalPrice.Text = totalPrice.ToString("C");
                }
                else
                {
                    lblNights.Text = "0";
                    lblRoomCount.Text = "0";
                    lblTotalPrice.Text = "$0.00";
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    BookingReservation.CustomerID = (int)(cboCustomer.SelectedValue ?? 0);
                    BookingReservation.BookingDate = dpBookingDate.SelectedDate;

                    // FIX: Proper casting for BookingStatus
                    if (cboBookingStatus.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag != null)
                    {
                        if (byte.TryParse(selectedItem.Tag.ToString(), out byte status))
                        {
                            BookingReservation.BookingStatus = status;
                        }
                        else
                        {
                            // Default to Confirmed if parsing fails
                            BookingReservation.BookingStatus = 1;
                        }
                    }
                    else
                    {
                        // Default to Confirmed if no selection
                        BookingReservation.BookingStatus = 1;
                    }

                    var checkIn = dpCheckIn.SelectedDate!.Value;
                    var checkOut = dpCheckOut.SelectedDate!.Value;
                    var nights = (checkOut - checkIn).Days;

                    decimal totalPrice = 0;
                    foreach (RoomInformation room in lstAvailableRooms.SelectedItems)
                    {
                        totalPrice += (room.RoomPricePerDay ?? 0) * nights;
                    }
                    BookingReservation.TotalPrice = totalPrice;

                    if (!isUpdate)
                    {
                        BookingReservation.BookingReservationID = bookingRepository.GetNextBookingReservationID();
                    }
                    else
                    {
                        bookingRepository.UpdateBookingReservation(BookingReservation);
                        SaveBookingDetails(checkIn, checkOut, nights);
                    }

                    DialogResult = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving booking: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}",
                        "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveBookingDetails(DateTime checkIn, DateTime checkOut, int nights)
        {
            try
            {
                if (isUpdate)
                {
                    var existingDetails = bookingDetailRepository.GetBookingDetailsByBookingReservationId(BookingReservation.BookingReservationID);
                    foreach (var detail in existingDetails)
                    {
                        bookingDetailRepository.DeleteBookingDetail(detail);
                    }

                    foreach (RoomInformation room in lstAvailableRooms.SelectedItems)
                    {
                        var bookingDetail = new BookingDetail
                        {
                            BookingReservationID = BookingReservation.BookingReservationID,
                            RoomID = room.RoomID,
                            StartDate = checkIn,
                            EndDate = checkOut,
                            ActualPrice = (room.RoomPricePerDay ?? 0) * nights
                        };

                        bookingDetailRepository.AddBookingDetail(bookingDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving booking details: {ex.Message}", ex);
            }
        }

        private bool ValidateInput()
        {
            if (cboCustomer.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!dpCheckIn.SelectedDate.HasValue || !dpCheckOut.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select check-in and check-out dates.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            var checkIn = dpCheckIn.SelectedDate.Value;
            var checkOut = dpCheckOut.SelectedDate.Value;

            if (checkIn >= checkOut)
            {
                MessageBox.Show("Check-in date must be before check-out date.", "Date Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (checkIn <= DateTime.Today)
            {
                MessageBox.Show("Check-in date must be after today.", "Date Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (lstAvailableRooms.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one room.", "Room Selection Required",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            try
            {
                var customerId = (int)cboCustomer.SelectedValue;
                var customer = customerRepository.GetCustomerById(customerId);
                if (customer == null)
                {
                    MessageBox.Show("Selected customer no longer exists. Please refresh and try again.",
                        "Customer Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error validating customer. Please try again.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
