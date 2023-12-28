using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Stoica_Ramona.Migrations
{
    public partial class modificareEngine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Assigned",
                table: "EngineType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "EngineType");
        }
    }
}
