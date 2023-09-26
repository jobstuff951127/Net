using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NTT_Data.Models
{
    public class Concept
    {
        [Key]
        public int ConceptId { get; set; }
        public decimal Quantity { get; set; }
        public int ProductId { get; set; }
        public int SalesId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        [JsonIgnore]
        public required Product Product { get; set; }

        [JsonIgnore]
        public required Sale Sale { get; set; }
    }
}
