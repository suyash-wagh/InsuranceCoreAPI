using System;

namespace InsuranceWebApi.ViewModels
{
    public class JwtTokenViewModel
    {
        public string Token { get; set; }
        public DateTime ExiresAt { get; set; }
    }
}
