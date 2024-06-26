using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class institutionadminID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_AspNetUsers_InstitutionAdminId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_InstitutionAdminId",
                table: "Institutions");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstitutionAdminId",
                table: "Institutions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionAdminId1",
                table: "Institutions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_InstitutionAdminId1",
                table: "Institutions",
                column: "InstitutionAdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_AspNetUsers_InstitutionAdminId1",
                table: "Institutions",
                column: "InstitutionAdminId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_AspNetUsers_InstitutionAdminId1",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_InstitutionAdminId1",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "InstitutionAdminId1",
                table: "Institutions");

            migrationBuilder.AlterColumn<string>(
                name: "InstitutionAdminId",
                table: "Institutions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_InstitutionAdminId",
                table: "Institutions",
                column: "InstitutionAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_AspNetUsers_InstitutionAdminId",
                table: "Institutions",
                column: "InstitutionAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
