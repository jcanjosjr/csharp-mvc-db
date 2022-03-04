using Microsoft.EntityFrameworkCore.Migrations;

namespace Odonto.Migrations
{
    public partial class fixpositionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Dentists_DentistId",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "IdDentist",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "IdPatient",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "IdRoom",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "IdScheduler",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "IdDentist",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "IdSpeciality",
                table: "Dentists");

            migrationBuilder.AlterColumn<int>(
                name: "DentistId",
                table: "Schedulers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Schedulers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Schedulers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchedulerId",
                table: "Procedures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "Dentists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciliatyId",
                table: "Dentists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Dentists_DentistId",
                table: "Schedulers",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Dentists_DentistId",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Schedulers");

            migrationBuilder.DropColumn(
                name: "SchedulerId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "SpeciliatyId",
                table: "Dentists");

            migrationBuilder.AlterColumn<int>(
                name: "DentistId",
                table: "Schedulers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdDentist",
                table: "Schedulers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPatient",
                table: "Schedulers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRoom",
                table: "Schedulers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdScheduler",
                table: "Procedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDentist",
                table: "Dentists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSpeciality",
                table: "Dentists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Dentists_DentistId",
                table: "Schedulers",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
