using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class Commission : BaseEntity
    {
        public Guid AccountId { get; set; }
        public double Amount { get; set; }
    }
}
