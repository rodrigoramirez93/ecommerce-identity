using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Domain.Migrations
{
    public partial class defaulttenantid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultTenantId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_DefaultTenantId",
                table: "User",
                column: "DefaultTenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tenant_DefaultTenantId",
                table: "User",
                column: "DefaultTenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_DefaultTenantId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DefaultTenantId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DefaultTenantId",
                table: "User");
        }
    }
}
