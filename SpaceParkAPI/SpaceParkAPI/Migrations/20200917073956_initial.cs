using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonModels",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SpaceshipModels",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceshipModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpaceshipModels_PersonModels_PersonID",
                        column: x => x.PersonID,
                        principalTable: "PersonModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpaces",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotID = table.Column<long>(type: "bigint", nullable: true),
                    SpaceShipID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParkingSpaces_ParkingLots_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "ParkingLots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingSpaces_SpaceshipModels_SpaceShipID",
                        column: x => x.SpaceShipID,
                        principalTable: "SpaceshipModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_ParkingLotID",
                table: "ParkingSpaces",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_SpaceShipID",
                table: "ParkingSpaces",
                column: "SpaceShipID");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceshipModels_PersonID",
                table: "SpaceshipModels",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpaces");

            migrationBuilder.DropTable(
                name: "ParkingLots");

            migrationBuilder.DropTable(
                name: "SpaceshipModels");

            migrationBuilder.DropTable(
                name: "PersonModels");
        }
    }
}
