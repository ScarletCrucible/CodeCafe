using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeCafe.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Image", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Cappucino", "logo.png", 2.9900000000000002, "Cappucino" },
                    { 2, "Mocha Frappe", "logo.png", 2.9900000000000002, "Mocha Frappe" },
                    { 3, "Caramel Frappe", "logo.png", 2.9900000000000002, "Caramel Frappe" },
                    { 4, "Black Coffee", "logo.png", 1.0, "Black Coffee" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                column: "ProductId",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
