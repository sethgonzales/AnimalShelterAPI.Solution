using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalShelter.Migrations
{
    public partial class SeedPetData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Age", "Breed", "Color", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 5, "Tortie", "Brown and Black", "Jackie", "Cat" },
                    { 2, 11, "Labrador", "Yellow", "Spike", "Dog" },
                    { 3, 3, "Tuxedo", "Black and White", "Felix", "Cat" },
                    { 4, 24, "Schnauzer", "White", "Poppins", "Dog" },
                    { 5, 12, "Bulldog", "Brown and White", "Benny", "Dog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 5);
        }
    }
}
