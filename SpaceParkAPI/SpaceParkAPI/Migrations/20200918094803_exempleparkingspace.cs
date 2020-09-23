using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class exempleparkingspace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "ID", "ParkingLotID", "SpaceShipID" },
                values: new object[] { 1L, 1L, 2L });

            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "ID", "ParkingLotID", "SpaceShipID" },
                values: new object[] { 2L, 2L, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ID",
                keyValue: 2L);
        }
    }
}
