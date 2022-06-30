using InsuranceLib.BL.Services;
using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.Helpers;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = Roles.Customer)]
    [Route("api/[controller]")]
    [ApiController]
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
        private readonly IRepository<Commission> commsRepo;
        private readonly IRepository<WithdrawAccount> wdaccountsRepo;
        private readonly IRepository<Query> queryRepo;

        public CustomersController(IRepository<State> statesRepo,
                               IRepository<City> citiesRepo,
                               IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Image> imagesRepo,
                               IRepository<Policy> policyRepo,
                               IRepository<InsuranceAccount> accountsRepo,
                               IRepository<Payment> paymentsRepo,
                               IRepository<InsuranceClaim> claimsRepo,
                               IRepository<Commission> commsRepo,
                               IRepository<WithdrawAccount> wdaccountsRepo,
                               IRepository<Query> queryRepo)
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
            this.commsRepo = commsRepo;
            this.wdaccountsRepo = wdaccountsRepo;
            this.queryRepo = queryRepo;
        }

        [HttpPost("uploadDocument")]
        public async Task<IActionResult> UploadDocument([FromBody] AddDocumentViewModel docVm)
        {
            Image image = new Image();
            image.ImageTitle = docVm.DocumentTitle;
            image.BaseEntityId = docVm.BaseEntityId;
            image.ImageData = docVm.DocumentFile;

            await imagesRepo.Add(image);
            return Ok("Image uploaded.");
        }

        [HttpGet("InsuranceType/getTypes")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await typesRepo.GetAll());
        }

        [HttpGet("InsurancePlan/getPlans/{insuranceSchemeName}")]
        public async Task<IActionResult> GetPlanByScheme(string insuranceSchemeName)
        {
            return Ok(await plansRepo.GetWhere(s => s.InsuranceSchemeTitle == insuranceSchemeName));
        }

        [HttpGet("InsuranceScheme/getSchemes")]
        public async Task<IActionResult> GetSchemes()
        {
            List<SendSchemeWithImage> sendSchemes = new List<SendSchemeWithImage>();
            var schemes = Enumerable.ToList(await schemesRepo.GetAll());
            foreach (var scheme in schemes)
            {
                var type = await typesRepo.FirstOrDefault(t => t.TypeTitle == scheme.InsuranceTypeTitle);
                SendSchemeWithImage sendSchemeWithImage = new SendSchemeWithImage()
                {
                    Id = scheme.Id,
                    InsuranceSchemeTitle = scheme.InsuranceSchemeTitle,
                    Information = scheme.Information,
                    InsuranceTypeTitle = scheme.InsuranceTypeTitle,
                    InsranceTypeImage = type.TypeImage,
                    CreatedAt = scheme.CreatedAt,
                };
                sendSchemes.Add(sendSchemeWithImage);

            }
            return Ok(sendSchemes);
        }

        [HttpGet("getImagesByBaseId/{id}")]
        public async Task<IActionResult> GetImagesByBaseId(string id)
        {
            return Ok(await imagesRepo.GetWhere(i => i.BaseEntityId == id));
        }

        [HttpDelete("deleteDocument/{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            await imagesRepo.Remove(id);
            return Ok("Document Deleted.");
        }

        [HttpGet("InsuranceScheme/getSchemes/{insuranceTypeName}")]
        public async Task<IActionResult> GetSchemeByType(string insuranceTypeName)
        {
            return Ok(await schemesRepo.GetWhere(s => s.InsuranceTypeTitle == insuranceTypeName));
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
            //if (!ModelState.IsValid) return BadRequest("Not a valid input.");
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
                PolicyTerm = policyVm.PolicyTerm,
                TotalPremiumAmount = policyVm.TotalPremiumAmount,
                ProfitRatio = planHere.ProfitRatio,
                SumAssured = policyVm.SumAssured,
                AgentCommission = policyVm.TotalPremiumAmount * schemeHere.CommissionNewRegistration / 100,
                InstallmentAmount = policyVm.InstallmentAmount,
                InstallmentsCount = policyVm.InstallmentCount
            });
            var policies = await policyRepo.GetWhere(p => p.AccountId == accountHere.Id 
                                                          && p.InsuranceTypeTitle == planHere.InsuranceTypeTitle
                                                          && p.InsuranceSchemeTitle == schemeHere.InsuranceSchemeTitle);
            await paymentsRepo.Add(new Payment()
            {
                AccountId = accountHere.Id,
                PaymentAmount = policyVm.InstallmentAmount,
                FinalAmount = policyVm.InstallmentAmount - agentCommission,
                PaidDate = DateTime.Now,
                IsPaid = true,
                InstallmentNumber = 1,
                PolicyId = Enumerable.ToList(policies)[0].Id
            });

            await commsRepo.Add(new Commission()
            {
                AgentId = accountHere.AgentId,
                AccountId = accountHere.Id,
                CommissionAmount = agentCommission,
                PolicyId= Enumerable.ToList(policies)[0].Id
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
                InstallmentNumber = accountPayments.Count() + 1,
                PolicyId = paymentVm.PolicyId
            });

            await commsRepo.Add(new Commission()
            {
                AgentId = accountHere.AgentId,
                AccountId = accountHere.Id,
                CommissionAmount = agentCommission,
                PolicyId = paymentVm.PolicyId
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

        [HttpGet("getPaymentsByPolicyId/{policyId}")]
        public async Task<IActionResult> GetPaymentsByPolicyId(string policyId)
        {
            return Ok(await paymentsRepo.GetWhere(p => p.PolicyId.ToString() == policyId));
        }

        [HttpGet("getAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await accountsRepo.GetAll());
        }

        [HttpGet("getAccount/{id}")]
        public async Task<IActionResult> GetAccountById(string id)
        {
            var accounts = await accountsRepo.GetWhere(a => a.Id == Guid.Parse(id));
            var account = Enumerable.ToList(accounts)[0];

            var policies = await policyRepo.GetWhere(p => p.AccountId == account.Id);
            var payments = await paymentsRepo.GetWhere(p => p.AccountId == account.Id);
            var claims = await claimsRepo.GetWhere(c => c.AccountId == account.Id);

            account.Policies = (List<Policy>)policies;
            account.Payments = (List<Payment>)payments;
            account.InsuranceClaims = (List<InsuranceClaim>)claims;
            return Ok(account);
        }

        [HttpGet("getPolicy/{id}")]
        public async Task<IActionResult> GetPolicyById(string id)
        {
            return Ok(await policyRepo.FirstOrDefault(a => a.Id == Guid.Parse(id)));
            
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

        [HttpPost("addQuery")]
        public async Task<IActionResult> AddQuery(AddQueryViewModel queryVm)
        {
            await queryRepo.Add(new Query()
            {
                CustomerId = queryVm.CustomerId,
                Title = queryVm.Title,
                Description = queryVm.Description
            });
            return Ok("Query added.");
        }

        [HttpGet("Query/getQueryByCustomerId/{id}")]
        public async Task<IActionResult> GetQueriesById(string id)
        {
            return Ok(await queryRepo.GetWhere(q => q.CustomerId == id));
        }
    }
}
