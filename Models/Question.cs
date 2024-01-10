using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Net.Models
{
    public class Question
    {
        private List<Answer> answers = new List<Answer>();

        [Key]
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
        public List<Answer> Answers { get => answers; set => answers = value; }         // Add other question-related properties
    }
}


