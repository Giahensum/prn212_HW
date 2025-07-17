using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class BookingReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingReservationID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BookingDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalPrice { get; set; }

        [Required]
        public int CustomerID { get; set; }

        public byte? BookingStatus { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new HashSet<BookingDetail>();
    }
}
