using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class RefactorPermissinNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermissionCode",
                table: "Permission",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "NamePermission",
                table: "Permission",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Permission",
                newName: "NamePermission");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Permission",
                newName: "PermissionCode");
        }
    }
}
