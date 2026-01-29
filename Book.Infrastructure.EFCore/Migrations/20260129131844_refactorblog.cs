using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class refactorblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Writer",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "Posts",
                newName: "ShortDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "Writer");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Posts",
                newName: "Publisher");

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
