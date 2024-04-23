using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class write_read_acces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "Recommendations",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "ObjectiveActionFiap",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "ObjectiveAction",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "Objective",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "Institutions",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "Departments",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "BaseDocuments",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "AuditMissions",
                newName: "WriteAccesUserId");

            migrationBuilder.RenameColumn(
                name: "AccesUserId",
                table: "Activities",
                newName: "WriteAccesUserId");

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "Recommendations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "ObjectiveActionFiap",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "Objective",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "Institutions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "BaseDocuments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "AuditMissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAccesUserId",
                table: "Activities",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "ObjectiveActionFiap");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "ObjectiveAction");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "BaseDocuments");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "AuditMissions");

            migrationBuilder.DropColumn(
                name: "ReadAccesUserId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "Recommendations",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "ObjectiveActionFiap",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "ObjectiveAction",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "Objective",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "Institutions",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "Departments",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "BaseDocuments",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "AuditMissions",
                newName: "AccesUserId");

            migrationBuilder.RenameColumn(
                name: "WriteAccesUserId",
                table: "Activities",
                newName: "AccesUserId");
        }
    }
}
