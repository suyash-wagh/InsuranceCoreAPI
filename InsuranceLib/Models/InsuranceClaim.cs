using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class InsuranceClaim : BaseEntity
    {
        public Guid AccountId { get; set; }
        public double WithdrawalAmount { get; set; }
        public bool IsWithdrawed { get; set; }
    }
}
