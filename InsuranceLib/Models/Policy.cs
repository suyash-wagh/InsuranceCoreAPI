using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class Policy : BaseEntity
    {
        public int AccountNumber { get; set; }
        public string InsuranceTypeTitle { get; set; }
        public string InsuranceSchemeTitle { get; set; }
        public DateTime MaturityDate { get; set; }
        public int PolicyTerm { get; set; }
        public double TotalPremiumAmount { get; set; }
        public int ProfitRatio { get; set; }
        public double SumAssured { get; set; }
        public double AgentCommission { get; set; }
    }
}
