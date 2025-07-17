using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class BookingDetail
    {
        [Key]
        [Column(Order = 0)]
        public int BookingReservationID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int RoomID { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualPrice { get; set; }

        // Navigation Properties
        [ForeignKey("BookingReservationID")]
        public virtual BookingReservation? BookingReservation { get; set; }

        [ForeignKey("RoomID")]
        public virtual RoomInformation? RoomInformation { get; set; }
    }
}
