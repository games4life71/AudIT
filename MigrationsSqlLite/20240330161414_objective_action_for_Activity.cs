using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class objective_action_for_Activity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ObjectiveActionId",
                table: "Activities",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectiveActionId",
                table: "Activities");
        }
    }
}
