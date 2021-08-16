using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Domain.Migrations
{
    public partial class UserTenant_AddRole_notNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "UserTenant",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "UserTenant",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
