using System;

namespace InsuranceWebApi.ViewModels
{
    public class SendSchemeWithImage
    {
        public Guid Id { get; set; }
        public string InsuranceTypeTitle { get; set; }
        public string InsranceTypeImage { get; set; }
        public string InsuranceSchemeTitle { get; set; }
        public int CommissionNewRegistration { get; set; }
        public int CommissionPerInstallment { get; set; }
        public string Information { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
