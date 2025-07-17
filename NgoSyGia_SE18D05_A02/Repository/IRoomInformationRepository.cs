using BusinessObject;

namespace Repository
{
    public interface IRoomInformationRepository
    {
        IEnumerable<RoomInformation> GetRoomInformations();
        RoomInformation? GetRoomInformationById(int roomId);
        void AddRoomInformation(RoomInformation room);
        void UpdateRoomInformation(RoomInformation room);
        void DeleteRoomInformation(RoomInformation room);
        IEnumerable<RoomInformation> SearchRoomInformations(string searchTerm);
        IEnumerable<RoomInformation> GetAvailableRooms(DateTime startDate, DateTime endDate);
        bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null);
    }
}
