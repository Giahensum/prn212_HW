using BusinessObject;

namespace Repository
{
    public interface IBookingDetailRepository
    {
        IEnumerable<BookingDetail> GetBookingDetails();
        BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId);
        IEnumerable<BookingDetail> GetBookingDetailsByBookingReservationId(int bookingReservationId);
        void AddBookingDetail(BookingDetail bookingDetail);
        void UpdateBookingDetail(BookingDetail bookingDetail);
        void DeleteBookingDetail(BookingDetail bookingDetail);
        IEnumerable<BookingDetail> GetBookingDetailsByRoom(int roomId);
        IEnumerable<BookingDetail> GetBookingDetailsByDateRange(DateTime startDate, DateTime endDate);
        bool IsRoomBookedInPeriod(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null);
    }
}
