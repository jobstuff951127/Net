using System.ComponentModel.DataAnnotations;

namespace NTT_Data.Data.DTOS
{
    public class ProductDto
    {
        public required string Name { get; set; }
        public required string UnitPrice { get; set; }
        public decimal Cost { get; set; }
    }
}
