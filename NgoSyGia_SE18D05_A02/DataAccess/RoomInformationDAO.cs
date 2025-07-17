using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RoomInformationDAO
    {
        private static RoomInformationDAO? instance;
        private static readonly object instanceLock = new();

        private RoomInformationDAO() { }

        public static RoomInformationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new RoomInformationDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<RoomInformation> GetRoomInformations()
        {
            List<RoomInformation> rooms = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                rooms = context.RoomInformations.Include(r => r.RoomType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rooms;
        }

        public RoomInformation? GetRoomInformationById(int roomId)
        {
            RoomInformation? room = null;
            try
            {
                using var context = new FUMiniHotelManagementContext();
                room = context.RoomInformations
                    .Include(r => r.RoomType)
                    .FirstOrDefault(r => r.RoomID == roomId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return room;
        }

        public void AddRoomInformation(RoomInformation room)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.RoomInformations.Add(room);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateRoomInformation(RoomInformation room)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.Entry(room).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteRoomInformation(RoomInformation room)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                var r = context.RoomInformations.FirstOrDefault(ri => ri.RoomID == room.RoomID);
                if (r != null)
                {
                    context.RoomInformations.Remove(r);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<RoomInformation> SearchRoomInformations(string searchTerm)
        {
            List<RoomInformation> rooms = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                rooms = context.RoomInformations
                    .Include(r => r.RoomType)
                    .Where(r => r.RoomNumber.Contains(searchTerm) ||
                               (r.RoomDetailDescription != null && r.RoomDetailDescription.Contains(searchTerm)) ||
                               (r.RoomType != null && r.RoomType.RoomTypeName.Contains(searchTerm)))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rooms;
        }

        public IEnumerable<RoomInformation> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            List<RoomInformation> availableRooms = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                var bookedRoomIds = context.BookingDetails
                    .Where(bd => bd.StartDate <= endDate && bd.EndDate >= startDate)
                    .Select(bd => bd.RoomID)
                    .Distinct()
                    .ToList();

                availableRooms = context.RoomInformations
                    .Include(r => r.RoomType)
                    .Where(r => r.RoomStatus == 1 && !bookedRoomIds.Contains(r.RoomID))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return availableRooms;
        }

        public bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                var query = context.BookingDetails
                    .Where(bd => bd.RoomID == roomId &&
                                bd.StartDate <= endDate &&
                                bd.EndDate >= startDate);

                if (excludeBookingId.HasValue)
                {
                    query = query.Where(bd => bd.BookingReservationID != excludeBookingId.Value);
                }

                return !query.Any();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
