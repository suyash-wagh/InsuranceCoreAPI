using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class WithdrawAccount : BaseEntity
    {
        public Guid AccountId { get; set; }

        [NotMapped]
        public List<Commission> Commissions { get; set; }
    }
}
