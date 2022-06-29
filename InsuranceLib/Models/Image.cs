using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    [Table("Image")]
    public class Image : BaseEntity
    {
        public string BaseEntityId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageData { get; set; }
        
    }
}
