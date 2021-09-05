using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Domain.Migrations
{
    public partial class addtrackinguser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_DefaultTenantId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultTenantId",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tenant_DefaultTenantId",
                table: "User",
                column: "DefaultTenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_DefaultTenantId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultTenantId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tenant_DefaultTenantId",
                table: "User",
                column: "DefaultTenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
