using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaySpace.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lower = table.Column<decimal>(type: "TEXT", nullable: false),
                    Upper = table.Column<decimal>(type: "TEXT", nullable: false),
                    Rate = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    TaxType = table.Column<int>(type: "INTEGER", nullable: false),
                    AnnualIncome = table.Column<decimal>(type: "TEXT", nullable: false),
                    AppliedRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CalculationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxResults", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "Lower", "Rate", "Upper" },
                values: new object[,]
                {
                    { 1, 0m, 10m, 8350m },
                    { 2, 8351m, 15m, 33950m },
                    { 3, 33951m, 25m, 82250m },
                    { 4, 82251m, 28m, 171550m },
                    { 5, 171551m, 33m, 372950m },
                    { 6, 372951m, 35m, 79228162514264337593543950335m }
                });

            migrationBuilder.InsertData(
                table: "TaxMap",
                columns: new[] { "Id", "PostalCode", "Type" },
                values: new object[,]
                {
                    { 1, "7441", 1 },
                    { 2, "A100", 2 },
                    { 3, "7000", 3 },
                    { 4, "1000", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");

            migrationBuilder.DropTable(
                name: "TaxMap");

            migrationBuilder.DropTable(
                name: "TaxResults");
        }
    }
}
