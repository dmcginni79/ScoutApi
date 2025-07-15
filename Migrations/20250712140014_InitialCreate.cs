using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoutApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsPrimaryGuardian = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EarnedAwards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScoutId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AwardId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateEarned = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarnedAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EarnedAwards_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EarnedAwards_Scouts_ScoutId",
                        column: x => x.ScoutId,
                        principalTable: "Scouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EarnedRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScoutId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RankId = table.Column<Guid>(type: "TEXT", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "GuardianScouts",
                columns: table => new
                {
                    GuardiansId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScoutsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianScouts", x => new { x.GuardiansId, x.ScoutsId });
                    table.ForeignKey(
                        name: "FK_GuardianScouts_Guardians_GuardiansId",
                        column: x => x.GuardiansId,
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuardianScouts_Scouts_ScoutsId",
                        column: x => x.ScoutsId,
                        principalTable: "Scouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EarnedAwards_AwardId",
                table: "EarnedAwards",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_EarnedAwards_ScoutId",
                table: "EarnedAwards",
                column: "ScoutId");

            migrationBuilder.CreateIndex(
                name: "IX_EarnedRanks_RankId",
                table: "EarnedRanks",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_EarnedRanks_ScoutId",
                table: "EarnedRanks",
                column: "ScoutId");

            migrationBuilder.CreateIndex(
                name: "IX_GuardianScouts_ScoutsId",
                table: "GuardianScouts",
                column: "ScoutsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarnedAwards");

            migrationBuilder.DropTable(
                name: "EarnedRanks");

            migrationBuilder.DropTable(
                name: "GuardianScouts");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "Scouts");
        }
    }
}
