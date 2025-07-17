using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BookingReservationDAO
    {
        private static BookingReservationDAO? _instance;
        private static readonly object _lock = new();

        private BookingReservationDAO() { }

        public static BookingReservationDAO Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new BookingReservationDAO();
                    return _instance;
                }
            }
        }

        public IEnumerable<BookingReservation> GetBookingReservations()
        {
            List<BookingReservation> bookings = [];
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                bookings = ctx.BookingReservations
                              .Include(br => br.Customer)
                              .Include(br => br.BookingDetails)
                              .ToList();
            }
            catch (Exception ex) { throw new(ex.Message); }
            return bookings;
        }

        public BookingReservation? GetBookingReservationById(int id)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                return ctx.BookingReservations
                          .Include(br => br.Customer)
                          .Include(br => br.BookingDetails)
                          .FirstOrDefault(br => br.BookingReservationID == id);
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public IEnumerable<BookingReservation> GetBookingReservationsByCustomer(int custId)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                return ctx.BookingReservations
                          .Include(br => br.Customer)
                          .Include(br => br.BookingDetails)
                          .Where(br => br.CustomerID == custId)
                          .OrderByDescending(br => br.BookingDate)
                          .ToList();
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public void AddBookingReservation(BookingReservation booking)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                ctx.BookingReservations.Add(booking);
                ctx.SaveChanges();
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public void UpdateBookingReservation(BookingReservation booking)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                ctx.Entry(booking).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public void DeleteBookingReservation(BookingReservation booking)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                var tmp = ctx.BookingReservations
                             .FirstOrDefault(x => x.BookingReservationID == booking.BookingReservationID);
                if (tmp != null)
                {
                    ctx.BookingReservations.Remove(tmp);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public IEnumerable<BookingReservation> GetBookingReservationsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                return ctx.BookingReservations
                          .Include(br => br.Customer)
                          .Include(br => br.BookingDetails)
                          .Where(br => br.BookingDate >= startDate && br.BookingDate <= endDate)
                          .OrderByDescending(br => br.BookingDate)
                          .ToList();
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public int GetNextBookingReservationID()
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                var max = ctx.BookingReservations.Max(br => (int?)br.BookingReservationID) ?? 0;
                return max + 1;
            }
            catch (Exception ex) { throw new(ex.Message); }
        }

        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                using var ctx = new FUMiniHotelManagementContext();
                return ctx.BookingReservations
                          .Where(br => br.BookingDate >= startDate &&
                                      br.BookingDate <= endDate &&
                                      br.BookingStatus == 1)
                          .Sum(br => br.TotalPrice ?? 0);
            }
            catch (Exception ex) { throw new(ex.Message); }
        }
    }
}
