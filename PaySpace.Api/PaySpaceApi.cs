using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PaySpace.Api.Entities;
using PaySpace.Api.Models;
using PaySpace.Api.Tax;

namespace PaySpace.Api
{
    internal static class PaySpaceApi
    {
        public static RouteGroupBuilder MapTaxRoutes(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/tax");
            group.WithTags("Tax");

            group.MapGet("/TaxMap", async (PaySpaceDbContext db) =>
            {
                return await db.TaxMap.AsNoTracking().ToListAsync();
            });

            group.MapGet("/", async (PaySpaceDbContext db) =>
            {
                return await db.TaxResults.AsNoTracking().ToListAsync();
            });

            group.MapPost("/", async Task<List<TaxResults>> (PaySpaceDbContext db, TaxModel taxModel) =>
            {
                await Calculator.CalculateTaxAmount(db, taxModel);

                return await db.TaxResults.AsNoTracking().ToListAsync();
            });

            return group;
        }
    }
}
