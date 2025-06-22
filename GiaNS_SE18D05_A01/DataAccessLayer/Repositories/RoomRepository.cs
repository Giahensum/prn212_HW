using DataAccessLayer.Models;
using DataAccessLayer.Data;

namespace DataAccessLayer.Repositories
{
    public class RoomRepository : BaseRepository<RoomInformation>, IRoomRepository
    {
        protected override List<RoomInformation> GetDbSet()
        {
            return _context.Rooms;
        }

        protected override int GetEntityId(RoomInformation entity)
        {
            return entity.RoomID;
        }

        protected override void SetEntityId(RoomInformation entity, int id)
        {
            entity.RoomID = id;
        }

        public RoomInformation GetByRoomNumber(string roomNumber)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
                return null;

            return _dbSet.FirstOrDefault(r =>
                r.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase) &&
                r.RoomStatus == 1);
        }

        public IEnumerable<RoomInformation> GetByRoomType(int roomTypeId)
        {
            return _dbSet.Where(r => r.RoomTypeID == roomTypeId && r.RoomStatus == 1).ToList();
        }

        public IEnumerable<RoomInformation> GetAvailableRooms()
        {
            return GetActiveRooms(); // Trong bài này chưa có booking nên available = active
        }

        public IEnumerable<RoomInformation> SearchByNumber(string roomNumber)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
                return GetActiveRooms();

            return _dbSet.Where(r =>
                r.RoomNumber.Contains(roomNumber, StringComparison.OrdinalIgnoreCase) &&
                r.RoomStatus == 1).ToList();
        }

        public IEnumerable<RoomInformation> GetActiveRooms()
        {
            return _dbSet.Where(r => r.RoomStatus == 1).ToList();
        }

        public override void Delete(RoomInformation entity)
        {
            // Soft delete - chỉ thay đổi status thay vì xóa thật
            if (entity != null)
            {
                entity.RoomStatus = 2; // 2 = Deleted
                Update(entity);
            }
        }

        public override void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
            {
                Delete(room);
            }
        }
    }
}
