using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Web.Helpers;
using System.IO;
using InsuranceWebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
namespace InsuranceWebApi.Controllers
{
   // [Authorize(Roles = Roles.Admin)]
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
        private readonly IRepository<Policy> policyRepo;
        private readonly IRepository<InsuranceAccount> accountsRepo;
        private readonly IRepository<Payment> paymentsRepo;
        private readonly IRepository<InsuranceClaim> claimsRepo;
        private readonly IRepository<Query> queryRepo;

        public AdminController(IRepository<State> statesRepo,
                               IRepository<City> citiesRepo,
                               IRepository<InsuranceScheme> schemesRepo,
                               IRepository<InsurancePlan> plansRepo,
                               IRepository<InsuranceType> typesRepo,
                               IRepository<Image> imagesRepo,
                               IRepository<Policy> policyRepo,
                               IRepository<InsuranceAccount> accountsRepo,
                               IRepository<Payment> paymentsRepo,
                               IRepository<InsuranceClaim> claimsRepo,
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
            this.queryRepo = queryRepo;
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
        [AllowAnonymous]
        [HttpGet("InsuranceScheme/getSchemes")]
        public async Task<IActionResult> GetSchemes()
        {
            return Ok(await schemesRepo.GetAll());
        }
            
        [AllowAnonymous]
        [HttpGet("InsuranceScheme/getScheme/{id}")]
        public async Task<IActionResult> GetSchemeById(Guid id)
        {
            return Ok(await schemesRepo.FirstOrDefault(s => s.Id == id));
        }

        [HttpGet("InsuranceScheme/getSchemes/{insuranceTypeName}")]
        public async Task<IActionResult> GetSchemeByType(string insuranceTypeName)
        {
            return Ok(await schemesRepo.GetWhere(s => s.InsuranceTypeTitle == insuranceTypeName));
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

        [HttpGet("InsurancePlan/getPlans/{insuranceSchemeName}")]
        public async Task<IActionResult> GetPlanByScheme(string insuranceSchemeName)
        {
            return Ok(await plansRepo.GetWhere(s => s.InsuranceSchemeTitle == insuranceSchemeName));
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

        [AllowAnonymous]
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

            if (planVm.ImageFile != null)
            {
                if (planVm.ImageFile.Length > 0)
                {
                    byte[] imageData = null;
                    IEnumerable<InsuranceType> type = await typesRepo.GetWhere(t => t.TypeTitle == planVm.TypeTitle);
                    using (var stream = planVm.ImageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            imageData = memoryStream.ToArray();
                        }
                    }
                    await imagesRepo.Add(new Image()
                    {
                        ImageData = imageData,
                        ImageTitle = planVm.ImageFile.FileName,
                        BaseEntity = type.GetEnumerator().Current
                    });
                    return Ok("Type Added along with the image.");
                }
            }
            return Ok("Type Added with no image.");
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


        //Query Api Endpoints---------------------------------------------------------------------------------------->

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
        //Image Api Endpoints---------------------------------------------------------------------------------------->

        [HttpGet("Image/getImages")]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await imagesRepo.GetAll());
        }

        [HttpGet("Image/getType/{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            return Ok(await imagesRepo.GetById(id));
        }

        //[HttpPost("Image/addType")]
        //public async Task<IActionResult> PostImage([FromBody] AddTypeViewModel planVm)
        //{
        //    if (!ModelState.IsValid) return BadRequest("Not a valid input.");
        //    await imagesRepo.Add(new Image()
        //    {
        //        TypeTitle = planVm.TypeTitle,
        //        IsActive = planVm.IsActive,
        //    });

        //}

        [HttpPut("Image/update")]
        public async Task<IActionResult> PutImage([FromBody] Image value)
        {
            if (!ModelState.IsValid) return BadRequest("Not a valid input.");
            await imagesRepo.Update(value);
            return Ok("Image updated.");
        }

        [HttpDelete("Image/{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            await imagesRepo.Remove(id);
            return Ok("Image deleted.");
        }
    }
}
