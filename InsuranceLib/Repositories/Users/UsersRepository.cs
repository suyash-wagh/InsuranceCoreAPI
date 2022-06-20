using InsuranceLib.DAL.Helpers;
using InsuranceLib.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLib.DAL.Repositories.Users
{
    public class UsersRepository : IUsersRepository<User>
    {
        private readonly InsuranceDbContext context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersRepository(InsuranceDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task AddAdminAsync(User entity)
        {
            await context.Users.AddAsync(new User()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash.Cipher(),
                DoB = entity.DoB,
                Age = entity.Age,
                UserName = entity.UserName
            });
            await context.SaveChangesAsync();
        }

        public Task<int> CountAll()
        {
            return context.Set<User>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<User, bool>> predicate)
        {
            return await context.Set<User>().CountAsync(predicate);
        }

        public Task<User> FirstOrDefault(Expression<Func<User, bool>> predicate)
        {
            return context.Set<User>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Set<User>().ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await context.Set<User>().FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetWhere(Expression<Func<User, bool>> predicate)
        {
            return await context.Set<User>().Where(predicate).ToListAsync();
        }

        public Task Remove(User entity)
        {
            context.Set<User>().Remove(entity);
            return context.SaveChangesAsync();

        }

        public async Task Update(User entity)
        {
            User existing = context.Users.Where(e => e.Id == entity.Id).AsNoTracking().FirstOrDefault();
            if (existing != null)
            {
                existing.FirstName = entity.FirstName;
                existing.UserName = entity.UserName;
                existing.LastName = entity.LastName;
                existing.Email = entity.Email;
                existing.DoB = entity.DoB;
                existing.Address = entity.Address;
                existing.City = entity.City;
                existing.State = entity.State;
                existing.Nominee = entity.Nominee;
                existing.NomineeRelation = existing.NomineeRelation;
                existing.PhoneNumber = existing.PhoneNumber;
                existing.Pincode = existing.Pincode;
                existing.PasswordHash = entity.PasswordHash;
                context.Set<User>().Update(existing);
            }
            context.Entry(existing).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoles(string role)
        {
            var userRole = await _roleManager.FindByNameAsync(role);
            var userIds = context.UserRoles.Where(ur => ur.RoleId == userRole.Id).Select(ur => ur.UserId).ToList();
            var users = new List<User>();
            foreach(var userId in userIds)
            {
                users.Add(await context.Users.FindAsync(userId));
            }
            return users;
        }
    }
}
