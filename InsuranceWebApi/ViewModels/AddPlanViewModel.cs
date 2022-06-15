using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.ViewModels
{
    public class AddPlanViewModel
    {
        [Required(ErrorMessage = "Insurance Type is required.")]
        public string InsuranceTypeTitle { get; set; }

        [Required(ErrorMessage = "Insurance Scheme is required.")]
        public string InsuranceSchemeTitle { get; set; }

        [Required(ErrorMessage = "Minimum Policy Term is required.")]
        public int PolicyTermMin { get; set; }
        [Required(ErrorMessage = "Maximum Policy Term is required.")]
        public int PolicyTermMax { get; set; }

        [Required(ErrorMessage = "Minimum age is required.")]
        public int AgeMin { get; set; }
        [Required(ErrorMessage = "Maximum age is required.")]
        public int AgeMax { get; set; }

        [Required(ErrorMessage = "Minimum investment amount is required.")]
        public int InvestmentMin { get; set; }
        [Required(ErrorMessage = "Maximum investment amount is required.")]
        public int InvestmentMax { get; set; }

        [Required(ErrorMessage = "Profit Ratio is required.")]
        public int ProfitRatio { get; set; }
        public bool IsActive { get; set; }
    }
}
