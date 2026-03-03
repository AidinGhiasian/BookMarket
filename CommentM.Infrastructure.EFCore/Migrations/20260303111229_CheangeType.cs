using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class CheangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
