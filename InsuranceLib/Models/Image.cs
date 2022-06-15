using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class Image : BaseEntity
    {
        public string ImageTitle { get; set; }
        public Byte[] ImageData { get; set; }
    }
}
