using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceWebApi.Controllers
{
    [Authorize(Roles= Roles.Agent)]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IRepository<InsuranceScheme> schemesRepo;
        private readonly IRepository<InsurancePlan> plansRepo;
        private readonly IRepository<InsuranceType> typesRepo;
        private readonly IRepository<Policy> policyRepo;
        private readonly IRepository<InsuranceAccount> accountsRepo;
        private readonly IRepository<Payment> paymentsRepo;
        private readonly IRepository<InsuranceClaim> claimsRepo;
        private readonly IRepository<Commission> commsRepo;
        private readonly IRepository<WithdrawAccount> wdaccountsRepo;
        private readonly IRepository<Image> imagesRepo;
        private readonly IRepository<State> statesRepo;
        private readonly IRepository<City> citiesRepo;

        public AgentController(IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Policy> policyRepo,
                               IRepository<InsuranceAccount> accountsRepo,
                               IRepository<Payment> paymentsRepo,
                               IRepository<InsuranceClaim> claimsRepo,
                               IRepository<Commission> commsRepo,
                               IRepository<WithdrawAccount> wdaccountsRepo,
                               IRepository<Image> imagesRepo,
                               IRepository<State> statesRepo,
                               IRepository<City> citiesRepo)
        {
            this.schemesRepo = schemesRepo;
            this.plansRepo = plansRepo;
            this.typesRepo = typesRepo;
            this.policyRepo = policyRepo;
            this.accountsRepo = accountsRepo;
            this.paymentsRepo = paymentsRepo;
            this.claimsRepo = claimsRepo;
            this.commsRepo = commsRepo;
            this.wdaccountsRepo = wdaccountsRepo;
            this.imagesRepo = imagesRepo;
            this.statesRepo = statesRepo;
            this.citiesRepo = citiesRepo;
        }


        [HttpGet("getPaymentsByPolicyId/{policyId}")]
        public async Task<IActionResult> GetPaymentsByPolicyId(string policyId)
        {
            return Ok(await paymentsRepo.GetWhere(p => p.PolicyId.ToString() == policyId));
        }

        [HttpGet("getAccountsByAgentId/{agentId}")]
        public async Task<IActionResult> GetAccountsByAgentId(string agentId)
        {
            var accounts = await accountsRepo.GetWhere(a => a.AgentId == agentId);
            var accountsList = Enumerable.ToList(accounts);

            foreach (var account in accountsList)
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

        [HttpGet("state/getStates")]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await statesRepo.GetAll());
        }

        [HttpGet("city/getCities")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await citiesRepo.GetAll());
        }

        [HttpGet("getImagesByBaseId/{id}")]
        public async Task<IActionResult> GetImagesByBaseId(string id)
        {
            return Ok(await imagesRepo.GetWhere(i => i.BaseEntityId == id));
        }

        [HttpGet("getCommissions")]
        public async Task<IActionResult> GetCommissions()
        {
            return Ok(await commsRepo.GetAll());
        }

        [HttpGet("getCommissionById/{commId}")]
        public async Task<IActionResult> GetCommissionsById(string commId)
        {
            return Ok(await commsRepo.GetWhere(c => c.Id.ToString() == commId));
        }

        [HttpGet("getCommissionByAgentId/{agentId}")]
        public async Task<IActionResult> GetCommissionByAgentId(string agentId)
        {
            return Ok(await commsRepo.GetWhere(c => c.AgentId == agentId));
        }

        [HttpGet("getCommissionByAccountId/{accountId}")]
        public async Task<IActionResult> GetCommissionByAccountId(string accountId)
        {
            return Ok(await commsRepo.GetWhere(c => c.AccountId.ToString() == accountId));
        }

        [HttpGet("getWithdrawAccountById/{id}")]
        public async Task<IActionResult> GetWithdrawAccountById(string id)
        {
            return Ok(await wdaccountsRepo.GetWhere(w => w.Id.ToString() == id));
        }

        [HttpGet("getWithdrawAccounts")]
        public async Task<IActionResult> GetWithdrawAccounts()
        {
            return Ok(await wdaccountsRepo.GetAll());
        }

        [HttpGet("getWithdrawAccountByAgentId/{agentId}")]
        public async Task<IActionResult> GetWithdrawAccountByAgentId(string agentId)
        {
            var wdAccounts = await wdaccountsRepo.GetWhere(w => w.AgentId == agentId);
            var wdAccount = Enumerable.ToList(wdAccounts)[0];
            var commissions = await commsRepo.GetWhere(c => c.AgentId == agentId);
            wdAccount.Commissions = Enumerable.ToList(commissions);
           
            return Ok(wdAccount);
        }

        [HttpPut("withdrawAmount")]
        public async Task<IActionResult> WithdrawAmount(WithdrawAccount withdrawAccount)
        {
            var wdAccounts = await wdaccountsRepo.GetWhere(w => w.Id == withdrawAccount.Id);
            var wdAccount = Enumerable.ToList(wdAccounts)[0];
            wdAccount.TotalAmount -= withdrawAccount.TotalAmount;
            await wdaccountsRepo.Update(wdAccount);
            return Ok(wdAccount);
        }
    }
}
