using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinTech.EntityFrameworkCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FTEmployees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FTEmployeeTemperature",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTEmployeeTemperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FTEmployeeTemperature_FTEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "FTEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FTEmployeeTemperature_EmployeeId",
                table: "FTEmployeeTemperature",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FTEmployeeTemperature");

            migrationBuilder.DropTable(
                name: "FTEmployees");
        }
    }
}
