using BusinessObject;
using DataAccess;

namespace Repository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public IEnumerable<BookingDetail> GetBookingDetails() => BookingDetailDAO.Instance.GetBookingDetails();

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId) => BookingDetailDAO.Instance.GetBookingDetailById(bookingReservationId, roomId);

        public IEnumerable<BookingDetail> GetBookingDetailsByBookingReservationId(int bookingReservationId) => BookingDetailDAO.Instance.GetBookingDetailsByBookingReservationId(bookingReservationId);

        public void AddBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.AddBookingDetail(bookingDetail);

        public void UpdateBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.UpdateBookingDetail(bookingDetail);

        public void DeleteBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.Instance.DeleteBookingDetail(bookingDetail);

        public IEnumerable<BookingDetail> GetBookingDetailsByRoom(int roomId) => BookingDetailDAO.Instance.GetBookingDetailsByRoom(roomId);

        public IEnumerable<BookingDetail> GetBookingDetailsByDateRange(DateTime startDate, DateTime endDate) => BookingDetailDAO.Instance.GetBookingDetailsByDateRange(startDate, endDate);

        public bool IsRoomBookedInPeriod(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null) => BookingDetailDAO.Instance.IsRoomBookedInPeriod(roomId, startDate, endDate, excludeBookingId);
    }
}
