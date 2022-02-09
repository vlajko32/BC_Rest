using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class Preliminary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Coaches",
                newName: "SelectionID");

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    GymID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.GymID);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectionName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.SelectionID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Selections_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingDuration = table.Column<int>(type: "int", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: true),
                    CoachUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK_Trainings_Coaches_CoachUserID",
                        column: x => x.CoachUserID,
                        principalTable: "Coaches",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainings_Selections_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_SelectionID",
                table: "Coaches",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SelectionID",
                table: "Players",
                column: "SelectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachUserID",
                table: "Trainings",
                column: "CoachUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_GymID",
                table: "Trainings",
                column: "GymID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_SelectionID",
                table: "Trainings",
                column: "SelectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Selections_SelectionID",
                table: "Coaches",
                column: "SelectionID",
                principalTable: "Selections",
                principalColumn: "SelectionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Selections_SelectionID",
                table: "Coaches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_SelectionID",
                table: "Coaches");

            migrationBuilder.RenameColumn(
                name: "SelectionID",
                table: "Coaches",
                newName: "MyProperty");
        }
    }
}
