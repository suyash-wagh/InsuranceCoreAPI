using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    [Table("BaseEntity")]
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
