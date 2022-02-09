﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class UpdateSelectionPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Selections_SelectionID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_SelectionID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SelectionID",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "SelectionName",
                table: "Selections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SelectionAge",
                table: "Selections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayerSelection",
                columns: table => new
                {
                    PlayersPlayerID = table.Column<int>(type: "int", nullable: false),
                    SelectionsSelectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSelection", x => new { x.PlayersPlayerID, x.SelectionsSelectionID });
                    table.ForeignKey(
                        name: "FK_PlayerSelection_Players_PlayersPlayerID",
                        column: x => x.PlayersPlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSelection_Selections_SelectionsSelectionID",
                        column: x => x.SelectionsSelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSelection_SelectionsSelectionID",
                table: "PlayerSelection",
                column: "SelectionsSelectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSelection");

            migrationBuilder.DropColumn(
                name: "SelectionAge",
                table: "Selections");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionName",
                table: "Selections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectionID",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_SelectionID",
                table: "Players",
                column: "SelectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Selections_SelectionID",
                table: "Players",
                column: "SelectionID",
                principalTable: "Selections",
                principalColumn: "SelectionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
