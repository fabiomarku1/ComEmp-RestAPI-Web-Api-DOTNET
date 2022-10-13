using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company2.Migrations
{
    /// <inheritdoc />
    public partial class AddedRefreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b05edcb-e230-4de6-b60a-d22f1c6a0cfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9362f1f4-8587-490f-a197-e47943be6e9c");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f5f3144-9d32-44ed-b24d-98062a0e853d", "893c1e87-a8b3-480a-8c65-b3884a931c8d", "Administrator", "ADMINISTRATOR" },
                    { "96cc7432-146f-4b30-9bdf-49163e2f023b", "b15a3e52-9152-4933-a967-de856dbd3608", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2022, 10, 13, 14, 18, 7, 146, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2022, 10, 13, 14, 18, 7, 146, DateTimeKind.Local).AddTicks(9758));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f5f3144-9d32-44ed-b24d-98062a0e853d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96cc7432-146f-4b30-9bdf-49163e2f023b");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
