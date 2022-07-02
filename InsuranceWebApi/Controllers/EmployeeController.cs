using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.Helpers;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceWebApi.Controllers
{
    [Authorize(Roles = Roles.Employee)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
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

        public EmployeeController(IRepository<State> statesRepo,
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


        [HttpPut("Query/replyToQuery")]
        public async Task<IActionResult> ReplyToQuery(Query query)
        {
            await queryRepo.Update(query);
            return Ok("Query Updated.");
        }

        [HttpGet("Query/getQueries")]
        public async Task<IActionResult> GetQueries()
        {
            return Ok(await queryRepo.GetAll());
        }

        [HttpGet("Query/getQueryById/{id}")]
        public async Task<IActionResult> GetQueriesById(string id)
        {
            return Ok(await queryRepo.GetWhere(q => q.Id.ToString() == id));
        }

        [HttpGet("getPayments")]
        public async Task<IActionResult> GetPayments()
        {
            return Ok(await paymentsRepo.GetAll());
        }

        [HttpGet("state/getState/{id}")]
        public async Task<IActionResult> GetStateById(Guid id)
        {
            return Ok(await statesRepo.GetById(id));
        }

        [HttpPost("state/addState")]
        public async Task<IActionResult> PostState([FromBody] AddStateViewModel stateVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");

            await statesRepo.Add(new State()
            {
                StateName = stateVm.StateName,
                IsActive = stateVm.IsActive
            });
            return Ok("State Added.");
        }

        [HttpPut("state/update")]
        public async Task<IActionResult> PutState([FromBody] State value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await statesRepo.Update(value);
            return Ok("State updated.");
        }

        [HttpDelete("state/{id}")]
        public async Task<IActionResult> DeleteState(Guid id)
        {
            await statesRepo.Remove(id);
            return Ok("State deleted.");
        }

        [HttpGet("InsuranceScheme/getScheme/{id}")]
        public async Task<IActionResult> GetSchemeById(Guid id)
        {
            return Ok(await schemesRepo.FirstOrDefault(s => s.Id == id));
        }

        [HttpGet("InsuranceScheme/getMainSchemes")]
        public async Task<IActionResult> GetMainSchemesById()
        {
            return Ok(await schemesRepo.GetAll());
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

        [HttpDelete("InsuranceScheme/{id}")]
        public async Task<IActionResult> DeleteScheme(Guid id)
        {
            await schemesRepo.Remove(id);
            return Ok("Scheme deleted.");
        }

        [HttpPut("InsuranceScheme/update")]
        public async Task<IActionResult> PutScheme([FromBody] InsuranceScheme value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await schemesRepo.Update(value);
            return Ok("Scheme updated.");
        }

        [HttpPost("InsuranceScheme/addScheme")]
        public async Task<IActionResult> PostScheme([FromBody] AddSchemeViewModel schemeVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await schemesRepo.Add(new InsuranceScheme()
            {
                InsuranceTypeTitle = schemeVm.InsuranceTypeTitle,
                InsuranceSchemeTitle = schemeVm.InsuranceSchemeTitle,
                Information = schemeVm.Information,
                CommissionNewRegistration = schemeVm.CommissionNewRegistration,
                CommissionPerInstallment = schemeVm.CommissionPerInstallment,
                IsActive = schemeVm.IsActive,

            });
            return Ok("Scheme Added.");
        }

        [HttpGet("InsurancePlan/getPlan/{id}")]
        public async Task<IActionResult> GetPlansById(Guid id)
        {
            return Ok(await plansRepo.GetById(id));
        }

        [HttpDelete("InsurancePlan/{id}")]
        public async Task<IActionResult> DeletePlan(Guid id)
        {
            await plansRepo.Remove(id);
            return Ok("Plan deleted.");
        }

        [HttpGet("InsuranceType/getTypes")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await typesRepo.GetAll());
        }

        [HttpPut("InsuranceType/update")]
        public async Task<IActionResult> PutType([FromBody] InsuranceType value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await typesRepo.Update(value);
            return Ok("Type updated.");
        }

        [HttpGet("InsuranceType/getType/{id}")]
        public async Task<IActionResult> GetTypeById(Guid id)
        {
            return Ok(await typesRepo.GetById(id));
        }

        [HttpDelete("InsuranceType/{id}")]
        public async Task<IActionResult> DeleteType(Guid id)
        {
            await typesRepo.Remove(id);
            return Ok("Type deleted.");
        }

        [HttpPut("InsurancePlan/update")]
        public async Task<IActionResult> PutPlan([FromBody] InsurancePlan value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await plansRepo.Update(value);
            return Ok("Plan updated.");
        }

        [HttpPost("InsurancePlan/addPlan")]
        public async Task<IActionResult> PostPlan([FromBody] AddPlanViewModel planVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await plansRepo.Add(new InsurancePlan()
            {
                InsuranceTypeTitle = planVm.InsuranceTypeTitle,
                InsuranceSchemeTitle = planVm.InsuranceSchemeTitle,

                InvestmentMax = planVm.InvestmentMax,
                InvestmentMin = planVm.InvestmentMin,

                PolicyTermMax = planVm.PolicyTermMax,
                PolicyTermMin = planVm.PolicyTermMin,

                AgeMax = planVm.AgeMax,
                AgeMin = planVm.AgeMin,

                ProfitRatio = planVm.ProfitRatio,

                IsActive = planVm.IsActive,

            });
            return Ok("Plan Added.");
        }

        [HttpGet("city/getCity/{id}")]
        public async Task<IActionResult> GetCityById(Guid id)
        {
            return Ok(await citiesRepo.GetById(id));
        }

        [HttpPut("city/update")]
        public async Task<IActionResult> PutCity([FromBody] City value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await citiesRepo.Update(value);
            return Ok("City updated.");
        }

        [HttpPost("city/addCity")]
        public async Task<IActionResult> PostCity([FromBody] AddCityViewModel cityVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await citiesRepo.Add(new City()
            {
                CityName = cityVm.CityName,
                IsActive = cityVm.IsActive,
                StateTitle = cityVm.StateTitle
            });
            return Ok("City Added.");
        }

        [HttpGet("InsurancePlan/getPlans")]
        public async Task<IActionResult> GetPlans()
        {
            return Ok(await plansRepo.GetAll());
        }

        [HttpGet("city/getCities")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await citiesRepo.GetAll());
        }

        [HttpGet("state/getStates")]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await statesRepo.GetAll());
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

    }
}
