using InsuranceLib.BL.Services;
using InsuranceLib.DAL;
using InsuranceLib.DAL.Helpers;
using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories;
using InsuranceLib.DAL.Repositories.Users;
using InsuranceWebApi.Helpers;
using InsuranceWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService service;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<InsuranceAccount> accountsRepo;
        private readonly IRepository<Commission> commsRepo;
        private readonly IRepository<WithdrawAccount> wdaccountsRepo;
        private readonly IUsersRepository<User> usersRepo;
        private readonly IConfiguration _configuration;

        public UsersController(UsersService service, 
                               IConfiguration configuration, 
                               UserManager<User> userManager, 
                               RoleManager<IdentityRole> roleManager,
                               IRepository<InsuranceAccount> accountsRepo,
                               IRepository<Commission> commsRepo,
                               IRepository<WithdrawAccount> wdaccountsRepo,
                               IUsersRepository<User> usersRepo)
        {
            this.service = service;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.accountsRepo = accountsRepo;
            this.commsRepo = commsRepo;
            this.wdaccountsRepo = wdaccountsRepo;
            this.usersRepo = usersRepo;
            this._configuration = configuration;
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.Employee)]
        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await service.GetUsers());
        }

        [Authorize(Roles = Roles.Agent + "," + Roles.Admin + "," + Roles.Employee +  "," + Roles.Customer)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            return Ok(await service.GetUserById(id));
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("update-admin")]
        public async Task<IActionResult> UpdateAdmin([FromBody] User userVm)
        {
            await service.Update(userVm);
            return Ok("User updated.");
        }

        [Authorize(Roles = Roles.Agent + "," + Roles.Admin + "," + Roles.Employee + "," + Roles.Customer)]
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] User userVm)
        {
            await service.Update(userVm);
            return Ok("User updated.");
        }

        [Authorize(Roles = Roles.Admin+ "," + Roles.Employee)]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await service.GetUserById(id);
            await service.RemoveUser(user);
            return Ok("User deleted");
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.Employee)]
        [HttpGet("getUsersByRoles/{role}")]
        public async Task<IActionResult> GetUsersByRoles(string role)
        {
            return Ok(await service.GetUsersByroles(role));
        }

        [Authorize(Roles = Roles.Agent + "," + Roles.Admin + "," + Roles.Employee)]
        [HttpGet("getUsersByParentId/{parentId}")]
        public async Task<IActionResult> GetUsersByParentId(string parentId)
        {
            return Ok(await service.GetUsersByParentId(parentId));
        }
        //JWT Token---------------------------------------------------------------------------------------------------->


        private async Task<JwtTokenViewModel> GenerateJwtToken(User user)
        {
            List<Claim> userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var loginKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(loginKey, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var result = new JwtTokenViewModel
            {
                Token = jwtToken,
                ExiresAt = token.ValidTo
            };
            return result;
        }

        // Admin Actions ---------------------------------------------------------------------------------------->

        //[Authorize(Roles = Roles.Admin)]
        [HttpPost("addAdmin")]
        public async Task<IActionResult> addAdmin([FromBody] AddAdminViewModel adminVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }

            var userExists = await _userManager.FindByNameAsync(adminVm.UserName);
            if (userExists != null)
            {
                return BadRequest($"Admin username: {userExists.UserName} already exists.");
            }
            User userToAdd = new User()
            {
                FirstName = adminVm.FirstName,
                LastName = adminVm.LastName,
                Email = adminVm.Email,
                PasswordHash = adminVm.Password,
                UserName = adminVm.UserName,
            };

            var result = await _userManager.CreateAsync(userToAdd, adminVm.Password.Cipher());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userToAdd, Roles.Admin);
                return Ok("Added admin.");
            }
            else
                return BadRequest("Admin could not be created.");
        }

        [HttpPost("admin-login")]
        public async Task<IActionResult> AdminLogin([FromBody] UserLoginViewModel userVm)
        {
            //var userAvailable = await _userManager.FindByNameAsync(userVm.UserName);
            var userAvailable = await usersRepo.FirstOrDefault(u => u.UserName == userVm.UserName);
            var userRole = service.GetRoleIdByUserID(r => r.UserId == userAvailable.Id);
            var adminRoleId = service.GetRoleIdWhere(r => r.Name == Roles.Admin);

            if (userRole != adminRoleId)
            {
                return Unauthorized("Only admins can login.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }
            //var userExists = await _userManager.FindByNameAsync(userVm.UserName);
            var userExists = await usersRepo.FirstOrDefault(u => u.UserName == userVm.UserName && u.PasswordHash == userVm.Password.Cipher());

            if (userExists != null)
            {
                var tokenReturned = await GenerateJwtToken(userExists);
                return Ok(tokenReturned);
            }
            else
                return Unauthorized();
        }

        // Employee Actions ---------------------------------------------------------------------------------------->

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("addEmployee")]
        public async Task<IActionResult> addEmployee([FromBody] AddUserViewModel customerVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }

            var userExists = await _userManager.FindByNameAsync(customerVm.UserName);
            if (userExists != null)
            {
                return BadRequest($"Employee {userExists.UserName} already exists.");
            }
            User userToAdd = new User()
            {
                FirstName = customerVm.FirstName,
                LastName = customerVm.LastName,
                Email = customerVm.Email,
                PasswordHash = customerVm.Password,
                UserName = customerVm.UserName,
                DoB = customerVm.DoB,
                Age = DateTime.Now.AddYears(-customerVm.DoB.Year).Year,
                PhoneNumber = customerVm.PhoneNumber,
                ParentId = customerVm.ParentId
            };

            var result = await _userManager.CreateAsync(userToAdd, customerVm.Password.Cipher());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userToAdd, Roles.Employee);
                return Ok("Added Employee.");
            }
            else
                return BadRequest("Employee could not be created.");
        }

        [HttpPost("employee-login")]
        public async Task<IActionResult> EmployeeLogin([FromBody] UserLoginViewModel userVm)
        {
            var userAvailable = await _userManager.FindByNameAsync(userVm.UserName);
            var userRole = service.GetRoleIdByUserID(r => r.UserId == userAvailable.Id);
            var empId = service.GetRoleIdWhere(r => r.Name == Roles.Employee);

            if (userRole != empId)
            {
                return Unauthorized("Only employees can login.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }
            var userExists = await _userManager.FindByNameAsync(userVm.UserName);

            if (userExists != null && await _userManager.CheckPasswordAsync(userExists, userVm.Password.Cipher()))
            {
                var tokenReturned = await GenerateJwtToken(userExists);
                return Ok(tokenReturned);
            }
            else
                return Unauthorized();
        }

        // Agent Actions ---------------------------------------------------------------------------------------->

        [Authorize(Roles = Roles.Admin + "," + Roles.Employee)]
        [HttpPost("addAgent")]
        public async Task<IActionResult> addAgent([FromBody] AddUserViewModel customerVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }

            var userExists = await _userManager.FindByNameAsync(customerVm.UserName);
            if (userExists != null)
            {
                return BadRequest($"Agent {userExists.UserName} already exists.");
            }
            User userToAdd = new User()
            {
                FirstName = customerVm.FirstName,
                LastName = customerVm.LastName,
                Email = customerVm.Email,
                PasswordHash = customerVm.Password,
                UserName = customerVm.UserName,
                DoB = customerVm.DoB,
                Age = DateTime.Now.AddYears(-customerVm.DoB.Year).Year,
                PhoneNumber = customerVm.PhoneNumber,
                ParentId = customerVm.ParentId
            };

            var result = await _userManager.CreateAsync(userToAdd, customerVm.Password.Cipher());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userToAdd, Roles.Agent);
                User agent = await _userManager.FindByEmailAsync(customerVm.Email);
                await wdaccountsRepo.Add(new WithdrawAccount()
                {
                    AgentId = agent.Id,
                    TotalAmount = 0
                });
                return Ok("Added Agent with withdrawl account.");
            }
            else
                return BadRequest("Agent could not be created.");
        }

        [HttpPost("agent-login")]
        public async Task<IActionResult> AgentLogin([FromBody] UserLoginViewModel userVm)
        {
            var userAvailable = await _userManager.FindByNameAsync(userVm.UserName);
            var userRole = service.GetRoleIdByUserID(r => r.UserId == userAvailable.Id);
            var empId = service.GetRoleIdWhere(r => r.Name == Roles.Agent);

            if (userRole != empId)
            {
                return Unauthorized("Only agents can login.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }
            var userExists = await _userManager.FindByNameAsync(userVm.UserName);

            if (userExists != null && await _userManager.CheckPasswordAsync(userExists, userVm.Password.Cipher()))
            {
                var tokenReturned = await GenerateJwtToken(userExists);
                return Ok(tokenReturned);
            }
            else
                return Unauthorized();
        }

        // Customer Actions ---------------------------------------------------------------------------------------->

        [Authorize(Roles = Roles.Agent + "," + Roles.Admin + "," + Roles.Employee)]
        [HttpPost("addCustomer")]
        public async Task<IActionResult> addCustomer([FromBody] AddUserViewModel customerVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }

            var userExists = await _userManager.FindByNameAsync(customerVm.UserName);
            if (userExists != null)
            {
                return BadRequest($"Customer {userExists.UserName} already exists.");
            }

            User userToAdd = new User()
            {
                FirstName = customerVm.FirstName,
                LastName = customerVm.LastName,
                Email = customerVm.Email,
                PasswordHash = customerVm.Password,
                UserName = customerVm.UserName,
                DoB = customerVm.DoB,
                Age = DateTime.Now.AddYears(-customerVm.DoB.Year).Year,
                PhoneNumber = customerVm.PhoneNumber,
                Nominee = customerVm.Nominee,
                NomineeRelation = customerVm.NomineeRelation,
                City = customerVm.City,
                State = customerVm.State,
                Address = customerVm.Address,
                ParentId = customerVm.ParentId
            };

            var result = await _userManager.CreateAsync(userToAdd, customerVm.Password.Cipher());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userToAdd, Roles.Customer);
                var thisUser = await _userManager.FindByNameAsync(customerVm.UserName);
                await accountsRepo.Add(new InsuranceAccount()
                {
                    CustomerId = thisUser.Id,
                    AgentId = customerVm.ParentId
                });
                return Ok("Added Customer.");
            }
            else
                return BadRequest("Customer could not be created.");
        }

        [HttpPost("customer-login")]
        public async Task<IActionResult> CustomerLogin([FromBody] UserLoginViewModel userVm)
        {
            var userAvailable = await _userManager.FindByNameAsync(userVm.UserName);
            var userRole = service.GetRoleIdByUserID(r => r.UserId == userAvailable.Id);
            var empId = service.GetRoleIdWhere(r => r.Name == Roles.Customer);

            if (userRole != empId)
            {
                return Unauthorized("Only customers can login.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter all details");
            }
            var userExists = await _userManager.FindByNameAsync(userVm.UserName);

            if (userExists != null && await _userManager.CheckPasswordAsync(userExists, userVm.Password.Cipher()))
            {
                var tokenReturned = await GenerateJwtToken(userExists);
                return Ok(tokenReturned);
            }
            else
                return Unauthorized();
        }
    }
}
