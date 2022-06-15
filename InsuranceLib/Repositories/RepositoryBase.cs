using InsuranceLib.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLib.DAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        protected InsuranceDbContext Context { get; set; }

        public RepositoryBase(InsuranceDbContext repositoryContext)
        {
            this.Context = repositoryContext;
        }
        public Task<T> GetById(Guid id)
        {
            return Context.Set<T>().FindAsync(id).AsTask();
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            // await Context.AddAsync(entity);
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            T existing = Context.Set<T>().Where(e => e.Id == entity.Id).AsNoTracking().FirstOrDefault<T>();
            if (existing != null)
            {
                existing = entity;
                Context.Set<T>().Update(existing);
            }
            Context.Entry(existing).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            T entity = Context.Set<T>().Where(e => e.Id == id).FirstOrDefault<T>();
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
