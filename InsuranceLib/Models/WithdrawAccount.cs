using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InsuranceLib.DAL.Models
{
    public class WithdrawAccount : BaseEntity
    {
        public string AgentId { get; set; }
        public double TotalAmount{ get; set; }

        [NotMapped]
        private List<Commission> _commissions;
        [NotMapped]
        public List<Commission> Commissions 
        {
            get { return _commissions; }
            set 
            { 
                _commissions = value;
                foreach(Commission commission in _commissions)
                {
                    TotalAmount += commission.CommissionAmount;
                }       
            }
        }
    }
}
