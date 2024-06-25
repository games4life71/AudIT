using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_grantedByProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrantedByUserId",
                table: "EntityAcces",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAcces_GrantedByUserId",
                table: "EntityAcces",
                column: "GrantedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAcces_UserId",
                table: "EntityAcces",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityAcces_AspNetUsers_GrantedByUserId",
                table: "EntityAcces",
                column: "GrantedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityAcces_AspNetUsers_UserId",
                table: "EntityAcces",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityAcces_AspNetUsers_GrantedByUserId",
                table: "EntityAcces");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityAcces_AspNetUsers_UserId",
                table: "EntityAcces");

            migrationBuilder.DropIndex(
                name: "IX_EntityAcces_GrantedByUserId",
                table: "EntityAcces");

            migrationBuilder.DropIndex(
                name: "IX_EntityAcces_UserId",
                table: "EntityAcces");

            migrationBuilder.DropColumn(
                name: "GrantedByUserId",
                table: "EntityAcces");
        }
    }
}
