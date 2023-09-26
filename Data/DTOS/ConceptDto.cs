using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NTT_Data.Data.DTOS
{
    public class ConceptDto
    {
        public decimal Quantity { get; set; }
        public int ProductId { get; set; }
        public int SalesId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
