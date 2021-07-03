using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Domain.Migrations
{
    public partial class roleClaimIsNotAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RoleClaim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "RoleClaim",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RoleClaim",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RoleClaim",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "RoleClaim",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "RoleClaim",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "RoleClaim",
                type: "int",
                nullable: true);
        }
    }
}
