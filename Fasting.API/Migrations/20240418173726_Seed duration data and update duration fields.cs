using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fasting.API.Migrations
{
    /// <inheritdoc />
    public partial class Seeddurationdataandupdatedurationfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationLength",
                table: "Durations",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "DurationId",
                table: "Durations",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Durations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Durations",
                columns: new[] { "Id", "Length", "Name" },
                values: new object[,]
                {
                    { 1, 12, "12" },
                    { 2, 16, "16" },
                    { 3, 18, "18" },
                    { 4, 72, "72" },
                    { 5, 84, "84" },
                    { 6, 96, "96" },
                    { 7, 0, "Custom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Durations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Durations");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Durations",
                newName: "DurationLength");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Durations",
                newName: "DurationId");
        }
    }
}
