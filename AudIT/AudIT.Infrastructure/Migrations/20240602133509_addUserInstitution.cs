using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "UserInstitution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    InstitutionId = table.Column<int>(type: "INTEGER", nullable: false),
                    InstitutionId1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInstitution_Institutions_InstitutionId1",
                        column: x => x.InstitutionId1,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_InstitutionAdminId1",
                table: "Institutions",
                column: "InstitutionAdminId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitution_InstitutionId1",
                table: "UserInstitution",
                column: "InstitutionId1");

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

            migrationBuilder.DropTable(
                name: "UserInstitution");

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
                nullable: true);

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
                principalColumn: "Id");
        }
    }
}
