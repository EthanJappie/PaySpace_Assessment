using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaySpace.Api.Entities;

namespace PaySpace.Api
{
    public class PaySpaceDbContext : DbContext
    {
        public PaySpaceDbContext(DbContextOptions<PaySpaceDbContext> options) : base(options) { }

        public DbSet<TaxEntity> TaxMap => Set<TaxEntity>();
        public DbSet<TaxResults> TaxResults => Set<TaxResults>();
        public DbSet<TaxBand> TaxBands => Set<TaxBand>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaxEntity>()
                .HasKey(x => x.Id);

            builder.Entity<TaxResults>()
                .HasKey(x => x.Id);

            builder.Entity<TaxBand>()
                .HasKey(x => x.Id);

            builder.Entity<TaxBand>()
                .HasData(new TaxBand
                {
                    Id = 1,
                    Lower = 0m,
                    Upper = 8350m,
                    Rate = 10
                },
                new TaxBand
                {
                    Id = 2,
                    Lower = 8351m,
                    Upper = 33950m,
                    Rate = 15
                },
                new TaxBand
                {
                    Id = 3,
                    Lower = 33951,
                    Upper = 82250,
                    Rate = 25
                },
                new TaxBand
                {
                    Id = 4,
                    Lower = 82251,
                    Upper = 171550,
                    Rate = 28
                },
                new TaxBand
                {
                    Id = 5,
                    Lower = 171551,
                    Upper = 372950,
                    Rate = 33
                },
                new TaxBand
                {
                    Id = 6,
                    Lower = 372951,
                    Upper = Decimal.MaxValue,
                    Rate = 35
                });

            builder.Entity<TaxEntity>()
                .HasData(new TaxEntity
                {
                    Id = 1,
                    PostalCode = "7441",
                    Type = Enumeration.TaxTypes.Progressive
                },
                new TaxEntity
                {
                    Id = 2,
                    PostalCode = "A100",
                    Type = Enumeration.TaxTypes.FlatValue
                },
                new TaxEntity
                {
                    Id = 3,
                    PostalCode = "7000",
                    Type = Enumeration.TaxTypes.FlatRate
                },
                new TaxEntity
                {
                    Id = 4,
                    PostalCode = "1000",
                    Type = Enumeration.TaxTypes.Progressive
                });

            base.OnModelCreating(builder);
        }
    }
}
