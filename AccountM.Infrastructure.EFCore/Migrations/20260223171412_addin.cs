using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountM.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Role_RoleId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_RoleId",
                table: "Permission");

          
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Role",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

          
           

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_RoleId",
                table: "Account",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_RoleId",
                table: "Account");


            migrationBuilder.DropIndex(
                name: "IX_Account_RoleId",
                table: "Account");

        

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Role",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

        

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");

           
            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Role_RoleId",
                table: "Permission",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
