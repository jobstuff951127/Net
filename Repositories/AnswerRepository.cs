using Microsoft.EntityFrameworkCore;
using Net.Data;
using Net.Interfaces;
using Net.Models;
using System.Diagnostics;

namespace Net.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(NetContext NetDataDb) : base(NetDataDb) {}
       
        /// <summary>
        /// Keep this method for backwards compatibility.
        /// </summary>
        public override Task<List<Answer>> GetAllAsync() => base.GetAllAsync();
        public override async Task<Answer?> GetAsync(int id)
        {
            try
            {
                return await DbSet.FirstOrDefaultAsync(item => item.AnswerId == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }
        public override async Task<bool> AddEntity(Answer entity)
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
        public override async Task<bool> UpdateEntity(Answer entity)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.AnswerId == entity.AnswerId);
                if (existdata != null)
                {
                    existdata.Content = entity.Content;
                    existdata.AnswerId = entity.AnswerId;
                    existdata.Question = entity.Question;
                    existdata.QuestionId = entity.QuestionId;
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
            var existdata = await DbSet.FirstOrDefaultAsync(item => item.AnswerId == id);
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

