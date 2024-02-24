using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dadasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMissions_AspNetUsers_UserId1",
                table: "AuditMissions");

            migrationBuilder.DropIndex(
                name: "IX_AuditMissions_UserId1",
                table: "AuditMissions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AuditMissions");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissions_UserId",
                table: "AuditMissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMissions_AspNetUsers_UserId",
                table: "AuditMissions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMissions_AspNetUsers_UserId",
                table: "AuditMissions");

            migrationBuilder.DropIndex(
                name: "IX_AuditMissions_UserId",
                table: "AuditMissions");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "AuditMissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissions_UserId1",
                table: "AuditMissions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMissions_AspNetUsers_UserId1",
                table: "AuditMissions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
