using System.ComponentModel.DataAnnotations;

namespace NTT_Data.Models
{
    public class Customer
    {
        [Key]
        public int CustumerId { get; set; }
        public required string Name { get; set; }

    }
}
