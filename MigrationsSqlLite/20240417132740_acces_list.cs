using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class acces_list : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "Recommendations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "Institutions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "BaseDocuments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "AuditMissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "Activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ObjectiveActionId",
                table: "Activities",
                column: "ObjectiveActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ObjectiveAction_ObjectiveActionId",
                table: "Activities",
                column: "ObjectiveActionId",
                principalTable: "ObjectiveAction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ObjectiveAction_ObjectiveActionId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ObjectiveActionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "BaseDocuments");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "AuditMissions");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "Activities");
        }
    }
}
