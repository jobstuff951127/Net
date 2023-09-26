using System.ComponentModel.DataAnnotations;

namespace NTT_Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string UnitPrice { get; set; }
        public decimal Cost { get; set; }
    }
}
