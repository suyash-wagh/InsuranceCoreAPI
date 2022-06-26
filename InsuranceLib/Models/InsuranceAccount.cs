using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class InsuranceAccount : BaseEntity
    {
        public string CustomerId { get; set; }

        public string AgentId { get; set; }

        [NotMapped]
        public List<Policy> Policies { get; set; }
    }
}
