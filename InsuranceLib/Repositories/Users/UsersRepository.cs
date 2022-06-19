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
            User existing = context.Set<User>().Where(e => e.Id == entity.Id).AsNoTracking().FirstOrDefault<User>();
            if (existing != null)
            {
                existing = entity;
                context.Set<User>().Update(existing);
            }
            context.Entry(existing).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
