using BusinessObject;
using DataAccess;

namespace Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public IEnumerable<RoomType> GetRoomTypes() => RoomTypeDAO.Instance.GetRoomTypes();

        public RoomType? GetRoomTypeById(int roomTypeId) => RoomTypeDAO.Instance.GetRoomTypeById(roomTypeId);

        public void AddRoomType(RoomType roomType) => RoomTypeDAO.Instance.AddRoomType(roomType);

        public void UpdateRoomType(RoomType roomType) => RoomTypeDAO.Instance.UpdateRoomType(roomType);

        public void DeleteRoomType(RoomType roomType) => RoomTypeDAO.Instance.DeleteRoomType(roomType);

        public IEnumerable<RoomType> SearchRoomTypes(string searchTerm) => RoomTypeDAO.Instance.SearchRoomTypes(searchTerm);
    }
}
