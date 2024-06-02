using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userinst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstitutionId",
                table: "AspNetUsers",
                column: "InstitutionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionId",
                table: "AspNetUsers",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InstitutionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "AspNetUsers");

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
    }
}
