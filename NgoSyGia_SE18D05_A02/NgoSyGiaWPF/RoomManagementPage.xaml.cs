using BusinessObject;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace NgoSyGiaWPF
{
    public partial class RoomManagementPage : Page
    {
        private readonly RoomInformationRepository roomRepository;
        private readonly RoomTypeRepository roomTypeRepository;
        private List<RoomInformation> rooms = [];

        public RoomManagementPage()
        {
            InitializeComponent();
            roomRepository = new RoomInformationRepository();
            roomTypeRepository = new RoomTypeRepository();
            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                rooms = roomRepository.GetRoomInformations().ToList();
                dgRooms.ItemsSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm) || searchTerm == "Search by room number, type, or description...")
            {
                LoadRooms();
                return;
            }

            try
            {
                var filteredRooms = roomRepository.SearchRoomInformations(searchTerm);
                dgRooms.ItemsSource = filteredRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching rooms: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addDialog = new RoomDialog();
            if (addDialog.ShowDialog() == true)
            {
                var room = addDialog.Room;
                try
                {
                    roomRepository.AddRoomInformation(room);
                    LoadRooms();
                    MessageBox.Show("Room added successfully!", "Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding room: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is RoomInformation selectedRoom)
            {
                var updateDialog = new RoomDialog(selectedRoom);
                if (updateDialog.ShowDialog() == true)
                {
                    var room = updateDialog.Room;
                    try
                    {
                        roomRepository.UpdateRoomInformation(room);
                        LoadRooms();
                        MessageBox.Show("Room updated successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating room: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to update.", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is RoomInformation selectedRoom)
            {
                var result = MessageBox.Show($"Are you sure you want to delete room '{selectedRoom.RoomNumber}'?",
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        roomRepository.DeleteRoomInformation(selectedRoom);
                        LoadRooms();
                        MessageBox.Show("Room deleted successfully!", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting room: {ex.Message}", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
