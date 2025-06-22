using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTOs 
{
    public class RoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Room number is required")]
        [StringLength(50, ErrorMessage = "Room number cannot exceed 50 characters")]
        public string RoomNumber { get; set; } = string.Empty;

        [StringLength(220, ErrorMessage = "Description cannot exceed 220 characters")]
        public string RoomDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Max capacity is required")]
        [Range(1, 10, ErrorMessage = "Max capacity must be between 1 and 10")]
        public int RoomMaxCapacity { get; set; }

        public int RoomStatus { get; set; } = 1;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal RoomPricePerDate { get; set; }

        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeID { get; set; }

        // Navigation properties
        public string RoomTypeName { get; set; } = string.Empty;

        // Computed properties
        public string StatusText => RoomStatus == 1 ? "Active" : "Deleted";
        public string FormattedPrice => RoomPricePerDate.ToString("N0") + " VND";
    }
}
