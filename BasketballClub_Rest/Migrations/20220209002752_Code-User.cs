using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class CodeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachID",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SelectionID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, 240798 });

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2, 897042 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectionID",
                table: "Users",
                column: "SelectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_CoachID",
                table: "Trainings",
                column: "CoachID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Selections_SelectionID",
                table: "Users",
                column: "SelectionID",
                principalTable: "Selections",
                principalColumn: "SelectionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_CoachID",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Selections_SelectionID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Users_SelectionID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SelectionID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Administrators_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SelectionID = table.Column<int>(type: "int", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Coaches_Selections_SelectionID",
                        column: x => x.SelectionID,
                        principalTable: "Selections",
                        principalColumn: "SelectionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coaches_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_SelectionID",
                table: "Coaches",
                column: "SelectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Coaches_CoachID",
                table: "Trainings",
                column: "CoachID",
                principalTable: "Coaches",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
