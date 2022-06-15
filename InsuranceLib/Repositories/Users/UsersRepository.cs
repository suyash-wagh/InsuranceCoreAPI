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

        public UsersRepository(InsuranceDbContext context)
        {
            this.context = context;
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

        public async Task Update(string id, User entity)
        {
            User user = await context.Set<User>().FindAsync(id);
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.PasswordHash = entity.PasswordHash.Cipher();
            //context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
