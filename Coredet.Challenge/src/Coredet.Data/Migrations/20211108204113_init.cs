using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coredet.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Basket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("a382002d-d515-4e40-99c6-f1069d151369"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(1950), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Beygir At", 50m },
                    { new Guid("c23cab66-ff72-477b-a628-e531e7849e3a"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(1979), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Safkan Arap At", 50m },
                    { new Guid("69cf9987-323d-4015-af30-dce2ca307840"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(1982), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Alaca Kısrak At", 50m },
                    { new Guid("0d1275ed-ca9b-470c-a028-943dc17518f1"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(1984), "https://media.gq.com/photos/56e71c0b14cbe0637b261d7f/4:3/w_2260,h_1695,c_limit/horseinsuit2.jpg", false, "Rahvan At", 50m },
                    { new Guid("a52d8454-c582-4be3-986f-e28a7b07a0c4"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(1987), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Doru At", 50m },
                    { new Guid("5bf9b37e-ccc8-4d71-a2b6-f55c7110a61c"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(1989), "http://cdn.shopify.com/s/files/1/0420/2528/7847/products/Horse-Rug-Liner-Black-Test.jpg?v=1631720831", false, "Şişme Mont At", 50m },
                    { new Guid("1e18b95f-08f9-4bb6-8151-9290a3d8c3d3"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(2003), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Binek At At", 50m },
                    { new Guid("a9776e71-893f-4668-a9a0-68a92b1f5117"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(2005), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Tinker Güzeli At", 50m },
                    { new Guid("86613a15-6a77-4735-b87b-32ea18f234c9"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(2007), "https://www.horze.eu/dw/image/v2/AATB_PRD/on/demandware.static/-/Sites-hz-master-catalog/default/dwa5525f47/Harryshorse/331637_BL.jpg?sw=1600&sh=1600&q=100", false, "Kör At", 50m },
                    { new Guid("d49f30a3-217e-45ec-84e6-d6e8f4fe4a94"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(2009), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Midilli At", 50m },
                    { new Guid("eab24f64-5aa7-4f11-9373-3a3c235cb89a"), new DateTime(2021, 11, 8, 20, 41, 12, 156, DateTimeKind.Utc).AddTicks(2081), "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", false, "Beygir", 50m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "Password" },
                values: new object[] { new Guid("8867c3f7-e10d-46a2-8f23-026791cb7e01"), new DateTime(2021, 11, 8, 20, 41, 12, 153, DateTimeKind.Utc).AddTicks(6169), false, "ikbalkazanc", "123" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_BasketId",
                table: "BasketProducts",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductId",
                table: "BasketProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
