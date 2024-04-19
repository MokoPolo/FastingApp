using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fasting.API.Migrations
{
    /// <inheritdoc />
    public partial class Changefastdurationtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fasts_Durations_DurationId",
                table: "Fasts");

            migrationBuilder.DropIndex(
                name: "IX_Fasts_DurationId",
                table: "Fasts");

            migrationBuilder.DropColumn(
                name: "DurationId",
                table: "Fasts");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Fasts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Fasts");

            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "Fasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fasts_DurationId",
                table: "Fasts",
                column: "DurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fasts_Durations_DurationId",
                table: "Fasts",
                column: "DurationId",
                principalTable: "Durations",
                principalColumn: "Id");
        }
    }
}
