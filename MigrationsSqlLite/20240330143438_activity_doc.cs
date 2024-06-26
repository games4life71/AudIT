using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class activity_doc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "BaseDocument",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocument_ActivityId",
                table: "BaseDocument",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_Activities_ActivityId",
                table: "BaseDocument",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_Activities_ActivityId",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_BaseDocument_ActivityId",
                table: "BaseDocument");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "BaseDocument");
        }
    }
}
