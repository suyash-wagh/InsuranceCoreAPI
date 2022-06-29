using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class AddTypeViewModel
    {
        [Required(ErrorMessage ="Type name is required.")]
        public string TypeTitle { get; set; }
        public string TypeImage { get; set; }
        public bool IsActive { get; set; }
    }
}