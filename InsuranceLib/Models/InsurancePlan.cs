using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class InsurancePlan : BaseEntity
    {
        public string InsuranceTypeTitle{ get; set; }
        public InsuranceType InsuranceType { get; set; }

        public string InsuranceSchemeTitle { get; set; }
        public InsuranceScheme InsuranceScheme { get; set; }

        public int PolicyTermMin { get; set; }
        public int PolicyTermMax { get; set; }

        public int AgeMin { get; set; }
        public int AgeMax { get; set; }

        public int InvestmentMin { get; set; }
        public int InvestmentMax { get; set; }

        public int ProfitRatio { get; set; }    
        public bool IsActive { get; set; }
    }
}
