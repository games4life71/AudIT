using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class recommendations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AuditMissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObjectiveActionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recommendations_ObjectiveAction_ObjectiveActionId",
                        column: x => x.ObjectiveActionId,
                        principalTable: "ObjectiveAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditMissionRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecommendationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditMissionRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditMissionRecommendations_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditMissionRecommendations_Recommendations_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissionRecommendations_AuditMissionId",
                table: "AuditMissionRecommendations",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissionRecommendations_RecommendationId",
                table: "AuditMissionRecommendations",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_ObjectiveActionId",
                table: "Recommendations",
                column: "ObjectiveActionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditMissionRecommendations");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AuditMissions");
        }
    }
}
