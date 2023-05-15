namespace PaySpace.Api.Entities
{
    public class TaxBand
    {
        public int Id { get; set; }
        public decimal Lower { get; set; }
        public decimal Upper { get; set; }
        public decimal Rate { get; set; }
    }
}
