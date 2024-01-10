
using Microsoft.EntityFrameworkCore;
using Net.Data;
using Net.Interfaces;
using Net.Models;
using System.Diagnostics;

namespace Net.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected NetContext dbContext;
        
        internal DbSet<T> DbSet { get; set; }
        public GenericRepository(NetContext netContext)
        {
            dbContext = netContext;
            DbSet = dbContext.Set<T>();
        }
        public virtual Task<bool> AddEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }



        public virtual Task<List<T>> GetAllAsync()
        {
            try
            {
                return DbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }
        public virtual Task<T?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetByDateRangeAsync(DateTime initDate, DateTime endDate)
        {
            return DbSet.ToListAsync();
        }
    }
}

