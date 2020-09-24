using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class exempledataforspaceship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Spaceships",
                columns: new[] { "ID", "PersonID" },
                values: new object[] { 1L, 2L });

            migrationBuilder.InsertData(
                table: "Spaceships",
                columns: new[] { "ID", "PersonID" },
                values: new object[] { 2L, 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spaceships",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Spaceships",
                keyColumn: "ID",
                keyValue: 2L);
        }
    }
}
