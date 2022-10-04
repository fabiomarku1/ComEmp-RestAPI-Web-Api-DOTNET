using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company2.Migrations
{
    /// <inheritdoc />
    public partial class initializeDAta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 11, "Lezhe", "Albania", new DateTime(2022, 10, 4, 15, 27, 4, 275, DateTimeKind.Local).AddTicks(8247), "Fabio" },
                    { 22, "Tirane", "Albania", new DateTime(2022, 10, 4, 15, 27, 4, 275, DateTimeKind.Local).AddTicks(8282), "Marku" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 21, 11, "Fabio Marku", "DIRECTOR" },
                    { 2, 24, 22, "MarkuFabio", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 22);
        }
    }
}
