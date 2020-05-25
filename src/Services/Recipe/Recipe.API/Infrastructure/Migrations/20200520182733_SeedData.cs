using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.API.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "recipes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "recipes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Poulet Curry" },
                    { 2, "Poulet Tandory" },
                    { 3, "Bo Boun" },
                    { 4, "PokeBall Oignon free" },
                    { 5, "MilkShake Bacon" }
                });

            migrationBuilder.InsertData(
                table: "recipe_product",
                columns: new[] { "recipe_id", "product_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 8 },
                    { 5, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "recipe_product",
                keyColumns: new[] { "recipe_id", "product_id" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "recipes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "recipes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "recipes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "recipes",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "recipes",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "recipes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
