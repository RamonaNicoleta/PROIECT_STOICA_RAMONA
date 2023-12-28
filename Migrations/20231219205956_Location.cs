using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Stoica_Ramona.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_LocationID",
                table: "Car",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Location_LocationID",
                table: "Car",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Location_LocationID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Car_LocationID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Car");
        }
    }
}
