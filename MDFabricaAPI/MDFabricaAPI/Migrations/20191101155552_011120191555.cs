using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDFabricaAPI.Migrations
{
    public partial class _011120191555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    MachineTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineTypeName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.MachineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLines",
                columns: table => new
                {
                    ProductionLineId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdLineName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLines", x => x.ProductionLineId);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperationName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    ToolName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    OperationTool = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    MachineTypeId = table.Column<long>(nullable: true),
                    OperationTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "MachineTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identification = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    Brand = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    Model = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    Localization = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    Capacity = table.Column<decimal>(type: "decimal(5, 2)", nullable: false, defaultValue: 0m),
                    MachineTypeId = table.Column<long>(nullable: true),
                    ProductionLineId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "MachineTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machines_ProductionLines_ProductionLineId",
                        column: x => x.ProductionLineId,
                        principalTable: "ProductionLines",
                        principalColumn: "ProductionLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_ProductionLineId",
                table: "Machines",
                column: "ProductionLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_MachineTypeId",
                table: "Operations",
                column: "MachineTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "ProductionLines");

            migrationBuilder.DropTable(
                name: "MachineTypes");
        }
    }
}
