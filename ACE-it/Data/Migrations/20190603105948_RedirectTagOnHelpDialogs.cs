using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class RedirectTagOnHelpDialogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3240cb8-b59e-435a-abf1-efae354f5ab0", "AQAAAAEAACcQAAAAEERCvVJzqdeNeGqVv/mSE/jR/dNppG93z+ydDFg+D3Dw58ON6eZepF12nXVhyCWZAQ==" });

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<li><span data-how='<a href=\"/Recipes/Details/2?redirect=true\">Boil Pasta</a>' data-when='now' data-amount='400g'>Boil the pasta</span> al dente in 1.5 liters of water</li>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bf22052-29f2-445e-bb0b-0d491f54c9d4", "AQAAAAEAACcQAAAAEBaDsx47eUp4gr+KOXQ/eNuWJZyNLTDJW2XMsLtJOwoKhhwNeG/kiz6dMPXswvmkJA==" });

            migrationBuilder.UpdateData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "<li><span data-how='<a href=\"/Recipes/Details/2\">Boil Pasta</a>' data-when='now' data-amount='400g'>Boil the pasta</span> al dente in 1.5 liters of water</li>");
        }
    }
}
