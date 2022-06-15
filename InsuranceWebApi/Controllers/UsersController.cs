using InsuranceLib.BL.Services;
using InsuranceLib.DAL;
using InsuranceLib.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InsuranceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService service;

        public UsersController(UsersService service)
        {
            this.service = service;
        }

        [HttpPost("addAdmin")]
        public async Task<IActionResult> addAdmin([FromBody] AddAdminViewModel adminVm)
        {
            await service.AddAdmin(new User()
            {
                FirstName = adminVm.FirstName,
                LastName = adminVm.LastName,
                Email = adminVm.Email,
                PasswordHash = adminVm.Password,
                DoB = adminVm.DoB,
                Age = DateTime.Now.AddYears(-adminVm.DoB.Year).Year,
                UserName = adminVm.UserName,
        });
            return Ok(adminVm);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await service.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            return Ok(await service.GetUserById(id));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] AddAdminViewModel userVm, string id)
        {
            User user = new User()
            {
                FirstName = userVm.FirstName,
                LastName = userVm.LastName,
                Email = userVm.Email,
                PasswordHash = userVm.Password
            };
            await service.Update(id, user);
            return Ok("User updated.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await service.GetUserById(id);
            await service.RemoveUser(user);
            return Ok("User deleted");
        }

    }
}
