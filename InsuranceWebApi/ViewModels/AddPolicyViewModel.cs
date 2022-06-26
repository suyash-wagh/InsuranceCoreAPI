﻿using InsuranceLib.DAL.Models;
using System;

namespace InsuranceWebApi.ViewModels
{
    public class AddPolicyViewModel
    {
        public string CustomerId { get; set; }
        public string InsuranceTypeTitle { get; set; }
        public string InsuranceSchemeTitle { get; set; }
        public double TotalPremiumAmount { get; set; }
    }
}