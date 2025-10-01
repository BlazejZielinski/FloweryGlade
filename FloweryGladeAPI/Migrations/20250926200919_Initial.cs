using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloweryGladeAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowerShops",
                columns: table => new
                {
                    FlowerShopID = table.Column<int>(type: "int", maxLength: 200, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerShops", x => x.FlowerShopID);
                });

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresss_FlowerShops_FlowerShopID",
                        column: x => x.FlowerShopID,
                        principalTable: "FlowerShops",
                        principalColumn: "FlowerShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_FlowerShops_FlowerShopID",
                        column: x => x.FlowerShopID,
                        principalTable: "FlowerShops",
                        principalColumn: "FlowerShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerPrice = table.Column<double>(type: "float", nullable: false),
                    FlowerShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flowers_FlowerShops_FlowerShopID",
                        column: x => x.FlowerShopID,
                        principalTable: "FlowerShops",
                        principalColumn: "FlowerShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_FlowerShops_FlowerShopID",
                        column: x => x.FlowerShopID,
                        principalTable: "FlowerShops",
                        principalColumn: "FlowerShopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_FlowerShopID",
                table: "Addresss",
                column: "FlowerShopID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FlowerShopID",
                table: "Clients",
                column: "FlowerShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_FlowerShopID",
                table: "Flowers",
                column: "FlowerShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FlowerShopID",
                table: "Users",
                column: "FlowerShopID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FlowerShops");
        }
    }
}
