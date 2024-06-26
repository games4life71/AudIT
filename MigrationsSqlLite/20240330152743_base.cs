using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMissionDocument_BaseDocument_BaseDocumentId",
                table: "AuditMissionDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_Activities_ActivityId",
                table: "BaseDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_AspNetUsers_OwnerId",
                table: "BaseDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocument_Departments_DepartmentId",
                table: "BaseDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseDocument",
                table: "BaseDocument");

            migrationBuilder.RenameTable(
                name: "BaseDocument",
                newName: "BaseDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocument_OwnerId",
                table: "BaseDocuments",
                newName: "IX_BaseDocuments_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocument_DepartmentId",
                table: "BaseDocuments",
                newName: "IX_BaseDocuments_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocument_ActivityId",
                table: "BaseDocuments",
                newName: "IX_BaseDocuments_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseDocuments",
                table: "BaseDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMissionDocument_BaseDocuments_BaseDocumentId",
                table: "AuditMissionDocument",
                column: "BaseDocumentId",
                principalTable: "BaseDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocuments_Activities_ActivityId",
                table: "BaseDocuments",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocuments_AspNetUsers_OwnerId",
                table: "BaseDocuments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocuments_Departments_DepartmentId",
                table: "BaseDocuments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditMissionDocument_BaseDocuments_BaseDocumentId",
                table: "AuditMissionDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocuments_Activities_ActivityId",
                table: "BaseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocuments_AspNetUsers_OwnerId",
                table: "BaseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseDocuments_Departments_DepartmentId",
                table: "BaseDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseDocuments",
                table: "BaseDocuments");

            migrationBuilder.RenameTable(
                name: "BaseDocuments",
                newName: "BaseDocument");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocuments_OwnerId",
                table: "BaseDocument",
                newName: "IX_BaseDocument_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocuments_DepartmentId",
                table: "BaseDocument",
                newName: "IX_BaseDocument_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseDocuments_ActivityId",
                table: "BaseDocument",
                newName: "IX_BaseDocument_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseDocument",
                table: "BaseDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditMissionDocument_BaseDocument_BaseDocumentId",
                table: "AuditMissionDocument",
                column: "BaseDocumentId",
                principalTable: "BaseDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_Activities_ActivityId",
                table: "BaseDocument",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_AspNetUsers_OwnerId",
                table: "BaseDocument",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseDocument_Departments_DepartmentId",
                table: "BaseDocument",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
