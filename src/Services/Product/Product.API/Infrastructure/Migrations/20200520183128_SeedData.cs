using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.API.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Poulet" },
                    { 2, "Curry" },
                    { 3, "Tandori" },
                    { 4, "Bo" },
                    { 5, "Boun" },
                    { 6, "Pokeball" },
                    { 7, "Pokeball" },
                    { 8, "Milk" },
                    { 9, "Bacon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
