using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Net.Data.DTOS
{
    public class QuestionDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public List<string> Tags { get; set; }
    }

}
