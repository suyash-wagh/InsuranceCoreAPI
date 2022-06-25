using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class InsuranceAccount : BaseEntity
    {
        public int AccountNumber { get; set; }

        public Guid CustomerId { get; set; }
        public User Customer { get; set; }

        public Guid AgentId { get; set; }
        public User Agent { get; set; }

        [NotMapped]
        public List<Policy> Policies { get; set; }
    }
}
