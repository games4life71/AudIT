using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedinheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ObjectiveAction",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AccesUserId",
                table: "Objective",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Objective",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Objective",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Objective",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Objective",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "ObjectiveAction");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ObjectiveAction");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ObjectiveAction");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ObjectiveAction");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ObjectiveAction");

            migrationBuilder.DropColumn(
                name: "AccesUserId",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Objective");
        }
    }
}
