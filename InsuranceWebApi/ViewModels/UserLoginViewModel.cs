using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
