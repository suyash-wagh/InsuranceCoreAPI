using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class AddSchemeViewModel
    {
        [Required(ErrorMessage = "Insurance Type is required.")]
        public string InsuranceTypeTitle { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string InsuranceSchemeTitle { get; set; }
        [Required(ErrorMessage = "Commission Per New Registration is required.")]
        public int CommissionNewRegistration { get; set; }
        [Required(ErrorMessage = "Commission Per Installment is required.")]
        public int CommissionPerInstallment { get; set; }
        [Required(ErrorMessage = "Information is required.")]
        public string Information { get; set; }
        public bool IsActive { get; set; }
    }
}
