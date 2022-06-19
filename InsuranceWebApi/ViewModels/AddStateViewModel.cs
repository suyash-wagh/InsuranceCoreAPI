using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class AddStateViewModel
    {
        [Required(ErrorMessage = "State Name is required.")]
        public string StateName { get; set; }

        public bool IsActive { get; set; }
    }
}
