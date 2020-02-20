using Microsoft.EntityFrameworkCore.Migrations;

namespace MDFabricaAPI.Migrations
{
    public partial class _201912162138 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Machines",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Machines");
        }
    }
}
