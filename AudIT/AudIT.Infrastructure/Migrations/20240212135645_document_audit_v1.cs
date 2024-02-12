using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class document_audit_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_AuditMissions_AuditMissionId",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_BaseDocument_AuditMissionId",
                table: "BaseDocument");

            migrationBuilder.DropColumn(
                name: "AuditMissionId",
                table: "BaseDocument");

            migrationBuilder.CreateTable(
                name: "AuditMissionDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BaseDocumentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditMissionDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditMissionDocument_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditMissionDocument_BaseDocument_BaseDocumentId",
                        column: x => x.BaseDocumentId,
                        principalTable: "BaseDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissionDocument_AuditMissionId",
                table: "AuditMissionDocument",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissionDocument_BaseDocumentId",
                table: "AuditMissionDocument",
                column: "BaseDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditMissionDocument");

            migrationBuilder.AddColumn<Guid>(
                name: "AuditMissionId",
                table: "BaseDocument",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocument_AuditMissionId",
                table: "BaseDocument",
                column: "AuditMissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_AuditMissions_AuditMissionId",
                table: "BaseDocument",
                column: "AuditMissionId",
                principalTable: "AuditMissions",
                principalColumn: "Id");
        }
    }
}
