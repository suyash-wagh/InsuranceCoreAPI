using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceWebApi.Controllers
{
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

        public AgentController(IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Policy> policyRepo,
                               IRepository<InsuranceAccount> accountsRepo,
                               IRepository<Payment> paymentsRepo,
                               IRepository<InsuranceClaim> claimsRepo,
                               IRepository<Commission> commsRepo,
                               IRepository<WithdrawAccount> wdaccountsRepo)
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
    }
}
