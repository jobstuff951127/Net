using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Net.Models
{
    public class QuestionTag
    {
        [Key]
        public int QuestionTagId { get; set; }
        public string TagName { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }

}
