using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addIsStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "IsStatus",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
