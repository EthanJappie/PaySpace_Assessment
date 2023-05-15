using PaySpace.Web.Models;
using PaySpace.Web.Interface;
using System.Net;

namespace PaySpace.Web
{
    public class AuthClient : IAuthClient
    {
        private readonly HttpClient _client;

        public AuthClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:5001");
        }

        public async Task<List<TaxResults>?> AddTaxCalculation(TaxModel model)
        {
            if (model is null)
                return null;

            List<TaxResults>? taxCalculations = null;

            var response = await _client.PostAsJsonAsync("tax", model);

            if (response.IsSuccessStatusCode)
                taxCalculations = await response.Content.ReadFromJsonAsync<List<TaxResults>>();

            return taxCalculations;
        } 

        public async Task<(HttpStatusCode, List<TaxResults>?)> GetHistoricTaxCalculations()
        {
            var response = await _client.GetAsync("tax");
            List<TaxResults>? results = null;

            if (response.IsSuccessStatusCode)
                results = await response.Content.ReadFromJsonAsync<List<TaxResults>>();

            return (response.StatusCode, results);
        }

    }
}
