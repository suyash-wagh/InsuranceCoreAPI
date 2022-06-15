using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class AddTypeViewModel
    {
        [Required(ErrorMessage ="Type name is required.")]
        public string TypeTitle { get; set; }
        public bool IsActive { get; set; }
    }
}