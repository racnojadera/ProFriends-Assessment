using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquityCalculator.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquityStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    Interest = table.Column<float>(type: "real", nullable: true),
                    Insurance = table.Column<float>(type: "real", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityStatuses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquityStatuses");
        }
    }
}
