using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fasting.API.Migrations
{
    /// <inheritdoc />
    public partial class Updatefastingtablefieldnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FastId",
                table: "Fasts",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fasts",
                newName: "FastId");
        }
    }
}
