using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leitner.Migrations;

/// <inheritdoc />
public partial class LastReviewToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastReviewed",
                table: "Flashcards");

            migrationBuilder.AddColumn<int>(
                name: "LastReviewedDay",
                table: "Flashcards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastReviewedDay",
                table: "Flashcards");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastReviewed",
                table: "Flashcards",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
