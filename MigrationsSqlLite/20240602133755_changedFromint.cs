using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedFromint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitution_Institutions_InstitutionId1",
                table: "UserInstitution");

            migrationBuilder.DropIndex(
                name: "IX_UserInstitution_InstitutionId1",
                table: "UserInstitution");

            migrationBuilder.DropColumn(
                name: "InstitutionId1",
                table: "UserInstitution");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstitutionId",
                table: "UserInstitution",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitution_InstitutionId",
                table: "UserInstitution",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitution_Institutions_InstitutionId",
                table: "UserInstitution",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitution_Institutions_InstitutionId",
                table: "UserInstitution");

            migrationBuilder.DropIndex(
                name: "IX_UserInstitution_InstitutionId",
                table: "UserInstitution");

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                table: "UserInstitution",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId1",
                table: "UserInstitution",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitution_InstitutionId1",
                table: "UserInstitution",
                column: "InstitutionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitution_Institutions_InstitutionId1",
                table: "UserInstitution",
                column: "InstitutionId1",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
