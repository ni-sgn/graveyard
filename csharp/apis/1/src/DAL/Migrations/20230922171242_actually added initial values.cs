using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class actuallyaddedinitialvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mobile",
                columns: new[] { "mobile_number", "Personcustom_id", "provider" },
                values: new object[,]
                {
                    { "123123123", null, "magti" },
                    { "321321321", null, "magti" }
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "custom_id", "date_of_birth", "first_name", "last_name", "mobile_number" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 22, 21, 12, 42, 616, DateTimeKind.Local).AddTicks(7004), "nika", "saganelidze", null },
                    { 2, new DateTime(2023, 9, 22, 21, 12, 42, 616, DateTimeKind.Local).AddTicks(7025), "nika's", "clone", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mobile",
                keyColumn: "mobile_number",
                keyValue: "123123123");

            migrationBuilder.DeleteData(
                table: "Mobile",
                keyColumn: "mobile_number",
                keyValue: "321321321");

            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "custom_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "custom_id",
                keyValue: 2);
        }
    }
}
