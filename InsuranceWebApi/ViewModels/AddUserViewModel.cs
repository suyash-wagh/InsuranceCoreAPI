using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DoB { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression("^\\s*(?:\\+?(\\d{1,3}))?[-. (]*(\\d{3})[-. )]*(\\d{3})[-. ]*(\\d{4})(?: *x(\\d+))?\\s*$", 
            ErrorMessage = "Please enter correct Phone number.")]
        public string PhoneNumber { get; set; }
    }
}