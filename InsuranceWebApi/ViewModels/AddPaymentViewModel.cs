using System;

namespace InsuranceWebApi.ViewModels
{
    public class AddPaymentViewModel
    {
        public string CustomerId { get; set; }
        public Guid PolicyId { get; set; }
        public double Amount { get; set; }
        public string InsuranceSchemeTitle { get; set; }
        public int InstallmentNumber { get; set; }
    }
}
