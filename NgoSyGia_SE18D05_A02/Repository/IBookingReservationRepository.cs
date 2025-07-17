using BusinessObject;

namespace Repository
{
    public interface IBookingReservationRepository
    {
        IEnumerable<BookingReservation> GetBookingReservations();
        BookingReservation? GetBookingReservationById(int bookingId);
        IEnumerable<BookingReservation> GetBookingReservationsByCustomer(int customerId);
        void AddBookingReservation(BookingReservation booking);
        void UpdateBookingReservation(BookingReservation booking);
        void DeleteBookingReservation(BookingReservation booking);
        IEnumerable<BookingReservation> GetBookingReservationsByDateRange(DateTime startDate, DateTime endDate);
        int GetNextBookingReservationID();
        decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate);
    }
}
