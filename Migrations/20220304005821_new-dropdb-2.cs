using Microsoft.EntityFrameworkCore.Migrations;

namespace Odonto.Migrations
{
    public partial class newdropdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DentistId",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "SpeciliatyId",
                table: "Dentists");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Dentists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Dentists");

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "Dentists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciliatyId",
                table: "Dentists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
