using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Selections_SelectionID",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Selections_SelectionID",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionID",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionID",
                table: "Coaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Selections_SelectionID",
                table: "Coaches",
                column: "SelectionID",
                principalTable: "Selections",
                principalColumn: "SelectionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Selections_SelectionID",
                table: "Players",
                column: "SelectionID",
                principalTable: "Selections",
                principalColumn: "SelectionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Selections_SelectionID",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Selections_SelectionID",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionID",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SelectionID",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Selections_SelectionID",
                table: "Coaches",
                column: "SelectionID",
                principalTable: "Selections",
                principalColumn: "SelectionID",
                onDelete: ReferentialAction.Cascade);

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
