
namespace Net.Data.DTOS
{
    public class QuestionWithAnswersDto
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
        public List<AnswerDto> Answers { get; set; }        
    }
}
