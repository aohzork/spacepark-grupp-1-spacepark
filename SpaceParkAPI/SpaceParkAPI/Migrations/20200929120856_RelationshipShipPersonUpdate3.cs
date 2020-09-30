using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class RelationshipShipPersonUpdate3 : Migration
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
                name: "ParkingSpaces",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParkingSpaces_ParkingLots_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "ParkingLots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spaceships",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpaceID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spaceships_ParkingSpaces_ParkingSpaceID",
                        column: x => x.ParkingSpaceID,
                        principalTable: "ParkingSpaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpaceshipID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persons_Spaceships_SpaceshipID",
                        column: x => x.SpaceshipID,
                        principalTable: "Spaceships",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ID", "TotalAmount" },
                values: new object[] { 1L, 15L });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ID", "TotalAmount" },
                values: new object[] { 2L, 14L });

            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "ID", "ParkingLotID" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "ID", "ParkingLotID" },
                values: new object[] { 2L, 1L });

            migrationBuilder.InsertData(
                table: "Spaceships",
                columns: new[] { "ID", "ParkingSpaceID" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "Spaceships",
                columns: new[] { "ID", "ParkingSpaceID" },
                values: new object[] { 2L, 2L });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Name", "SpaceshipID" },
                values: new object[] { 1L, "sebastian", 1L });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Name", "SpaceshipID" },
                values: new object[] { 2L, "Eric", 2L });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_ParkingLotID",
                table: "ParkingSpaces",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SpaceshipID",
                table: "Persons",
                column: "SpaceshipID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spaceships_ParkingSpaceID",
                table: "Spaceships",
                column: "ParkingSpaceID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Spaceships");

            migrationBuilder.DropTable(
                name: "ParkingSpaces");

            migrationBuilder.DropTable(
                name: "ParkingLots");
        }
    }
}
