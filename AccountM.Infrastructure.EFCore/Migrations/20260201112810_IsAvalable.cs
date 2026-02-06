using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IsAvalable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RePassword",
                table: "Account");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvalable",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvalable",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "RePassword",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
