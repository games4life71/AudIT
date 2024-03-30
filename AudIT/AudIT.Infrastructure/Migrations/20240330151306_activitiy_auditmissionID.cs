﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class activitiy_auditmissionID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AuditMissions_AuditMissionId",
                table: "Activities");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuditMissionId",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AuditMissions_AuditMissionId",
                table: "Activities",
                column: "AuditMissionId",
                principalTable: "AuditMissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AuditMissions_AuditMissionId",
                table: "Activities");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuditMissionId",
                table: "Activities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AuditMissions_AuditMissionId",
                table: "Activities",
                column: "AuditMissionId",
                principalTable: "AuditMissions",
                principalColumn: "Id");
        }
    }
}
