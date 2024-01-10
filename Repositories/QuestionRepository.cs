using Microsoft.EntityFrameworkCore;
using Net.Data;
using Net.Interfaces;
using Net.Models;
using System.Diagnostics;

namespace Net.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(NetContext NetDataDb) : base(NetDataDb) {}
       
        /// <summary>
        /// Keep this method for backwards compatibility.
        /// </summary>
        public override Task<List<Question>> GetAllAsync() => base.GetAllAsync();
        public override async Task<Question?> GetAsync(int id)
        {
            try
            {
                return await DbSet.FirstOrDefaultAsync(item => item.QuestionId == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        public List<Question> GetQuestionsByTag(string tagName)
        {
            try
            {
                return DbSet.Include(q => q.Answers).Include(q => q.QuestionTags).Where(q => q.QuestionTags.Any(t => t.TagName == tagName)).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        public async Task AddQuestionsAsync(List<Question> questions)
        {
            try
            {
                await DbSet.AddRangeAsync(questions);
                
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }

        }

        public override async Task<bool> AddEntity(Question entity)
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
        public override async Task<bool> UpdateEntity(Question entity)
        {
            try
            {
                var existdata = await DbSet.FirstOrDefaultAsync(item => item.QuestionId == entity.QuestionId);
                if (existdata != null)
                {
                    existdata.Answers = entity.Answers;
                    existdata.QuestionTags = entity.QuestionTags;
                    existdata.UserId = entity.UserId;
                    existdata.Content = entity.Content;
                    existdata.User = entity.User;
                    existdata.Title = entity.Title;
                    
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
            var existdata = await DbSet.FirstOrDefaultAsync(item => item.QuestionId == id);
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
