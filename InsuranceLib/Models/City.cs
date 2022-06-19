using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    [Table("City")]
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public State State { get; set; }
        public string StateTitle { get; set; }
    }
}
