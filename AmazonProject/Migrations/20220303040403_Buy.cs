using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonProject.Migrations
{
    public partial class Buy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "CartLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    BuyitemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_CartLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLineItem_Buys_BuyitemId",
                        column: x => x.BuyitemId,
                        principalTable: "Buys",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItem_BookId",
                table: "CartLineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItem_BuyitemId",
                table: "CartLineItem",
                column: "BuyitemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLineItem");

            migrationBuilder.DropTable(
                name: "Buys");
        }
    }
}
