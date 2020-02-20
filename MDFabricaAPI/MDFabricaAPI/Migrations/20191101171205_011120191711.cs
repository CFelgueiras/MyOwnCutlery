using Microsoft.EntityFrameworkCore.Migrations;

namespace MDFabricaAPI.Migrations
{
    public partial class _011120191711 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PreparationTime",
                table: "Operations",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "Operations");
        }
    }
}
