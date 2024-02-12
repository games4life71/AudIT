using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mission_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateDocuments_Users_OwnerId",
                table: "TemplateDocuments");

            migrationBuilder.DropTable(
                name: "StandaloneDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateDocuments",
                table: "TemplateDocuments");

            migrationBuilder.RenameTable(
                name: "TemplateDocuments",
                newName: "BaseDocument");

            migrationBuilder.RenameIndex(
                name: "IX_TemplateDocuments_OwnerId",
                table: "BaseDocument",
                newName: "IX_BaseDocument_OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "BaseDocument",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "BaseDocument",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "BaseDocument",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<Guid>(
                name: "AuditMissionId",
                table: "BaseDocument",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "BaseDocument",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseDocument",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseDocument",
                table: "BaseDocument",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuditMissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditMissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditMissions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditMissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditMissionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AuditMissions_AuditMissionId",
                        column: x => x.AuditMissionId,
                        principalTable: "AuditMissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocument_AuditMissionId",
                table: "BaseDocument",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseDocument_DepartmentId",
                table: "BaseDocument",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AuditMissionId",
                table: "Activities",
                column: "AuditMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DepartmentId",
                table: "Activities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissions_DepartmentId",
                table: "AuditMissions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMissions_UserId",
                table: "AuditMissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_AuditMissions_AuditMissionId",
                table: "BaseDocument",
                column: "AuditMissionId",
                principalTable: "AuditMissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_Departments_DepartmentId",
                table: "BaseDocument",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_Users_OwnerId",
                table: "BaseDocument",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_AuditMissions_AuditMissionId",
                table: "BaseDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_Departments_DepartmentId",
                table: "BaseDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_Users_OwnerId",
                table: "BaseDocument");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AuditMissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseDocument",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_BaseDocument_AuditMissionId",
                table: "BaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_BaseDocument_DepartmentId",
                table: "BaseDocument");

            migrationBuilder.DropColumn(
                name: "AuditMissionId",
                table: "BaseDocument");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "BaseDocument");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseDocument");

            migrationBuilder.RenameTable(
                name: "BaseDocument",
                newName: "TemplateDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocument_OwnerId",
                table: "TemplateDocuments",
                newName: "IX_TemplateDocuments_OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "TemplateDocuments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "TemplateDocuments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "TemplateDocuments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateDocuments",
                table: "TemplateDocuments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StandaloneDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Extension = table.Column<string>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandaloneDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandaloneDocuments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandaloneDocuments_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandaloneDocuments_DepartmentId",
                table: "StandaloneDocuments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StandaloneDocuments_OwnerId",
                table: "StandaloneDocuments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateDocuments_Users_OwnerId",
                table: "TemplateDocuments",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
