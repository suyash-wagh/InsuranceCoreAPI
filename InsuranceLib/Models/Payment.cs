using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class Payment : BaseEntity
    {
        public Guid AccountId { get; set; }
        public double TransactionAmount { get; set; }
        public double PaymentAmount { get; set; }
        public double FinalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidDate { get; set; }
        public int InstallmentNumber { get; set; }
    }
}
