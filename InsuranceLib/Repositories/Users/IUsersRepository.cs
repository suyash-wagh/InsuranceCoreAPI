﻿using InsuranceLib.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InsuranceLib.DAL.Repositories.Users
{
    public interface IUsersRepository<T> where T : User
    {
        Task<T> GetById(string id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task AddAdminAsync(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<User>> GetUsersByRoles(string role);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
        string GetRoleIdByUserID(Expression<Func<IdentityUserRole<string>, bool>> predicate);
        string GetRoleIdWhere(Expression<Func<IdentityRole<string>, bool>> predicate);
        Task<IEnumerable<User>> GetUsersByParentId(string parentId);
    }
}
