using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NTT_Data.Data.DTOS
{
    public class SaleDto
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }

    }
}
