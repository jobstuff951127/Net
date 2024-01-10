using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Net.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string UserName { get; set; }
        // Add other user-related properties
    }

}


