using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InsuranceLib.DAL.Models;
using InsuranceLib.DAL.Repositories.Users;

namespace InsuranceLib.BL.Services
{
    public class UsersService
    {
        private readonly IUsersRepository<User> repo;

        public UsersService(IUsersRepository<User> repo)
        {
            this.repo = repo;
        }

        public async Task AddAdmin(User entity)
        {
            await repo.AddAdminAsync(entity);
        }

        public async Task<int> CountUsers()
        {
            return await repo.CountAll();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await repo.GetAll();
        }

        public async Task<User> GetUserById(string id)
        {
            return await repo.GetById(id);
        }

        public async Task<IEnumerable<User>> GetWhere(Expression<Func<User, bool>> predicate)
        {
            return await repo.GetWhere(predicate);
        }

        public async Task RemoveUser(User entity)
        {
            await repo.Remove(entity);
        }

        public async Task Update(User entity)
        {
            await repo.Update(entity);
        }
    }
}
