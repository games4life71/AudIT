using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class latestPLZ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_UserId1",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_AspNetUsers_OwnerId1",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_BaseDocument_OwnerId1",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "BaseDocument");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Activities");

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocument_OwnerId",
                table: "BaseDocument",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_AspNetUsers_OwnerId",
                table: "BaseDocument",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_AspNetUsers_OwnerId",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_BaseDocument_OwnerId",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserId",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "BaseDocument",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocument_OwnerId1",
                table: "BaseDocument",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId1",
                table: "Activities",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UserId1",
                table: "Activities",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_AspNetUsers_OwnerId1",
                table: "BaseDocument",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
