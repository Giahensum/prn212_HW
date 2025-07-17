using BusinessObject;
using DataAccess;

namespace Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public IEnumerable<BookingReservation> GetBookingReservations() => BookingReservationDAO.Instance.GetBookingReservations();

        public BookingReservation? GetBookingReservationById(int bookingId) => BookingReservationDAO.Instance.GetBookingReservationById(bookingId);

        public IEnumerable<BookingReservation> GetBookingReservationsByCustomer(int customerId) => BookingReservationDAO.Instance.GetBookingReservationsByCustomer(customerId);

        public void AddBookingReservation(BookingReservation booking) => BookingReservationDAO.Instance.AddBookingReservation(booking);

        public void UpdateBookingReservation(BookingReservation booking) => BookingReservationDAO.Instance.UpdateBookingReservation(booking);

        public void DeleteBookingReservation(BookingReservation booking) => BookingReservationDAO.Instance.DeleteBookingReservation(booking);

        public IEnumerable<BookingReservation> GetBookingReservationsByDateRange(DateTime startDate, DateTime endDate) => BookingReservationDAO.Instance.GetBookingReservationsByDateRange(startDate, endDate);

        public int GetNextBookingReservationID() => BookingReservationDAO.Instance.GetNextBookingReservationID();

        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate) => BookingReservationDAO.Instance.GetTotalRevenueByDateRange(startDate, endDate);
    }
}
