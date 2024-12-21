using System.ComponentModel.DataAnnotations;

namespace Product_With_Images_Task.Models
{
    public class Auth_Model
    {
        public int User_ID { get; set; }

        public string User_Name { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
           ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]

        public string User_Password { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string User_Email { get; set; }

    }
}
