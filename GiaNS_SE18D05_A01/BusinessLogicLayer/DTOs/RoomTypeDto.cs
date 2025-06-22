using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTOs // Sửa từ BusinessLogicLayer.Service
{
    public class RoomTypeDto
    {
        public int RoomTypeID { get; set; }

        [Required(ErrorMessage = "Room type name is required")]
        [StringLength(50, ErrorMessage = "Room type name cannot exceed 50 characters")]
        public string RoomTypeName { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string TypeDescription { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Note cannot exceed 250 characters")]
        public string TypeNote { get; set; } = string.Empty;

        // Computed properties
        public int RoomCount { get; set; }
    }
}
