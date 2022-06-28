using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class Query : BaseEntity
    {
        public string CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyTime { get; set; }
    }
}
