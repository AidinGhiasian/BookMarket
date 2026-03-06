using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
