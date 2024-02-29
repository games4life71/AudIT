using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class objectives_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objectives",
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

            migrationBuilder.CreateTable(
                name: "AuditMissionObjectives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditMissionObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditMissionObjectives_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditMissionObjectives_Objective_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ControaleInterneExistente = table.Column<string>(type: "TEXT", nullable: false),
                    ControaleInterneAsteptate = table.Column<string>(type: "TEXT", nullable: false),
                    Selected = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectiveAction_Objective_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActionRisk",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Risk = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectiveActionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionRisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionRisk_ObjectiveAction_ObjectiveActionId",
                        column: x => x.ObjectiveActionId,
                        principalTable: "ObjectiveAction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionRisk_ObjectiveActionId",
                table: "ActionRisk",
                column: "ObjectiveActionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissionObjectives_AuditMissionId",
                table: "AuditMissionObjectives",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissionObjectives_ObjectiveId",
                table: "AuditMissionObjectives",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_AuditMissionId",
                table: "Objectives",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveAction_ObjectiveId",
                table: "ObjectiveAction",
                column: "ObjectiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionRisk");

            migrationBuilder.DropTable(
                name: "AuditMissionObjectives");

            migrationBuilder.DropTable(
                name: "ObjectiveAction");

            migrationBuilder.DropTable(
                name: "Objectives");
        }
    }
}
