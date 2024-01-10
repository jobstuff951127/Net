using Net.Data;
using Net.Interfaces;
using Net.Repositories;


namespace Net.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public IAnswerRepository AnswerRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }

        private readonly NetContext _NetContext;

        public UnitOfWorkRepository(NetContext netContext)
        {
            _NetContext = netContext;
            AnswerRepository = new AnswerRepository(netContext);
            QuestionRepository = new QuestionRepository(netContext);
        }

        public async Task CompleteAsync()
        {
            await _NetContext.SaveChangesAsync();
        }
    }
}
