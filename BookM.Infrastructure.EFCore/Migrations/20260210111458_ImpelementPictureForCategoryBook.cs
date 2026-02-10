using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ImpelementPictureForCategoryBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "BookCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "BookCategories");
        }
    }
}
