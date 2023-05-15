using Microsoft.EntityFrameworkCore;
using PaySpace.Api.Entities;
using PaySpace.Api.Enumeration;
using PaySpace.Api.Models;
using System.Transactions;

namespace PaySpace.Api.Tax
{
    public static class Calculator
    {
        public static async Task<decimal> CalculateTaxAmount(PaySpaceDbContext db, TaxModel model)
        {
            var taxType = db.TaxMap.Where(x => x.PostalCode == model.PostalCode).FirstOrDefault().Type;

            return taxType switch
            {
                TaxTypes.Progressive => await Progressive(db, model),
                TaxTypes.FlatValue => await FlatValue(db, model),
                TaxTypes.FlatRate => await FlatRate(db, model),
                _ => 0,
            };
        }

        public static async Task<decimal> Progressive(PaySpaceDbContext db, TaxModel model)
        {
            var taxBands = await db.TaxBands.AsNoTracking().ToListAsync();
            var taxPayable = 0m;
            var taxBandRate = 0m;

            foreach (var band in taxBands)
            {
                if (model.AnnualIncome > band.Lower)
                {
                    var taxRate = Math.Min(band.Upper - band.Lower, model.AnnualIncome - band.Lower);
                    var taxBand = taxRate * band.Rate;
                    taxPayable += taxBand;
                    taxBandRate = band.Rate;
                }
            }

            var taxResult = new TaxResults()
            {
                AnnualIncome = model.AnnualIncome,
                AppliedRate = taxBandRate,
                CalculationDate = DateTime.Now,
                PostalCode = model.PostalCode,
                TaxType = TaxTypes.Progressive,
                TaxAmount = taxPayable
            };

            await SaveCalculations(db, taxResult);
            return await Task.FromResult(taxPayable);
        }

        public static async Task<decimal> FlatRate(PaySpaceDbContext db, TaxModel model)
        {

            var taxAmount = 0m;
            if (model.AnnualIncome < 200000)
                taxAmount = model.AnnualIncome * 0.05m;
            else
                taxAmount = 10000m;

            var result = new TaxResults()
            {
                AnnualIncome = model.AnnualIncome,
                AppliedRate = taxAmount > 10000m ? 0 : 5,
                CalculationDate = DateTime.Now,
                PostalCode = model.PostalCode,
                TaxType = TaxTypes.FlatRate,
                TaxAmount = taxAmount
            };

            await SaveCalculations(db, result);

            return await Task.FromResult(taxAmount);
        }

        public static async Task<decimal> FlatValue(PaySpaceDbContext db, TaxModel model)
        {
            var result = new TaxResults()
            {
                AnnualIncome = model.AnnualIncome,
                AppliedRate = 17.5m,
                CalculationDate = DateTime.Now,
                PostalCode = model.PostalCode,
                TaxAmount = (model.AnnualIncome * 0.175m),
                TaxType = TaxTypes.FlatValue
            };

            await SaveCalculations(db, result);

            return await Task.FromResult(0);
        }

        public static async Task SaveCalculations(PaySpaceDbContext db, TaxResults results) 
        { 
            await db.TaxResults.AddAsync(results);
            await db.SaveChangesAsync();
        }
    }
}
