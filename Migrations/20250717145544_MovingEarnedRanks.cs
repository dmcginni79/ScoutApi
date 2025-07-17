using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoutApi.Migrations
{
    /// <inheritdoc />
    public partial class MovingEarnedRanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarnedRanks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Awards");

            migrationBuilder.AddColumn<string>(
                name: "EarnedRanks",
                table: "Scouts",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarnedRanks",
                table: "Scouts");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Awards",
                type: "TEXT",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Awards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EarnedRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RankId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScoutId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateEarned = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarnedRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EarnedRanks_Awards_RankId",
                        column: x => x.RankId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EarnedRanks_Scouts_ScoutId",
                        column: x => x.ScoutId,
                        principalTable: "Scouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EarnedRanks_RankId",
                table: "EarnedRanks",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_EarnedRanks_ScoutId",
                table: "EarnedRanks",
                column: "ScoutId");
        }
    }
}
