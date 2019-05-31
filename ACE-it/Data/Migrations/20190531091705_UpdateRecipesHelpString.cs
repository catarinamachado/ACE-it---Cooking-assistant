using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateRecipesHelpString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89c732b6-5055-47e4-a9dd-5ac3d1a63801", "AQAAAAEAACcQAAAAEBAKXGEkNR0dRVN2NMZjf3jy6SRrOTuXjjZvtxucXweZ45vu+pbkhnF1t55nV8Spkg==" });

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<li><span data-how='<a href=\"/Recipes/Details/2\">Boil Pasta</a>' data-when='now' data-amount='400g'>Boil the pasta</span> al dente in 1.5 liters of water</li>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6905d37f-a4cf-4392-b9b3-aaf1cd20d103", "AQAAAAEAACcQAAAAEIha7kad+3FfDBpUMo7WnhoXl72euUvPgHSfFz9dGO7ennEe4stW3XynR3OKV3vc1A==" });

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<li><span data-how='<a href=\"/Recipes/Details/2\">Boil Pasta</a>' data-when='<span>now</span>' data-amount='400g'>Boil the pasta</span> al dente in 1.5 liters of water</li>");
        }
    }
}
