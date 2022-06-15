using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class InsuranceScheme : BaseEntity
    {
        public string InsuranceTypeTitle { get; set; }
        public string InsuranceSchemeTitle { get; set; }
        public int CommissionNewRegistration { get; set; }
        public int CommissionPerInstallment { get; set; }
        public string Information { get; set; }
        public bool IsActive { get; set; }
    }
}
