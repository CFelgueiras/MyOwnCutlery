using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDProducaoAPI.Migrations
{
    public partial class _021120191626 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturingPlans",
                columns: table => new
                {
                    manufacturingPlanId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingPlans", x => x.manufacturingPlanId);
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
                    OperationTime = table.Column<int>(nullable: false),
                    PreparationTime = table.Column<double>(nullable: false),
                    manufacturingPlanId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_ManufacturingPlans_manufacturingPlanId",
                        column: x => x.manufacturingPlanId,
                        principalTable: "ManufacturingPlans",
                        principalColumn: "manufacturingPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    ManPlanId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ManufacturingPlans_ManPlanId",
                        column: x => x.ManPlanId,
                        principalTable: "ManufacturingPlans",
                        principalColumn: "manufacturingPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_manufacturingPlanId",
                table: "Operations",
                column: "manufacturingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManPlanId",
                table: "Products",
                column: "ManPlanId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ManufacturingPlans");
        }
    }
}
