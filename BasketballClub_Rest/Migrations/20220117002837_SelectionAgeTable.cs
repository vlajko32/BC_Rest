using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class SelectionAgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectionAge",
                table: "Selections");

            migrationBuilder.AddColumn<int>(
                name: "SelectionAgeID",
                table: "Selections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SelectionAges",
                columns: table => new
                {
                    SelectionAgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectionAgeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionAges", x => x.SelectionAgeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_SelectionAgeID",
                table: "Selections",
                column: "SelectionAgeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_SelectionAges_SelectionAgeID",
                table: "Selections",
                column: "SelectionAgeID",
                principalTable: "SelectionAges",
                principalColumn: "SelectionAgeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selections_SelectionAges_SelectionAgeID",
                table: "Selections");

            migrationBuilder.DropTable(
                name: "SelectionAges");

            migrationBuilder.DropIndex(
                name: "IX_Selections_SelectionAgeID",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "SelectionAgeID",
                table: "Selections");

            migrationBuilder.AddColumn<string>(
                name: "SelectionAge",
                table: "Selections",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
