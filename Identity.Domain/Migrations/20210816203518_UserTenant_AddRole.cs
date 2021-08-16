using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Domain.Migrations
{
    public partial class UserTenant_AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserTenant",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTenant_RoleId",
                table: "UserTenant",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTenant_Role_RoleId",
                table: "UserTenant",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTenant_Role_RoleId",
                table: "UserTenant");

            migrationBuilder.DropIndex(
                name: "IX_UserTenant_RoleId",
                table: "UserTenant");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserTenant");
        }
    }
}
