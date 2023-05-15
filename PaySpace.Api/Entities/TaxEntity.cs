using PaySpace.Api.Enumeration;
using System.ComponentModel.DataAnnotations;

namespace PaySpace.Api.Entities
{
    public class TaxEntity
    {
        public int Id { get; set; }
        [Required]
        public string PostalCode { get; set; } = default!;
        [Required]
        public TaxTypes Type { get; set; }
    }
}
