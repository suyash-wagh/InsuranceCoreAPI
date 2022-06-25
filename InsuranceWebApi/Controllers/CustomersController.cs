using InsuranceLib.BL.Services;
using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace InsuranceWebApi.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository<State> statesRepo;
        private readonly IRepository<City> citiesRepo;
        private readonly IRepository<InsuranceScheme> schemesRepo;
        private readonly IRepository<InsurancePlan> plansRepo;
        private readonly IRepository<InsuranceType> typesRepo;
        private readonly IRepository<Image> imagesRepo;
        private readonly IRepository<Policy> policyRepo;
        private readonly IRepository<InsuranceAccount> accountsRepo;

        public CustomersController(IRepository<State> statesRepo,
                               IRepository<City> citiesRepo,
                               IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Image> imagesRepo,
                               IRepository<Policy> policyRepo,
                               IRepository<InsuranceAccount> accountsRepo)
        {
            this.statesRepo = statesRepo;
            this.citiesRepo = citiesRepo;
            this.schemesRepo = schemesRepo;
            this.plansRepo = plansRepo;
            this.typesRepo = typesRepo;
            this.imagesRepo = imagesRepo;
            this.policyRepo = policyRepo;
            this.accountsRepo = accountsRepo;
        }

        [HttpGet("getPolicies")]
        public async Task<IActionResult> GetPolicies()
        {
            return Ok(await policyRepo.GetAll());
        }

        [HttpPost("addPolicy")]
        public async Task<IActionResult> PostPolicy([FromBody] AddPolicyViewModel policyVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            InsurancePlan planHere = await plansRepo.FirstOrDefault(p => p.InsuranceSchemeTitle == policyVm.InsuranceSchemeTitle);
            InsuranceScheme schemeHere = await schemesRepo.FirstOrDefault(p => p.InsuranceSchemeTitle == policyVm.InsuranceSchemeTitle);
            InsuranceAccount accountHere = await accountsRepo.FirstOrDefault(a => a.Customer.Id == policyVm.CustomerId);
            if (policyVm.TotalPremiumAmount > planHere.InvestmentMax || policyVm.TotalPremiumAmount < planHere.InvestmentMin)
            {
                return BadRequest("Investment amount is not valid");
            }
            int endYears = planHere.PolicyTermMax;
            await policyRepo.Add(new Policy()
            {
                AccountId = accountHere.Id,
                InsuranceTypeTitle = policyVm.InsuranceTypeTitle,
                InsuranceSchemeTitle = policyVm.InsuranceSchemeTitle,
                MaturityDate = DateTime.Now.AddYears(endYears),
                PolicyTerm = endYears,
                TotalPremiumAmount = policyVm.TotalPremiumAmount,
                ProfitRatio = planHere.ProfitRatio,
                SumAssured = policyVm.TotalPremiumAmount + policyVm.TotalPremiumAmount * planHere.ProfitRatio / 100,
                AgentCommission = policyVm.TotalPremiumAmount * schemeHere.CommissionNewRegistration / 100
            });
            return Ok("Policy Added.");
        }
    }
}
