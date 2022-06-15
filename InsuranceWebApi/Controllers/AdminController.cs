using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository<State> statesRepo;
        private readonly IRepository<City> citiesRepo;
        private readonly IRepository<InsuranceScheme> schemesRepo;
        private readonly IRepository<InsurancePlan> plansRepo;
        private readonly IRepository<InsuranceType> typesRepo;
        private readonly IRepository<Image> imagesRepo;

        public AdminController(IRepository<State> statesRepo, 
                               IRepository<City> citiesRepo,
                               IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Image> imagesRepo)
        {
            this.statesRepo = statesRepo;
            this.citiesRepo = citiesRepo;
            this.schemesRepo = schemesRepo;
            this.plansRepo = plansRepo;
            this.typesRepo = typesRepo;
            this.imagesRepo = imagesRepo;
        }

        [HttpGet("state/getStates")]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await statesRepo.GetAll());
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
                StateName = stateVm.Title,
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


        //City Api Endpoints---------------------------------------------------------------------------------------->

        [HttpGet("city/getCities")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await citiesRepo.GetAll());
        }

        [HttpGet("city/getCity/{id}")]
        public async Task<IActionResult> GetCityById(Guid id)
        {
            return Ok(await citiesRepo.GetById(id));
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

        [HttpPut("city/update")]
        public async Task<IActionResult> PutCity([FromBody] City value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await citiesRepo.Update(value);
            return Ok("City updated.");
        }

        [HttpDelete("city/{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            await citiesRepo.Remove(id);
            return Ok("City deleted.");
        }


        //Insurance Scheme Api Endpoints---------------------------------------------------------------------------------------->

        [HttpGet("InsuranceScheme/getSchemes")]
        public async Task<IActionResult> GetSchemes()
        {
            return Ok(await schemesRepo.GetAll());
        }

        [HttpGet("InsuranceScheme/getScheme/{id}")]
        public async Task<IActionResult> GetSchemeById(Guid id)
        {
            return Ok(await schemesRepo.GetById(id));
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

        [HttpPut("InsuranceScheme/update")]
        public async Task<IActionResult> PutScheme([FromBody] InsuranceScheme value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await schemesRepo.Update(value);
            return Ok("Scheme updated.");
        }

        [HttpDelete("InsuranceScheme/{id}")]
        public async Task<IActionResult> DeleteScheme(Guid id)
        {
            await schemesRepo.Remove(id);
            return Ok("Scheme deleted.");
        }


        //Insurance Plans Api Endpoints---------------------------------------------------------------------------------------->

        [HttpGet("InsurancePlan/getPlans")]
        public async Task<IActionResult> GetPlans()
        {
            return Ok(await plansRepo.GetAll());
        }

        [HttpGet("InsurancePlan/getPlan/{id}")]
        public async Task<IActionResult> GetPlansById(Guid id)
        {
            return Ok(await plansRepo.GetById(id));
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

        [HttpPut("InsurancePlan/update")]
        public async Task<IActionResult> PutPlan([FromBody] InsurancePlan value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await plansRepo.Update(value);
            return Ok("Plan updated.");
        }

        [HttpDelete("InsurancePlan/{id}")]
        public async Task<IActionResult> DeletePlan(Guid id)
        {
            await plansRepo.Remove(id);
            return Ok("Plan deleted.");
        }


        //Insurance Types Api Endpoints---------------------------------------------------------------------------------------->

        [HttpGet("InsuranceType/getTypes")]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await typesRepo.GetAll());
        }

        [HttpGet("InsuranceType/getType/{id}")]
        public async Task<IActionResult> GetTypeById(Guid id)
        {
            return Ok(await typesRepo.GetById(id));
        }

        [HttpPost("InsuranceType/addType")]
        public async Task<IActionResult> PostType([FromBody] AddTypeViewModel planVm)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await typesRepo.Add(new InsuranceType()
            {
                TypeTitle = planVm.TypeTitle,
                IsActive = planVm.IsActive,
            });
            return Ok("Type Added.");
        }

        [HttpPut("InsuranceType/update")]
        public async Task<IActionResult> PutType([FromBody] InsuranceType value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await typesRepo.Update(value);
            return Ok("Type updated.");
        }

        [HttpDelete("InsuranceType/{id}")]
        public async Task<IActionResult> DeleteType(Guid id)
        {
            await typesRepo.Remove(id);
            return Ok("Type deleted.");
        }
    }
}
