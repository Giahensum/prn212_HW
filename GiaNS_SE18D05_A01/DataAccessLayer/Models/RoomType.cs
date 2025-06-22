using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomTypeName { get; set; } = string.Empty;

        [StringLength(250)]
        public string TypeDescription { get; set; } = string.Empty;

        [StringLength(250)]
        public string TypeNote { get; set; } = string.Empty;

        // Navigation property
        public virtual ICollection<RoomInformation> Rooms { get; set; } = new HashSet<RoomInformation>();
    }
}
