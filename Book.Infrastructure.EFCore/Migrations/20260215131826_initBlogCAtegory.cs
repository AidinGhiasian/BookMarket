using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class initBlogCAtegory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogCategoryId",
                table: "Posts",
                column: "BlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_BlogCategories_BlogCategoryId",
                table: "Posts",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_BlogCategories_BlogCategoryId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId",
                table: "Posts");
        }
    }
}
