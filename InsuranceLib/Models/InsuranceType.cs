using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class InsuranceType : BaseEntity
    {
        public string TypeTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
