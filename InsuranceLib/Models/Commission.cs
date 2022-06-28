using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class Commission : BaseEntity
    {
        public string AgentId { get; set; }
        public Guid AccountId { get; set; }
        public double CommissionAmount { get; set; }
        public Guid PolicyId { get; set; }

    }
}
