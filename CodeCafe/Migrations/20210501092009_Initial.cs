using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCafe.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    FlavorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlavorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.FlavorId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FlavorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.ProductId, x.FlavorId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Flavors_FlavorId",
                        column: x => x.FlavorId,
                        principalTable: "Flavors",
                        principalColumn: "FlavorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flavors",
                columns: new[] { "FlavorId", "FlavorName" },
                values: new object[,]
                {
                    { 1, "Bitter" },
                    { 2, "Sour" },
                    { 3, "Fruity" },
                    { 4, "Salty" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Image", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Cappucino", "/images/Cappuccino.jpg", 2.9900000000000002, "Cappucino" },
                    { 2, "Mocha Frappe", "/images/MochaFrappe.jpg", 2.9900000000000002, "Mocha Frappe" },
                    { 3, "Caramel Frappe", "/images/CaramelFrappe.jpg", 2.9900000000000002, "Caramel Frappe" },
                    { 4, "Black Coffee", "/images/BlackCoffee.jpg", 1.0, "Black Coffee" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "FlavorId", "ProductId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 2, 2 },
                    { 4, 3 },
                    { 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FlavorId",
                table: "OrderItems",
                column: "FlavorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Flavors");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
