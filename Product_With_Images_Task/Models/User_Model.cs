using System.ComponentModel.DataAnnotations;

namespace Product_With_Images_Task.Models
{
    public class User_Model
    {
        public int User_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string User_Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string User_Password { get; set; }

        [Compare("User_Password", ErrorMessage = "Password Not Match")]
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        public string User_Confirm_Password { get; set; }

        [Required(ErrorMessage = "Please Enter Phone No")]
        [MaxLength(10, ErrorMessage = "Phone number cannot exceed 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please Enter a Valid 10-digit Phone Number")]
        public string User_Phone { get; set; }
    }
}
