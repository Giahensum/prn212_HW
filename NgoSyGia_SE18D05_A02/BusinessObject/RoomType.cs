using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomTypeID { get; set; }

        [Required]
        public string RoomTypeName { get; set; } = "";

        [StringLength(250)]
        public string? TypeDescription { get; set; }

        [StringLength(250)]
        public string? TypeNote { get; set; }

        public virtual ICollection<RoomInformation> RoomInformations { get; set; } = new HashSet<RoomInformation>();
    }
}
