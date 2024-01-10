using Net.Interfaces;

namespace Net.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; }
        IQuestionRepository QuestionRepository { get; }

        Task CompleteAsync();
    }
}