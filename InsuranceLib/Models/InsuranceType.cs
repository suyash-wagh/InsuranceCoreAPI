using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    [Table("InsuranceType")]
    public class InsuranceType : BaseEntity
    {
        public string TypeTitle { get; set; }
        public Image TypeImage { get; set; }
        public bool IsActive { get; set; }
    }
}
