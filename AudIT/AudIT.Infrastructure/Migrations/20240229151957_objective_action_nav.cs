using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class objective_action_nav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMissionObjectives_Objectives_ObjectiveId",
                table: "AuditMissionObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectiveAction_Objectives_ObjectiveId",
                table: "ObjectiveAction");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.AlterColumn<Guid>(
                name: "ObjectiveId",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objective_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objective_AuditMissionId",
                table: "Objective",
                column: "AuditMissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMissionObjectives_Objective_ObjectiveId",
                table: "AuditMissionObjectives",
                column: "ObjectiveId",
                principalTable: "Objective",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectiveAction_Objective_ObjectiveId",
                table: "ObjectiveAction",
                column: "ObjectiveId",
                principalTable: "Objective",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMissionObjectives_Objective_ObjectiveId",
                table: "AuditMissionObjectives");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectiveAction_Objective_ObjectiveId",
                table: "ObjectiveAction");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.AlterColumn<Guid>(
                name: "ObjectiveId",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_AuditMissionId",
                table: "Objective",
                column: "AuditMissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMissionObjectives_Objectives_ObjectiveId",
                table: "AuditMissionObjectives",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectiveAction_Objectives_ObjectiveId",
                table: "ObjectiveAction",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id");
        }
    }
}
