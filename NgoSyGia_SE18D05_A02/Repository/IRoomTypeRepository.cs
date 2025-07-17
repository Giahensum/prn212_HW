using BusinessObject;

namespace Repository
{
    public interface IRoomTypeRepository
    {
        IEnumerable<RoomType> GetRoomTypes();
        RoomType? GetRoomTypeById(int roomTypeId);
        void AddRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
        void DeleteRoomType(RoomType roomType);
        IEnumerable<RoomType> SearchRoomTypes(string searchTerm);
    }
}
