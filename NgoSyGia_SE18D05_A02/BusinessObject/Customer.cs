using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string? CustomerFullName { get; set; }

        [StringLength(12)]
        public string? Telephone { get; set; }

        [Required]
        public string EmailAddress { get; set; } = "";

        [Column(TypeName = "date")]
        public DateTime? CustomerBirthday { get; set; }

        public byte? CustomerStatus { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new HashSet<BookingReservation>();
    }
}
