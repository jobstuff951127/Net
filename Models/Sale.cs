using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NTT_Data.Models
{
    public class Sale
    {
        [Key]
        public int  SaleId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }

        [JsonIgnore]
        public required Customer Customer { get; set; }

    }
}
