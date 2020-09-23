using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class exempleparkinglot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ID", "TotalAmount" },
                values: new object[] { 1L, 15L });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ID", "TotalAmount" },
                values: new object[] { 2L, 14L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ID",
                keyValue: 2L);
        }
    }
}
