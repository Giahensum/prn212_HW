using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DTOs
{
    public class CustomerDto
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, ErrorMessage = "Full name cannot exceed 50 characters")]
        public string CustomerFullName { get; set; } = string.Empty;

        [StringLength(12, ErrorMessage = "Telephone cannot exceed 12 characters")]
        [RegularExpression(@"^[0-9+\-\s()]*$", ErrorMessage = "Invalid telephone format")]
        public string Telephone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime CustomerBirthday { get; set; }

        public int CustomerStatus { get; set; } = 1;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
        public string Password { get; set; } = string.Empty;

        // Computed properties
        public int Age => DateTime.Now.Year - CustomerBirthday.Year;
        public string StatusText => CustomerStatus == 1 ? "Active" : "Deleted";
    }
}
