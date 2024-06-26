using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_objective_action_fiap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectiveActionFiap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ObjectiveActionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditedPeriodStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuditedPeriodEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Problem = table.Column<string>(type: "TEXT", nullable: false),
                    AditionalFindings = table.Column<string>(type: "TEXT", nullable: true),
                    Cause = table.Column<string>(type: "TEXT", nullable: true),
                    Consequence = table.Column<string>(type: "TEXT", nullable: true),
                    Recommendation = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccesUserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveActionFiap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectiveActionFiap_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveActionFiap_ObjectiveAction_ObjectiveActionId",
                        column: x => x.ObjectiveActionId,
                        principalTable: "ObjectiveAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveActionFiap_AuditMissionId",
                table: "ObjectiveActionFiap",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveActionFiap_ObjectiveActionId",
                table: "ObjectiveActionFiap",
                column: "ObjectiveActionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectiveActionFiap");
        }
    }
}
