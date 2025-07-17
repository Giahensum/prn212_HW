using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class RoomInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }

        [Required]
        public string RoomNumber { get; set; } = "";

        [StringLength(220)]
        public string? RoomDetailDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

        [Required]
        public int RoomTypeID { get; set; }

        public byte? RoomStatus { get; set; }

        [Column(TypeName = "money")]
        public decimal? RoomPricePerDay { get; set; }

        [ForeignKey("RoomTypeID")]
        public virtual RoomType? RoomType { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new HashSet<BookingDetail>();
    }
}
