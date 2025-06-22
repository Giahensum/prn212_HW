using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class RoomInformation
    {
        public int RoomID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomNumber { get; set; } = string.Empty;

        [StringLength(220)]
        public string RoomDescription { get; set; } = string.Empty;

        [Range(1, 10)]
        public int RoomMaxCapacity { get; set; }

        public int RoomStatus { get; set; } = 1;

        [Range(0, double.MaxValue)]
        public decimal RoomPricePerDate { get; set; }

        public int RoomTypeID { get; set; }

        // Navigation property
        public virtual RoomType? RoomType { get; set; }
    }
}
