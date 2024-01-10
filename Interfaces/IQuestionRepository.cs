using Net.Models;

namespace Net.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task AddQuestionsAsync(List<Question> questions);

        List<Question> GetQuestionsByTag(string tagName);

    }
}