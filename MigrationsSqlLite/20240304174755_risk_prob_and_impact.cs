using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class risk_prob_and_impact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionRisk_ObjectiveAction_ObjectiveActionId",
                table: "ActionRisk");

            migrationBuilder.AlterColumn<Guid>(
                name: "ObjectiveActionId",
                table: "ActionRisk",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Impact",
                table: "ActionRisk",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Probability",
                table: "ActionRisk",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRisk_ObjectiveAction_ObjectiveActionId",
                table: "ActionRisk",
                column: "ObjectiveActionId",
                principalTable: "ObjectiveAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionRisk_ObjectiveAction_ObjectiveActionId",
                table: "ActionRisk");

            migrationBuilder.DropColumn(
                name: "Impact",
                table: "ActionRisk");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "ActionRisk");

            migrationBuilder.AlterColumn<Guid>(
                name: "ObjectiveActionId",
                table: "ActionRisk",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRisk_ObjectiveAction_ObjectiveActionId",
                table: "ActionRisk",
                column: "ObjectiveActionId",
                principalTable: "ObjectiveAction",
                principalColumn: "Id");
        }
    }
}
