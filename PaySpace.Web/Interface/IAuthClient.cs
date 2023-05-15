using PaySpace.Web.Models;
using System.Net;

namespace PaySpace.Web.Interface
{
    public interface IAuthClient
    {
        public Task<List<TaxResults>?> AddTaxCalculation(TaxModel model);
        public Task<(HttpStatusCode, List<TaxResults>?)> GetHistoricTaxCalculations();
    }
}
