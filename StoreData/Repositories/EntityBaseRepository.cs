using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StoreData.Data;
using StoreData.Interfaces;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class EntityBaseRepository<T> : IEntityBase<T> where T : class, IBase, new()
    {
        private readonly StoreContext _context;
        private readonly DapperContext _dappercontext;
        public EntityBaseRepository(StoreContext context , DapperContext dappercontext)
        {
            _context = context;
            _dappercontext = dappercontext;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            if (entity == null)
                throw new Exception("Entity NotFound");
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            using (var connection = _dappercontext.CreateConnection())
            {
                var result = await connection.QueryAsync<T>(query);
                if (result.Count() == 0)
                    throw new Exception(new ErrorMessage() { StatusCode = 404, Message = "NotFound" }.ToString());
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(string query ,int id)
        {
            using (var connection = _dappercontext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(query, new { id });
            }
            // return await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        }
        
        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
