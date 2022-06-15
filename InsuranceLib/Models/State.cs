using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class State : BaseEntity
    {
        public string StateName { get; set; }
        public bool IsActive { get; set; }  
    }
}
