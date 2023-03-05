using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValorantMoments.Migrations
{
    /// <inheritdoc />
    public partial class thien66 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moment",
                table: "Moment");

            migrationBuilder.RenameTable(
                name: "Moment",
                newName: "Moments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moments",
                table: "Moments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Moments",
                table: "Moments");

            migrationBuilder.RenameTable(
                name: "Moments",
                newName: "Moment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moment",
                table: "Moment",
                column: "Id");
        }
    }
}
