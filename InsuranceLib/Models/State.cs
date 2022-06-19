using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    [Table("State")]
    public class State : BaseEntity
    {
        public string StateName { get; set; }
        public bool IsActive { get; set; }  
    }
}
