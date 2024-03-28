﻿using LogisticApi.Application.Abstraction.Repostories.Generic;
using LogisticApi.Domain.Entities.Common;
using LogisticApi.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Repostories.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }
        public async void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }
        public void Recovery(T entity)
        {
            entity.IsDeleted = false;
            _dbSet.Update(entity);
        }
        public async void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
<<<<<<< HEAD
        public IQueryable<T> GetAll(bool isTracking = false,bool? isDeleted=false, bool QueryFilter = false, params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (isDeleted == null) query = query.Where(x => x.IsDeleted == null);
            else if (isDeleted == false) query = query.Where(x => x.IsDeleted == false);
            else if (isDeleted == true) query = query.Where(x => x.IsDeleted == true);
=======
        public IQueryable<T> GetAll(bool isTracking = false, bool QueryFilter = false, params string[] includes)
        {
            IQueryable<T> query = _dbSet;
>>>>>>> main
            query = isTracking ? query : query.AsNoTracking();
            query = QueryFilter ? query : query.IgnoreQueryFilters();
            query = Includes(query, includes);
            return query;
        }
        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderexpression = null,
<<<<<<< HEAD
            bool? isDeleted = false,bool isDescending = false, bool isTracking = false, bool queryFilter = false, int skip = 0, int take = 0, params string[] includes)
=======
            bool isDescending = false, bool isTracking = false, bool queryFilter = false, int skip = 0, int take = 0, params string[] includes)
>>>>>>> main
        {
            IQueryable<T> query = _dbSet;
            if (expression != null) query = query.Where(expression);
            if (orderexpression != null)
            {
                query = isDescending ? query.OrderByDescending(orderexpression) : query.OrderBy(orderexpression);
            }
            if (skip != 0) query = query.Skip(skip);
            if (take != 0) query = query.Take(take);
<<<<<<< HEAD
            if (isDeleted == null) query = query.Where(x => x.IsDeleted == null);
            else if (isDeleted == false) query = query.Where(x => x.IsDeleted == false);
            else if (isDeleted == true) query = query.Where(x => x.IsDeleted == true);
=======
>>>>>>> main
            query = isTracking ? query : query.AsNoTracking();
            query = queryFilter ? query : query.IgnoreQueryFilters();
            query = Includes(query, includes);
            return query;
        }
<<<<<<< HEAD
        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, bool? isDeleted = false, bool isTracking = false,
            bool QueryFilter = false, params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(expression);
            if (isDeleted == null) query = query.Where(x => x.IsDeleted == null);
            else if (isDeleted == false) query = query.Where(x => x.IsDeleted == false);
            else if (isDeleted == true) query = query.Where(x => x.IsDeleted == true);
=======
        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = false,
            bool QueryFilter = false, params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(expression);
>>>>>>> main
            query = isTracking ? query : query.AsNoTracking();
            query = QueryFilter ? query : query.IgnoreQueryFilters();
            query = Includes(query, includes);
            return await query.FirstOrDefaultAsync();
        }
<<<<<<< HEAD
        public async Task<T> GetByIdAsync(int id, bool? isDeleted = false, bool isTracking = false, bool QueryFilter = false, params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(t => t.Id == id);
            if (isDeleted == null) query = query.Where(x => x.IsDeleted == null);
            else if (isDeleted == false) query = query.Where(x => x.IsDeleted == false);
            else if (isDeleted == true) query = query.Where(x => x.IsDeleted == true);
=======
        public async Task<T> GetByIdAsync(int id, bool isTracking = false, bool QueryFilter = false, params string[] includes)
        {
            IQueryable<T> query = _dbSet.Where(t => t.Id == id);
>>>>>>> main
            query = isTracking ? query : query.AsNoTracking();
            query = QueryFilter ? query : query.IgnoreQueryFilters();
            query = Includes(query, includes);
            return await query.FirstOrDefaultAsync();
        }
        private static IQueryable<T> Includes(IQueryable<T> query, params string[] includes)
        {
            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
    }
}
