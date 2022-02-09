using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class SelectionAgeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SelectionAges",
                columns: new[] { "SelectionAgeID", "SelectionAgeName" },
                values: new object[,]
                {
                    { 1, "Under 10" },
                    { 2, "Under 12" },
                    { 3, "Under 14" },
                    { 4, "Under 16" },
                    { 5, "Juniors" },
                    { 6, "Seniors" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SelectionAges",
                keyColumn: "SelectionAgeID",
                keyValue: 6);
        }
    }
}
