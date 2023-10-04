using Microsoft.EntityFrameworkCore;
using NTT_Data.Data;
using NTT_Data.Interfaces;
using NTT_Data.Models;
using System.Diagnostics;

namespace NTT_Data.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISalesRepository
    {
        public SaleRepository(NTTDataContext NTTDataDb) : base(NTTDataDb) {}
       
        /// <summary>
        /// Keep this method for backwards compatibility.
        /// </summary>
        public override Task<List<Sale>> GetAllAsync() => base.GetAllAsync();
        public override async Task<Sale?> GetAsync(int id)
        {
            try
            {
                return await DbSet.FirstOrDefaultAsync(item => item.SaleId == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        public override async Task<List<Sale>> GetByDateRangeAsync(DateTime initDate, DateTime endDate)
        {
            try
            {
                return await DbSet.Where(item => item.Date >= initDate && item.Date <= endDate).ToListAsync();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        public override async Task<bool> AddEntity(Sale entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                return true;

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }
        public override async Task<bool> UpdateEntity(Sale entity)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.SaleId == entity.SaleId);
                if (existdata != null)
                {
                    existdata.Total = entity.Total;
                    existdata.Date = entity.Date;
                    existdata.CustomerId = entity.CustomerId;
                    existdata.IsCancelled = entity.IsCancelled;
                    
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        public override async Task<bool> DeleteEntity(int id)
        {
            var existdata = await DbSet.FirstOrDefaultAsync(item => item.SaleId == id);
            if (existdata != null)
            {
                DbSet.Remove(existdata);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
