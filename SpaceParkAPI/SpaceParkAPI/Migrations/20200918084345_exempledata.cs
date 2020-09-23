using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class exempledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_SpaceshipModels_SpaceShipID",
                table: "ParkingSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_SpaceshipModels_PersonModels_PersonID",
                table: "SpaceshipModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceshipModels",
                table: "SpaceshipModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonModels",
                table: "PersonModels");

            migrationBuilder.RenameTable(
                name: "SpaceshipModels",
                newName: "Spaceships");

            migrationBuilder.RenameTable(
                name: "PersonModels",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_SpaceshipModels_PersonID",
                table: "Spaceships",
                newName: "IX_Spaceships_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1L, "sebastian" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2L, "Eric" });

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_Spaceships_SpaceShipID",
                table: "ParkingSpaces",
                column: "SpaceShipID",
                principalTable: "Spaceships",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spaceships_Persons_PersonID",
                table: "Spaceships",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_Spaceships_SpaceShipID",
                table: "ParkingSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Spaceships_Persons_PersonID",
                table: "Spaceships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.RenameTable(
                name: "Spaceships",
                newName: "SpaceshipModels");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "PersonModels");

            migrationBuilder.RenameIndex(
                name: "IX_Spaceships_PersonID",
                table: "SpaceshipModels",
                newName: "IX_SpaceshipModels_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceshipModels",
                table: "SpaceshipModels",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonModels",
                table: "PersonModels",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_SpaceshipModels_SpaceShipID",
                table: "ParkingSpaces",
                column: "SpaceShipID",
                principalTable: "SpaceshipModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceshipModels_PersonModels_PersonID",
                table: "SpaceshipModels",
                column: "PersonID",
                principalTable: "PersonModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
