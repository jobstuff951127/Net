using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NTT_Data.Data.DTOS
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public required int CustomerId { get; set; }
        public decimal Total { get; set; }

    }
}
