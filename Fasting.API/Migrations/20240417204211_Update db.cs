using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fasting.API.Migrations
{
    /// <inheritdoc />
    public partial class Updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fasts",
                newName: "FastId");

            migrationBuilder.AddColumn<int>(
                name: "DurationId",
                table: "Fasts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Fasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Fasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Fasts_DurationId",
                table: "Fasts",
                column: "DurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fasts_Durations_DurationId",
                table: "Fasts",
                column: "DurationId",
                principalTable: "Durations",
                principalColumn: "DurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "End",
                table: "Fasts");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Fasts");

            migrationBuilder.RenameColumn(
                name: "FastId",
                table: "Fasts",
                newName: "Id");
        }
    }
}
