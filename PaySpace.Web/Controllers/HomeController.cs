using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.Web.Interface;
using PaySpace.Web.Models;
using System.Diagnostics;

namespace PaySpace.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthClient _client;

        public HomeController(ILogger<HomeController> logger, IAuthClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            List<TaxResults> resultHistory = new();
            using (var client = new HttpClient())
            {
                try
                {
                    var (httpStatus, history) = await _client.GetHistoricTaxCalculations();
                    resultHistory = history ?? new List<TaxResults>();
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }

            return View(resultHistory);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> TaxCalculation(string PostalCode, decimal AnnualIncome)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var taxModel = new TaxModel() { AnnualIncome = AnnualIncome, PostalCode = PostalCode };
                    
                    await _client.AddTaxCalculation(taxModel);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View("Index");
        }
    }
}