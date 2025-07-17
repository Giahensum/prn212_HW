using BusinessObject;
using Repository;
using System.Windows;

namespace NgoSyGiaWPF
{
    public partial class RoomDialog : Window
    {
        public RoomInformation Room { get; set; }
        private readonly bool isUpdate = false;
        private readonly RoomTypeRepository roomTypeRepository;

        public RoomDialog()
        {
            InitializeComponent();
            roomTypeRepository = new RoomTypeRepository();
            Room = new RoomInformation { RoomNumber = "" };
            LoadRoomTypes();
        }

        public RoomDialog(RoomInformation room)
        {
            InitializeComponent();
            roomTypeRepository = new RoomTypeRepository();
            Room = room;
            isUpdate = true;
            LoadRoomTypes();
            LoadRoomData();
        }

        private void LoadRoomTypes()
        {
            try
            {
                var roomTypes = roomTypeRepository.GetRoomTypes().ToList();
                cboRoomType.ItemsSource = roomTypes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error");
            }
        }

        private void LoadRoomData()
        {
            lblTitle.Text = "Update Room";
            txtRoomNumber.Text = Room.RoomNumber;
            cboRoomType.SelectedValue = Room.RoomTypeID;
            txtMaxCapacity.Text = Room.RoomMaxCapacity?.ToString();
            txtPricePerDay.Text = Room.RoomPricePerDay?.ToString();
            txtDescription.Text = Room.RoomDetailDescription;
            chkStatus.IsChecked = Room.RoomStatus == 1;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                if (!isUpdate)
                {
                    Room = new RoomInformation { RoomNumber = txtRoomNumber.Text.Trim() };
                }

                Room.RoomNumber = txtRoomNumber.Text.Trim();
                Room.RoomTypeID = (int)cboRoomType.SelectedValue;
                Room.RoomMaxCapacity = int.TryParse(txtMaxCapacity.Text, out int capacity) ? capacity : null;
                Room.RoomPricePerDay = decimal.TryParse(txtPricePerDay.Text, out decimal price) ? price : null;
                Room.RoomDetailDescription = txtDescription.Text.Trim();
                Room.RoomStatus = (byte)(chkStatus.IsChecked == true ? 1 : 0);

                DialogResult = true;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Room number is required.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cboRoomType.SelectedValue == null)
            {
                MessageBox.Show("Please select a room type.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtMaxCapacity.Text, out _))
            {
                MessageBox.Show("Please enter a valid max capacity.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPricePerDay.Text, out _))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
