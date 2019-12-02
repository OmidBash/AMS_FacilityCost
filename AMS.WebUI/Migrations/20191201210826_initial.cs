using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AMS.WebUI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    CostIncomeType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmptyUnitShare = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    KindOfUsage = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitFacilityCost",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FacilityCostId = table.Column<Guid>(nullable: false),
                    IsApplicant = table.Column<bool>(nullable: false),
                    OwnerPays = table.Column<bool>(nullable: false),
                    Share = table.Column<int>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false),
                    UsagePeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitFacilityCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitFacilityCost_FacilityCosts_FacilityCostId",
                        column: x => x.FacilityCostId,
                        principalTable: "FacilityCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitFacilityCost_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitFacilityCost_FacilityCostId",
                table: "UnitFacilityCost",
                column: "FacilityCostId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitFacilityCost_UnitId",
                table: "UnitFacilityCost",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitFacilityCost");

            migrationBuilder.DropTable(
                name: "FacilityCosts");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
