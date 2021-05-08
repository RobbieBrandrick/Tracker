using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false),
                    RPE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseTypes_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSets",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false),
                    SetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSets", x => new { x.SetId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_ExerciseSets_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSets_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Squat" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Bench" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Deadlift" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Pullups" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseTypeId",
                table: "Exercise",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_SessionId",
                table: "Exercise",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_SetId",
                table: "ExerciseSets",
                column: "SetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
