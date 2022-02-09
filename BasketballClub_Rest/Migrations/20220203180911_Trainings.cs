using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballClub_Rest.Migrations
{
    public partial class Trainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachUserID",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Gyms_GymID",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CoachUserID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "CoachUserID",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TrainingDuration",
                table: "Trainings",
                newName: "CoachID");

            migrationBuilder.AlterColumn<int>(
                name: "GymID",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrainingEnd",
                table: "Trainings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachID",
                table: "Trainings",
                column: "CoachID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Coaches_CoachID",
                table: "Trainings",
                column: "CoachID",
                principalTable: "Coaches",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Gyms_GymID",
                table: "Trainings",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "GymID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachID",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Gyms_GymID",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_CoachID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingEnd",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "CoachID",
                table: "Trainings",
                newName: "TrainingDuration");

            migrationBuilder.AlterColumn<int>(
                name: "GymID",
                table: "Trainings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CoachUserID",
                table: "Trainings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_CoachUserID",
                table: "Trainings",
                column: "CoachUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Coaches_CoachUserID",
                table: "Trainings",
                column: "CoachUserID",
                principalTable: "Coaches",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Gyms_GymID",
                table: "Trainings",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "GymID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
