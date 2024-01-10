using System.ComponentModel.DataAnnotations;

namespace Net.Models
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public int QuestionId { get; set; }
        public required Question Question { get; set; }
        public int AnswerId { get; set; }
        public required Answer Answer { get; set; }
        // Add other vote-related properties
    }

}
