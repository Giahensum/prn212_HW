using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BookingDetailDAO
    {
        private static BookingDetailDAO? instance = null;
        private static readonly object instanceLock = new object();

        private BookingDetailDAO() { }

        public static BookingDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new BookingDetailDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<BookingDetail> GetBookingDetails()
        {
            List<BookingDetail> bookingDetails = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                bookingDetails = context.BookingDetails
                    .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br!.Customer)
                    .Include(bd => bd.RoomInformation)
                    .ThenInclude(ri => ri!.RoomType)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookingDetails;
        }

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId)
        {
            BookingDetail? bookingDetail = null;
            try
            {
                using var context = new FUMiniHotelManagementContext();
                bookingDetail = context.BookingDetails
                    .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br!.Customer)
                    .Include(bd => bd.RoomInformation)
                    .ThenInclude(ri => ri!.RoomType)
                    .FirstOrDefault(bd => bd.BookingReservationID == bookingReservationId && bd.RoomID == roomId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookingDetail;
        }

        public IEnumerable<BookingDetail> GetBookingDetailsByBookingReservationId(int bookingReservationId)
        {
            List<BookingDetail> bookingDetails = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                bookingDetails = context.BookingDetails
                    .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br!.Customer)
                    .Include(bd => bd.RoomInformation)
                    .ThenInclude(ri => ri!.RoomType)
                    .Where(bd => bd.BookingReservationID == bookingReservationId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookingDetails;
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.BookingDetails.Add(bookingDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                context.Entry(bookingDetail).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var context = new FUMiniHotelManagementContext();
                var bd = context.BookingDetails.FirstOrDefault(b =>
                    b.BookingReservationID == bookingDetail.BookingReservationID &&
                    b.RoomID == bookingDetail.RoomID);
                if (bd != null)
                {
                    context.BookingDetails.Remove(bd);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<BookingDetail> GetBookingDetailsByRoom(int roomId)
        {
            List<BookingDetail> bookingDetails = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                bookingDetails = context.BookingDetails
                    .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br!.Customer)
                    .Include(bd => bd.RoomInformation)
                    .ThenInclude(ri => ri!.RoomType)
                    .Where(bd => bd.RoomID == roomId)
                    .OrderByDescending(bd => bd.StartDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookingDetails;
        }

        public IEnumerable<BookingDetail> GetBookingDetailsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<BookingDetail> bookingDetails = [];
            try
            {
                using var context = new FUMiniHotelManagementContext();
                bookingDetails = context.BookingDetails
                    .Include(bd => bd.BookingReservation)
                    .ThenInclude(br => br!.Customer)
                    .Include(bd => bd.RoomInformation)
                    .ThenInclude(ri => ri!.RoomType)
                    .Where(bd => bd.StartDate <= endDate && bd.EndDate >= startDate)
                    .OrderByDescending(bd => bd.StartDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookingDetails;
        }

        public bool IsRoomBookedInPeriod(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null)
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

                return query.Any();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
