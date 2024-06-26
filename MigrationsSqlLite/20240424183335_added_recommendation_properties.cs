using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_recommendation_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AditionalFindings",
                table: "Recommendations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cause",
                table: "Recommendations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consequence",
                table: "Recommendations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Problem",
                table: "Recommendations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecommendationDescription",
                table: "Recommendations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AditionalFindings",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Cause",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Consequence",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Problem",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "RecommendationDescription",
                table: "Recommendations");
        }
    }
}
