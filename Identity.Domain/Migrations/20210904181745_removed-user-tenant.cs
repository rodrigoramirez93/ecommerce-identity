using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Domain.Migrations
{
    public partial class removedusertenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTenant");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "UserRole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_TenantId",
                table: "UserRole",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Tenant_TenantId",
                table: "UserRole",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Tenant_TenantId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_TenantId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "UserRole");

            migrationBuilder.CreateTable(
                name: "UserTenant",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTenant", x => new { x.TenantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserTenant_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTenant_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTenant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTenant_RoleId",
                table: "UserTenant",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTenant_UserId",
                table: "UserTenant",
                column: "UserId");
        }
    }
}
