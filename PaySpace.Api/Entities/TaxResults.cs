using PaySpace.Api.Enumeration;

namespace PaySpace.Api.Entities
{
    public class TaxResults
    {
        public int Id { get; set; }
        public string PostalCode { get; set; } = default!;
        public TaxTypes TaxType { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal AppliedRate { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
