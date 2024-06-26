using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserpNavProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserInstitution_UserId",
                table: "UserInstitution",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitution_AspNetUsers_UserId",
                table: "UserInstitution",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitution_AspNetUsers_UserId",
                table: "UserInstitution");

            migrationBuilder.DropIndex(
                name: "IX_UserInstitution_UserId",
                table: "UserInstitution");
        }
    }
}
