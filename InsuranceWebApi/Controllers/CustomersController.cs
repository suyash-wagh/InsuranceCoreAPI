using InsuranceLib.BL.Services;
using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepository<Payment> paymentsRepo;
        private readonly IRepository<InsuranceClaim> claimsRepo;

        public CustomersController(IRepository<State> statesRepo,
                               IRepository<City> citiesRepo,
                               IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Image> imagesRepo,
                               IRepository<Policy> policyRepo,
                               IRepository<InsuranceAccount> accountsRepo,
                               IRepository<Payment> paymentsRepo,
                               IRepository<InsuranceClaim> claimsRepo)
        {
            this.statesRepo = statesRepo;
            this.citiesRepo = citiesRepo;
            this.schemesRepo = schemesRepo;
            this.plansRepo = plansRepo;
            this.typesRepo = typesRepo;
            this.imagesRepo = imagesRepo;
            this.policyRepo = policyRepo;
            this.accountsRepo = accountsRepo;
            this.paymentsRepo = paymentsRepo;
            this.claimsRepo = claimsRepo;
        }

        [HttpGet("getPolicies")]
        public async Task<IActionResult> GetPolicies()
        {
            return Ok(await policyRepo.GetAll());
        }
        [HttpGet("getPayments")]
        public async Task<IActionResult> GetPayments()
        {
            return Ok(await paymentsRepo.GetAll());
        }
        [HttpGet("getClaims")]
        public async Task<IActionResult> GetClaims()
        {
            return Ok(await claimsRepo.GetAll());
        }

        [HttpPost("addPolicy")]
        public async Task<IActionResult> PostPolicy([FromBody] AddPolicyViewModel policyVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            InsurancePlan planHere = await plansRepo.FirstOrDefault(p => p.InsuranceSchemeTitle == policyVm.InsuranceSchemeTitle);
            InsuranceScheme schemeHere = await schemesRepo.FirstOrDefault(p => p.InsuranceSchemeTitle == policyVm.InsuranceSchemeTitle);
            InsuranceAccount accountHere = await accountsRepo.FirstOrDefault(a => a.CustomerId == policyVm.CustomerId);
            if (policyVm.TotalPremiumAmount > planHere.InvestmentMax || policyVm.TotalPremiumAmount < planHere.InvestmentMin)
            {
                return BadRequest("Investment amount is not valid");
            }
            int endYears = planHere.PolicyTermMax;
            double agentCommission = policyVm.InstallmentAmount * schemeHere.CommissionNewRegistration / 100;
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
                AgentCommission = policyVm.TotalPremiumAmount * schemeHere.CommissionNewRegistration / 100,
                InstallmentAmount = policyVm.InstallmentAmount,
                InstallmentsCount = policyVm.InstallmentCount
            });

            await paymentsRepo.Add(new Payment()
            {
                AccountId = accountHere.Id,
                PaymentAmount = policyVm.InstallmentAmount,
                FinalAmount = policyVm.InstallmentAmount - agentCommission,
                PaidDate = DateTime.Now,
                IsPaid = true,
                InstallmentNumber = 1
            });

            return Ok("Policy Added.");
        }

        [HttpPost("addPayment")]
        public async Task<IActionResult> AddPayment([FromBody] AddPaymentViewModel paymentVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            InsuranceAccount accountHere = await accountsRepo.FirstOrDefault(a => a.CustomerId == paymentVm.CustomerId);
            InsuranceScheme schemeHere = await schemesRepo.FirstOrDefault(p => p.InsuranceSchemeTitle == paymentVm.InsuranceSchemeTitle);
            var accountPayments = await paymentsRepo.GetWhere(p => p.AccountId == accountHere.Id);
            var agentCommission = paymentVm.Amount * schemeHere.CommissionPerInstallment / 100;
            if (accountHere == null) return BadRequest("No accounts found");

            await paymentsRepo.Add(new Payment()
            {
                AccountId = accountHere.Id,
                PaymentAmount = paymentVm.Amount,
                FinalAmount = paymentVm.Amount - agentCommission,
                PaidDate = DateTime.Now,
                IsPaid = true,
                InstallmentNumber = accountPayments.Count() + 1
            });
            return Ok("Payment Added.");
        }

        [HttpGet("getAccountByCustomerId/{customerId}")]
        public async Task<IActionResult> GetAccountByCustomerId(string customerId)
        {
            var accounts = await accountsRepo.GetWhere(a => a.CustomerId == customerId);
            var account = Enumerable.ToList(accounts)[0];

            var policies = await policyRepo.GetWhere(p => p.AccountId == account.Id);
            var payments = await paymentsRepo.GetWhere(p => p.AccountId == account.Id);
            var claims = await claimsRepo.GetWhere(c => c.AccountId == account.Id);

            account.Policies = (List<Policy>)policies;
            account.Payments = (List<Payment>)payments;
            account.InsuranceClaims = (List<InsuranceClaim>)claims;
            return Ok(account);
        }

        [HttpGet("getAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await accountsRepo.GetAll());
        }

        [HttpGet("getAccountsByAgentId/{agentId}")]
        public async Task<IActionResult> GetAccountsByAgentId(string agentId)
        {
            var accounts = await accountsRepo.GetWhere(a => a.AgentId == agentId);
            var accountsList = Enumerable.ToList(accounts);

            foreach(var account in accountsList)
            {
                var policies = await policyRepo.GetWhere(p => p.AccountId == account.Id);
                var payments = await paymentsRepo.GetWhere(p => p.AccountId == account.Id);
                var claims = await claimsRepo.GetWhere(c => c.AccountId == account.Id);
                account.Policies = (List<Policy>)policies;
                account.Payments = (List<Payment>)payments;
                account.InsuranceClaims = (List<InsuranceClaim>)claims;
            }
            return Ok(accountsList);
        }
    }
}
