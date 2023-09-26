using Microsoft.EntityFrameworkCore;
using NTT_Data.Data;
using NTT_Data.Interfaces;
using NTT_Data.Models;
using System.Diagnostics;

namespace NTT_Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomersRepository
    {
        public CustomerRepository(NTTDataContext NTTDataDb) : base(NTTDataDb) {}
       
        /// <summary>
        /// Keep this method for backwards compatibility.
        /// </summary>
        public override Task<List<Customer>> GetAllAsync() => base.GetAllAsync();
        public override async Task<Customer?> GetAsync(int id)
        {
            try
            {
                return await DbSet.FirstOrDefaultAsync(item => item.CustumerId == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }
        
        public override async Task<bool> AddEntity(Customer entity)
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
        public override async Task<bool> UpdateEntity(Customer entity)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.CustumerId == entity.CustumerId);
                if (existdata != null)
                {
                    existdata.Name = entity.Name;
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
            var existdata = await DbSet.FirstOrDefaultAsync(item => item.CustumerId == id);
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
