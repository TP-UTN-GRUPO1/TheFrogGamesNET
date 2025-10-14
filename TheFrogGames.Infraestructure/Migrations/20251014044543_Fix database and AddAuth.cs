using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheFrogGames.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FixdatabaseandAddAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "Date", "Email", "IsActive", "LastName", "Name", "Password", "Province", "RoleId" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sysadmin@demo.com", true, "SysAdmin", "SysAdmin", "1234", null, 1 },
                    { 2, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@demo.com", true, "Admin", "Admin", "1234", null, 2 },
                    { 3, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@demo.com", true, "User", "User", "1234", null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "Date", "Email", "IsActive", "LastName", "Name", "Password", "Province", "RoleId" },
                values: new object[,]
                {
                    { 6, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sysadmin@demo.com", true, "SysAdmin", "SysAdmin", "1234", null, 1 },
                    { 7, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@demo.com", true, "Admin", "Admin", "1234", null, 2 },
                    { 8, null, null, null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@demo.com", true, "User", "User", "1234", null, 3 }
                });
        }
    }
}
