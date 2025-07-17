using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO? instance = null;
        private static readonly object instanceLock = new object();

        private RoomTypeDAO() { }

        public static RoomTypeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new RoomTypeDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            List<RoomType> roomTypes = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                roomTypes = context.RoomTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return roomTypes;
        }

        public RoomType? GetRoomTypeById(int roomTypeId)
        {
            RoomType? roomType = null;
            try
            {
                using var context = new FUMiniHotelManagementContext();
                roomType = context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == roomTypeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return roomType;
        }

        public void AddRoomType(RoomType roomType)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.RoomTypes.Add(roomType);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateRoomType(RoomType roomType)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.Entry(roomType).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteRoomType(RoomType roomType)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                var rt = context.RoomTypes.FirstOrDefault(r => r.RoomTypeID == roomType.RoomTypeID);
                if (rt != null)
                {
                    context.RoomTypes.Remove(rt);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<RoomType> SearchRoomTypes(string searchTerm)
        {
            List<RoomType> roomTypes = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                roomTypes = context.RoomTypes
                    .Where(rt => rt.RoomTypeName.Contains(searchTerm) ||
                                (rt.TypeDescription != null && rt.TypeDescription.Contains(searchTerm)))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return roomTypes;
        }
    }
}
