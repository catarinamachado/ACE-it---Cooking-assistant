using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateRecipesHelp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "<li>In a frying pan, <span data-video='https://www.youtube.com/embed/CTyV3JExDT8'>sauté</span> the remaining olive oil, a <span data-video='https://www.youtube.com/embed/dCGS067s0zo'>chopped</span> onion and the chopped garlic.</li>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0a8bd6d-5cfd-430e-accb-54ab2f1b781d", "AQAAAAEAACcQAAAAEDvA/vxz/jxdfqOQafEHOr577j3EA1p9+Ti9XYjSJFuvM0vpPCXX2c77lB1/6Qm7Mg==" });

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<li><span data-how='<a href=\"/recipes/2\"/>' data-when='<span>now</span>' data-amount='400g'>Boil the pasta</span> al dente in 1.5 liters of water</li>");

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "<li>In a frying pan, <span data-video='https://youtu.be/CTyV3JExDT8'>sauté</span> the remaining olive oil, a <span data-video='https://youtu.be/dCGS067s0zo'>chopped</span> onion and the chopped garlic.</li>");
        }
    }
}
