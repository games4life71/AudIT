using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class domains_instit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailDomains",
                table: "Institutions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstitutionAdminId",
                table: "Institutions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_AspNetUsers_InstitutionAdminId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_InstitutionAdminId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "EmailDomains",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "InstitutionAdminId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "AspNetUsers");
        }
    }
}
