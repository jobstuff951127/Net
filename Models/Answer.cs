using System.ComponentModel.DataAnnotations;

namespace Net.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
        // Add other answer-related properties
    }

}
