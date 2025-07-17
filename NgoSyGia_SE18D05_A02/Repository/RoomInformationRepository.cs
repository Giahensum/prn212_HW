using BusinessObject;
using DataAccess;

namespace Repository
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public IEnumerable<RoomInformation> GetRoomInformations() => RoomInformationDAO.Instance.GetRoomInformations();

        public RoomInformation? GetRoomInformationById(int roomId) => RoomInformationDAO.Instance.GetRoomInformationById(roomId);

        public void AddRoomInformation(RoomInformation room) => RoomInformationDAO.Instance.AddRoomInformation(room);

        public void UpdateRoomInformation(RoomInformation room) => RoomInformationDAO.Instance.UpdateRoomInformation(room);

        public void DeleteRoomInformation(RoomInformation room) => RoomInformationDAO.Instance.DeleteRoomInformation(room);

        public IEnumerable<RoomInformation> SearchRoomInformations(string searchTerm) => RoomInformationDAO.Instance.SearchRoomInformations(searchTerm);

        public IEnumerable<RoomInformation> GetAvailableRooms(DateTime startDate, DateTime endDate) => RoomInformationDAO.Instance.GetAvailableRooms(startDate, endDate);

        public bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null) => RoomInformationDAO.Instance.IsRoomAvailable(roomId, startDate, endDate, excludeBookingId);
    }
}
