using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company2.Migrations
{
    /// <inheritdoc />
    public partial class addedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b05edcb-e230-4de6-b60a-d22f1c6a0cfc", "ac8b8345-afa2-4c9f-b85a-3d39c79f0145", "Manager", "MANAGER" },
                    { "9362f1f4-8587-490f-a197-e47943be6e9c", "5619e54d-91ed-4c6e-abb0-87037d74bd69", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2022, 10, 13, 10, 17, 23, 203, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2022, 10, 13, 10, 17, 23, 203, DateTimeKind.Local).AddTicks(8691));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b05edcb-e230-4de6-b60a-d22f1c6a0cfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9362f1f4-8587-490f-a197-e47943be6e9c");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2022, 10, 13, 10, 9, 37, 388, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2022, 10, 13, 10, 9, 37, 388, DateTimeKind.Local).AddTicks(5036));
        }
    }
}
