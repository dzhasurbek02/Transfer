using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transfer.Migrations
{
    /// <inheritdoc />
    public partial class Exchangerate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_Currency1Id",
                        column: x => x.Currency1Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_Currency2Id",
                        column: x => x.Currency2Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_Currency1Id",
                table: "ExchangeRates",
                column: "Currency1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_Currency2Id",
                table: "ExchangeRates",
                column: "Currency2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");
        }
    }
}
