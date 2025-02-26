using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Data.Interfaces;

namespace WebApi.Data.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
        where T : class
    {
        protected readonly AppDbContext _context = context;

        public async Task<IList<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }

            return await dbQuery.AsNoTracking().ToListAsync<T>(); ;
        }
        public async Task<IList<T>> GetAllTake(int take, int skip, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }

            var list = await dbQuery
                .AsNoTracking()
                .Take(take)
                .Skip(skip)
                .ToListAsync<T>();

            return list;
        }

        public async Task<IList<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            _context.Database.SetCommandTimeout(300);
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }

            var list = await dbQuery
                .AsNoTracking()
                .Where(where)
                .ToListAsync<T>();

            return list;
        }

        public async Task<int> GetCount()
        {
            var cnt = await _context.Set<T>().CountAsync();
            return cnt;
        }
        public Task<int> GetCount(Expression<Func<T, bool>> where)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            var cnt = dbQuery
                .CountAsync(where); //Apply where clause

            return cnt;
        }

        public async Task Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            await _context.SaveChangesAsync();
        }
        public async Task Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        public async Task Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }

            await _context.SaveChangesAsync();
        }

        
       
    }
}
